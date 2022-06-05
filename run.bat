color 02
ECHO off

dotnet build
dotnet tool install --global dotnet-ef
dotnet ef database update --project=FengShuiNumber
dotnet run --project=FengShuiNumber