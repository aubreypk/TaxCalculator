# TaxCalculator
Application for managing client information

Application has been developed using .net core framework on Visual Studio code.

1. Data:
Code first approach used to allow easy deployment. 
Switch between SQLServer and InMemory by uncommenting the desired DBContext setting in Startup.cs. 
Entity framework core used. 


2. API:
.Net Core 3.1 API
Project: tax-api. 
Deploy: use "dotnet run" cli command. Default route is "https://localhost:5001/api/" for status. 
see controllers for other API methods.

2.1 xUnit Tests:
seperate project using xUnit for testing.
Project: tax-api.Tests. use "dotnet test" to run unit tests.


3. Web Client
.Net core client web application
Project: tax-web
Deploy: use "dotnet run" cli command. App runs on https://localhost:5002/
