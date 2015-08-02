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
        private const float Epsilon = 1e-1f;
        private const float Step = 100.0f / 70;
        
        #region CIE XYZ <-> CIE Lab

        [Test]
        public void CieXYZToLab_converts_correctly()
        {
            TestCieXYZToLab(0, 0, 0, 0, 0, 0);

            TestCieXYZToLab(41.240f, 21.260f, 1.930f, 53.233f, 80.109f, 67.220f); // RGB (1, 0, 0)
            TestCieXYZToLab(35.760f, 71.520f, 11.920f, 87.737f, -86.185f, 83.181f); // RGB (0, 1, 0)
            TestCieXYZToLab(18.050f, 7.220f, 95.050f, 32.303f, 79.197f, -107.864f); // RGB (0, 0, 1)
            TestCieXYZToLab(95.050f, 100.000f, 108.900f, 100.000f, 0.005f, -0.010f); // RGB (1, 1, 1)

            TestCieXYZToLab(0.5f, 30.0f, 20.0f, 61.654f, -245.269f, 20.197f);
            TestCieXYZToLab(30.0f, 0.5f, 20.0f, 4.516f, 251.999f, -78.316f);
            TestCieXYZToLab(30.0f, 20.0f, 0.5f, 51.837f, 48.031f, 82.223f);
        }

        [Test]
        public void LabToCieXYZ_converts_correctly()
        {
            TestLabToCieXYZ(0, 0, 0, 0, 0, 0);

            TestLabToCieXYZ(53.233f, 80.109f, 67.220f, 41.240f, 21.260f, 1.930f); // RGB (1, 0, 0)
            TestLabToCieXYZ(87.737f, -86.185f, 83.181f, 35.760f, 71.520f, 11.920f); // RGB (0, 1, 0)
            TestLabToCieXYZ(32.303f, 79.197f, -107.864f, 18.050f, 7.220f, 95.050f); // RGB (0, 0, 1)
            TestLabToCieXYZ(100.000f, 0.005f, -0.010f, 95.050f, 100.000f, 108.900f); // RGB (1, 1, 1)

            TestLabToCieXYZ(61.654f, -245.269f, 20.197f, 0.5f, 30.0f, 20.0f);
            TestLabToCieXYZ(4.516f, 251.999f, -78.316f, 30.0f, 0.5f, 20.0f);
            TestLabToCieXYZ(51.837f, 48.031f, 82.223f, 30.0f, 20.0f, 0.5f);
        }

        [Test]
        public void LabToCieXYZ_is_inverse_of_CieXYZToLab()
        {
            for (float x = 0; x <= 95.047f; x += Step)
            {
                for (float y = Step; y <= 100.0f; y += Step)
                {
                    for (float z = 0; z <= 108.883; z += Step)
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
