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
    }
}
