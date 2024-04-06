# Scheduling System
This is a class scheduling app for Ethiopian universities that can automatically generate weekly schedules.

## Prerequisites

Before you begin, make sure you have the following installed on your machine:

1. [.NET Core SDK](https://dotnet.microsoft.com/download)
2. [Node.js and npm](https://nodejs.org/)
3. [Angular CLI](https://angular.io/cli)
4. [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Setting Up the Database

1. Install SQL Server if you haven't already.
2. Create a new database for the project. You can do this using SQL Server Management Studio or any other preferred method.
3. Update the connection string in `appsettings.json` file in the ASP.NET Core project (`scheduling-system/appsettings.json`) to point to your newly created database.

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=YourDatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

## Running the ASP.NET Core API
1. Navigate to the root directory of the ASP.NET Core project in your terminal or command prompt.
2. Run the following command to restore dependencies:
```
dotnet restore
```
3. After the restoration is complete, run the following command to apply any pending migrations and seed data:
```
dotnet ef database update
```
4. Once the database is updated, run the following command to start the ASP.NET Core API:
```
dotnet run
```
5. The API should now be running on https://localhost:5001 (or http://localhost:5000).

## Running the Angular Client
1. Navigate to the root directory of the Angular project in your terminal or command prompt:
```
cd ClientApp
```
2. Run the following command to install the required dependencies:
```
npm install
```
3. After the installation is complete, run the following command to start the Angular development server:
```
ng serve
```
4. The Angular application should now be accessible at http://localhost:4200 in your web browser.

## Accessing the Application
You can now access the application by visiting http://localhost:4200 in your web browser. The Angular frontend communicates with the ASP.NET Core API running on https://localhost:5001 to fetch and manipulate data.
