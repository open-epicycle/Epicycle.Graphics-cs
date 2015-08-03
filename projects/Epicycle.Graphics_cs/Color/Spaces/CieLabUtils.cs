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

using Epicycle.Commons;

namespace Epicycle.Graphics.Color.Spaces
{
    using System;

    public static class CieLabUtils
    {
        private static float[] ReferenceWhite_XYZ_D50 = new float[] { 0.964212f, 1.0f, 0.825188f };
        private static float[] ReferenceWhite_XYZ_D55 = new float[] { 0.956797f, 1.0f, 0.921481f };
        private static float[] ReferenceWhite_XYZ_D65 = new float[] { 0.950429f, 1.0f, 1.088900f };
        private static float[] ReferenceWhite_XYZ_D75 = new float[] { 0.949722f, 1.0f, 1.226394f };

        private static float[] ReferenceWhite_XYZ_Default = ReferenceWhite_XYZ_D65;

        #region CIE XYZ <-> CIE Lab

        private const float Epsilon = 216.0f / 24389.0f;
        private const float Kappa = 24389.0f / 27.0f;

        public static void CieXYZToLab(float x, float y, float z, out float l, out float a, out float b, float[] referenceWhite = null)
        {
            referenceWhite = referenceWhite ?? ReferenceWhite_XYZ_Default;

            var xr = x / referenceWhite[0];
            var yr = y / referenceWhite[1];
            var zr = z / referenceWhite[2];

            var fx = RelativeLuminanceToLightness(xr);
            var fy = RelativeLuminanceToLightness(yr);
            var fz = RelativeLuminanceToLightness(zr);

            l = 116 * fy - 16;
            a = 500 * (fx - fy);
            b = 200 * (fy - fz);
        }

        public static void LabToCieXYZ(float l, float a, float b, out float x, out float y, out float z, float[] referenceWhite = null)
        {
            referenceWhite = referenceWhite ?? ReferenceWhite_XYZ_Default;

            var fy = (l + 16) / 116;
            var fx = (a / 500) + fy;
            var fz = fy - (b / 200);

            var xr = LightnessToRelativeLuminance(fx);
            var yr = LightnessToRelativeLuminance(fy);
            var zr = LightnessToRelativeLuminance(fz);

            x = xr * referenceWhite[0];
            y = yr * referenceWhite[1];
            z = zr * referenceWhite[2];
        }

        private static float RelativeLuminanceToLightness(float x)
        {
            return x > Epsilon ? (float) Math.Pow(x, 1.0 / 3.0) : (Kappa * x + 16.0f) / 116.0f;
        }

        private static float LightnessToRelativeLuminance(float x)
        {
            var x3 = x * x * x;

            return x3 > Epsilon ? x3 : (116.0f * x - 16.0f) / Kappa;
        }

        #endregion

        #region CIE Lab <-> CIE LCh(ab)

        public static void LabToLCh(float l, float a, float b, out float lch_l, out float lch_c, out float lch_h)
        {
            float h_rad;
            MathUtils.CartesianToPolarCoordinatesPositive(a, b, out lch_c, out h_rad);
            
            lch_l = l;
            lch_h = (float)BasicMath.RadToDeg(MathUtils.Atan2Positive(b, a));
        }

        public static void LChToLab(float l, float c, float h, out float lab_l, out float lab_a, out float lab_b)
        {
            lab_l = l;
            MathUtils.PolarToCartesianCoordinates(c, (float) BasicMath.DegToRad(h), out lab_a, out lab_b);
        }

        #endregion
    }
}
