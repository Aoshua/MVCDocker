I am attempting to integrate Docker with a .Net Core MVC project within a Visual Studio environment as seamlessly as possible.

##Quick Run-Down:
1. Make MVC Project with Docker Support
2. Ensure that NuGet Packages install correctly
3. Right click project, select -> add -> Container Orchestrator Support
4. Add database service to services in docker-compose.yml
5. Set up context (file and in startup)
6. Add connection string to appsettings.json (the server is the name of your DB container)
