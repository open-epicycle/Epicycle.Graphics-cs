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
    public class LChUtilsTest
    {
        private const float Epsilon = 1e-3f;
        private const float Step = 1.0f / 70;

        #region Lxy <-> LCh

        [Test]
        public void LxyToLCh_converts_correctly()
        {
            TestLxyToLCh(0, 0, 0, 0, 0);

            TestLxyToLCh(0.5f, 0.5f, 0, 0.5f, 0);
            TestLxyToLCh(0.5f, 0, 0.5f, 0.5f, 0.25f);
            TestLxyToLCh(0.5f, -0.5f, 0, 0.5f, 0.5f);
            TestLxyToLCh(0.5f, 0, -0.5f, 0.5f, 0.75f);

            TestLxyToLCh(0.5f, 0.2f, -0.3f, 0.36056f, 303.690f / 360);
        }

        [Test]
        public void LChToLxy_converts_correctly()
        {
            TestLChToLxy(0, 0, 0, 0, 0);

            TestLChToLxy(0.5f, 0.5f, 0, 0.5f, 0);
            TestLChToLxy(0.5f, 0.5f, 0.25f, 0, 0.5f);
            TestLChToLxy(0.5f, 0.5f, 0.5f, -0.5f, 0);
            TestLChToLxy(0.5f, 0.5f, 0.75f, 0, -0.5f);

            TestLChToLxy(0.5f, 0.36056f, 303.690f / 360, 0.2f, -0.3f);
        }

        [Test]
        public void LChToLxy_is_inverse_LxyToLCh()
        {
            for (float l = 0; l <= 1; l += Step)
            {
                for (float x = Step; x <= 1; x += Step)
                {
                    for (float y = 0; y <= 1; y += Step)
                    {
                        float lch_l, lch_c, lch_h;
                        LChUtils.LxyToLCh(l, x, y, out lch_l, out lch_c, out lch_h);

                        TestLChToLxy(lch_l, lch_c, lch_h, x, y);
                    }
                }
            }
        }

        private static void TestLxyToLCh(float l, float x, float y, float expectedC, float expectedH)
        {
            float lch_l, lch_c, lch_h;
            LChUtils.LxyToLCh(l, x, y, out lch_l, out lch_c, out lch_h);

            Assert.That(lch_l, Is.EqualTo(l).Within(Epsilon));
            Assert.That(lch_c, Is.EqualTo(expectedC).Within(Epsilon));
            Assert.That(lch_h, Is.EqualTo(expectedH).Within(Epsilon));
        }

        private static void TestLChToLxy(float l, float c, float h, float expectedX, float expectedY)
        {
            float lxy_l, lxy_x, lxy_y;
            LChUtils.LChToLxy(l, c, h, out lxy_l, out lxy_x, out lxy_y);

            Assert.That(lxy_l, Is.EqualTo(l).Within(Epsilon));
            Assert.That(lxy_x, Is.EqualTo(expectedX).Within(Epsilon));
            Assert.That(lxy_y, Is.EqualTo(expectedY).Within(Epsilon));
        }

        #endregion
    }
}
