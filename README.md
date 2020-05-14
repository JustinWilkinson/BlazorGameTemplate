# BlazorGameTemplate
A template for an online game implemented using Blazor WebAssembly. Simply rename the solution/csproj and namespaces as desired.

## Code

### BlazorGameTemplate.Client
A client-side Blazor WebAssembly application, which communicates with the server over HTTP and SignalR.

### BlazorGameTemplate.Server
A Blazor Server project with API Controllers to serve client requests, and a SignalR Hub to push changes to connected clients.

### BlazorGameTemplate.Shared
A project containing abstractions shared between the client and the server.

### BlazorGameTemplate.Test
An NUnit Test project containing tests for the solution.

## Hosting
* BlazorGameTemplate is an ASP.NET Core Hosted Blazor WebAssembly application.
* .NET Core is cross platform, so can be hosted on Linux or Windows.
* Steps for hosting ASP.NET Core applications can be found [here](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/?view=aspnetcore-3.1).

### Docker Support
* For hosting the application in a docker container, either:
* Build your own container using the below commands
  * To build the docker container run cd into the solution root folder, and run the following command: `docker build -t BlazorGameTemplate .`
  * The container can then be run using the following command `docker run -p 8080:80 BlazorGameTemplate`. Here, port 8080 on the host is mapped to port 80 in the container - this can be amended to taste.
* Download/Pull an existing image
  * The latest docker images are available from  [GitHub](https://github.com/JustinWilkinson/BlazorGameTemplate/packages) or [DockerHub](https://hub.docker.com/repository/docker/justinwilkinson/blazorgametemplate)
  * Alternatively, topull the package from the command line, simply use `docker pull justinwilkinson/blazorgametemplate`.