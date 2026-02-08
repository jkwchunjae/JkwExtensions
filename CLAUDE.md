# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

JkwExtensions (Jkw.Extensions) is a C# extension methods library that provides utility functions for common programming tasks. Published as a NuGet package.

**Repository**: https://github.com/jkwchunjae/JkwExtensions
**Package**: Jkw.Extensions
**Target Framework**: .NET 8.0 (previously netcoreapp3.1 and net47)
**Current Version**: 1.0.13

## Build Commands

```bash
# Build the project
dotnet build JkwExtensions/JkwExtensions.csproj

# Build in Release mode
dotnet build JkwExtensions/JkwExtensions.csproj -c Release

# Pack for NuGet
dotnet pack JkwExtensions/JkwExtensions.csproj -c Release
```

## Solution Structure

The project uses `.slnx` format (XML-based solution file for Visual Studio 2022 17.10+) instead of traditional `.sln` files.

## Architecture

This is a single-project library organized by extension categories:

### Core Extension Files

- **EnumerableExtensions.cs** - IEnumerable<T> extensions
  - Random operations: `GetRandom()`, `RandomShuffle()`
  - Utilities: `Empty()`, `ForEach()`, `ForEachAsync()`, `ForEachParallelAsync()`
  - Async helpers: `WhenAll()`, `WhenAny()`
  - Safe aggregates: `MaxOrNull()`, `MinOrNull()` for various numeric types
  - Functional: `Reduce()`, `ReduceAsync()`

- **StringExtensions.cs** - String manipulation
  - Formatting: `With()` (string.Format wrapper), `WithVar()` (property-based formatting)
  - Joining: `StringJoin()` with various overloads
  - Conversion: `ToInt()`, `ToLong()`, `ToDouble()`, `ToBoolean()` with default values
  - Validation: `IsInt()`, `IsLong()`, `HasInvalidFileNameChar()`, `HasInvalidPathChar()`
  - Manipulation: `Left()`, `Right()`, `ToCamelCase()`, `Repeat()`, `RegexReplace()`

- **DictionaryExtensions.cs** - Dictionary utilities
  - Conversion to `DefaultDictionary<TKey, TValue>`

- **DateTimeExtensions.cs** - Date/time parsing and formatting
  - String to DateTime conversion: `TryToDate()`, `ToDate()`, `ToDateTime()`
  - Localized weekday names: `GetWeekday()` (supports KR/EN languages)

- **MathHelper.cs** - Mathematical operations
  - `StandardDeviation()` for IEnumerable<double>

### Supporting Classes

- **DefaultDictionary.cs** - Dictionary that returns a default value for missing keys
- **StaticRandom.cs** - Thread-safe static random number generator used by EnumerableExtensions
- **ConsoleHelper.cs** - Console utilities
- **AttributeExtensions.cs** - Attribute reflection helpers
- **EnumExtensions.cs** - Enum utilities
- **ReaderWriterLockSlimExtensions.cs** - Lock utilities
- **XmlExtensions.cs** - XML parsing helpers

## Design Patterns

- **Extension Methods Pattern**: All utilities are implemented as extension methods in static classes
- **DefaultDictionary**: Uses indexer override to provide Python-like defaultdict behavior
- **ForEach with Exception Collection**: Several ForEach overloads accept exception collections for fault-tolerant iteration
- **OrNull Pattern**: Safe aggregate functions (MaxOrNull, MinOrNull) that return null for empty collections instead of throwing

## Version Management

Version is managed in `JkwExtensions.csproj`:
- `<Version>` - NuGet package version (currently 1.0.13)
- `<AssemblyVersion>` and `<FileVersion>` - Assembly versions (currently 1.0.1.0)

When publishing updates, increment the `<Version>` property.
