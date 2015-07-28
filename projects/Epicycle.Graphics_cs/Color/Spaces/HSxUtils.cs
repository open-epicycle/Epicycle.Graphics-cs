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
        #region Color3 <-> HSL

        public static void Color3ToHSL(float c1, float c2, float c3, out float hue, out float saturation, out float lightness)
        {
            var cc1 = MathUtils.ClipUnit(c1);
            var cc2 = MathUtils.ClipUnit(c2);
            var cc3 = MathUtils.ClipUnit(c3);

            float min;
            float max;
            float chroma;
            Color3MaxComponents maxComponent;
            GetMinMaxChroma(cc1, cc2, cc3, out min, out max, out chroma, out maxComponent);

            lightness = (min + max) / 2.0f;

            if (maxComponent != Color3MaxComponents.Achromatic)
            {
                saturation = chroma / (1 - Math.Abs(min + max - 1));
                hue = CalculateHue(cc1, cc2, cc3, chroma, maxComponent);
            }
            else
            {
                saturation = 0;
                hue = 0;
            }
        }

        public static void HSLToColor3(float hue, float saturation, float lightness, out float c1, out float c2, out float c3)
        {
            var nh = MathUtils.WrapUnit(hue);
            var cs = MathUtils.ClipUnit(saturation);
            var cl = MathUtils.ClipUnit(lightness);

            var max = (cl <= 0.5f) ? (cl * (1 + cs)) : (cl + cs - cl * cs);
            if (max > 0 && cs > 0)
            {
                var min = 2 * cl - max;
                HueMinMaxToColor3(nh, min, max, out c1, out c2, out c3);
            }
            else
            {
                c1 = cl;
                c2 = cl;
                c3 = cl;
            }
        }

        #endregion

        #region Color3 <-> HSV

        public static void Color3ToHSV(float c1, float c2, float c3, out float hue, out float saturation, out float value)
        {
            var cc1 = MathUtils.ClipUnit(c1);
            var cc2 = MathUtils.ClipUnit(c2);
            var cc3 = MathUtils.ClipUnit(c3);

            float min;
            float max;
            float chroma;
            Color3MaxComponents maxComponent;
            GetMinMaxChroma(cc1, cc2, cc3, out min, out max, out chroma, out maxComponent);

            value = max;

            if (maxComponent != Color3MaxComponents.Achromatic)
            {
                saturation = chroma / value;
                hue = CalculateHue(cc1, cc2, cc3, chroma, maxComponent);
            }
            else
            {
                saturation = 0;
                hue = 0;
            }
        }

        public static void HSVToColor3(float hue, float saturation, float value, out float c1, out float c2, out float c3)
        {
            var nh = MathUtils.WrapUnit(hue);
            var cs = MathUtils.ClipUnit(saturation);
            var cv = MathUtils.ClipUnit(value);

            if (cv > 0 && cs > 0)
            {
                var min = cv * (1 - cs);
                HueMinMaxToColor3(nh, min, cv, out c1, out c2, out c3);
            }
            else
            {
                c1 = cv;
                c2 = cv;
                c3 = cv;
            }
        }

        #endregion

        #region Color3 <-> HSI

        public static void Color3ToHSI(float c1, float c2, float c3, out float hue, out float saturation, out float intensity)
        {
            var cc1 = MathUtils.ClipUnit(c1);
            var cc2 = MathUtils.ClipUnit(c2);
            var cc3 = MathUtils.ClipUnit(c3);

            var min = MathUtils.Min(cc1, cc2, cc3);
            var max = MathUtils.Max(cc1, cc2, cc3);

            if(min != max)
            {
                var nr = cc1 / max;
                var ng = cc2 / max;
                var nb = cc3 / max;

                var hueNormAcos = MathUtils.SafeAcos(
                    (0.5f * (2 * nr - ng - nb)) /
                    (float) Math.Sqrt((nr - ng) * (nr - ng) + (nr - nb) * (ng - nb)))
                    / PI2;
                
                hue = (nb <= ng) ? hueNormAcos : 1 - hueNormAcos;

                intensity = (cc1 + cc2 + cc3) / 3;
                saturation = 1 - min / intensity;
            }
            else
            {
                hue = 0;
                saturation = 0;
                intensity = min;
            }
        }

        public static void HSIToColor3(float hue, float saturation, float intensity, out float c1, out float c2, out float c3)
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
                c1 = ci * (1 + cs * r);
                c2 = ci * (1 + cs * (1 - r));
                c3 = ci * (1 - cs);
            }
            else if (nh < TwoThirds)
            {
                var rad = PI2 * (nh - Third);
                var r = (float)(Math.Cos(rad) / Math.Cos(PIdiv3 - rad));
                c2 = ci * (1 + cs * r);
                c3 = ci * (1 + cs * (1 - r));
                c1 = ci * (1 - cs);
            }
            else
            {
                var rad = PI2 * (nh - TwoThirds);
                var r = (float)(Math.Cos(rad) / Math.Cos(PIdiv3 - rad));
                c3 = ci * (1 + cs * r);
                c1 = ci * (1 + cs * (1 - r));
                c2 = ci * (1 - cs);
            }
        }

        #endregion

        #region Helper functions

        private const float PI2 = 2 * (float)Math.PI;

        private enum Color3MaxComponents
        {
            Achromatic,
            c1,
            c2,
            c3
        }

        private static void GetMinMaxChroma(
            float c1, float c2, float c3, 
            out float min, out float max, out float chroma, out Color3MaxComponents maxComponent)
        {
            min = MathUtils.Min(c1, c2, c3);
            max = MathUtils.Max(c1, c2, c3);
            chroma = max - min;

            if(chroma == 0)
            {
                maxComponent = Color3MaxComponents.Achromatic;
            }
            else if (max == c1)
            {
                maxComponent = Color3MaxComponents.c1;
            }
            else if (max == c2)
            {
                maxComponent = Color3MaxComponents.c2;
            }
            else
            {
                maxComponent = Color3MaxComponents.c3;
            }
        }

        private static float CalculateHue(float c1, float c2, float c3, float chroma, Color3MaxComponents maxComponent)
        {
            var chroma6 = chroma * 6.0f;

            switch (maxComponent)
            {
                case Color3MaxComponents.c1:
                    return (c2 - c3) / chroma6 + (c2 < c3 ? 1 : 0);
                case Color3MaxComponents.c2:
                    return (c3 - c1) / chroma6 + (1.0f / 3.0f);
                case Color3MaxComponents.c3:
                    return (c1 - c2) / chroma6 + (2.0f / 3.0f);
                default:
                    throw new InternalException("Invalid color component");
            }
        }

        private static void HueMinMaxToColor3(float hue, float min, float max, out float c1, out float c2, out float c3)
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
                    c1 = max;
                    c2 = mid1;
                    c3 = min;
                    break;
                case 1:
                    c1 = mid2;
                    c2 = max;
                    c3 = min;
                    break;
                case 2:
                    c1 = min;
                    c2 = max;
                    c3 = mid1;
                    break;
                case 3:
                    c1 = min;
                    c2 = mid2;
                    c3 = max;
                    break;
                case 4:
                    c1 = mid1;
                    c2 = min;
                    c3 = max;
                    break;
                case 5:
                    c1 = max;
                    c2 = min;
                    c3 = mid2;
                    break;
                default:
                    throw new InternalException("This can never happen!");
            }
        }

        #endregion
    }
}
