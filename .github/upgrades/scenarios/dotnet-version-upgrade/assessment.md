# Projects and dependencies analysis

This document provides a comprehensive overview of the projects and their dependencies in the context of upgrading to .NETCoreApp,Version=v9.0.

## Table of Contents

- [Executive Summary](#executive-Summary)
  - [Highlevel Metrics](#highlevel-metrics)
  - [Projects Compatibility](#projects-compatibility)
  - [Package Compatibility](#package-compatibility)
  - [API Compatibility](#api-compatibility)
- [Aggregate NuGet packages details](#aggregate-nuget-packages-details)
- [Top API Migration Challenges](#top-api-migration-challenges)
  - [Technologies and Features](#technologies-and-features)
  - [Most Frequent API Issues](#most-frequent-api-issues)
- [Projects Relationship Graph](#projects-relationship-graph)
- [Project Details](#project-details)

  - [BenchmarkSuite1\BenchmarkSuite1.csproj](#benchmarksuite1benchmarksuite1csproj)
  - [ConsoleApp\ConsoleApp.csproj](#consoleappconsoleappcsproj)
  - [ConsoleApp_Debug\ConsoleApp_Debug.csproj](#consoleapp_debugconsoleapp_debugcsproj)
  - [ConsoleApp_Profiler\ConsoleApp_Profiler.csproj](#consoleapp_profilerconsoleapp_profilercsproj)
  - [Hangman\Hangman.csproj](#hangmanhangmancsproj)
  - [Models\Models.csproj](#modelsmodelscsproj)
  - [WebApp\WebApp.csproj](#webappwebappcsproj)


## Executive Summary

### Highlevel Metrics

| Metric | Count | Status |
| :--- | :---: | :--- |
| Total Projects | 7 | 0 require upgrade |
| Total NuGet Packages | 2 | All compatible |
| Total Code Files | 21 |  |
| Total Code Files with Incidents | 0 |  |
| Total Lines of Code | 969 |  |
| Total Number of Issues | 0 |  |
| Estimated LOC to modify | 0+ | at least 0,0% of codebase |

### Projects Compatibility

| Project | Target Framework | Difficulty | Package Issues | API Issues | Est. LOC Impact | Description |
| :--- | :---: | :---: | :---: | :---: | :---: | :--- |
| [BenchmarkSuite1\BenchmarkSuite1.csproj](#benchmarksuite1benchmarksuite1csproj) | net10.0 | ✅ None | 0 | 0 |  | DotNetCoreApp, Sdk Style = True |
| [ConsoleApp\ConsoleApp.csproj](#consoleappconsoleappcsproj) | net10.0 | ✅ None | 0 | 0 |  | DotNetCoreApp, Sdk Style = True |
| [ConsoleApp_Debug\ConsoleApp_Debug.csproj](#consoleapp_debugconsoleapp_debugcsproj) | net10.0 | ✅ None | 0 | 0 |  | DotNetCoreApp, Sdk Style = True |
| [ConsoleApp_Profiler\ConsoleApp_Profiler.csproj](#consoleapp_profilerconsoleapp_profilercsproj) | net10.0 | ✅ None | 0 | 0 |  | DotNetCoreApp, Sdk Style = True |
| [Hangman\Hangman.csproj](#hangmanhangmancsproj) | net10.0 | ✅ None | 0 | 0 |  | DotNetCoreApp, Sdk Style = True |
| [Models\Models.csproj](#modelsmodelscsproj) | net10.0 | ✅ None | 0 | 0 |  | ClassLibrary, Sdk Style = True |
| [WebApp\WebApp.csproj](#webappwebappcsproj) | net10.0 | ✅ None | 0 | 0 |  | AspNetCore, Sdk Style = True |

### Package Compatibility

| Status | Count | Percentage |
| :--- | :---: | :---: |
| ✅ Compatible | 2 | 100,0% |
| ⚠️ Incompatible | 0 | 0,0% |
| 🔄 Upgrade Recommended | 0 | 0,0% |
| ***Total NuGet Packages*** | ***2*** | ***100%*** |

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

## Aggregate NuGet packages details

| Package | Current Version | Suggested Version | Projects | Description |
| :--- | :---: | :---: | :--- | :--- |
| BenchmarkDotNet | 0.15.2 |  | [BenchmarkSuite1.csproj](#benchmarksuite1benchmarksuite1csproj) | ✅Compatible |
| Microsoft.VisualStudio.DiagnosticsHub.BenchmarkDotNetDiagnosers | 18.3.36812.1 |  | [BenchmarkSuite1.csproj](#benchmarksuite1benchmarksuite1csproj) | ✅Compatible |

## Top API Migration Challenges

### Technologies and Features

| Technology | Issues | Percentage | Migration Path |
| :--- | :---: | :---: | :--- |

### Most Frequent API Issues

| API | Count | Percentage | Category |
| :--- | :---: | :---: | :--- |

## Projects Relationship Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart LR
    P1["<b>📦&nbsp;ConsoleApp.csproj</b><br/><small>net10.0</small>"]
    P2["<b>📦&nbsp;Models.csproj</b><br/><small>net10.0</small>"]
    P3["<b>📦&nbsp;WebApp.csproj</b><br/><small>net10.0</small>"]
    P4["<b>📦&nbsp;Hangman.csproj</b><br/><small>net10.0</small>"]
    P5["<b>📦&nbsp;ConsoleApp_Debug.csproj</b><br/><small>net10.0</small>"]
    P6["<b>📦&nbsp;ConsoleApp_Profiler.csproj</b><br/><small>net10.0</small>"]
    P7["<b>📦&nbsp;BenchmarkSuite1.csproj</b><br/><small>net10.0</small>"]
    P3 --> P2
    P7 --> P6
    click P1 "#consoleappconsoleappcsproj"
    click P2 "#modelsmodelscsproj"
    click P3 "#webappwebappcsproj"
    click P4 "#hangmanhangmancsproj"
    click P5 "#consoleapp_debugconsoleapp_debugcsproj"
    click P6 "#consoleapp_profilerconsoleapp_profilercsproj"
    click P7 "#benchmarksuite1benchmarksuite1csproj"

```

## Project Details

<a id="benchmarksuite1benchmarksuite1csproj"></a>
### BenchmarkSuite1\BenchmarkSuite1.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 1
- **Dependants**: 0
- **Number of Files**: 3
- **Lines of Code**: 191
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["BenchmarkSuite1.csproj"]
        MAIN["<b>📦&nbsp;BenchmarkSuite1.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#benchmarksuite1benchmarksuite1csproj"
    end
    subgraph downstream["Dependencies (1"]
        P6["<b>📦&nbsp;ConsoleApp_Profiler.csproj</b><br/><small>net10.0</small>"]
        click P6 "#consoleapp_profilerconsoleapp_profilercsproj"
    end
    MAIN --> P6

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

<a id="consoleappconsoleappcsproj"></a>
### ConsoleApp\ConsoleApp.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 0
- **Dependants**: 0
- **Number of Files**: 4
- **Lines of Code**: 152
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["ConsoleApp.csproj"]
        MAIN["<b>📦&nbsp;ConsoleApp.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#consoleappconsoleappcsproj"
    end

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

<a id="consoleapp_debugconsoleapp_debugcsproj"></a>
### ConsoleApp_Debug\ConsoleApp_Debug.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 0
- **Dependants**: 0
- **Number of Files**: 1
- **Lines of Code**: 29
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["ConsoleApp_Debug.csproj"]
        MAIN["<b>📦&nbsp;ConsoleApp_Debug.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#consoleapp_debugconsoleapp_debugcsproj"
    end

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

<a id="consoleapp_profilerconsoleapp_profilercsproj"></a>
### ConsoleApp_Profiler\ConsoleApp_Profiler.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 0
- **Dependants**: 1
- **Number of Files**: 1
- **Lines of Code**: 48
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph upstream["Dependants (1)"]
        P7["<b>📦&nbsp;BenchmarkSuite1.csproj</b><br/><small>net10.0</small>"]
        click P7 "#benchmarksuite1benchmarksuite1csproj"
    end
    subgraph current["ConsoleApp_Profiler.csproj"]
        MAIN["<b>📦&nbsp;ConsoleApp_Profiler.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#consoleapp_profilerconsoleapp_profilercsproj"
    end
    P7 --> MAIN

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

<a id="hangmanhangmancsproj"></a>
### Hangman\Hangman.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 0
- **Dependants**: 0
- **Number of Files**: 6
- **Lines of Code**: 347
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["Hangman.csproj"]
        MAIN["<b>📦&nbsp;Hangman.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#hangmanhangmancsproj"
    end

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

<a id="modelsmodelscsproj"></a>
### Models\Models.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** ClassLibrary
- **Dependencies**: 0
- **Dependants**: 1
- **Number of Files**: 2
- **Lines of Code**: 15
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph upstream["Dependants (1)"]
        P3["<b>📦&nbsp;WebApp.csproj</b><br/><small>net10.0</small>"]
        click P3 "#webappwebappcsproj"
    end
    subgraph current["Models.csproj"]
        MAIN["<b>📦&nbsp;Models.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#modelsmodelscsproj"
    end
    P3 --> MAIN

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

<a id="webappwebappcsproj"></a>
### WebApp\WebApp.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** AspNetCore
- **Dependencies**: 1
- **Dependants**: 0
- **Number of Files**: 7
- **Lines of Code**: 187
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["WebApp.csproj"]
        MAIN["<b>📦&nbsp;WebApp.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#webappwebappcsproj"
    end
    subgraph downstream["Dependencies (1"]
        P2["<b>📦&nbsp;Models.csproj</b><br/><small>net10.0</small>"]
        click P2 "#modelsmodelscsproj"
    end
    MAIN --> P2

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

