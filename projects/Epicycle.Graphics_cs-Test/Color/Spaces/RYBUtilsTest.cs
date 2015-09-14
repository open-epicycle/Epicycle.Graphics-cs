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
    public class RYBUtilsTest
    {
        private const float Epsilon = 1e-2f;

        [Test]
        public void RYBToRGB_correct_RGB_values_on_RYB_cube_corners()
        {
            TestRYBToRGB(0, 0, 0, 1,      1,      1);    // None

            TestRYBToRGB(1, 0, 0, 1,      0,      0);    // Red
            TestRYBToRGB(0, 1, 0, 1,      1,      0);    // Yellow
            TestRYBToRGB(0, 0, 1, 0.163f, 0.373f, 0.6f); // Blue

            TestRYBToRGB(1, 1, 0, 1,      0.5f,   0);    // Red + Yellow
            TestRYBToRGB(1, 0, 1, 0.5f,   0,      0.5f); // Red + Blue
            TestRYBToRGB(0, 1, 1, 0,      0.66f,  0.2f); // Yellow + Blue

            TestRYBToRGB(1, 1, 1, 0.2f,   0.094f, 0);    // Red + Yellow + Blue
        }

        [Test]
        public void RYBToRGB_correct_produces_correct_output()
        {
            TestRYBToRGB(1.000f, 0.500f, 0.000f, 1.000f, 0.251f, 0.000f);
            TestRYBToRGB(0.500f, 1.000f, 0.000f, 1.000f, 0.753f, 0.000f);
            TestRYBToRGB(0.000f, 1.000f, 0.500f, 0.506f, 0.831f, 0.102f);
            TestRYBToRGB(0.000f, 0.500f, 1.000f, 0.082f, 0.518f, 0.404f);
            TestRYBToRGB(0.500f, 0.000f, 1.000f, 0.333f, 0.188f, 0.553f);
            TestRYBToRGB(1.000f, 0.000f, 0.500f, 0.753f, 0.000f, 0.251f);
        }

        [Test]
        public void RYBToRGB_input_is_clipped()
        {
            TestRYBToRGB(10, -10, 0, 1, 0, 0);
            TestRYBToRGB(0, 10, -10, 1, 1, 0);
            TestRYBToRGB(-10, 0, 10, 0.163f, 0.373f, 0.6f);
        }

        private static void TestRYBToRGB(
            float red, float yellow, float blue,
            float expectedRed, float expectedGreen, float expectedBlue)
        {
            float outRed;
            float outGreen;
            float outBlue;

            RYBUtils.RYBToRGB(red, yellow, blue, out outRed, out outGreen, out outBlue);

            Assert.That(outRed, Is.EqualTo(expectedRed).Within(Epsilon));
            Assert.That(outGreen, Is.EqualTo(expectedGreen).Within(Epsilon));
            Assert.That(outBlue, Is.EqualTo(expectedBlue).Within(Epsilon));
        }
    }
}
