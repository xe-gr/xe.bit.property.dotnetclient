dotnet build -c Release
copy .\bin\release\netcoreapp2.2\* lib /Y
..\..\nuget pack
nuget push xe.bit.property.core.0.5.0.nupkg -Source https://api.nuget.org/v3/index.json