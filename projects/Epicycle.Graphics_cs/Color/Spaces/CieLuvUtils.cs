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
    using System;

    public static class CieLuvUtils
    {
        public static float[] DefaultReferenceWhite = ReferenceWhiteUtils.ReferenceWhite_XYZ_D65;

        #region CIE XYZ <-> CIE Luv

        private const float Epsilon = 216.0f / 24389.0f;
        private const float KappaDiv100 = 24389.0f / 2700.0f;
        private const float KappaEpsilonDiv100 = 2.0f / 25.0f;

        public static void CieXYZToLuv(float x, float y, float z, out float l, out float u, out float v, float[] referenceWhiteXyz = null)
        {
            referenceWhiteXyz = referenceWhiteXyz ?? DefaultReferenceWhite;

            var d = x + 15 * y + 3 * z;
            var dr = referenceWhiteXyz[0] + 15 * referenceWhiteXyz[1] + 3 * referenceWhiteXyz[2];

            var ut = (4 * x) / d;
            var vt = (9 * y) / d;

            var ur = (4 * referenceWhiteXyz[0]) / dr;
            var vr = (9 * referenceWhiteXyz[1]) / dr;

            var yr = y / referenceWhiteXyz[1];

            l = YToL(yr);
            u = 13 * l * (ut - ur);
            v = 13 * l * (vt - vr);
        }

        public static void LuvToCieXYZ(float l, float u, float v, out float x, out float y, out float z, float[] referenceWhiteXyz = null)
        {
            referenceWhiteXyz = referenceWhiteXyz ?? DefaultReferenceWhite;

            var dr = referenceWhiteXyz[0] + 15 * referenceWhiteXyz[1] + 3 * referenceWhiteXyz[2];
            var u0 = (4 * referenceWhiteXyz[0]) / dr;
            var v0 = (9 * referenceWhiteXyz[1]) / dr;

            y = LToY(l);

            var a = 1.0f / 3 * ((52 * l) / (u + 13 * l * u0) - 1);
            var b = -5 * y;
            var c = -1.0f / 3;
            var d = y * ((39 * l) / (v + 13 * l * v0) - 5);

            x = (d - b) / (a - c);
            z = x * a + b;
        }

        private static float YToL(float x)
        {
            return x > Epsilon ? 1.16f * (float)Math.Pow(x, 1.0 / 3.0) - 0.16f : (KappaDiv100 * x);
        }

        private static float LToY(float l)
        {
            if (l > KappaEpsilonDiv100)
            {
                var r = (l + 0.16f) / 1.16f;
                return r * r * r;
            }
            else
            {
                return l / KappaDiv100;
            }
        }

        #endregion
    }
}
