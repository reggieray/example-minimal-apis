# Overview

This repository was created as an intro/example of Minimal APIs. Minimal APIs were introduced with the [release of .NET6](https://devblogs.microsoft.com/dotnet/announcing-net-6/) as a alternative approach for building API's compared to the MVC/Controller approach. 

A quote from taken from the Microsoft doc [Tutorial: Create a minimal web API with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio) defines a Minimal API as the following:

> Minimal APIs are architected to create HTTP APIs with minimal dependencies. They are ideal for microservices and apps that want to include only the minimum files, features, and dependencies in ASP.NET Core.

## Features that make Minimal APIs possible:

- [Top-level statements](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/top-level-statements): Introduced with C# 9 you don't have to explicitly include a `Main` method. The `Main` method is implied, it is implicitly there.

```
// Before C# 9
class TestClass
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}
```
```
// Introduced in C# 9
Console.WriteLine("Hello World!");
```
- [Global and implicit usings](https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/#global-and-implicit-usings): Introduced in C# 10, implicit usings feature automatically adds common global using directives.
```
// format: global using <fully-qualified-namespace>;
// applies to the entire project

global using System;

global using static System.Console;
global using Env = System.Environment;
```
- [Improvements for lambda expressions](https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/#improvements-for-lambda-expressions-and-method-groups): Another feature introduced in C# 10 implicit lambda expressions.
```
// Before C# 10
Func<string, int> parse = (string s) => int.Parse(s);
```
```
// Introduced in C# 10
var parse = (string s) => int.Parse(s);
```
- [Attributes on lambdas](https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/#attributes-on-lambdas): In the same way you could put attributes to methods or local functions you can you put them on lambdas, Also introduced in C# 10.
```
Func<string, int> parse = [Example(1)] (s) => int.Parse(s);
var choose = [Example(2)][Example(3)] object (bool b) => b ? 1 : "two";
```

# Contents

- 0. Hello World - A simple hello world example project.
- 1. Comparison - Minimal API vs MVC/Controller API project comparison.
- 2. Structure - Todo Minimal API's structured in various ways with some examples using popular libraries.
- 4. Testing - Unit tests and integration tests for Minimal APIs.



# Further reading

- [Creating a minimal web API](https://docs.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio) - Tutorial documentation from Microsoft for creating a minimal API. Also contains a instructions for creating a Todo app.
 - [Minimal APIs overview](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0) - Microsoft documentation overview on Minimal APIs.
- [Integration testing minimal apis](https://github.com/martincostello/dotnet-minimal-api-integration-testing) - Github repo exploring integration testing.
