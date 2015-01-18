@echo off

cd projects
msbuild Epicycle.Graphics.net35.sln /t:Clean,Build /p:Configuration=Debug
msbuild Epicycle.Graphics.net35.sln /t:Clean,Build /p:Configuration=Release
msbuild Epicycle.Graphics.net40.sln /t:Clean,Build /p:Configuration=Debug
msbuild Epicycle.Graphics.net40.sln /t:Clean,Build /p:Configuration=Release
msbuild Epicycle.Graphics.net45.sln /t:Clean,Build /p:Configuration=Debug
msbuild Epicycle.Graphics.net45.sln /t:Clean,Build /p:Configuration=Release

pause
