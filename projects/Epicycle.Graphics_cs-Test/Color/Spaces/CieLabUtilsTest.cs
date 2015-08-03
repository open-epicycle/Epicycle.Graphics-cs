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
    public class CieLabUtilsTest
    {
        private const float PI = (float) System.Math.PI;
        private const float Epsilon = 1e-3f;
        private const float Step = 100.0f / 70;
        
        #region CIE XYZ <-> CIE Lab

        [Test]
        public void CieXYZToLab_converts_correctly()
        {
            TestCieXYZToLab(0, 0, 0, 0, 0, 0);

            TestCieXYZToLab(0.41240f, 0.21260f, 0.01930f, 53.233f, 80.109f, 67.220f); // RGB (1, 0, 0)
            TestCieXYZToLab(0.35760f, 0.71520f, 0.11920f, 87.737f, -86.185f, 83.181f); // RGB (0, 1, 0)
            TestCieXYZToLab(0.18050f, 0.07220f,  0.95050f, 32.303f, 79.197f, -107.864f); // RGB (0, 0, 1)
            TestCieXYZToLab(0.95050f, 1.000f,   1.08900f, 100.000f, 0.005f, -0.010f); // RGB (1, 1, 1)

            TestCieXYZToLab(0.005f, 0.300f, 0.200f, 61.654f, -245.269f, 20.197f);
            TestCieXYZToLab(0.300f, 0.005f, 0.200f, 4.516f, 251.999f, -78.316f);
            TestCieXYZToLab(0.300f, 0.200f, 0.005f, 51.837f, 48.031f, 82.223f);
        }

        [Test]
        public void LabToCieXYZ_converts_correctly()
        {
            TestLabToCieXYZ(0, 0, 0, 0, 0, 0);

            TestLabToCieXYZ(53.233f,  80.109f,  67.220f,  0.41240f, 0.21260f, 0.01930f); // RGB (1, 0, 0)
            TestLabToCieXYZ(87.737f, -86.185f,  83.181f,  0.35760f, 0.71520f, 0.11920f); // RGB (0, 1, 0)
            TestLabToCieXYZ(32.303f,  79.197f, -107.864f, 0.18050f, 0.07220f, 0.95050f); // RGB (0, 0, 1)
            TestLabToCieXYZ(100.000f, 0.005f,  -0.010f,   0.95050f, 1.00000f, 1.08900f); // RGB (1, 1, 1)

            TestLabToCieXYZ(61.654f, -245.269f,  20.197f, 0.005f, 0.300f, 0.200f);
            TestLabToCieXYZ(4.516f, 251.999f, -78.316f, 0.300f, 0.005f, 0.200f);
            TestLabToCieXYZ(51.837f, 48.031f, 82.223f, 0.300f, 0.200f, 0.005f);
        }

        [Test]
        public void LabToCieXYZ_is_inverse_of_CieXYZToLab()
        {
            for (float x = 0; x <= 0.95047f; x += Step)
            {
                for (float y = Step; y <= 1.0f; y += Step)
                {
                    for (float z = 0; z <= 1.08883; z += Step)
                    {
                        float l, a, b;
                        CieLabUtils.CieXYZToLab(x, y, z, out l, out a, out b);

                        TestLabToCieXYZ(l, a, b, x, y, z);
                    }
                }
            }
        }

        private static void TestCieXYZToLab(float x, float y, float z, float expectedL, float expectedA, float expectedB)
        {
            float l, a, b;
            CieLabUtils.CieXYZToLab(x, y, z, out l, out a, out b);

            Assert.That(l, Is.EqualTo(expectedL).Within(Epsilon * 100));
            Assert.That(a, Is.EqualTo(expectedA).Within(Epsilon * 100));
            Assert.That(b, Is.EqualTo(expectedB).Within(Epsilon * 100));
        }

        private static void TestLabToCieXYZ(float l, float a, float b, float expectedX, float expectedY, float expectedZ)
        {
            float x, y, z;
            CieLabUtils.LabToCieXYZ(l, a, b, out x, out y, out z);

            Assert.That(x, Is.EqualTo(expectedX).Within(Epsilon));
            Assert.That(y, Is.EqualTo(expectedY).Within(Epsilon));
            Assert.That(z, Is.EqualTo(expectedZ).Within(Epsilon));
        }

        #endregion

        #region CIE Lab <-> CIE LCh(ab)

        [Test]
        public void LabToLCh_converts_correctly()
        {
            TestLabToLCh(0, 0, 0, 0, 0);

            TestLabToLCh(50, 50, 0, 50, 0);
            TestLabToLCh(50, 0, 50, 50, 90);
            TestLabToLCh(50, -50, 0, 50, 180);
            TestLabToLCh(50, 0, -50, 50, 270);

            TestLabToLCh(50, 20, -30, 36.056f, 303.690f);
        }

        [Test]
        public void LChToLab_converts_correctly()
        {
            TestLChToLab(0, 0, 0, 0, 0);

            TestLChToLab(50, 50, 0, 50, 0);
            TestLChToLab(50, 50, 90, 0, 50);
            TestLChToLab(50, 50, 180, -50, 0);
            TestLChToLab(50, 50, 270, 0, -50);

            TestLChToLab(50, 36.056f, 303.690f, 20, -30);
        }

        [Test]
        public void LChToLab_is_inverse_LabToLCh()
        {
            for (float l = 0; l <= 100f; l += Step)
            {
                for (float a = Step; a <= 100f; a += Step)
                {
                    for (float b = 0; b <= 100f; b += Step)
                    {
                        float lch_l, lch_c, lch_h;
                        CieLabUtils.LabToLCh(l, a, b, out lch_l, out lch_c, out lch_h);

                        TestLChToLab(lch_l, lch_c, lch_h, a, b);
                    }
                }
            }
        }

        private static void TestLabToLCh(float l, float a, float b, float expectedC, float expectedH)
        {
            float lch_l, lch_c, lch_h;
            CieLabUtils.LabToLCh(l, a, b, out lch_l, out lch_c, out lch_h);

            Assert.That(lch_l, Is.EqualTo(l).Within(Epsilon * 100));
            Assert.That(lch_c, Is.EqualTo(expectedC).Within(Epsilon * 100));
            Assert.That(lch_h, Is.EqualTo(expectedH).Within(Epsilon));
        }

        private static void TestLChToLab(float l, float c, float h, float expectedA, float expectedB)
        {
            float lab_l, lab_a, lab_b;
            CieLabUtils.LChToLab(l, c, h, out lab_l, out lab_a, out lab_b);

            Assert.That(lab_l, Is.EqualTo(l).Within(Epsilon * 100));
            Assert.That(lab_a, Is.EqualTo(expectedA).Within(Epsilon * 100));
            Assert.That(lab_b, Is.EqualTo(expectedB).Within(Epsilon));
        }

        #endregion
    }
}
