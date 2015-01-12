# Epicycle.Graphics-cs 0.1.1.0
Epicycle .NET graphics library. Includes: Platform-independent image library and color infrastructure.

***Note***: *This library is in it's 0.X version, that means that it's still in active development and backward compatibility is not guaranteed!*

## Links
* NuGet package: https://www.nuget.org/packages/Epicycle.Graphics-cs
* Git repository: https://github.com/open-epicycle/Epicycle.Graphics-cs
* All Epicycle Git repositories: https://github.com/open-epicycle

## Main features
* Robust Image library
* Platform-independent color infrastructure.
* Conversion to and from **Windows.Drawing** primitives
* Supported frameworks: **.NET 4.5**, **.NET 4.0**, **.NET 3.5**

## Namespaces
* **Epicycle.Graphics**:
  * Platform-independent color classes
* **Epicycle.Graphics.Images**:
  * Platform-independent image infrastructure
* **Epicycle.Math.Windows**: (separate assembly)
  * Utilities for converting **Windows.Drawing** primitives to and from **Epicycle.Graphics** primitives

## License
Apache License 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
Copyright 2015 Epicycle (http://epicycle.org)

## Release Notes
### Version 0.1 

* **Version 0.1.1** [2015-01-13]
  * Creating a new namespace for the image infrastructure: Epicycle.Graphics.Images
  * Bug fix in Epicycle.Graphics.Color4b.Equals
  * Added some unit tests

* **Version 0.1.0** [2015-01-12]
  * Initial release
