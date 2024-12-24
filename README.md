
# Survivor API

This project is a web API application built using ASP.NET Core with Entity Framework Core and PostgreSQL as the database.

---

## Prerequisites

1. **.NET SDK**: Ensure you have .NET SDK installed on your machine.  
   [Download .NET SDK](https://dotnet.microsoft.com/download)

2. **PostgreSQL**: Install and configure PostgreSQL for the database.  
   [Download PostgreSQL](https://www.postgresql.org/download/)

---

## Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/your-repository/survivor-api.git
cd survivor-api
```

### 2. Configure the Database Connection String

Update the `DefaultConnection` in the `appsettings.json` file with your PostgreSQL connection string.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=SurvivorDb;Username=your_username;Password=your_password"
}
```

### 3. Install Dependencies

Run the following command to restore the required dependencies:

```bash
dotnet restore
```

### 4. Apply Database Migrations

Use Entity Framework Core to create or update the database schema:

```bash
dotnet ef database update
```

### 5. Run the Application

Launch the application:

```bash
dotnet run
```

---

## API Endpoints

- **Swagger UI**: Available at `https://localhost:<port>/swagger` in development mode.  
  Swagger provides an interactive interface to explore and test the API.

- **Base URL**: `https://localhost:<port>/`

---

## Project Structure

- **`Program.cs`**: Configures services and the application's request pipeline.
- **`Survivor.Data/SurvivorDbContext.cs`**: Manages the Entity Framework Core database context.
- **`Controllers/`**: Contains API controllers for handling HTTP requests.

---

## Technologies Used

- **ASP.NET Core**: Backend framework for building web APIs.
- **Entity Framework Core**: Object-relational mapping (ORM) tool.
- **PostgreSQL**: Database management system.
- **Swagger/OpenAPI**: API documentation and testing.

---

## Development Mode

To enable Swagger UI and other development tools, ensure the environment is set to `Development`:

```bash
ASPNETCORE_ENVIRONMENT=Development
```

---

## Deployment

For production deployment:

1. Use a production-grade PostgreSQL database.
2. Ensure HTTPS is properly configured.
3. Publish the application using the following command:

```bash
dotnet publish -c Release
```

Deploy the published files to your server or hosting provider.

---

## Contributing

Contributions are welcome! Feel free to submit a pull request or raise issues for enhancements or bug fixes.

---

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.
