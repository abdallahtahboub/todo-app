# Todo API

A C# portfolio project with a versioned ASP.NET Core REST API, PostgreSQL persistence through Entity Framework Core, and xUnit controller tests. The repository also contains a Blazor Server prototype that stores items in memory.

## Run the API locally

**Prerequisites:** .NET SDK 9.0.305 (see [global.json](global.json)) and a running PostgreSQL instance. Create a development database named `todo` and give a local PostgreSQL role permission to create tables in it.

```bash
git clone https://github.com/abdallahtahboub/todo-app.git
cd todo-app

dotnet tool install --tool-path ./.git/ef-tools dotnet-ef --version 9.0.8
```

Set the connection string for your local database. Replace the example username and password with your development credentials.

```bash
export ConnectionStrings__DefaultConnection='Host=localhost;Port=5432;Database=todo;Username=todo_user;Password=replace-me'

./.git/ef-tools/dotnet-ef database update \
  --project todo.data/todo.data.csproj \
  --startup-project todo.api/todo.api.csproj

dotnet run --project todo.api/todo.api.csproj --launch-profile todo.api
```

Open [Swagger UI](http://localhost:5002/swagger) to try the API. For a quick check against the running service:

```bash
curl --fail http://localhost:5002/api/v1/Todo/all
```

A fresh database returns `[]`.

## API routes

All routes start with `/api/v1/Todo`. Item IDs are integers.

| Method | Route suffix | Behavior |
| --- | --- | --- |
| POST | — | Create an item from `{"value":"Buy groceries"}`. New items start incomplete. |
| GET | `/{id}` | Fetch an item by ID. Returns 404 for a missing item. |
| GET | `/all` | List items. |
| PUT | `/{id}` | Update the text and completion state, for example `{"value":"Buy groceries","isCompleted":true}`. |
| DELETE | `/{id}` | Delete one item. |
| DELETE | `/all` | Delete all items in the development database. |

## Tests

```bash
dotnet test todo.sln
```

The xUnit tests call the controller directly using EF Core’s in-memory provider. They cover successful lookup and the missing-item response and can run independently of PostgreSQL. The [GitHub Actions build-and-test workflow](.github/workflows/basicWorkflow.yml) runs on push and on a schedule.

## Where to start reading

| Path | What to look at |
| --- | --- |
| [todo.api](todo.api) | Versioned controller, request and response DTOs, Swagger configuration, and error-handling middleware. |
| [todo.data](todo.data) | EF Core context and the initial PostgreSQL migration. |
| [todo.tests](todo.tests) | xUnit controller tests for lookup behavior. |
| [todo.app](todo.app) | Standalone Blazor Server prototype for adding and deleting in-memory items. |

To try the Blazor prototype separately, run `dotnet run --project todo.app/todo.app.csproj --launch-profile todo.app` and open [http://localhost:5000](http://localhost:5000).

## Author

[Abdallah Tahboub on LinkedIn](https://www.linkedin.com/in/abdallah-tahboub-024954a7/)
