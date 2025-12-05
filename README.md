# Advent of Code 2025

See [Advent of Code 2025](https://adventofcode.com/2025)

## Create new nunit project
`dotnet new nunit`

## Add Fluent Assertions
`dotnet add package fluentassertions@7`

## Add project to solution
Do this from solution directory. It is essential so that tests can be discovered automatically by your IDE.
`dotnet sld add .\abc\abc.csproj`

## Run tests
`dotnet test`

Or in Visual Studio Code use 'CTRL+; A' to run all discovered tests.

### Watch code for changes and run tests automatically
`dotnet watch test`
