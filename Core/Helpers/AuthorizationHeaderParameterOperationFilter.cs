using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Domain.Helpers
{
    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
            var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeFilter);
            var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);
            if (isAuthorized && !allowAnonymous)
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<IParameter>();
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "Authorization",
                    In = "header",
                    Description = "access token",
                    Required = true,
                    Type = "string"
                });
            }

            if (operation.OperationId == "ConnectTokenPost")
            {
                operation.Consumes.Add("application/x-www-form-urlencoded");
                var p = new List<IParameter>();
                if (operation.Parameters == null)
                {
                    operation.Parameters = p;
                }
                operation.Parameters.Add(new BodyParameter
                {
                    Name = "grant_type",
                    In = "formData",
                    Description = "post formdata"
                });
                operation.Parameters.Add(new BodyParameter
                {
                    Name = "username",
                    In = "formData",
                    Description = "post formdata"
                });
                operation.Parameters.Add(new BodyParameter
                {
                    Name = "password",
                    In = "formData",
                    Description = "post formdata"
                });
            }
        }
    }
}
