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

    public static class HSxUtils
    {
        #region RGB <-> HSL

        public static void RGBToHSL(float red, float green, float blue, out float hue, out float saturation, out float lightness)
        {
            var cr = MathUtils.ClipUnit(red);
            var cg = MathUtils.ClipUnit(green);
            var cb = MathUtils.ClipUnit(blue);

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

        public static void HSLToRGB(float hue, float saturation, float lightness, out float red, out float green, out float blue)
        {
            var nh = MathUtils.WrapUnit(hue);
            var cs = MathUtils.ClipUnit(saturation);
            var cl = MathUtils.ClipUnit(lightness);

            var max = (cl <= 0.5f) ? (cl * (1 + cs)) : (cl + cs - cl * cs);
            if (max > 0 && cs > 0)
            {
                var min = 2 * cl - max;
                HueMinMaxToRGB(nh, min, max, out red, out green, out blue);
            }
            else
            {
                red = cl;
                green = cl;
                blue = cl;
            }
        }

        #endregion

        #region RGB <-> HSV

        public static void RGBToHSV(float red, float green, float blue, out float hue, out float saturation, out float value)
        {
            var cr = MathUtils.ClipUnit(red);
            var cg = MathUtils.ClipUnit(green);
            var cb = MathUtils.ClipUnit(blue);

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

        public static void HSVToRGB(float hue, float saturation, float value, out float red, out float green, out float blue)
        {
            var nh = MathUtils.WrapUnit(hue);
            var cs = MathUtils.ClipUnit(saturation);
            var cv = MathUtils.ClipUnit(value);

            if (cv > 0 && cs > 0)
            {
                var min = cv * (1 - cs);
                HueMinMaxToRGB(nh, min, cv, out red, out green, out blue);
            }
            else
            {
                red = cv;
                green = cv;
                blue = cv;
            }
        }

        #endregion

        #region RGB <-> HSI

        public static void RGBToHSI(float red, float green, float blue, out float hue, out float saturation, out float intensity)
        {
            var cr = MathUtils.ClipUnit(red);
            var cg = MathUtils.ClipUnit(green);
            var cb = MathUtils.ClipUnit(blue);

            var min = MathUtils.Min(cr, cg, cb);
            var max = MathUtils.Max(cr, cg, cb);

            if(min != max)
            {
                var nr = cr / max;
                var ng = cg / max;
                var nb = cb / max;

                var hueNormAcos = MathUtils.SafeAcos(
                    (0.5f * (2 * nr - ng - nb)) /
                    (float) Math.Sqrt((nr - ng) * (nr - ng) + (nr - nb) * (ng - nb)))
                    / PI2;
                
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

        public static void HSIToRGB(float hue, float saturation, float intensity, out float red, out float green, out float blue)
        {
            var nh = MathUtils.WrapUnit(hue);
            var cs = MathUtils.ClipUnit(saturation);
            var ci = MathUtils.ClipUnit(intensity);

            // Based on a post by Brian Neltner: http://blog.saikoled.com/post/43693602826/why-every-led-light-should-be-using-hsi

            const float Third = 1.0f / 3.0f;
            const float TwoThirds = 2.0f / 3.0f;
            const float PIdiv3 = Third * (float) Math.PI;

            if (nh < Third)
            {
                var rad = PI2 * nh;
                var r = (float)(Math.Cos(rad) / Math.Cos(PIdiv3 - rad));
                red = ci * (1 + cs * r);
                green = ci * (1 + cs * (1 - r));
                blue = ci * (1 - cs);
            }
            else if (nh < TwoThirds)
            {
                var rad = PI2 * (nh - Third);
                var r = (float)(Math.Cos(rad) / Math.Cos(PIdiv3 - rad));
                green = ci * (1 + cs * r);
                blue = ci * (1 + cs * (1 - r));
                red = ci * (1 - cs);
            }
            else
            {
                var rad = PI2 * (nh - TwoThirds);
                var r = (float)(Math.Cos(rad) / Math.Cos(PIdiv3 - rad));
                blue = ci * (1 + cs * r);
                red = ci * (1 + cs * (1 - r));
                green = ci * (1 - cs);
            }
        }

        #endregion

        #region Helper functions

        private const float PI2 = 2 * (float)Math.PI;

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
            min = MathUtils.Min(red, green, blue);
            max = MathUtils.Max(red, green, blue);
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

        private static void HueMinMaxToRGB(float hue, float min, float max, out float red, out float green, out float blue)
        {
            var hue6 = hue * 6.0f;
            var sextant = (int)Math.Floor(hue6);

            var f = hue6 - sextant;
            var x = f * (max - min);
            var mid1 = min + x;
            var mid2 = max - x;

            switch (sextant % 6)
            {
                case 0:
                    red = max;
                    green = mid1;
                    blue = min;
                    break;
                case 1:
                    red = mid2;
                    green = max;
                    blue = min;
                    break;
                case 2:
                    red = min;
                    green = max;
                    blue = mid1;
                    break;
                case 3:
                    red = min;
                    green = mid2;
                    blue = max;
                    break;
                case 4:
                    red = mid1;
                    green = min;
                    blue = max;
                    break;
                case 5:
                    red = max;
                    green = min;
                    blue = mid2;
                    break;
                default:
                    throw new InternalException("This can never happen!");
            }
        }

        #endregion
    }
}
