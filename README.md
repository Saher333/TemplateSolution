# Template Solution

**Template** is a pre-configured .NET solution designed to accelerate the bootstrapping process for new projects. It provides a modular, scalable, and test-driven foundation, adhering to best practices such as separation of concerns, CQRS, and event-driven architecture. This template is ideal for building robust, maintainable applications, from small projects to large, complex systems.

---

## Table of Contents

- [Solution Structure](#solution-structure)
- [Project Descriptions](#project-descriptions)
- [Project Dependencies](#project-dependencies)
- [Naming Conventions](#naming-conventions)
- [Customization](#customization)
- [Getting Started](#getting-started)
- [Contributing](#contributing)
- [License](#license)

---

## Solution Structure

The solution is organized into two main folders: `Src` for source code and `Tests` for testing projects. This separation ensures clarity and maintainability.

```
TemplateSolution.sln
Src/
  Template.Core/
    Common/
    Configuration/
    Constants/
    CQRS/
    Interfaces/
    Repositories/
    Services/
    Template.Core.csproj
  Template.WebApi/
    Controllers/
    Models/
    Validators/
    Template.WebApi.csproj
Tests/
  Template.UnitTests/
    Template.UnitTests.csproj
  Template.IntegrationTests/
    Template.IntegrationTests.csproj
  Template.ApiClient/
    Template.ApiClient.csproj
  Template.IntegrationEvents/
    Template.IntegrationEvents.csproj
```

---

## Project Descriptions

Each project in the solution serves a specific purpose:

- **Template.Core**:  
  Contains the core business logic, domain models, and interfaces. It is the heart of the application, housing:
  - `Common`: Shared utilities and helpers.
  - `Configuration`: Application-wide settings and configurations.
  - `Constants`: Global constants used across the solution.
  - `CQRS`: Command and Query Responsibility Segregation components for handling operations.
  - `Interfaces`: Definitions for services, repositories, etc.
  - `Repositories`: Data access logic (implementations of repository interfaces).
  - `Services`: Business logic services.

- **Template.WebApi**:  
  The presentation layer, typically a Web API, responsible for handling HTTP requests and responses. It includes:
  - `Controllers`: API endpoints.
  - `Models`: Data transfer objects (DTOs) and view models.
  - `Validators`: Input validation logic.

- **Template.UnitTests**:  
  Contains unit tests for the `Template.Core` and `Template.WebApi` projects, ensuring individual components function correctly.

- **Template.IntegrationTests**:  
  Houses integration tests to verify the interaction between components, such as database operations or API calls.

- **Template.ApiClient**:  
  A client library for interacting with external APIs or services. *(Note: If this is primarily for testing, consider clarifying its purpose or moving it to `Src` if it's part of the main application.)*

- **Template.IntegrationEvents**:  
  Manages integration events for event-driven communication between services, ideal for microservices or distributed systems.

---

## Project Dependencies

The projects are structured with clear dependencies to enforce separation of concerns:

- **`Template.WebApi`** depends on **`Template.Core`**.
- **`Template.Core`** has no dependencies on other projects.
- **`Template.UnitTests`** depends on **`Template.Core`** and **`Template.WebApi`**.
- **`Template.IntegrationTests`** depends on **`Template.Core`**, **`Template.WebApi`**, and potentially **`Template.ApiClient`**.
- **`Template.ApiClient`** (if part of the main app) may depend on **`Template.Core`**.
- **`Template.IntegrationEvents`** may be referenced by **`Template.Core`** or **`Template.WebApi`** as needed.

This setup ensures that the core logic remains independent and testable.

---

## Naming Conventions

- **Project Names**: Use **PascalCase** (e.g., `Template.Core`, `Template.WebApi`).
- **Namespaces**: Match the project names for consistency (e.g., `Template.Core`, `Template.WebApi`).
- **Folders and Files**: Use descriptive names that reflect their purpose (e.g., `Controllers`, `Services`, `Models`).

---

## Customization

This template is designed to be flexible. Here’s how you can adapt it for your specific needs:

- **Rename Projects**: Replace "Template" with your company or application name (e.g., `AcmeCorp.Core`, `AcmeCorp.WebApi`).
- **Adjust for Project Size**: For smaller projects, you can omit components like `CQRS` or `IntegrationEvents`. Simply remove or comment out the unnecessary folders or projects.
- **Replace `WeatherForecast.cs`**: This is a placeholder file in `Template.WebApi`. Replace it with domain-specific controllers and models relevant to your application.
- **Extend with Additional Projects**: Add projects like `Template.Infrastructure` for cross-cutting concerns (e.g., logging, security) if needed.

---

## Getting Started

To use this template for a new project:

1. **Clone the Repository**: Start by cloning this template to your local machine.
2. **Rename the Solution and Projects**: Update the solution and project names to reflect your new application (e.g., `MyApp.sln`, `MyApp.Core.csproj`).
3. **Update Namespaces**: Ensure namespaces match the new project names.
4. **Remove Placeholder Code**: Delete or replace files like `WeatherForecast.cs` with your domain-specific code.
5. **Set Up Dependencies**: Install any required NuGet packages or external dependencies.
6. **Run Tests**: Execute the unit and integration tests to ensure everything is set up correctly.

---

## Contributing

Contributions to improve this template are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or fix.
3. Submit a pull request with a clear description of your changes.

---

## License

This project is licensed under the [MIT License](LICENSE). Feel free to use, modify, and distribute it as needed.

---
