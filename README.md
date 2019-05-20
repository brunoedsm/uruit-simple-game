# UruIT
Game of Drones Programming Assessment

## Pre Requisites
### Back-End:
- .NET Core Framework 2.2
- SQL Server 2012 or above
- Visual Studio Code

### Front-End:
- Node Js LTS version
- NPM LTS version
- Angular-CLI Console

## Start Application

### .NET Core API
1 - Clone the repository with Git console at: https://github.com/brunoedsm/UruIT.git
2 - Via command line, browse to the folder back-end and run the command "dotnet build" (to restore all dependencies and build the project)
3 - After the build (with no errors), browse to the UruIT.GameOfDrones.Repository to update database with three steps:
3.1 - Check the connection string at appsettings.json on UruIT.GameOfDrones.Api to match with your environment
3.2 - Run at CMD: dotnet ef migrations add Development --startup-project ..\UruIT.GameOfDrones.Api
3.3 - Run at CMD: dotnet ef database update Development --startup-project ..\UruIT.GameOfDrones.Api
4 - With the database updated, browse to UruIT.GameOfDrones.Api and execute the following command: dotnet run
5 - Done. The Api will listening at the address http://localhost:5000

### Angular SPA
1 - Clone the repository with Git console at: https://github.com/brunoedsm/UruIT.git
2 - Via command line, browse to the folder "front-end" and after "uruit-angular-client"
3 - Inside the folder, type on terminal "ng build". Wait until proccess is done and run "ng serve"
4 - Okay, client app is running at http://localhost:4200 (this is a mock version of app)

*** Doubts, I'm still available.
