# FinalProjectContProg

This project is an **ASP.NET Core MVC** application utilizing **Entity Framework Core (EF Core)** to manage entities such as team members, projects, tasks, skills, colors, and foods. The project demonstrates CRUD operations and relational database modeling.

## Features
- Manage **Team Members**, **Projects**, **Skills**, **Tasks**, **Colors**, and **Foods**.
- Implements **Entity Framework Core** for database interactions.
- Organized using the **MVC (Model-View-Controller)** design pattern.
- Migration and database setup included.
- Supports relationships between entities.

---
## How to Start the DB/Program

### Make sure your code is up-to-date in VS Code terminal
`dotnet ef database update --project FinalProjectContProg/FinalProjectContProg.csproj`

### Then, run the application with
`dotnet run --project FinalProjectContProg/FinalProjectContProg.csproj --environment Development`

### In your browser, navigate to:
### `http://localhost:5294/swagger/index.html#/`
### This should show the available endpoints and documentation.
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

- **`ColorsController.cs`**
  Handles CRUD operations for `Color` entities.

- **`FoodsController.cs`**
  Handles CRUD operations for `Food` entities.

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
  Represents a team member entity. Relates to `Project`, `Skill`, `Color`, and `Food`.

- **`Color.cs`**
  Represents a color entity. Relates to `TeamMember`.

- **`Food.cs`**
  Represents a food entity. Relates to `TeamMember`.

### `Migrations/`
Contains EF Core migration files to track database schema changes.

- **`InitialCreate.cs`**
  The first migration, which sets up the database schema.

---

## Entity Relationships

The project uses a relational database with the following entity relationships:
1. A `TeamMember` can have many `Projects`, `Skills`, `Colors`, and `Foods`.
2. A `Project` belongs to a `TeamMember` and can have many `Tasks`.
3. A `Task` belongs to a `Project`.
4. A `Skill`, `Color`, and `Food` belong to a `TeamMember`.

### Entity Relationship Diagram (ERD)
```mermaid
erDiagram
    TEAM_MEMBER {
        int Id PK
        string FullName
        datetime BirthDate
        string CollegeProgram
        string YearInProgram
    }
    COLOR {
        int Id PK
        string Name
        string ColorOne
        string ColorTwo
        string ColorThree
        string ColorFour
        int TeamMemberId FK
    }
    FOOD {
        int Id PK
        string Name
        string Breakfast
        string Lunch
        string Snack
        string Dinner
        int TeamMemberId FK
    }
    PROJECT {
        int Id PK
        string Name
        string Description
        int TeamMemberId FK
    }
    SKILL {
        int Id PK
        string Name
        int TeamMemberId FK
    }
    TASK {
        int Id PK
        string Title
        string Status
        int ProjectId FK
    }
    
    TEAM_MEMBER ||--o{ COLOR : "has"
    TEAM_MEMBER ||--o{ FOOD : "has"
    TEAM_MEMBER ||--o{ PROJECT : "participates in"
    TEAM_MEMBER ||--o{ SKILL : "has"
    PROJECT ||--o{ TASK : "contains"
