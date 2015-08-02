﻿// [[[[INFO>
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
        private static float[] ReferenceWhite_XYZ_D50 = new float[] { 96.4212f, 100.0f, 82.5188f };
        private static float[] ReferenceWhite_XYZ_D55 = new float[] { 95.6797f, 100.0f, 92.1481f };
        private static float[] ReferenceWhite_XYZ_D65 = new float[] { 95.0429f, 100.0f, 108.8900f };
        private static float[] ReferenceWhite_XYZ_D75 = new float[] { 94.9722f, 100.0f, 122.6394f };

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

        #region CIE Lab <-> CIE LCh

        public static void LabToLCh(float l, float a, float b, out float lch_l, out float lch_c, out float lch_h)
        {
            lch_l = l;

            if(a != 0 || b != 0)
            {
                lch_c = (float)Math.Sqrt(a * a + b * b);
                
                var atan = Math.Atan2(b, a);
                lch_h = (float)BasicMath.RadToDeg(atan >= 0 ? atan : (atan + (Math.PI * 2)));
            }
            else
            {
                lch_c = 0;
                lch_h = 0;
            }
        }

        public static void LChToLab(float l, float c, float h, out float lab_l, out float lab_a, out float lab_b)
        {
            var h_rad = BasicMath.DegToRad(h);

            lab_l = l;
            lab_a = c * (float)Math.Cos(h_rad);
            lab_b = c * (float)Math.Sin(h_rad);
        }

        #endregion
    }
}
