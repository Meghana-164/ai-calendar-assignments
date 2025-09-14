# AI Calendar Project - Homework 1 & 2

---

## Homework 1: Project Setup and Initial Commit

This branch (**master**) contains the complete solution for Homework 1 of the AI Calendar course project. Below is a detailed overview of the steps taken, project structure, and contents of each folder/module.

### Steps Taken for Homework 1

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
   - Explained the use of two branches (main and master) and confirmed code is in `master`.

### Project Folder Structure and Content

| Folder Name          | Description                                           | Key Files                       |
|---------------------|-------------------------------------------------------|--------------------------------|
| **AICalendar.Api**    | API Layer handling client requests                    | `Program.cs`, `EventController.cs`, `appsettings.json`  |
| **AICalendar.Domain** | Business layer defining service interfaces            | `IEventService.cs`              |
| **AICalendar.Data**   | Data access layer implementing repositories           | `EventRepository.cs`            |

### How to Use This Branch

- Checkout or browse the `master` branch to explore the full source code.
- Future homework phases (2, 3, 4, etc.) will also continue in this branch for consistency.
- The code here serves as the base modular monolith architecture setup for the AI Calendar project.

---

## Homework 2: Step 1 — Compare API Styles & Decide

### Overview

For Homework 2, the first step is to evaluate the available API styles—**gRPC, GraphQL, and REST**—against the specific needs of the AI Calendar project. Based on this evaluation, a firm decision on the API style or hybrid approach will be made. Below is the detailed comparison, risks, mitigations, and final decision.

### Key Factors Considered

- **Domain Needs:**  
  Events, calendars, attendees, reminders, time zones, recurring rules, invitations.

- **Client Types:**  
  Mobile apps, web browsers, and server-to-server interaction.

- **Network Patterns:**  
  Latency, payload size, streaming/real-time update requirements.

- **Ecosystem and Tooling Support:**  
  Availability of frameworks, client libraries, and developer productivity.

- **Operational Concerns:**  
  Versioning strategies, rollout flexibility, observability, monitoring.

- **Security Requirements:**  
  Authentication methods (JWT, OAuth2), rate limiting, and fine-grained access control.

- **Scalability and Cost:**  
  Infrastructure scalability, cost implications, and performance efficiency.

---

### API Style Comparison Matrix

| Feature / Criteria     | gRPC                                    | GraphQL                                | REST (OpenAPI 3.1)                 |
|-----------------------|----------------------------------------|--------------------------------------|------------------------------------|
| Protocol              | HTTP/2 with binary serialization        | HTTP/1.1 or HTTP/2                   | HTTP/1.1 or HTTP/2                 |
| Performance           | High performance, low latency           | Moderate, query efficient            | Good, but potential over-fetching  |
| Streaming Support     | Native support (server/client streaming) | Requires additional setup             | Limited, usually via websockets    |
| Flexibility           | Strict contracts, fixed types           | Very flexible queries and mutations  | Fixed endpoints, versioning needed |
| Tooling & Ecosystem   | Rich tooling for microservices           | Growing ecosystem                    | Mature, wide adoption and tools    |
| Client Compatibility  | Best for internal services, gRPC clients | Excellent for diverse clients        | Best for broad client compatibility|
| Complexity            | More complex to setup and learn         | Steeper learning curve               | Easiest to understand and use      |
| Versioning            | Proto file versioning                    | Schema evolution practices           | URL versioning or headers          |
| Security              | Supports SSL/TLS, token-based auth      | Supports JWT, OAuth2                 | Rich options including OAuth2, CORS|
| Caching               | Not natively supported                   | Not natively supported               | Natural caching support            |
| Cost/Infrastructure   | Usually requires HTTP/2 support          | Standard HTTP servers                | Widely supported and cost-effective|

---

### Risks and Mitigations

| Risk                          | Mitigation                                           |
|-------------------------------|----------------------------------------------------|
| gRPC complexity & client support | Use REST/gRPC hybrid if needed; clear client docs.|
| GraphQL schema evolution       | Adopt strict versioning and deprecation policies   |
| REST over-fetching             | Use pagination, filtering, and efficient queries   |
| Streaming needs unmet          | Consider websocket integration or hybrid approach  |
| Security gaps                 | Implement layered security, audits, and tests      |

---

### Decision: Use REST (OpenAPI 3.1)

For the AI Calendar project, **REST with OpenAPI 3.1** is the most suitable API style initially due to:

- Its wide client compatibility supporting mobile, web, and server apps.
- Simplicity and familiarity that aligns well with the current project skeleton.
- Mature tooling and ecosystem support, easing development and testing.
- Built-in support for HTTP semantics like caching, versioning, and security.
- Clear path for gradual evolution and integration of authentication, rate limit, and observability requirements.

Other styles like GraphQL or gRPC could be adopted later for specific features if necessary.

---

### What’s Next for Homework 2

- Define the API contract using OpenAPI 3.1, with endpoints like `/calendars`, `/events`, and `/attendees`.
- Use query parameters for date/time filters, time zones, pagination, and other operations.
- Store the final contract file in a `/contracts` folder in this repository.

---

*This “Day 2” section will be updated further as Homework 2 progresses, including example API calls, versioning policies, migration notes, security and observability details.*

---

**End of Homework 2 Step 1 Documentation**

---

*For more information, see the commit history and related files in this master branch.*

