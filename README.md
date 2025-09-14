# AI Calendar Project - Homework 1

This branch (**master**) contains the complete solution for Homework 1 of the AI Calendar course project. Below is a detailed overview of the steps taken, project structure, and contents of each folder/module.

---

## Steps Taken for Homework 1

1. **Created Modular Monolith Solution**  
   - Chose `.NET 8.0 LTS` as the target framework.
   - Created a solution named `AICalendar` with three projects representing API, Domain, and Data layers.

2. **Added Projects and References**  
   - **AICalendar.Api**: The API layer project responsible for HTTP controllers and endpoints.  
   - **AICalendar.Domain**: The Domain layer project containing business service interfaces.  
   - **AICalendar.Data**: The Data layer project responsible for repository implementation and future EF Core integration.
   - Added project references:  
     - API references Domain and Data projects.  
     - Data references Domain project.

3. **Created Basic API Controller and Endpoint**  
   - Added `EventController` in API with a simple GET endpoint `/api/event/hello` that returns `"Hello World!"`.

4. **Defined Domain Service Interface**  
   - Created `IEventService` interface with a method `GetWelcome()` to represent business logic contract.

5. **Implemented Data Repository**  
   - Created `EventRepository` class implementing `IEventService` returning a sample welcome string.

6. **Cleaned Up Default Files**  
   - Removed unnecessary auto-generated files like `WeatherForecast.cs` and its controller for a clean starting point.

7. **Set up Git and GitHub Repository**  
   - Initialized local Git repository in Visual Studio.  
   - Connected and pushed code to remote GitHub repository (branch: `master`).  
   - Explained the use of two branches (`main` and `master`) and confirmed code is in `master`.

---

## Project Folder Structure and Content

| Folder Name          | Description                                           | Key Files                       |
|---------------------|-------------------------------------------------------|--------------------------------|
| **AICalendar.Api**    | API Layer handling client requests                    | `Program.cs`, `EventController.cs`, `appsettings.json`  |
| **AICalendar.Domain** | Business layer defining service interfaces            | `IEventService.cs`              |
| **AICalendar.Data**   | Data access layer implementing repositories           | `EventRepository.cs`            |

---

## How to Use This Branch

- Checkout or browse the `master` branch to explore the full source code.
- Future homework phases (2, 3, 4, etc.) will also continue in this branch for consistency.
- The code here serves as the base modular monolith architecture setup for the AI Calendar project.

---

If you have any questions or need clarifications, please refer to the commits and source code in the `master` branch.

---

*This README provides a detailed overview for reviewers, instructors, and yourself to track project progress clearly and professionally.*
