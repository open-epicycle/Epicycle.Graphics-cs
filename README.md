# Epicycle.Graphics-cs 0.1.6.0
Epicycle .NET graphics library. Includes: Platform-independent image library and color infrastructure.

***Note***: *This library is in it's 0.X version, that means that it's still in active development and backward compatibility is not guaranteed!*

## Links
* NuGet package: https://www.nuget.org/packages/Epicycle.Graphics-cs
* Git repository: https://github.com/open-epicycle/Epicycle.Graphics-cs
* All Epicycle Git repositories: https://github.com/open-epicycle

## Main features
* Robust Image library
* Platform-independent color infrastructure
* Conversion to and from **Windows.Drawing** primitives
* Read and write PLY files with custom properties
* Supported frameworks: **.NET 4.5**, **.NET 4.0**, **.NET 3.5**

## Namespaces
* **Epicycle.Graphics**:
  * Platform-independent color classes
* **Epicycle.Graphics.Color.Spaces**:
  * Conversion between various color spaces such as RGB, HSL/HSV/HSI, XYZ, Lab, LCh, etc.
* **Epicycle.Graphics.Images**:
  * Platform-independent image infrastructure
* **Epicycle.Graphics.Geometry.Ply**:
  * PLY file serializer and de-serializer. Supports custom properties
* **Epicycle.Graphics.Platform.SystemDrawing**: (separate assembly)
  * Utilities for converting **Windows.Drawing** primitives to and from **Epicycle.Graphics** and **Epicycle.Math.Geometry** primitives
* **Epicycle.Graphics.Platform.Android**: (separate assembly)
  * Xamarin library (currently not built and not ready for production)
  
## License
Apache License 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
Copyright 2015 Epicycle (http://epicycle.org)

## Release Notes
### Version 0.1 

* **Version 0.1.6** [2015-09-14]
  * Upgrading Epicycle.Commons-cs: 0.1.6.0 => 0.1.8.0
  * Upgrading Epicycle.Math-cs: 0.1.5.0 => 0.1.6.0
  * Colors:
    * Integer RGB/RGBA
      * Renaming Color3b and Color4b into ColorRGB and ColorRGBA
      * Generating 12 bit-per-channel and 16 bit-per-channel versions (ColorRGB12, ColorRGBA12, ColorRGB16, ColorRGBA16)
    * Conversion between various color spaces:
      * RGB (including different RGB models)
      * HSx: HSL, HSV/HSB, HSI
      * CIE XYZ, xyY, Lab, Luv, LCh
      * Subtractive RYB
  
* **Version 0.1.5** [2015-01-28]
  * Upgrading Epicycle.Math-cs: 0.1.4.0 => 0.1.5.0

* **Version 0.1.4** [2015-01-26]
  * Upgrading Epicycle.Math-cs: 0.1.3.0 => 0.1.4.0

* **Version 0.1.3** [2012-01-14]
  * Adding PLY file infrastructure (Epicycle.Graphics.Geometry.Ply)
  * Upgrading Epicycle.Math-cs: 0.1.2.0 => 0.1.3.0
  * Upgrading: Epicycle.Commons-cs: 0.1.5.0 => 0.1.6.0

* **Version 0.1.2** [2012-01-13]
  * Renaming namespace Epicycle.Graphics.Windows to Epicycle.Graphics.Platform.SystemDrawing
  * Importing System.Drawing related math utils from Epicycle.Math
  * Added some unit tests

* **Version 0.1.1** [2015-01-13]
  * Creating a new namespace for the image infrastructure: Epicycle.Graphics.Images
  * Bug fix in Epicycle.Graphics.Color4b.Equals
  * Added some unit tests

* **Version 0.1.0** [2015-01-12]
  * Initial release
