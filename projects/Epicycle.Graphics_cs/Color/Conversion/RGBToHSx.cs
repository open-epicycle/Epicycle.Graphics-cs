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

namespace Epicycle.Graphics.Color.Conversion
{
    using System;

    public static class RGBToHSx
    {
        #region RGB <-> HSL

        public static void RGBToHSL(float red, float green, float blue, out float hue, out float saturation, out float lightness)
        {
            var cr = ClipUnit(red);
            var cg = ClipUnit(green);
            var cb = ClipUnit(blue);

            float min;
            float max;
            float chroma;
            RGBMaxComponents maxComponent;
            GetMinMaxChroma(cr, cg, cb, out min, out max, out chroma, out maxComponent);

            lightness = (min + max) / 2.0f;

            if (maxComponent != RGBMaxComponents.Achromatic)
            {
                saturation = chroma / (1 - Math.Abs(min + max - 1));
                hue = CalculateHue(cr, cg, cb, chroma, maxComponent);
            }
            else
            {
                saturation = 0;
                hue = 0;
            }
        }

        #endregion

        #region RGB <-> HSV

        public static void RGBToHSV(float red, float green, float blue, out float hue, out float saturation, out float value)
        {
            var cr = ClipUnit(red);
            var cg = ClipUnit(green);
            var cb = ClipUnit(blue);

            float min;
            float max;
            float chroma;
            RGBMaxComponents maxComponent;
            GetMinMaxChroma(cr, cg, cb, out min, out max, out chroma, out maxComponent);

            value = max;

            if (maxComponent != RGBMaxComponents.Achromatic)
            {
                saturation = chroma / value;
                hue = CalculateHue(cr, cg, cb, chroma, maxComponent);
            }
            else
            {
                saturation = 0;
                hue = 0;
            }
        }

        #endregion

        #region RGB <-> HSI

        public static void RGBToHSI(float red, float green, float blue, out float hue, out float saturation, out float intensity)
        {
            var cr = ClipUnit(red);
            var cg = ClipUnit(green);
            var cb = ClipUnit(blue);

            var min = Min(cr, cg, cb);
            var max = Max(cr, cg, cb);

            if(min != max)
            {
                var nr = cr / max;
                var ng = cg / max;
                var nb = cb / max;

                var pi2 = 2 * (float)Math.PI;
                var hueNormAcos = (float)Math.Acos(
                    (0.5f * (2 * nr - ng - nb)) /
                    Math.Sqrt((nr - ng) * (nr - ng) + (nr - nb) * (ng - nb)))
                    / pi2;
                hue = (nb <= ng) ? hueNormAcos : 1 - hueNormAcos;

                intensity = (cr + cg + cb) / 3;
                saturation = 1 - min / intensity;
            }
            else
            {
                hue = 0;
                saturation = 0;
                intensity = min;
            }
        }

        #endregion

        #region Helper functions

        private enum RGBMaxComponents
        {
            Achromatic,
            Red,
            Green,
            Blue
        }

        private static void GetMinMaxChroma(
            float red, float green, float blue, 
            out float min, out float max, out float chroma, out RGBMaxComponents maxComponent)
        {
            min = Min(red, green, blue);
            max = Max(red, green, blue);
            chroma = max - min;

            if(chroma == 0)
            {
                maxComponent = RGBMaxComponents.Achromatic;
            }
            else if (max == red)
            {
                maxComponent = RGBMaxComponents.Red;
            }
            else if (max == green)
            {
                maxComponent = RGBMaxComponents.Green;
            }
            else
            {
                maxComponent = RGBMaxComponents.Blue;
            }
        }

        private static float CalculateHue(float red, float green, float blue, float chroma, RGBMaxComponents maxComponent)
        {
            var chroma6 = chroma * 6.0f;

            switch (maxComponent)
            {
                case RGBMaxComponents.Red:
                    return (green - blue) / chroma6 + (green < blue ? 1 : 0);
                case RGBMaxComponents.Green:
                    return (blue - red) / chroma6 + (1.0f / 3.0f);
                case RGBMaxComponents.Blue:
                    return (red - green) / chroma6 + (2.0f / 3.0f);
                default:
                    throw new InternalException("Invalid color component");
            }
        }

        // TODO: Use BasicMath when ready for float
        private static float ClipUnit(float x)
        {
            return BasicMath.Clip(x, 0, 1);
        }

        private static float Min(float a, float b, float c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
        
        private static float Max(float a, float b, float c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        #endregion
    }
}
