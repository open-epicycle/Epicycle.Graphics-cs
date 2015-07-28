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
    public class CieXYZUtilsTest
    {
        private const float Epsilon = 1e-3f;
        private const float Step = 1.0f / 48;

        #region CieRGB <-> XYZ

        [Test]
        public void CieRGBToXYZ_converts_correctly()
        {
            TestCieRGBToXYZ(0, 0, 0, 0, 0, 0);
            TestCieRGBToXYZ(1, 1, 1, 1 / 0.17697f, 1 / 0.17697f, 1 / 0.17697f);

            TestCieRGBToXYZ(1, 0, 0, 2.7688f, 1, 0);
            TestCieRGBToXYZ(0, 1, 0, 1.7517f, 4.5906f, 0.0565f);
            TestCieRGBToXYZ(0, 0, 1, 1.1301f, 0.0601f, 5.5942f);

            TestCieRGBToXYZ(0.1f, 0.2f, 0.3f, 0.9663f, 1.0361f, 1.6895f);
        }

        [Test]
        public void XYZToCieRGB_converts_correctly()
        {
            TestXYZToCieRGB(0, 0, 0, 0, 0, 0);
            TestXYZToCieRGB(1, 1, 1, 0.17697f, 0.17697f, 0.17697f);

            TestXYZToCieRGB(1, 0, 0, 0.41847f, -0.091169f, 0.0009209f);
            TestXYZToCieRGB(0, 1, 0, -0.15866f, 0.25243f, -0.0025498f);
            TestXYZToCieRGB(0, 0, 1, -0.082835f, 0.015708f, 0.1786f);

            TestXYZToCieRGB(0.1f, 0.2f, 0.3f, -0.0147f, 0.0461f, 0.0532f);
        }

        [Test]
        public void XYZToCieRGB_is_inverse_of_CieRGBToXYZ()
        {
            for (float r = -1; r <= 1; r += Step)
            {
                for (float g = 0; g <= 1; g += Step)
                {
                    for (float b = 0; b <= 1; b += Step)
                    {
                        float x, y, z;
                        CieXYZUtils.CieRGBToXYZ(r, g, b, out x, out y, out z);

                        TestXYZToCieRGB(x, y, z, r, g, b);
                    }
                }
            }
        }

        private static void TestCieRGBToXYZ(float r, float g, float b, float expectedX, float expectedY, float expectedZ)
        {
            float x, y, z;
            CieXYZUtils.CieRGBToXYZ(r, g, b, out x, out y, out z);

            Assert.That(x, Is.EqualTo(expectedX).Within(Epsilon));
            Assert.That(y, Is.EqualTo(expectedY).Within(Epsilon));
            Assert.That(z, Is.EqualTo(expectedZ).Within(Epsilon));
        }

        private static void TestXYZToCieRGB(float x, float y, float z, float expectedR, float expectedG, float expectedB)
        {
            float r, g, b;
            CieXYZUtils.XYZToCieRGB(x, y, z, out r, out g, out b);

            Assert.That(r, Is.EqualTo(expectedR).Within(Epsilon));
            Assert.That(g, Is.EqualTo(expectedG).Within(Epsilon));
            Assert.That(b, Is.EqualTo(expectedB).Within(Epsilon));
        }

        #endregion
    }
}
