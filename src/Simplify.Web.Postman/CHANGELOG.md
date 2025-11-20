# Changelog

## [2.1] - Unreleased

### Fixed

- Exception when generating Postman collections for controller request bodies containing `IList<string>` properties.

## [2.0] - 2024-06-05

### Dependencies

- Simplify.Web bump to 5.0

## [1.1] - 2023-11-07

### Fixed

- Cannot dynamically create an instance of type array (#31)

### Added

- Generate request bodies for list/array properties (#32)

## [1.0] - 2023-07-16

### Added

- Simple controller tests generation (#5)

### Dependencies

- System.Text.Json bump to 7.0.3 (PR#28)

## [1.0-pre04] - 2022-11-20

### Added

- Requests folders structure in postman should reflect controller route structure (#19)
- .NET 6 targeting

## [1.0-pre03] - 2022-09-15

### Dependencies

- Simplify.Web bump to 4.6
- System.Text.Json to 6.0.6

## [1.0-pre02] - 2021-11-24

### Dependencies

- Simplify.Web bump to 4.5

## [1.0-pre01] - 2021-07-24

### Added

- Controllers list generation (#2)
- Basic environment generation (#3)
- Model JSON extraction and generation (#4)
