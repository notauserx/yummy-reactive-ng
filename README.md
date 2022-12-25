# yummy-reactive-ng

a recipe app built with sqlite, .NET core, Ef core, angular, primeng and more.

## start the server

From rezept-api/Api folder, run

```
dotnet run
```

After changing entities, run

```
 dotnet ef migrations add <migration_name>
```

to update the database ->

```
dotnet ef database update
```

## start the client

from rezept-app

```
ng serve
```

