# 02-update-target-frameworks: Update Target Frameworks Across All Projects

Update the `<TargetFramework>` element from `net10.0` to `net9.0` in all 7 project files:
- BenchmarkSuite1/BenchmarkSuite1.csproj
- ConsoleApp/ConsoleApp.csproj
- ConsoleApp_Debug/ConsoleApp_Debug.csproj
- ConsoleApp_Profiler/ConsoleApp_Profiler.csproj
- Hangman/Hangman.csproj
- Models/Models.csproj
- WebApp/WebApp.csproj

All projects are SDK-style and use the same pattern.

**Done when**: All project files specify `<TargetFramework>net9.0</TargetFramework>` and no project references .NET 10
