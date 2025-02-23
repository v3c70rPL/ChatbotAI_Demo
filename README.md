# ChatbotAI_Demo
Chatbot AI with mock AI model

# Deployment
Currently configured to local deployment on windows OS with preinstalled developer tools for .net 8 and angular 17

# Setup requirements
* windows OS
* installed MS SQL Server (default domain login)
* installed Angular CLI
* installed .NET 8 SDK 

# Implementation
* frontend - Angular, Angular Material
```
    Angular CLI: 17.0.3
    Node: 18.20.2
    Package Manager: npm 10.5.0
    OS: win32 x64

    Angular:
    ...

    Package                      Version
    ------------------------------------------------------
    @angular-devkit/architect    0.1700.3
    @angular-devkit/core         17.0.3
    @angular-devkit/schematics   17.0.3
    @schematics/angular          17.0.3
```
* backend - .NET 8, MS SQL Server 15, MediatR for CQRS pattern

# TODO
* unit tests for backend
* test for frontend
* deployment using docker containers

