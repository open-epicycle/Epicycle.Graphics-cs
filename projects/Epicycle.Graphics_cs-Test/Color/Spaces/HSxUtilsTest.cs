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

namespace Epicycle.Graphics.Color.Spaces
{
    [TestFixture]
    public class HSxUtilsTest
    {
        private const float Epsilon = 1e-2f;
        private const float Color3Step = 1.0f / 96;

        #region Color3 <-> HSL

        [Test]
        public void Color3ToHSL_converts_properly()
        {
            TestColor3ToHSL(0.00f, 0.00f, 0.00f, 0.000f, 0.000f, 0.000f);
            TestColor3ToHSL(1.00f, 1.00f, 1.00f, 0.000f, 0.000f, 1.000f);
            TestColor3ToHSL(0.25f, 0.25f, 0.25f, 0.000f, 0.000f, 0.250f);
            TestColor3ToHSL(1.00f, 0.00f, 0.00f, 0.000f, 1.000f, 0.500f);
            TestColor3ToHSL(0.00f, 1.00f, 0.00f, 0.333f, 1.000f, 0.500f);
            TestColor3ToHSL(0.00f, 0.00f, 1.00f, 0.667f, 1.000f, 0.500f);
            TestColor3ToHSL(0.75f, 0.25f, 0.50f, 0.917f, 0.500f, 0.500f);
            TestColor3ToHSL(0.75f, 0.50f, 0.25f, 0.083f, 0.500f, 0.500f);
            TestColor3ToHSL(0.25f, 0.75f, 0.50f, 0.417f, 0.500f, 0.500f);
            TestColor3ToHSL(0.50f, 0.75f, 0.25f, 0.250f, 0.500f, 0.500f);
            TestColor3ToHSL(0.25f, 0.50f, 0.75f, 0.583f, 0.500f, 0.500f);
            TestColor3ToHSL(0.50f, 0.25f, 0.75f, 0.750f, 0.500f, 0.500f);
            TestColor3ToHSL(0.36f, 0.51f, 0.70f, 0.592f, 0.361f, 0.533f);
        }

        [Test]
        public void Color3ToHSL_input_is_clipped()
        {
            TestColor3ToHSL(10.00f, -10.00f, 0.00f, 0.000f, 1.000f, 0.500f);
            TestColor3ToHSL(0.00f, 10.00f, -10.00f, 0.333f, 1.000f, 0.500f);
            TestColor3ToHSL(-10.00f, 0.00f, 10.00f, 0.667f, 1.000f, 0.500f);
        }

        [Test]
        public void HSLToColor3_converts_properly()
        {
            TestHSLToColor3(0.000f, 0.000f, 0.000f, 0.00f, 0.00f, 0.00f);
            TestHSLToColor3(0.000f, 0.000f, 1.000f, 1.00f, 1.00f, 1.00f);
            TestHSLToColor3(0.000f, 0.000f, 0.250f, 0.25f, 0.25f, 0.25f);
            TestHSLToColor3(0.000f, 1.000f, 0.500f, 1.00f, 0.00f, 0.00f);
            TestHSLToColor3(0.333f, 1.000f, 0.500f, 0.00f, 1.00f, 0.00f);
            TestHSLToColor3(0.667f, 1.000f, 0.500f, 0.00f, 0.00f, 1.00f);
            TestHSLToColor3(0.917f, 0.500f, 0.500f, 0.75f, 0.25f, 0.50f);
            TestHSLToColor3(0.083f, 0.500f, 0.500f, 0.75f, 0.50f, 0.25f);
            TestHSLToColor3(0.417f, 0.500f, 0.500f, 0.25f, 0.75f, 0.50f);
            TestHSLToColor3(0.250f, 0.500f, 0.500f, 0.50f, 0.75f, 0.25f);
            TestHSLToColor3(0.583f, 0.500f, 0.500f, 0.25f, 0.50f, 0.75f);
            TestHSLToColor3(0.750f, 0.500f, 0.500f, 0.50f, 0.25f, 0.75f);
            TestHSLToColor3(0.592f, 0.361f, 0.533f, 0.36f, 0.51f, 0.70f);
        }

        [Test]
        public void HSLToColor3_hue_wraps_around()
        {
            for(float x = -10; x <= 10; x += 1)
            {
                TestHSLToColor3(x + 0.592f, 0.361f, 0.533f, 0.36f, 0.51f, 0.70f);
            }
        }

        [Test]
        public void HSLToColor3_saturation_is_clipped()
        {
            TestHSLToColor3(0.000f, -10.000f, 0.250f, 0.25f, 0.25f, 0.25f);
            TestHSLToColor3(0.000f, 10.000f, 0.500f, 1.00f, 0.00f, 0.00f);
        }

        [Test]
        public void HSLToColor3_lightness_is_clipped()
        {
            TestHSLToColor3(0.000f, 0.000f, -10.000f, 0.00f, 0.00f, 0.00f);
            TestHSLToColor3(0.000f, 0.000f, 10.000f, 1.00f, 1.00f, 1.00f);
        }

        [Test]
        public void HSLToColor3_is_inverse_of_Color3ToHSL()
        {
            for (float r = 0; r <= 1; r += Color3Step)
            {
                for (float g = 0; g <= 1; g += Color3Step)
                {
                    for (float b = 0; b <= 1; b += Color3Step)
                    {
                        float hue, saturation, lightness;
                        HSxUtils.Color3ToHSL(r, g, b, out hue, out saturation, out lightness);

                        TestHSLToColor3(hue, saturation, lightness, r, g, b);
                    }
                }
            }
        }

        private static void TestColor3ToHSL(
            float c1, float c2, float c3, 
            float expectedHue, float expectedSaturation, float expectedLightness)
        {
            float hue;
            float saturation;
            float lightness;

            HSxUtils.Color3ToHSL(c1, c2, c3, out hue, out saturation, out lightness);

            Assert.That(hue, Is.EqualTo(expectedHue).Within(Epsilon));
            Assert.That(saturation, Is.EqualTo(expectedSaturation).Within(Epsilon));
            Assert.That(lightness, Is.EqualTo(expectedLightness).Within(Epsilon));
        }

        private static void TestHSLToColor3(
            float hue, float saturation, float lightness,
            float expectedC1, float expectedC2, float expectedC3)
        {
            float c1;
            float c2;
            float c3;

            HSxUtils.HSLToColor3(hue, saturation, lightness, out c1, out c2, out c3);

            Assert.That(c1, Is.EqualTo(expectedC1).Within(Epsilon));
            Assert.That(c2, Is.EqualTo(expectedC2).Within(Epsilon));
            Assert.That(c3, Is.EqualTo(expectedC3).Within(Epsilon));
        }

        #endregion

        #region Color3 <-> HSV

        [Test]
        public void Color3ToHSV_converts_properly()
        {
            TestColor3ToHSV(0.00f, 0.00f, 0.00f, 0.000f, 0.000f, 0.000f);
            TestColor3ToHSV(1.00f, 1.00f, 1.00f, 0.000f, 0.000f, 1.000f);
            TestColor3ToHSV(0.25f, 0.25f, 0.25f, 0.000f, 0.000f, 0.250f);
            TestColor3ToHSV(1.00f, 0.00f, 0.00f, 0.000f, 1.000f, 1.000f);
            TestColor3ToHSV(0.00f, 1.00f, 0.00f, 0.333f, 1.000f, 1.000f);
            TestColor3ToHSV(0.00f, 0.00f, 1.00f, 0.667f, 1.000f, 1.000f);
            TestColor3ToHSV(0.75f, 0.25f, 0.50f, 0.917f, 0.670f, 0.750f);
            TestColor3ToHSV(0.75f, 0.50f, 0.25f, 0.083f, 0.670f, 0.750f);
            TestColor3ToHSV(0.25f, 0.75f, 0.50f, 0.417f, 0.670f, 0.750f);
            TestColor3ToHSV(0.50f, 0.75f, 0.25f, 0.250f, 0.670f, 0.750f);
            TestColor3ToHSV(0.25f, 0.50f, 0.75f, 0.583f, 0.670f, 0.750f);
            TestColor3ToHSV(0.50f, 0.25f, 0.75f, 0.750f, 0.670f, 0.750f);
            TestColor3ToHSV(0.36f, 0.51f, 0.70f, 0.592f, 0.480f, 0.702f);
        }

        [Test]
        public void Color3ToHSV_input_is_clipped()
        {
            TestColor3ToHSV(10.00f, -10.00f, 0.00f, 0.000f, 1.000f, 1.000f);
            TestColor3ToHSV(0.00f, 10.00f, -10.00f, 0.333f, 1.000f, 1.000f);
            TestColor3ToHSV(-10.00f, 0.00f, 10.00f, 0.667f, 1.000f, 1.000f);
        }
        
        [Test]
        public void HSVToColor3_converts_properly()
        {
            TestHSVToColor3(0.000f, 0.000f, 0.000f, 0.00f, 0.00f, 0.00f);
            TestHSVToColor3(0.000f, 0.000f, 1.000f, 1.00f, 1.00f, 1.00f);
            TestHSVToColor3(0.000f, 0.000f, 0.250f, 0.25f, 0.25f, 0.25f);
            TestHSVToColor3(0.000f, 1.000f, 1.000f, 1.00f, 0.00f, 0.00f);
            TestHSVToColor3(0.333f, 1.000f, 1.000f, 0.00f, 1.00f, 0.00f);
            TestHSVToColor3(0.667f, 1.000f, 1.000f, 0.00f, 0.00f, 1.00f);
            TestHSVToColor3(0.917f, 0.670f, 0.750f, 0.75f, 0.25f, 0.50f);
            TestHSVToColor3(0.083f, 0.670f, 0.750f, 0.75f, 0.50f, 0.25f);
            TestHSVToColor3(0.417f, 0.670f, 0.750f, 0.25f, 0.75f, 0.50f);
            TestHSVToColor3(0.250f, 0.670f, 0.750f, 0.50f, 0.75f, 0.25f);
            TestHSVToColor3(0.583f, 0.670f, 0.750f, 0.25f, 0.50f, 0.75f);
            TestHSVToColor3(0.750f, 0.670f, 0.750f, 0.50f, 0.25f, 0.75f);
            TestHSVToColor3(0.592f, 0.480f, 0.702f, 0.36f, 0.51f, 0.70f);
        }

        [Test]
        public void HSVToColor3_hue_wraps_around()
        {
            for (float x = -10; x <= 10; x += 1)
            {
                TestHSVToColor3(x + 0.592f, 0.480f, 0.702f, 0.36f, 0.51f, 0.70f);
            }
        }

        [Test]
        public void HSVToColor3_saturation_is_clipped()
        {
            TestHSVToColor3(0.000f, -10.000f, 0.250f, 0.25f, 0.25f, 0.25f);
            TestHSVToColor3(0.000f, 10.000f, 1.000f, 1.00f, 0.00f, 0.00f);
        }

        [Test]
        public void HSVToColor3_value_is_clipped()
        {
            TestHSVToColor3(0.000f, 0.000f, -10.000f, 0.00f, 0.00f, 0.00f);
            TestHSVToColor3(0.000f, 0.000f, 10.000f, 1.00f, 1.00f, 1.00f);
        }

        [Test]
        public void HSVToColor3_is_inverse_of_Color3ToHSV()
        {
            for (float r = 0; r <= 1; r += Color3Step)
            {
                for (float g = 0; g <= 1; g += Color3Step)
                {
                    for (float b = 0; b <= 1; b += Color3Step)
                    {
                        float hue, saturation, value;
                        HSxUtils.Color3ToHSV(r, g, b, out hue, out saturation, out value);

                        TestHSVToColor3(hue, saturation, value, r, g, b);
                    }
                }
            }
        }

        private static void TestColor3ToHSV(
            float c1, float c2, float c3,
            float expectedHue, float expectedSaturation, float expectedValue)
        {
            float hue;
            float saturation;
            float value;

            HSxUtils.Color3ToHSV(c1, c2, c3, out hue, out saturation, out value);

            Assert.That(hue, Is.EqualTo(expectedHue).Within(Epsilon));
            Assert.That(saturation, Is.EqualTo(expectedSaturation).Within(Epsilon));
            Assert.That(value, Is.EqualTo(expectedValue).Within(Epsilon));
        }

        private static void TestHSVToColor3(
            float hue, float saturation, float value,
            float expectedC1, float expectedC2, float expectedC3)
        {
            float c1;
            float c2;
            float c3;

            HSxUtils.HSVToColor3(hue, saturation, value, out c1, out c2, out c3);

            Assert.That(c1, Is.EqualTo(expectedC1).Within(Epsilon));
            Assert.That(c2, Is.EqualTo(expectedC2).Within(Epsilon));
            Assert.That(c3, Is.EqualTo(expectedC3).Within(Epsilon));
        }

        #endregion

        #region Color3 <-> HSI

        [Test]
        public void Color3ToHSI_converts_properly()
        {
            TestColor3ToHSI(0.00f, 0.00f, 0.00f, 0.000f, 0.000f, 0.000f);
            TestColor3ToHSI(1.00f, 1.00f, 1.00f, 0.000f, 0.000f, 1.000f);
            TestColor3ToHSI(0.25f, 0.25f, 0.25f, 0.000f, 0.000f, 0.250f);
            TestColor3ToHSI(1.00f, 0.00f, 0.00f, 0.000f, 1.000f, 0.332f);
            TestColor3ToHSI(0.00f, 1.00f, 0.00f, 0.333f, 1.000f, 0.332f);
            TestColor3ToHSI(0.00f, 0.00f, 1.00f, 0.667f, 1.000f, 0.332f);
            TestColor3ToHSI(0.75f, 0.25f, 0.50f, 0.917f, 0.500f, 0.500f);
            TestColor3ToHSI(0.75f, 0.50f, 0.25f, 0.083f, 0.500f, 0.500f);
            TestColor3ToHSI(0.25f, 0.75f, 0.50f, 0.417f, 0.500f, 0.500f);
            TestColor3ToHSI(0.50f, 0.75f, 0.25f, 0.250f, 0.500f, 0.500f);
            TestColor3ToHSI(0.25f, 0.50f, 0.75f, 0.583f, 0.500f, 0.500f);
            TestColor3ToHSI(0.50f, 0.25f, 0.75f, 0.750f, 0.500f, 0.500f);
            TestColor3ToHSI(0.36f, 0.51f, 0.70f, 0.594f, 0.308f, 0.527f);
        }

        [Test]
        public void Color3ToHSI_input_is_clipped()
        {
            TestColor3ToHSI(10.00f, -10.00f, 0.00f, 0.000f, 1.000f, 0.332f);
            TestColor3ToHSI(0.00f, 10.00f, -10.00f, 0.333f, 1.000f, 0.332f);
            TestColor3ToHSI(-10.00f, 0.00f, 10.00f, 0.667f, 1.000f, 0.332f);
        }

        [Test]
        public void HSIToColor3_converts_properly()
        {
            TestHSIToColor3(0.000f, 0.000f, 0.000f, 0.00f, 0.00f, 0.00f);
            TestHSIToColor3(0.000f, 0.000f, 1.000f, 1.00f, 1.00f, 1.00f);
            TestHSIToColor3(0.000f, 0.000f, 0.250f, 0.25f, 0.25f, 0.25f);
            TestHSIToColor3(0.000f, 1.000f, 0.332f, 1.00f, 0.00f, 0.00f);
            TestHSIToColor3(0.333f, 1.000f, 0.332f, 0.00f, 1.00f, 0.00f);
            TestHSIToColor3(0.667f, 1.000f, 0.332f, 0.00f, 0.00f, 1.00f);
            TestHSIToColor3(0.917f, 0.500f, 0.500f, 0.75f, 0.25f, 0.50f);
            TestHSIToColor3(0.083f, 0.500f, 0.500f, 0.75f, 0.50f, 0.25f);
            TestHSIToColor3(0.417f, 0.500f, 0.500f, 0.25f, 0.75f, 0.50f);
            TestHSIToColor3(0.250f, 0.500f, 0.500f, 0.50f, 0.75f, 0.25f);
            TestHSIToColor3(0.583f, 0.500f, 0.500f, 0.25f, 0.50f, 0.75f);
            TestHSIToColor3(0.750f, 0.500f, 0.500f, 0.50f, 0.25f, 0.75f);
            TestHSIToColor3(0.594f, 0.308f, 0.527f, 0.36f, 0.51f, 0.70f);
        }

        [Test]
        public void Color3ToHSI_output_is_correct_when_hue_is_180_deg()
        {
            TestColor3ToHSI(0.15625f, 0.46875f, 0.46875f, 0.5f, 0.5714f, 0.3647f);
        }

        [Test]
        public void HSIToColor3_hue_wraps_around()
        {
            for (float x = -10; x <= 10; x += 1)
            {
                TestHSIToColor3(x + 0.594f, 0.308f, 0.527f, 0.36f, 0.51f, 0.70f);
            }
        }

        [Test]
        public void HSIToColor3_saturation_is_clipped()
        {
            TestHSIToColor3(0.000f, -10.000f, 0.250f, 0.25f, 0.25f, 0.25f);
            TestHSIToColor3(0.000f, 10.000f, 0.332f, 1.00f, 0.00f, 0.00f);
        }

        [Test]
        public void HSIToColor3_intensity_is_clipped()
        {
            TestHSIToColor3(0.000f, 0.000f, -10.000f, 0.00f, 0.00f, 0.00f);
            TestHSIToColor3(0.000f, 0.000f, 10.000f, 1.00f, 1.00f, 1.00f);
        }

        [Test]
        public void HSIToColor3_is_inverse_of_Color3ToHSI()
        {
            for (float r = 0; r <= 1; r += Color3Step)
            {
                for (float g = 0; g <= 1; g += Color3Step)
                {
                    for (float b = 0; b <= 1; b += Color3Step)
                    {
                        float hue, saturation, intensity;
                        HSxUtils.Color3ToHSI(r, g, b, out hue, out saturation, out intensity);

                        TestHSIToColor3(hue, saturation, intensity, r, g, b);
                    }
                }
            }
        }

        private static void TestColor3ToHSI(
            float c1, float c2, float c3,
            float expectedHue, float expectedSaturation, float expectedIntensity)
        {
            float hue;
            float saturation;
            float intensity;

            HSxUtils.Color3ToHSI(c1, c2, c3, out hue, out saturation, out intensity);

            Assert.That(hue, Is.EqualTo(expectedHue).Within(Epsilon));
            Assert.That(saturation, Is.EqualTo(expectedSaturation).Within(Epsilon));
            Assert.That(intensity, Is.EqualTo(expectedIntensity).Within(Epsilon));
        }

        private static void TestHSIToColor3(
            float hue, float saturation, float intensity,
            float expectedC1, float expectedC2, float expectedC3)
        {
            float c1;
            float c2;
            float c3;

            HSxUtils.HSIToColor3(hue, saturation, intensity, out c1, out c2, out c3);
            
            Assert.That(c1, Is.EqualTo(expectedC1).Within(Epsilon));
            Assert.That(c2, Is.EqualTo(expectedC2).Within(Epsilon));
            Assert.That(c3, Is.EqualTo(expectedC3).Within(Epsilon));
        }

        #endregion
    }
}
