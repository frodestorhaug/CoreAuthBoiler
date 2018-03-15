This is a work in progress and any input is Welcome.

The goal is to have a simple boilerplate for setting up a .net core web app with authentication, swagger and EF bacend
and React, redux, webpack frontend

create a db and insert connectionstring to appsettings.json

dotnet ef migrations add InitialCreate

dotnet ef database update


start the application 

go to http://localhost:5000/swagger/ 

insert 

{
	"Email":"me@mail.com",
	"Password":"123a456"
}

into model in POST /api/Account

And you have your user