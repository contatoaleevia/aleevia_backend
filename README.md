# aleevia-backend

## Rodar o projeto
```bash
dotnet run --project src/Api/Api.csproj
```

# Gerenciando Migrações
## Para criar uma nova migração:
```bash
dotnet ef migrations add NomeDaMigracao --project src/Infrastructure --startup-project src/Api --context ApiDbContext
```

## Aplicar migrações ao banco de dados
```bash
dotnet ef database update --project src/Infrastructure --startup-project src/Api --context ApiDbContext
```
