using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Core.Authorization.Models;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _applicationDbContext;
        private static bool _databaseChecked;

        public AccountController(
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _applicationDbContext = applicationDbContext;
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        //[Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            EnsureDatabaseCreated(_applicationDbContext);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                return StatusCode(StatusCodes.Status409Conflict);
            }

            user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("admin"))
                {
                    var adminRole = new IdentityRole("admin");
                    await _roleManager.CreateAsync(adminRole);
                    await _roleManager.AddClaimAsync(adminRole, new Claim(CustomClaimTypes.Permission, Users.Admin));
                }
                await _userManager.AddToRoleAsync(user, "admin");
            
                return Ok();
            }
            AddErrors(result);

            // If we got this far, something failed.
            return BadRequest(ModelState);
        }

       /* [HttpPost("roles")]
        [Authorize(Authorization.Policies.SiteAdmin)]
        public async Task<IActionResult> CreateRole([FromBody] RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                if (role == null)
                    return BadRequest($"{nameof(role)} cannot be null");


                ApplicationRole appRole = Mapper.Map<ApplicationRole>(role);

                var result = await _accountManager.CreateRoleAsync(appRole, role.Permissions?.Select(p => p.Value).ToArray());
                if (result.Item1)
                {
                    RoleViewModel roleVM = await GetRoleViewModelHelper(appRole.Name);
                    return CreatedAtAction(GetRoleByIdActionName, new { id = roleVM.Id }, roleVM);
                }

                AddErrors(result.Item2);
            }

            return BadRequest(ModelState);
        }
    */
        #region Helpers

        // The following code creates the database and schema if they don't exist.
        // This is a temporary workaround since deploying database through EF migrations is
        // not yet supported in this release.
        // Please see this http://go.microsoft.com/fwlink/?LinkID=615859 for more information on how to do deploy the database
        // when publishing your application.
        private static void EnsureDatabaseCreated(ApplicationDbContext context)
        {
            if (_databaseChecked) return;
            _databaseChecked = true;
            context.Database.EnsureCreated();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        #endregion
    }
}
