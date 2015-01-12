@echo off

rmdir NuGetPackage /s /q
mkdir NuGetPackage
mkdir NuGetPackage\Epicycle.Graphics-cs.0.1.0.0
mkdir NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib

copy package.nuspec NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\Epicycle.Graphics-cs.0.1.0.0.nuspec
copy README.md NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\README.md
copy LICENSE NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\LICENSE

xcopy bin\net35\Release\Epicycle.Graphics.Windows_cs.dll NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net35\
xcopy bin\net35\Release\Epicycle.Graphics.Windows_cs.pdb NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net35\
xcopy bin\net35\Release\Epicycle.Graphics.Windows_cs.xml NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net35\
xcopy bin\net35\Release\Epicycle.Graphics_cs.dll NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net35\
xcopy bin\net35\Release\Epicycle.Graphics_cs.pdb NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net35\
xcopy bin\net35\Release\Epicycle.Graphics_cs.xml NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net35\
xcopy bin\net40\Release\Epicycle.Graphics.Windows_cs.dll NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net40\
xcopy bin\net40\Release\Epicycle.Graphics.Windows_cs.pdb NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net40\
xcopy bin\net40\Release\Epicycle.Graphics.Windows_cs.xml NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net40\
xcopy bin\net40\Release\Epicycle.Graphics_cs.dll NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net40\
xcopy bin\net40\Release\Epicycle.Graphics_cs.pdb NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net40\
xcopy bin\net40\Release\Epicycle.Graphics_cs.xml NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net40\
xcopy bin\net45\Release\Epicycle.Graphics.Windows_cs.dll NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net45\
xcopy bin\net45\Release\Epicycle.Graphics.Windows_cs.pdb NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net45\
xcopy bin\net45\Release\Epicycle.Graphics.Windows_cs.xml NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net45\
xcopy bin\net45\Release\Epicycle.Graphics_cs.dll NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net45\
xcopy bin\net45\Release\Epicycle.Graphics_cs.pdb NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net45\
xcopy bin\net45\Release\Epicycle.Graphics_cs.xml NuGetPackage\Epicycle.Graphics-cs.0.1.0.0\lib\net45\

pause