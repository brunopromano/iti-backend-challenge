# Iti Backend Challenge

* [Requirements](#Requirements)
* [Usage](#Usage)
* [Rest Api Documentation](#Rest-Api-Documentation)
* [Tests](#Tests)

## Requirements

<a href="https://dotnet.microsoft.com/download/dotnet/3.1">.Net Core SDK 3.1.x</a>

## Usage

First, go to project root and restore all project dependencies:
```shell
$ dotnet restore
```

Then, run the Rest API:
```shell
$ dotnet run --project src/Iti.Challenge.RestApi
```

## Rest Api Documentation

The rest API documentation is provided by Swagger. You must start the API (above step) and then go to `http://localhost:5000/swagger`

## Api Monitoring

To check the application and endpoints status, go to:
`https://localhost:5001/healthchecks-ui`

## Tests

To run all the tests (unit and integration) you must point to project root then:
```shell
$ dotnet test
```

To run unit tests only:
```shell
$ dotnet test ./tests/Iti.Challenge.Tests.Unit
```

To run integration tests only:
```shell
$ dotnet test ./tests/Iti.Challenge.Tests.Integration
```
