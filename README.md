# UruIT
Game of Drones Programming Assessment

## Pre Requisites
### Back-End:
- .NET Core Framework 2.2
- SQL Server 2012 or above
- Visual Studio Code

### Front-End:
- Node JS LTS version
- NPM LTS version
- Angular-CLI Console

## Install/Start Application

### .NET Core API
- Clone the repository with CMD(console)/Terminal at: https://github.com/brunoedsm/UruIT.git
- Still with CMD(console)/Terminal, browse to the folder back-end and run the command "dotnet build" (to restore all dependencies and build the project)
- After the build (with no errors), browse to the UruIT.GameOfDrones.Api and alter the variable "ConnectionStrings":"DefaultConnection" on both files: appsettings.json and appsettings.Development.json
- Browse to the UruIT.GameOfDrones.Repository to update database with three steps:
- 1 Check the connection string at appsettings.json on UruIT.GameOfDrones.Api to match with your environment
- 2 Run at CMD(console)/Terminal: dotnet ef migrations add Development --startup-project ..\UruIT.GameOfDrones.Api
- 3 Run at CMD(console)/Terminal: dotnet ef database update Development --startup-project ..\UruIT.GameOfDrones.Api
- With the database updated, browse to UruIT.GameOfDrones.Api and execute the following command: dotnet run
- Done. The Api will listening at the address http://localhost:5000

### Angular SPA
- Clone the repository with CMD(console)/Terminal at: https://github.com/brunoedsm/UruIT.git
- Via CMD(console)/Terminal, browse to the folder "front-end" and after "uruit-angular-client"
- Inside the folder, type on CMD(console)/Terminal "npm install" and wait the download/install packages, and after run "ng build" and after that "ng serve".
- Okay, client app is running at http://localhost:4200

*** Doubts, I'm still available.
