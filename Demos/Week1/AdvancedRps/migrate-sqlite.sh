#!/bin/sh

dotnet-ef migrations add SqliteMigration${1} -p Rps.Storage/Rps.Storage.csproj -s Rps.Local/Rps.Local.csproj -c SqliteContext
dotnet-ef database update -p Rps.Storage/Rps.Storage.csproj -s Rps.Local/Rps.Local.csproj -c SqliteContext
