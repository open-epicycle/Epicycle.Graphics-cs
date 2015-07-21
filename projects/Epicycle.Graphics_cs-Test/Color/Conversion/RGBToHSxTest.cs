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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Epicycle.Graphics.Color.Conversion
{
    [TestFixture]
    public class RGBToHSxTest
    {
        private const float Epsilon = 1e-2f;

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
    }
}
