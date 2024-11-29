# FinalProjectContProg

This project is an **ASP.NET Core MVC** application utilizing **Entity Framework Core (EF Core)** to manage entities such as team members, projects, tasks, and skills. The project demonstrates CRUD operations and relational database modeling.

## Features
- Manage **Team Members**, **Projects**, **Skills**, and **Tasks**.
- Implements **Entity Framework Core** for database interactions.
- Organized using the **MVC (Model-View-Controller)** design pattern.
- Migration and database setup included.
- Supports relationships between entities.

---

## Project Structure

### `Controllers/`
Handles HTTP requests and provides endpoints for CRUD operations.

- **`ProjectController.cs`**
  Handles CRUD operations for `Project` entities.

- **`SkillsController.cs`**
  Handles CRUD operations for `Skill` entities.

- **`TeamMembersController.cs`**
  Handles CRUD operations for `TeamMember` entities.

### `Data/`
Contains the EF Core database context.

- **`AppDbContext.cs`**
  Defines the database context and the `DbSet` properties for each model. Also handles entity configurations.

### `Models/`
Defines the data models and relationships.

- **`Project.cs`**
  Represents a project entity. Relates to `TeamMember` and `Task`.

- **`Skill.cs`**
  Represents a skill entity. Relates to `TeamMember`.

- **`Task.cs`**
  Represents a task entity. Relates to `Project`.

- **`TeamMember.cs`**
  Represents a team member entity. Relates to `Project` and `Skill`.

### `Migrations/`
Contains EF Core migration files to track database schema changes.

- **`InitialCreate.cs`**
  The first migration, which sets up the database schema.

---

## Entity Relationships

The project uses a relational database with the following entity relationships:
1. A `TeamMember` can have many `Projects` and `Skills`.
2. A `Project` belongs to a `TeamMember` and can have many `Tasks`.
3. A `Task` belongs to a `Project`.
4. A `Skill` belongs to a `TeamMember`.

### Entity Relationship Diagram (ERD)
```mermaid
erDiagram
    TeamMember {
        int Id
        string FullName
        DateTime BirthDate
        string CollegeProgram
        string YearInProgram
    }
    Project {
        int Id
        string Name
        string Description
        int TeamMemberId
    }
    Skill {
        int Id
        string Name
        int TeamMemberId
    }
    Task {
        int Id
        string Title
        string Status
        int ProjectId
    }
    TeamMember ||--o{ Project : has
    TeamMember ||--o{ Skill : has
    Project ||--o{ Task : includes
    Task }o--|| Project : belongs_to
    Skill }o--|| TeamMember : belongs_to
