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

using NUnit.Framework;

namespace Epicycle.Graphics.Color.Conversion
{
    [TestFixture]
    public class RGBToHSxTest
    {
        private const float Epsilon = 1e-2f;
        private const float RGBStep = 1.0f / 96;

        #region RGB <-> HSL

        [Test]
        public void RGBToHSL_converts_properly()
        {
            TestRGBToHSL(0.00f, 0.00f, 0.00f, 0.000f, 0.000f, 0.000f);
            TestRGBToHSL(1.00f, 1.00f, 1.00f, 0.000f, 0.000f, 1.000f);
            TestRGBToHSL(0.25f, 0.25f, 0.25f, 0.000f, 0.000f, 0.250f);
            TestRGBToHSL(1.00f, 0.00f, 0.00f, 0.000f, 1.000f, 0.500f);
            TestRGBToHSL(0.00f, 1.00f, 0.00f, 0.333f, 1.000f, 0.500f);
            TestRGBToHSL(0.00f, 0.00f, 1.00f, 0.667f, 1.000f, 0.500f);
            TestRGBToHSL(0.75f, 0.25f, 0.50f, 0.917f, 0.500f, 0.500f);
            TestRGBToHSL(0.75f, 0.50f, 0.25f, 0.083f, 0.500f, 0.500f);
            TestRGBToHSL(0.25f, 0.75f, 0.50f, 0.417f, 0.500f, 0.500f);
            TestRGBToHSL(0.50f, 0.75f, 0.25f, 0.250f, 0.500f, 0.500f);
            TestRGBToHSL(0.25f, 0.50f, 0.75f, 0.583f, 0.500f, 0.500f);
            TestRGBToHSL(0.50f, 0.25f, 0.75f, 0.750f, 0.500f, 0.500f);
            TestRGBToHSL(0.36f, 0.51f, 0.70f, 0.592f, 0.361f, 0.533f);
        }

        [Test]
        public void RGBToHSL_input_is_clipped()
        {
            TestRGBToHSL(10.00f, -10.00f, 0.00f, 0.000f, 1.000f, 0.500f);
            TestRGBToHSL(0.00f, 10.00f, -10.00f, 0.333f, 1.000f, 0.500f);
            TestRGBToHSL(-10.00f, 0.00f, 10.00f, 0.667f, 1.000f, 0.500f);
        }

        [Test]
        public void HSLToRGB_converts_properly()
        {
            TestHSLToRGB(0.000f, 0.000f, 0.000f, 0.00f, 0.00f, 0.00f);
            TestHSLToRGB(0.000f, 0.000f, 1.000f, 1.00f, 1.00f, 1.00f);
            TestHSLToRGB(0.000f, 0.000f, 0.250f, 0.25f, 0.25f, 0.25f);
            TestHSLToRGB(0.000f, 1.000f, 0.500f, 1.00f, 0.00f, 0.00f);
            TestHSLToRGB(0.333f, 1.000f, 0.500f, 0.00f, 1.00f, 0.00f);
            TestHSLToRGB(0.667f, 1.000f, 0.500f, 0.00f, 0.00f, 1.00f);
            TestHSLToRGB(0.917f, 0.500f, 0.500f, 0.75f, 0.25f, 0.50f);
            TestHSLToRGB(0.083f, 0.500f, 0.500f, 0.75f, 0.50f, 0.25f);
            TestHSLToRGB(0.417f, 0.500f, 0.500f, 0.25f, 0.75f, 0.50f);
            TestHSLToRGB(0.250f, 0.500f, 0.500f, 0.50f, 0.75f, 0.25f);
            TestHSLToRGB(0.583f, 0.500f, 0.500f, 0.25f, 0.50f, 0.75f);
            TestHSLToRGB(0.750f, 0.500f, 0.500f, 0.50f, 0.25f, 0.75f);
            TestHSLToRGB(0.592f, 0.361f, 0.533f, 0.36f, 0.51f, 0.70f);
        }

        [Test]
        public void HSLToRGB_hue_wraps_around()
        {
            for(float x = -10; x <= 10; x += 1)
            {
                TestHSLToRGB(x + 0.592f, 0.361f, 0.533f, 0.36f, 0.51f, 0.70f);
            }
        }

        [Test]
        public void HSLToRGB_saturation_is_clipped()
        {
            TestHSLToRGB(0.000f, -10.000f, 0.250f, 0.25f, 0.25f, 0.25f);
            TestHSLToRGB(0.000f, 10.000f, 0.500f, 1.00f, 0.00f, 0.00f);
        }

        [Test]
        public void HSLToRGB_lightness_is_clipped()
        {
            TestHSLToRGB(0.000f, 0.000f, -10.000f, 0.00f, 0.00f, 0.00f);
            TestHSLToRGB(0.000f, 0.000f, 10.000f, 1.00f, 1.00f, 1.00f);
        }

        [Test]
        public void HSLToRGB_is_inverse_of_RGBToHSL()
        {
            for (float r = 0; r <= 1; r += RGBStep)
            {
                for (float g = 0; g <= 1; g += RGBStep)
                {
                    for (float b = 0; b <= 1; b += RGBStep)
                    {
                        float hue, saturation, lightness;
                        RGBToHSx.RGBToHSL(r, g, b, out hue, out saturation, out lightness);

                        TestHSLToRGB(hue, saturation, lightness, r, g, b);
                    }
                }
            }
        }

        private static void TestRGBToHSL(
            float red, float green, float blue, 
            float expectedHue, float expectedSaturation, float expectedLightness)
        {
            float hue;
            float saturation;
            float lightness;

            RGBToHSx.RGBToHSL(red, green, blue, out hue, out saturation, out lightness);

            Assert.That(hue, Is.EqualTo(expectedHue).Within(Epsilon));
            Assert.That(saturation, Is.EqualTo(expectedSaturation).Within(Epsilon));
            Assert.That(lightness, Is.EqualTo(expectedLightness).Within(Epsilon));
        }

        private static void TestHSLToRGB(
            float hue, float saturation, float lightness,
            float expectedRed, float expectedGreen, float expectedBlue)
        {
            float red;
            float green;
            float blue;

            RGBToHSx.HSLToRGB(hue, saturation, lightness, out red, out green, out blue);

            Assert.That(red, Is.EqualTo(expectedRed).Within(Epsilon));
            Assert.That(green, Is.EqualTo(expectedGreen).Within(Epsilon));
            Assert.That(blue, Is.EqualTo(expectedBlue).Within(Epsilon));
        }

        #endregion

        #region RGB <-> HSV

        [Test]
        public void RGBToHSV_converts_properly()
        {
            TestRGBToHSV(0.00f, 0.00f, 0.00f, 0.000f, 0.000f, 0.000f);
            TestRGBToHSV(1.00f, 1.00f, 1.00f, 0.000f, 0.000f, 1.000f);
            TestRGBToHSV(0.25f, 0.25f, 0.25f, 0.000f, 0.000f, 0.250f);
            TestRGBToHSV(1.00f, 0.00f, 0.00f, 0.000f, 1.000f, 1.000f);
            TestRGBToHSV(0.00f, 1.00f, 0.00f, 0.333f, 1.000f, 1.000f);
            TestRGBToHSV(0.00f, 0.00f, 1.00f, 0.667f, 1.000f, 1.000f);
            TestRGBToHSV(0.75f, 0.25f, 0.50f, 0.917f, 0.670f, 0.750f);
            TestRGBToHSV(0.75f, 0.50f, 0.25f, 0.083f, 0.670f, 0.750f);
            TestRGBToHSV(0.25f, 0.75f, 0.50f, 0.417f, 0.670f, 0.750f);
            TestRGBToHSV(0.50f, 0.75f, 0.25f, 0.250f, 0.670f, 0.750f);
            TestRGBToHSV(0.25f, 0.50f, 0.75f, 0.583f, 0.670f, 0.750f);
            TestRGBToHSV(0.50f, 0.25f, 0.75f, 0.750f, 0.670f, 0.750f);
            TestRGBToHSV(0.36f, 0.51f, 0.70f, 0.592f, 0.480f, 0.702f);
        }

        [Test]
        public void RGBToHSV_input_is_clipped()
        {
            TestRGBToHSV(10.00f, -10.00f, 0.00f, 0.000f, 1.000f, 1.000f);
            TestRGBToHSV(0.00f, 10.00f, -10.00f, 0.333f, 1.000f, 1.000f);
            TestRGBToHSV(-10.00f, 0.00f, 10.00f, 0.667f, 1.000f, 1.000f);
        }
        
        [Test]
        public void HSVToRGB_converts_properly()
        {
            TestHSVToRGB(0.000f, 0.000f, 0.000f, 0.00f, 0.00f, 0.00f);
            TestHSVToRGB(0.000f, 0.000f, 1.000f, 1.00f, 1.00f, 1.00f);
            TestHSVToRGB(0.000f, 0.000f, 0.250f, 0.25f, 0.25f, 0.25f);
            TestHSVToRGB(0.000f, 1.000f, 1.000f, 1.00f, 0.00f, 0.00f);
            TestHSVToRGB(0.333f, 1.000f, 1.000f, 0.00f, 1.00f, 0.00f);
            TestHSVToRGB(0.667f, 1.000f, 1.000f, 0.00f, 0.00f, 1.00f);
            TestHSVToRGB(0.917f, 0.670f, 0.750f, 0.75f, 0.25f, 0.50f);
            TestHSVToRGB(0.083f, 0.670f, 0.750f, 0.75f, 0.50f, 0.25f);
            TestHSVToRGB(0.417f, 0.670f, 0.750f, 0.25f, 0.75f, 0.50f);
            TestHSVToRGB(0.250f, 0.670f, 0.750f, 0.50f, 0.75f, 0.25f);
            TestHSVToRGB(0.583f, 0.670f, 0.750f, 0.25f, 0.50f, 0.75f);
            TestHSVToRGB(0.750f, 0.670f, 0.750f, 0.50f, 0.25f, 0.75f);
            TestHSVToRGB(0.592f, 0.480f, 0.702f, 0.36f, 0.51f, 0.70f);
        }

        [Test]
        public void HSVToRGB_hue_wraps_around()
        {
            for (float x = -10; x <= 10; x += 1)
            {
                TestHSVToRGB(x + 0.592f, 0.480f, 0.702f, 0.36f, 0.51f, 0.70f);
            }
        }

        [Test]
        public void HSVToRGB_saturation_is_clipped()
        {
            TestHSVToRGB(0.000f, -10.000f, 0.250f, 0.25f, 0.25f, 0.25f);
            TestHSVToRGB(0.000f, 10.000f, 1.000f, 1.00f, 0.00f, 0.00f);
        }

        [Test]
        public void HSVToRGB_value_is_clipped()
        {
            TestHSVToRGB(0.000f, 0.000f, -10.000f, 0.00f, 0.00f, 0.00f);
            TestHSVToRGB(0.000f, 0.000f, 10.000f, 1.00f, 1.00f, 1.00f);
        }

        [Test]
        public void HSVToRGB_is_inverse_of_RGBToHSV()
        {
            for (float r = 0; r <= 1; r += RGBStep)
            {
                for (float g = 0; g <= 1; g += RGBStep)
                {
                    for (float b = 0; b <= 1; b += RGBStep)
                    {
                        float hue, saturation, value;
                        RGBToHSx.RGBToHSV(r, g, b, out hue, out saturation, out value);

                        TestHSVToRGB(hue, saturation, value, r, g, b);
                    }
                }
            }
        }

        private static void TestRGBToHSV(
            float red, float green, float blue,
            float expectedHue, float expectedSaturation, float expectedValue)
        {
            float hue;
            float saturation;
            float value;

            RGBToHSx.RGBToHSV(red, green, blue, out hue, out saturation, out value);

            Assert.That(hue, Is.EqualTo(expectedHue).Within(Epsilon));
            Assert.That(saturation, Is.EqualTo(expectedSaturation).Within(Epsilon));
            Assert.That(value, Is.EqualTo(expectedValue).Within(Epsilon));
        }

        private static void TestHSVToRGB(
            float hue, float saturation, float value,
            float expectedRed, float expectedGreen, float expectedBlue)
        {
            float red;
            float green;
            float blue;

            RGBToHSx.HSVToRGB(hue, saturation, value, out red, out green, out blue);

            Assert.That(red, Is.EqualTo(expectedRed).Within(Epsilon));
            Assert.That(green, Is.EqualTo(expectedGreen).Within(Epsilon));
            Assert.That(blue, Is.EqualTo(expectedBlue).Within(Epsilon));
        }

        #endregion

        #region RGB <-> HSI

        [Test]
        public void RGBToHSI_converts_properly()
        {
            TestRGBToHSI(0.00f, 0.00f, 0.00f, 0.000f, 0.000f, 0.000f);
            TestRGBToHSI(1.00f, 1.00f, 1.00f, 0.000f, 0.000f, 1.000f);
            TestRGBToHSI(0.25f, 0.25f, 0.25f, 0.000f, 0.000f, 0.250f);
            TestRGBToHSI(1.00f, 0.00f, 0.00f, 0.000f, 1.000f, 0.332f);
            TestRGBToHSI(0.00f, 1.00f, 0.00f, 0.333f, 1.000f, 0.332f);
            TestRGBToHSI(0.00f, 0.00f, 1.00f, 0.667f, 1.000f, 0.332f);
            TestRGBToHSI(0.75f, 0.25f, 0.50f, 0.917f, 0.500f, 0.500f);
            TestRGBToHSI(0.75f, 0.50f, 0.25f, 0.083f, 0.500f, 0.500f);
            TestRGBToHSI(0.25f, 0.75f, 0.50f, 0.417f, 0.500f, 0.500f);
            TestRGBToHSI(0.50f, 0.75f, 0.25f, 0.250f, 0.500f, 0.500f);
            TestRGBToHSI(0.25f, 0.50f, 0.75f, 0.583f, 0.500f, 0.500f);
            TestRGBToHSI(0.50f, 0.25f, 0.75f, 0.750f, 0.500f, 0.500f);
            TestRGBToHSI(0.36f, 0.51f, 0.70f, 0.594f, 0.308f, 0.527f);
        }

        [Test]
        public void RGBToHSI_input_is_clipped()
        {
            TestRGBToHSI(10.00f, -10.00f, 0.00f, 0.000f, 1.000f, 0.332f);
            TestRGBToHSI(0.00f, 10.00f, -10.00f, 0.333f, 1.000f, 0.332f);
            TestRGBToHSI(-10.00f, 0.00f, 10.00f, 0.667f, 1.000f, 0.332f);
        }

        [Test]
        public void HSIToRGB_converts_properly()
        {
            TestHSIToRGB(0.000f, 0.000f, 0.000f, 0.00f, 0.00f, 0.00f);
            TestHSIToRGB(0.000f, 0.000f, 1.000f, 1.00f, 1.00f, 1.00f);
            TestHSIToRGB(0.000f, 0.000f, 0.250f, 0.25f, 0.25f, 0.25f);
            TestHSIToRGB(0.000f, 1.000f, 0.332f, 1.00f, 0.00f, 0.00f);
            TestHSIToRGB(0.333f, 1.000f, 0.332f, 0.00f, 1.00f, 0.00f);
            TestHSIToRGB(0.667f, 1.000f, 0.332f, 0.00f, 0.00f, 1.00f);
            TestHSIToRGB(0.917f, 0.500f, 0.500f, 0.75f, 0.25f, 0.50f);
            TestHSIToRGB(0.083f, 0.500f, 0.500f, 0.75f, 0.50f, 0.25f);
            TestHSIToRGB(0.417f, 0.500f, 0.500f, 0.25f, 0.75f, 0.50f);
            TestHSIToRGB(0.250f, 0.500f, 0.500f, 0.50f, 0.75f, 0.25f);
            TestHSIToRGB(0.583f, 0.500f, 0.500f, 0.25f, 0.50f, 0.75f);
            TestHSIToRGB(0.750f, 0.500f, 0.500f, 0.50f, 0.25f, 0.75f);
            TestHSIToRGB(0.594f, 0.308f, 0.527f, 0.36f, 0.51f, 0.70f);
        }

        [Test]
        public void RGBToHSI_output_is_correct_when_hue_is_180_deg()
        {
            TestRGBToHSI(0.15625f, 0.46875f, 0.46875f, 0.5f, 0.5714f, 0.3647f);
        }

        [Test]
        public void HSIToRGB_hue_wraps_around()
        {
            for (float x = -10; x <= 10; x += 1)
            {
                TestHSIToRGB(x + 0.594f, 0.308f, 0.527f, 0.36f, 0.51f, 0.70f);
            }
        }

        [Test]
        public void HSIToRGB_saturation_is_clipped()
        {
            TestHSIToRGB(0.000f, -10.000f, 0.250f, 0.25f, 0.25f, 0.25f);
            TestHSIToRGB(0.000f, 10.000f, 0.332f, 1.00f, 0.00f, 0.00f);
        }

        [Test]
        public void HSIToRGB_intensity_is_clipped()
        {
            TestHSIToRGB(0.000f, 0.000f, -10.000f, 0.00f, 0.00f, 0.00f);
            TestHSIToRGB(0.000f, 0.000f, 10.000f, 1.00f, 1.00f, 1.00f);
        }

        [Test]
        public void HSIToRGB_is_inverse_of_RGBToHSI()
        {
            for (float r = 0; r <= 1; r += RGBStep)
            {
                for (float g = 0; g <= 1; g += RGBStep)
                {
                    for (float b = 0; b <= 1; b += RGBStep)
                    {
                        float hue, saturation, intensity;
                        RGBToHSx.RGBToHSI(r, g, b, out hue, out saturation, out intensity);

                        TestHSIToRGB(hue, saturation, intensity, r, g, b);
                    }
                }
            }
        }

        private static void TestRGBToHSI(
            float red, float green, float blue,
            float expectedHue, float expectedSaturation, float expectedIntensity)
        {
            float hue;
            float saturation;
            float intensity;

            RGBToHSx.RGBToHSI(red, green, blue, out hue, out saturation, out intensity);

            Assert.That(hue, Is.EqualTo(expectedHue).Within(Epsilon));
            Assert.That(saturation, Is.EqualTo(expectedSaturation).Within(Epsilon));
            Assert.That(intensity, Is.EqualTo(expectedIntensity).Within(Epsilon));
        }

        private static void TestHSIToRGB(
            float hue, float saturation, float intensity,
            float expectedRed, float expectedGreen, float expectedBlue)
        {
            float red;
            float green;
            float blue;

            RGBToHSx.HSIToRGB(hue, saturation, intensity, out red, out green, out blue);
            
            Assert.That(red, Is.EqualTo(expectedRed).Within(Epsilon));
            Assert.That(green, Is.EqualTo(expectedGreen).Within(Epsilon));
            Assert.That(blue, Is.EqualTo(expectedBlue).Within(Epsilon));
        }

        #endregion
    }
}
