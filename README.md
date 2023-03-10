# xe currency converter testing

 Test Automation Framework project for the UI and API testing 

 Following stack used:
 - Dotnet 6.0
 - NUnit 3.13.3
 - Selenium 4.8.1

 Testing done for the: https://www.xe.com/currencyconverter
 
 Provided test cases are testing user story:
As a User I should be able to perform forex conversions in a converter widget.
 
 You can find here documented test cases. 
 
 
 ## Installing / Getting started

 ### Prerequisites
- IDE (Visual Studio / Visual Studio Code)
- .NET SDK x64
- Selenium WebDriver 4.8.1
- ChromeDriver 111.0

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
### add  NuGet packages 
Packages names: FluentAssertions, Microsoft.NET.Test.Sdk, NUnit, NUnit, NUnit3TestAdapter, Selenium.WebDriver, Selenium.WebDriver.ChromeDriver 
```Shell
dotnet add package <PACKAGE_NAME>
```

- Run all tests:
```Shell
dotnet test
```
- Run specific test:
```Shell
dotnet test --filter <test_name>
```
