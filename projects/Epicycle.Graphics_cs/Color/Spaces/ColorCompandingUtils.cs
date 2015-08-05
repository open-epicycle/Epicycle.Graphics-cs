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

    public static class ColorCompandingUtils
    {
        private const float Epsilon = 216.0f / 24389.0f;
        private const float KappaDiv100 = 24389.0f / 2700.0f;
        private const float KappaEpsilonDiv100 = 2.0f / 25.0f;

        #region Gamma Companding

        public static float ApplyGammaCompanding(float value, float gamma)
        {
            return (float)Math.Pow(value, 1.0 / gamma);
        }

        public static float ApplyInverseGammaCompanding(float value, float gamma)
        {
            return (float)Math.Pow(value, gamma);
        }

        #endregion

        #region sRGB Companding

        public static float ApplySRGBCompanding(float value)
        {
            return (value <= 0.0031308) ? 12.92f * value : (1.055f * (float)Math.Pow(value, 1 / 2.4) - 0.055f);
        }

        public static float ApplyInverseSRGBCompanding(float value)
        {
            return (value <= 0.04045f) ? value / 12.92f : (float)Math.Pow((value + 0.055f) / 1.055f, 2.4);
        }

        #endregion

        #region L* Companding

        public static float ApplyLStarCompanding(float value)
        {
            return (value <= Epsilon) ? KappaDiv100 * value : (1.16f * (float)Math.Pow(value, 1.0 / 3.0) - 0.16f);
        }

        public static float ApplyInverseLStarCompanding(float value)
        {
            return (value <= KappaEpsilonDiv100) ? value / KappaDiv100 : (float)Math.Pow((value + 0.16f) / 1.16f, 3.0);
        }

        #endregion
    }
}
