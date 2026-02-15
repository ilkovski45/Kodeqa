## Product API with Entity Framework Core
This is a simple Product API built using ASP.NET Core and Entity Framework Core. 
It allows you to perform CRUD operations on products stored in a SQL Server database.

## Run the following commands in your terminal - GIT Bash:
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer 
- dotnet add package Microsoft.EntityFrameworkCore.Tools 
- dotnet add package FluentValidation.AspNetCore 

## Change the connection string for your database in the appsettings.json file:

"ConnectionStrings": {
  "Default": "Server=(localdb)\\MSSQLLocalDB;Database=ProductDb;Trusted_Connection=True;TrustServerCertificate=True"
}

## Run the following commands to create the database and apply the migrations:

- dotnet ef migrations add InitialCreate 
- dotnet ef database update

## Connect to Database in Tools -> Connect to Server -> Databases - ProductDb - Tables - dbo.Products