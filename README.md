# NopCommerce.Test

 Basic Test Automation Framework project for UI and API purposes of testing.<br />
 <br />
 Following stack used:
 - Dotnet 6.0
 - NUnit 3.13.3
 - Selenium 4.5.1
 - RestSharp 108.0.2
 - NUnit.Allure 1.2.1.1
 <br />
 Page objects built on example website: https://demo.nopcommerce.com/<br />
 Api Test Automation Framewwork built on example API documentation: <br />
 https://www.appsloveworld.com/sample-rest-api-url-for-testing-with-authentication.
 
 ## Installing / Getting started

 ### Prerequisites
- IDE (Visual Studio / Visual Studio Code)
- .NET SDK x64
- Installed Scoop: <br />
In PWS execute following commands:
```shell
 Set-ExecutionPolicy RemoteSigned -Scope CurrentUser # Optional: Needed to run a remote script the first time
 irm get.scoop.sh | iex
```
- Installed Alure: <br />
In PWS execute following commands:
```shell
 scoop install allure
```

### Hands on
- Clone the project locally in directory by choice
```shell
git clone <HTTPS>
```
- Load project in IDE
- Build and restore project:
```Shell
dotnet build
dotnet restore
dotnet clean
```
- Run all tests:
```Shell
dotnet test
```
- Run specific test:
```Shell
dotnet test --filter <test_name>
```
 
 ### Generate Allure report
 - Open PowerShell
 - Generate report:
```shell
allure generate "allure-results-directory" --clean
```
- Open the report:
```shell
allure open "allure-report-directory"
```
