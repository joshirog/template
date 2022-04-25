# Monkeylab Template

## Migrations
~~~
* dotnet ef database update -s Monkeylab.Templates.Api -p Monkeylab.Templates.Infrastructure

* dotnet ef database update 0 -s Monkeylab.Templates.Api -p Monkeylab.Templates.Infrastructure
* dotnet ef migrations remove -s Monkeylab.Templates.Api -p Monkeylab.Templates.Infrastructure

* dotnet ef migrations add CreateInitialScheme -s Monkeylab.Templates.Api -p Monkeylab.Templates.Infrastructure -o Persistences/Migrations
~~~