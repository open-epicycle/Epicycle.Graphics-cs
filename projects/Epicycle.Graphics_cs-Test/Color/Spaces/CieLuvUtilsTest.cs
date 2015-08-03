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
    public class CieLuvUtilsTest
    {
        private const float Epsilon = 1e-3f;
        private const float Step = 1.0f / 70;

        #region CIE XYZ <-> CIE Luv

        [Test]
        public void CieXYZToLuv_converts_correctly()
        {
            TestCieXYZToLuv(0.4124f, 0.2126f, 0.0193f, 53.233f, 175.053f, 37.751f); // RGB (1, 0, 0)
            TestCieXYZToLuv(0.3576f, 0.7152f, 0.1192f, 87.737f, -83.080f, 107.401f); // RGB (0, 1, 0)
            TestCieXYZToLuv(0.1805f, 0.0722f, 0.9505f, 32.303f, -9.400f, -130.358f); // RGB (0, 0, 1)
            TestCieXYZToLuv(0.9505f, 1, 1.0890f, 100.000f, 0.001f, -0.017f); // RGB (1, 1, 1)

            TestCieXYZToLuv(0.005f, 0.300f, 0.200f, 61.654f, -155.430f, 48.537f);
            TestCieXYZToLuv(0.300f, 0.005f, 0.200f, 4.516f, 60.647f, -24.788f);
            TestCieXYZToLuv(0.300f, 0.200f, 0.005f, 51.837f, 110.619f, 50.306f);
        }

        [Test]
        public void LuvToCieXYZ_converts_correctly()
        {
            TestLuvToCieXYZ(53.233f, 175.053f, 37.751f, 0.4124f, 0.2126f, 0.0193f); // RGB (1, 0, 0)
            TestLuvToCieXYZ(87.737f, -83.080f, 107.401f, 0.3576f, 0.7152f, 0.1192f); // RGB (0, 1, 0)
            TestLuvToCieXYZ(32.303f, -9.400f, -130.358f, 0.1805f, 0.0722f, 0.9505f); // RGB (0, 0, 1)
            TestLuvToCieXYZ(100.000f, 0.001f, -0.017f, 0.9505f, 1, 1.0890f); // RGB (1, 1, 1)

            TestLuvToCieXYZ(61.654f, -155.430f, 48.537f, 0.005f, 0.300f, 0.200f);
            TestLuvToCieXYZ(4.516f, 60.647f, -24.788f, 0.300f, 0.005f, 0.200f);
            TestLuvToCieXYZ(51.837f, 110.619f, 50.306f, 0.300f, 0.200f, 0.005f);
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
                        if(x == 0)
                        {
                            continue;
                        }

                        float l, u, v;
                        CieLuvUtils.CieXYZToLuv(x, y, z, out l, out u, out v);

                        TestLuvToCieXYZ(l, u, v, x, y, z);
                    }
                }
            }
        }

        private static void TestCieXYZToLuv(float x, float y, float z, float expectedL, float expectedU, float expectedV)
        {
            float l, u, v;
            CieLuvUtils.CieXYZToLuv(x, y, z, out l, out u, out v);

            Assert.That(l, Is.EqualTo(expectedL).Within(Epsilon * 100));
            Assert.That(u, Is.EqualTo(expectedU).Within(Epsilon * 100));
            Assert.That(v, Is.EqualTo(expectedV).Within(Epsilon * 100));
        }

        private static void TestLuvToCieXYZ(float l, float u, float v, float expectedX, float expectedY, float expectedZ)
        {
            float x, y, z;
            CieLuvUtils.LuvToCieXYZ(l, u, v, out x, out y, out z);

            Assert.That(x, Is.EqualTo(expectedX).Within(Epsilon));
            Assert.That(y, Is.EqualTo(expectedY).Within(Epsilon));
            Assert.That(z, Is.EqualTo(expectedZ).Within(Epsilon));
        }
        
        #endregion
    }
}
