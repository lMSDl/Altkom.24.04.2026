# Centralne Zarządzanie Wersjami Paczek NuGet

## Struktura

Ten projekt używa **Central Package Management (CPM)** - mechanizmu .NET do zarządzania wersjami paczek NuGet w jednym miejscu.

## Pliki

- **Directory.Packages.props** - definiuje wersje wszystkich paczek NuGet używanych w solution

## Jak to działa?

### 1. Dodawanie nowej paczki

**Krok 1:** Dodaj definicję wersji w `Directory.Packages.props`:
```xml
<PackageVersion Include="NazwaPaczki" Version="1.2.3" />
```

**Krok 2:** W pliku `.csproj` dodaj referencję **bez** wersji:
```xml
<PackageReference Include="NazwaPaczki" />
```

### 2. Aktualizacja wersji paczki

Wystarczy zmienić wersję w `Directory.Packages.props` - automatycznie zaktualizuje się we wszystkich projektach.

### 3. Nadpisanie wersji dla konkretnego projektu

Jeśli konkretny projekt potrzebuje innej wersji:
```xml
<PackageReference Include="NazwaPaczki" VersionOverride="2.0.0" />
```

## Zalety

✅ **Spójność** - wszystkie projekty używają tych samych wersji paczek  
✅ **Łatwość aktualizacji** - jedna zmiana w jednym miejscu  
✅ **Bezpieczeństwo** - łatwiejsze zarządzanie podatnościami  
✅ **Przejrzystość** - szybki przegląd wszystkich zależności  
✅ **Kontrola wersji** - łatwiejsze code review zmian w zależnościach  

## Przykłady

### Dodanie Entity Framework Core

W `Directory.Packages.props`:
```xml
<PackageVersion Include="Microsoft.EntityFrameworkCore" Version="10.0.0" />
<PackageVersion Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.0" />
<PackageVersion Include="Microsoft.EntityFrameworkCore.Design" Version="10.0.0" />
```

W projekcie (np. `WebApp.csproj`):
```xml
<ItemGroup>
  <PackageReference Include="Microsoft.EntityFrameworkCore" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" />
</ItemGroup>
```

### Dodanie testów jednostkowych

W `Directory.Packages.props`:
```xml
<PackageVersion Include="xunit" Version="2.9.2" />
<PackageVersion Include="xunit.runner.visualstudio" Version="2.8.2" />
<PackageVersion Include="Microsoft.NET.Test.Sdk" Version="17.11.1" />
<PackageVersion Include="Moq" Version="4.20.72" />
```

## Więcej informacji

📚 [Dokumentacja Microsoft - Central Package Management](https://learn.microsoft.com/en-us/nuget/consume-packages/central-package-management)
