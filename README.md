# Iti Backend Challenge

* [Requirements](#Requirements)
* [Usage](#Usage)
* [Reste Api Documentation](#Rest-Api-Documentation)
* [Tests](#Tests)

## Requeriments


## Usage

In the project root restore all project dependencies:
```shell
$ dotnet restore
```

To run the Rest API:
```shell
$ dotnet run --project src/Iti.Challenge.RestApi
```

## Rest Api Documentation

The rest API documentation is provided by Swagger. You must start the API (above step) and then go to `http://localhost:5000/swagger` 

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