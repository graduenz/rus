# Development

## Migrations

Specify the following parameters to run the EF commands:
- `--project` with the migrations project.
- `--startup-project` with the startup project.
- `--context` with the DbContext class name.

### Adding new migrations

```
dotnet ef migrations add Initial --project .\src\Advertiser.Migrations\ --startup-project .\src\Rus.Api\ --context AdvertiserDbContext
```

### Updating the database

```
dotnet ef database update --project .\src\Advertiser.Migrations\ --startup-project .\src\Rus.Api\ --context AdvertiserDbContext
```
