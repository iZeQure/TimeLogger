## TimeLogger
 My view of what a timelogger is, used for project control and invoices.
 
#### NUnit Testing
Providing the ability to test the controllers.

##### Timelogger.Api.Tests
- [x] ProjectControllerTests
  > Tests the Projects controller, if it's able to extract data from the given repository.
  - GetAll, should give an Ok Status Code 200 when tested.
  - GetById, returns 3 different codes, whether if it Fails, No Content or Ok.
  
##### Timelogger.Tests
- [x] ApiDatabaseTests
  > Tests if it's possible to connect correctly to the database.
  - It's being validated if the connection is Closed, Connection, Open, Closing or Broken.
 
#### Api Controllers
The usage of the few controllers, to make it possible to manipulate the available data.

##### Projects Controller
- [x] POST: api/projects
  > Creates a new project, with a JSON object from the body.
    ```json
    {
        "ProjectName": "User 2 Project 1",
        "ProjectOwner": {
            "EntityId": 2 //Project Owner, from a valid user entity.
        },
        "ProjectCustomer": {
            "EntityId": 1 //The Customer of the project, with a valid customer entity.
        },
        "ProjectDateOfCreation": "2020-10-02",
        "ProjectDeadline": "2020-11-10"
    }
    ```
- [x] GET: api/projects
  > Returns JSON objects with the available projects.
- [x] GET: api/projects/1
  > Returns a JSON object of the available project.
- [x] GET: api/projects/user/1
  > Returns JSON objects with the available projects for the specified user.
- [x] GET: api/projects/1/registrations
  > Returns a JSON object with project if available, containing an array of time registrations.

##### Registrations Controller
- [x] POST: api/registrations
  > Creates a registration for a project, with a JSON object from the body.
    ```json
    {
        "ProjectID": 1,
        "Time": "1:20:48" //The Time is given in string, and converted to a TimeSpan by the system.
    }
    ```
    
#### Credits
> Made with love and passion for a development challenge, provided by VISMA E-Conomic
- [x] .NET Core 3.1
- [x] Visual Studio Enterprise
- [x] React Front-End Framework
- [x] NUnit Testing

#### Configuration
- [x] Repositories is being dependency injected into the controllers from the Startup class.
- [x] The Database connection is currently hardcoded into the ApiDatabase class.
- [x] Scripts to the database, needs to be fired in MSSQL, as it's been created with T-SQL.

#### Nice to Know
- [x] Singleton Pattern
- [x] Repository Pattern
- [ ] Factory Pattern
- [x] Dependency Injection
- [x] Using SOLID Principles

###### Made By
> iZeQure, AKA Tobias Rosenvinge - Student, studying software engineering in Denmark.
