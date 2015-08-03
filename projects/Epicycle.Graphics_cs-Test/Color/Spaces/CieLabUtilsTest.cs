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
        private const float Epsilon = 1e-3f;
        private const float Step = 1.0f / 70;
        
        #region CIE XYZ <-> CIE Lab

        [Test]
        public void CieXYZToLab_converts_correctly()
        {
            TestCieXYZToLab(0, 0, 0, 0, 0, 0);

            TestCieXYZToLab(0.4124f, 0.2126f, 0.0193f, 0.53233f,  0.80109f,  0.67220f); // RGB (1, 0, 0)
            TestCieXYZToLab(0.3576f, 0.7152f, 0.1192f, 0.87737f, -0.86185f,  0.83181f); // RGB (0, 1, 0)
            TestCieXYZToLab(0.1805f, 0.0722f, 0.9505f, 0.32303f,  0.79197f, -1.07864f); // RGB (0, 0, 1)
            TestCieXYZToLab(0.9505f, 1,       1.0890f, 1,         0.00005f,  -0.00010f); // RGB (1, 1, 1)

            TestCieXYZToLab(0.005f, 0.300f, 0.200f, 0.61654f, -2.45269f, 0.20197f);
            TestCieXYZToLab(0.300f, 0.005f, 0.200f, 0.04516f, 2.51999f, -0.78316f);
            TestCieXYZToLab(0.300f, 0.200f, 0.005f, 0.51837f, 0.48031f, 0.82223f);
        }

        [Test]
        public void LabToCieXYZ_converts_correctly()
        {
            TestLabToCieXYZ(0, 0, 0, 0, 0, 0);

            TestLabToCieXYZ(0.53233f,  0.80109f,  0.67220f, 0.41240f, 0.21260f, 0.01930f); // RGB (1, 0, 0)
            TestLabToCieXYZ(0.87737f, -0.86185f,  0.83181f, 0.35760f, 0.71520f, 0.11920f); // RGB (0, 1, 0)
            TestLabToCieXYZ(0.32303f,  0.79197f, -1.07864f, 0.18050f, 0.07220f, 0.95050f); // RGB (0, 0, 1)
            TestLabToCieXYZ(1,         0.00005f, -0.0001f,  0.95050f, 1.00000f, 1.08900f); // RGB (1, 1, 1)

            TestLabToCieXYZ(0.61654f, -2.45269f,  0.20197f, 0.005f, 0.300f, 0.200f);
            TestLabToCieXYZ(0.04516f,  2.51999f, -0.78316f, 0.300f, 0.005f, 0.200f);
            TestLabToCieXYZ(0.51837f,  0.48031f,  0.82223f, 0.300f, 0.200f, 0.005f);
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

            Assert.That(l, Is.EqualTo(expectedL).Within(Epsilon));
            Assert.That(a, Is.EqualTo(expectedA).Within(Epsilon));
            Assert.That(b, Is.EqualTo(expectedB).Within(Epsilon));
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

            TestLabToLCh(0.5f, 0.5f, 0, 0.5f, 0);
            TestLabToLCh(0.5f, 0, 0.5f, 0.5f, 0.25f);
            TestLabToLCh(0.5f, -0.5f, 0, 0.5f, 0.5f);
            TestLabToLCh(0.5f, 0, -0.5f, 0.5f, 0.75f);

            TestLabToLCh(0.5f, 0.2f, -0.3f, 0.36056f, 303.690f / 360);
        }

        [Test]
        public void LChToLab_converts_correctly()
        {
            TestLChToLab(0, 0, 0, 0, 0);

            TestLChToLab(0.5f, 0.5f, 0, 0.5f, 0);
            TestLChToLab(0.5f, 0.5f, 0.25f, 0, 0.5f);
            TestLChToLab(0.5f, 0.5f, 0.5f, -0.5f, 0);
            TestLChToLab(0.5f, 0.5f, 0.75f, 0, -0.5f);

            TestLChToLab(0.5f, 0.36056f, 303.690f / 360, 0.2f, -0.3f);
        }

        [Test]
        public void LChToLab_is_inverse_LabToLCh()
        {
            for (float l = 0; l <= 1; l += Step)
            {
                for (float a = Step; a <= 1; a += Step)
                {
                    for (float b = 0; b <= 1; b += Step)
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

            Assert.That(lch_l, Is.EqualTo(l).Within(Epsilon));
            Assert.That(lch_c, Is.EqualTo(expectedC).Within(Epsilon));
            Assert.That(lch_h, Is.EqualTo(expectedH).Within(Epsilon));
        }

        private static void TestLChToLab(float l, float c, float h, float expectedA, float expectedB)
        {
            float lab_l, lab_a, lab_b;
            CieLabUtils.LChToLab(l, c, h, out lab_l, out lab_a, out lab_b);

            Assert.That(lab_l, Is.EqualTo(l).Within(Epsilon));
            Assert.That(lab_a, Is.EqualTo(expectedA).Within(Epsilon));
            Assert.That(lab_b, Is.EqualTo(expectedB).Within(Epsilon));
        }

        #endregion
    }
}
