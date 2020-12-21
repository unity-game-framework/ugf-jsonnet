# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.2.1](https://github.com/unity-game-framework/ugf-jsonnet/releases/tag/1.2.1) - 2020-12-21  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-jsonnet/milestone/6?closed=1)  
    

### Fixed

- Fix ConvertPropertyNameWriter convert to string ([#22](https://github.com/unity-game-framework/ugf-jsonnet/pull/22))  
    - Fix `ConvertPropertyNameWriter.ToString()` method to return `TextWriter` result value.

## [1.2.0](https://github.com/unity-game-framework/ugf-jsonnet/releases/tag/1.2.0) - 2020-12-20  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-jsonnet/milestone/5?closed=1)  
    

### Added

- Add type information with custom names ([#19](https://github.com/unity-game-framework/ugf-jsonnet/pull/19))  
    - Add `ConvertTypeInfo` structure to define type conversion to name and assembly name.
    - Add `IConvertTypeProvider` and `ConvertTypeProvider` as default implementation to manage known type infos.
    - Add `ConvertTypeNameBinder` used with `JsonSerializerSettings` to override type information binding.
- Add option to convert property names when read and write ([#18](https://github.com/unity-game-framework/ugf-jsonnet/pull/18))  
    - Add `ConvertPropertyNameReader` and `ConvertPropertyNameWriter` used to convert target property names with specified names.

## [1.1.0](https://github.com/unity-game-framework/ugf-jsonnet/releases/tag/1.1.0) - 2020-10-13  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-jsonnet/milestone/4?closed=1)  
    

### Added

- Add FromJson with target type as parameter ([#14](https://github.com/unity-game-framework/ugf-jsonnet/pull/14))  

### Changed

- Update project to Unity 2020.2 ([#13](https://github.com/unity-game-framework/ugf-jsonnet/pull/13))

## [1.0.0](https://github.com/unity-game-framework/ugf-jsonnet/releases/tag/1.0.0) - 2020-10-05  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-jsonnet/milestone/3?closed=1)  
    

### Changed

- Update Unity JsonNet to 2.0.0  ([#9](https://github.com/unity-game-framework/ugf-jsonnet/pull/9))  
    - Update `com.unity.nuget.newtonsoft-json` dependency to `2.0.0`.
- Update to Unity 2020.1 ([#6](https://github.com/unity-game-framework/ugf-jsonnet/issues/6))

## [0.2.0-preview](https://github.com/unity-game-framework/ugf-jsonnet/releases/tag/0.2.0-preview) - 2020-01-11  

- [Commits](https://github.com/unity-game-framework/ugf-jsonnet/compare/0.1.0-preview...0.2.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-jsonnet/milestone/2?closed=1)

### Added
- `JsonNetUtility.ToJson` parameter to convert Json to readable format.

## [0.1.0-preview](https://github.com/unity-game-framework/ugf-jsonnet/releases/tag/0.1.0-preview) - 2019-12-24  

- [Commits](https://github.com/unity-game-framework/ugf-jsonnet/compare/5357b7d...0.1.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-jsonnet/milestone/1?closed=1)

### Added
- This is a initial release.


