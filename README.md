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

## Homework 2: Step 2 — Define the Contract (Schema/Spec)

### Overview

Step 2 focuses on authoring the correct API contract for the chosen style in Step 1. For this AI Calendar project, the REST API style with **OpenAPI 3.1** was selected. This step involves formally specifying all API endpoints, query parameters, request and response schemas, and documenting versioning and breaking change policies.

The contract serves as the **authoritative source of truth** guiding development, testing, and client integration.

---

### Detailed Work Completed

#### 1. OpenAPI Contract File Created
- Stored at `/contracts/openapi.yaml` in root solution folder, separate from implementation.
- Version: 3.1.0 with semantic versioning explained in the header.

#### 2. Defined RESTful Endpoints
- **/calendars**  
  Supports `GET` for list, `POST` for creation, `PUT` for update, and `DELETE` for removal.  
  Example:  
  - `GET /api/calendars` returns array of Calendar objects.  
  - `POST /api/calendars` expects JSON Calendar object in body.

- **/events**  
  Includes `GET` with query parameters and full CRUD:  
  - Query parameters allow filtering events by `calendarId`, date `start` and `end` ranges (ISO 8601), and `timeZone`.  
  - `POST`, `PUT`, and `DELETE` support event management.

- **/attendees**  
  Includes full CRUD (get list, get by id, create, update, delete).

#### 3. Query Parameters for Events
- `/events?calendarId=id&start=YYYY-MM-DDTHH:mm:ssZ&end=YYYY-MM-DDTHH:mm:ssZ&timeZone=Zone`  
Allows clients to efficiently fetch events for specific calendars and time ranges considering time zones.

#### 4. Rich Schema Definitions
- **Calendar:** id, name, owner  
- **Event:** id, title, start & end datetime, timeZone, attendees array, recurrenceRule, reminders array, invitations array, notes  
- **Attendee:** id, name, email  
- **RecurrenceRule, Reminder, Invitation:** detailed nested schemas to support complex event recurrence, notification reminders, and invitations.

#### 5. Versioning & Breaking Change Policy Documented
- Contract header includes semantic versioning strategy:  
  - Backward-compatible changes increment minor version.  
  - Breaking changes increment major version and are documented in the contract header and through supplementary changelogs.  
- Policy gives clear guidance for clients and developers to manage API evolution and migration.

---

### API Testing Examples

#### Calendars

- **Create Calendar (POST /api/calendars)**  
  Request Body:
  {
   "id": "cal1",
   "name": "Work Calendar",
  "owner": "alice@example.com"
   }

  Expected Response: `201 Created` with the created calendar resource.

- **Get All Calendars (GET /api/calendars)**  
Response: HTTP status 200 with array of calendar objects.

- **Get Calendar by ID (GET /api/calendars/cal1)**  
Response: HTTP 200 with calendar JSON or 404 if not found.

- **Update Calendar (PUT /api/calendars/cal1)**  
Request Body:
  {
"id": "cal1",
"name": "Updated Work Calendar",
"owner": "alice@example.com"
}
Expected Response: HTTP 204 No Content on success.

- **Delete Calendar (DELETE /api/calendars/cal1)**  
Expected Response: HTTP 204 No Content on success.

---

#### Events

- **Create Event (POST /api/events)**  
Request Body:
{
"id": "evt1",
"title": "Team Meeting",
"start": "2025-09-20T10:00:00Z",
"end": "2025-09-20T11:00:00Z",
"timeZone": "UTC",
"attendees": [{"id":"att1","name":"Bob","email":"bob@example.com"}],
"recurrenceRule": {"frequency":"Weekly","interval":1},
"reminders": [{"id":"rem1","leadTime":"00:15:00","method":"Email"}],
"invitations": [{"id":"inv1","invitationStatus":"Pending","invitee":{"id":"att1"}}],
"notes": "Discuss Q3 goals"
}
Expected Response: `201 Created`.

- **List Events with Filters (GET /api/events?calendarId=cal1&start=2025-09-01T00:00:00Z&end=2025-09-30T23:59:59Z&timeZone=UTC)**  
Returns events within specified range for calendar `cal1`.

---

#### Attendees

- **Create Attendee (POST /api/attendees)**  
Request Body:
{
"id": "att1",
"name": "Bob",
"email": "bob@example.com"
}
Expected Response: `201 Created`.

- **List Attendees (GET /api/attendees)**  
Returns array of attendees.

---

### Summary

- The OpenAPI contract fully defines the REST API with clear paths, parameters, and schemas.
- Querying capabilities for events by time ranges and time zones support client requirements.
- The contract includes a **Versioning and Breaking Changes policy**, guiding future evolution.
- This contract serves as the basis for testing and implementation, successfully validated with Swagger UI.
- Work completed fully meets the acceptance criteria for Homework 2 Step 2.

---

This completes Step 2: Define the Contract, establishing a solid foundation for API development and usage.




