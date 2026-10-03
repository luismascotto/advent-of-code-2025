# Advent of Code 2025

Personal solutions to [Advent of Code 2025](https://adventofcode.com/) challenges implemented in C#.

## Structure

- `ConsoleApp1/` - Main console application with daily solutions
- `Test/` - Unit tests using xUnit
- `Benchmarks/` - Performance benchmarks using BenchmarkDotNet
- `Hlp/` - Helper extension methods

## Requirements

- .NET 10.0 SDK

## Running

```bash
dotnet run --project ConsoleApp1 <day>
```

## Testing

```bash
dotnet test
```

## Benchmarks

```bash
dotnet run --project Benchmarks -c Release
```
