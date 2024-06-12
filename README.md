# SignalR with AspNetCore 8

### Project structure

- ASP.NET Core MVC Web Application
    - SignalRCallCenterSolution
        - SignalRCallCenterWebApp
        		- Packages for the WebApp Project
              - Install-Package Microsoft.EntityFrameworkCore -v 8.0.6
              - Install-Package Microsoft.EntityFrameworkCoreSqlServer -v 8.0.6
              - Install-Package Microsoft.EntityFrameworkCore.Design -v 8.0.6

### Dotnet tools

- dotnet tool list --global
- dotnet tool install --global microsoft.web.librarymanager.cli
- dotnet tool install --global dotnet-ef

### Dotnet-Ef

- dotnet ef migrations add InitialDb --output-dir Data/Migrations --project SignalRCallCenterWebApp
- dotnet ef database update --project SignalRCallCenterWebApp

### Client Side Libraries

- Search for @aspnet/signalr@1.1.4
- Add to the project client side library signalr@1.1.4, just take the dist/browser

#### Git Branches

- 01Start
- 02EntitySetup
- 03AddSignalRServices
- 04SendMessages
- 05ClientSideCode
- 06StronglyTyped
- 07Groups
