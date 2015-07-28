// [[[[INFO>
// Copyright 2015 Epicycle (http://epicycle.org, https://github.com/open-epicycle)
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 
// For more information check https://github.com/open-epicycle/Epicycle.Graphics-cs
// ]]]]

namespace Epicycle.Graphics.Color.Spaces
{
    public static class CieXYZUtils
    {
        #region CieRGB <-> XYZ
        
        private static float[,] RGBToXYZMatrix = new float[,]
            {{ 0.49f / 0.17697f,    0.31f    / 0.17697f, 0.20f    / 0.17697f },
             { 1,                   0.81240f / 0.17697f, 0.01063f / 0.17697f },
             { 0f,                  0.01f    / 0.17697f, 0.99f    / 0.17697f }};

        private static float[,] XYZToRGBMatrix = new float[,]
            {{  0.41847f,    -0.15866f,   -0.082835f },
             { -0.091169f,    0.25243f,    0.015708f },
             {  0.00092090f, -0.0025498f,  0.17860f  }};

        public static void CieRGBToXYZ(float r, float g, float b, out float x, out float y, out float z)
        {
            MathUtils.TransformVector3(RGBToXYZMatrix, r, g, b, out x, out y, out z);
        }

        public static void XYZToCieRGB(float x, float y, float z, out float r, out float g, out float b)
        {
            MathUtils.TransformVector3(XYZToRGBMatrix, x, y, z, out r, out g, out b);
        }

        #endregion
    }
}
