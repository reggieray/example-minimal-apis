# Overview

This repository was created as an intro/example of Minimal APIs. Minimal APIs were introduced with the [release of .NET6](https://devblogs.microsoft.com/dotnet/announcing-net-6/) as a alternative approach for building API's compared to the MVC/Controller approach. 

A quote from taken from the Microsoft doc [Tutorial: Create a minimal web API with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio) defines a Minimal API as the following:

> Minimal APIs are architected to create HTTP APIs with minimal dependencies. They are ideal for microservices and apps that want to include only the minimum files, features, and dependencies in ASP.NET Core.

# Contents

0. Hello World - A simple hello world example project.

This project demonstrates how simple it is to get going with minimal apis in a [hello world example project](https://github.com/reggieray/example-minimal-apis/tree/main/Examples.MinimalApi.HelloWorld).

1. Comparison - Minimal API vs MVC/Controller API project comparison.

This section contains the following two projects
- [Examples.MinimalApi.WeatherForecast](https://github.com/reggieray/example-minimal-apis/tree/main/Examples.MinimalApi.WeatherForecast) - an example of the default project that gets created when creating minimal api
- [Examples.MVC.WeatherForecast](https://github.com/reggieray/example-minimal-apis/tree/main/Examples.MVC.WeatherForecast) - an example of the default project when using the MVC approach for building a api

> **_NOTE:_** These projects are not mutually exclusive. You can use a mixture of both approaches in one project, but if you introduce the MVC approach with a minimal api you forgo the performance improvements that come with the removal of Controllers.    

2. Structure - Todo Minimal API's structured in various ways with some examples using popular libraries.

This section contains three example todo API projects that demonstrate the various ways you can create minimal apis created with popular libraries:
- [Examples.MinimalApi.Todo.EFCore](https://github.com/reggieray/example-minimal-apis/tree/main/Examples.MinimalApi.Todo.EFCore) - a simple CRUD example api built with the [EFCore](https://docs.microsoft.com/en-gb/ef/core/) package.
- [Examples.MinimalApi.Todo.MediatR](https://github.com/reggieray/example-minimal-apis/tree/main/Examples.MinimalApi.Todo.MediatR) - similar to the previous project with the introduction of [MediatR](https://github.com/jbogard/MediatR) package, demonstrating one possible way of structuring a minimal api using a popular library.
- [Examples.MinimalApi.Todo.FastEndpoints](https://github.com/reggieray/example-minimal-apis/tree/main/Examples.MinimalApi.Todo.FastEndpoints) - another example todo api project structured using the [FastEndpoints](https://github.com/dj-nitehawk/FastEndpoints) package. A light-weight REST Api framework for ASP.Net 6 that implements REPR (Request-Endpoint-Response) Pattern.

4. Testing - Unit tests and integration tests for Minimal APIs.

This sections has two projects that gives examples of testing a minimal api. These test projects were created for the [Examples.MinimalApi.Todo.FastEndpoints](https://github.com/reggieray/example-minimal-apis/tree/main/Examples.MinimalApi.Todo.FastEndpoints) project.

- [Examples.MinimalApi.Todo.FastEndpoints.UnitTests](https://github.com/reggieray/example-minimal-apis/tree/main/Examples.MinimalApi.Todo.FastEndpoints.UnitTests) - example of unit testing a minimal api.
- [Examples.MinimalApi.Todo.FastEndpoints.IntegrationTests](https://github.com/reggieray/example-minimal-apis/tree/main/Examples.MinimalApi.Todo.FastEndpoints.UnitTests) - example of integration tests for a minimal api.

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

# Useful links

- [Creating a minimal web API](https://docs.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio)
 - [Minimal APIs overview](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0)
- [Integration testing minimal apis](https://github.com/martincostello/dotnet-minimal-api-integration-testing)
- [Minimal API Playground](https://github.com/DamianEdwards/MinimalApiPlayground)
- [.NET Docs Show on Minimal APIs](https://github.com/Elfocrash/DotnetDocsShow.MinimalApis) - [Youtube Link](https://www.youtube.com/watch?v=HDinmuGYaIA)