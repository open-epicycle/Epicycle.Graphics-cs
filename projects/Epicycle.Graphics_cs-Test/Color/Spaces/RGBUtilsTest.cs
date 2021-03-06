﻿// [[[[INFO>
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
    public class RGBUtilsTest
    {
        private const float Epsilon = 1e-3f;
        private const float Step = 1.0f / 70;
        
        #region CIE XYZ <-> RGB
        
        [Test]
        public void CieXYZToRGB_converts_correctly()
        {
            TestCieXYZToRGB(0, 0, 0, 0, 0, 0);
            TestCieXYZToRGB(0.41240f, 0.21260f, 0.01930f, 1, 0, 0);
            TestCieXYZToRGB(0.35760f, 0.71520f, 0.11920f, 0, 1, 0);
            TestCieXYZToRGB(0.18050f, 0.07220f, 0.95050f, 0, 0, 1);
            TestCieXYZToRGB(0.77000f, 0.92780f, 0.13850f, 1, 1, 0);
            TestCieXYZToRGB(0.59290f, 0.28480f, 0.96980f, 1, 0, 1);
            TestCieXYZToRGB(0.53810f, 0.78740f, 1.06970f, 0, 1, 1);
            TestCieXYZToRGB(0.95050f, 1.00000f, 1.08900f, 1, 1, 1);

            TestCieXYZToRGB(0.12869f, 0.12754f, 0.44167f, 0.01f, 0.4f, 0.7f);
        }

        [Test]
        public void RGBToCieXYZ_converts_correctly()
        {
            TestRGBToCieXYZ(0, 0, 0, 0, 0, 0);
            TestRGBToCieXYZ(1, 0, 0, 0.41240f, 0.21260f, 0.01930f);
            TestRGBToCieXYZ(0, 1, 0, 0.35760f, 0.71520f, 0.11920f);
            TestRGBToCieXYZ(0, 0, 1, 0.18050f, 0.07220f, 0.95050f);
            TestRGBToCieXYZ(1, 1, 0, 0.77000f, 0.92780f, 0.13850f);
            TestRGBToCieXYZ(1, 0, 1, 0.59290f, 0.28480f, 0.96980f);
            TestRGBToCieXYZ(0, 1, 1, 0.53810f, 0.78740f, 1.06970f);
            TestRGBToCieXYZ(1, 1, 1, 0.95050f, 1.00000f, 1.08900f);

            TestRGBToCieXYZ(0.01f, 0.4f, 0.7f, 0.12869f, 0.12754f, 0.44167f);
        }

        [Test]
        public void CieXYZToRGB_is_inverse_of_RGBToCieXYZ()
        {
            for (float r = 0; r <= 1; r += Step)
            {
                for (float g = Step; g <= 1; g += Step)
                {
                    for (float b = 0; b <= 1; b += Step)
                    {
                        float x, y, z;
                        RGBUtils.SRGB.RGBToCieXYZ(r, g, b, out x, out y, out z);

                        TestCieXYZToRGB(x, y, z, r, g, b);
                    }
                }
            }
        }

        private static void TestCieXYZToRGB(float x, float y, float z, float expectedR, float expectedG, float expectedB)
        {
            float r, g, b;
            RGBUtils.SRGB.CieXYZToRGB(x, y, z, out r, out g, out b);

            Assert.That(r, Is.EqualTo(expectedR).Within(Epsilon));
            Assert.That(g, Is.EqualTo(expectedG).Within(Epsilon));
            Assert.That(b, Is.EqualTo(expectedB).Within(Epsilon));
        }

        private static void TestRGBToCieXYZ(float r, float g, float b, float expectedX, float expectedY, float expectedZ)
        {
            float x, y, z;
            RGBUtils.SRGB.RGBToCieXYZ(r, g, b, out x, out y, out z);

            Assert.That(x, Is.EqualTo(expectedX).Within(Epsilon));
            Assert.That(y, Is.EqualTo(expectedY).Within(Epsilon));
            Assert.That(z, Is.EqualTo(expectedZ).Within(Epsilon));
        }

        #endregion

        #region RGB <-> CIE Lab

        [Test]
        public void CieLabToRGB_converts_correctly()
        {
            float rgbR, rgbG, rgbB;
            RGBUtils.SRGB.CieLabToRGB(0.42390f, 0.05070f, -0.47378f, out rgbR, out rgbG, out rgbB);

            Assert.That(rgbR, Is.EqualTo(0.01f).Within(Epsilon));
            Assert.That(rgbG, Is.EqualTo(0.4f).Within(Epsilon));
            Assert.That(rgbB, Is.EqualTo(0.7f).Within(Epsilon));
        }

        [Test]
        public void RGBToCieLab_converts_correctly()
        {
            float l, a, b;
            RGBUtils.SRGB.RGBToCieLab(0.01f, 0.4f, 0.7f, out l, out a, out b);

            Assert.That(l, Is.EqualTo(0.42390f).Within(Epsilon));
            Assert.That(a, Is.EqualTo(0.05070f).Within(Epsilon));
            Assert.That(b, Is.EqualTo(-0.47378f).Within(Epsilon));
        }

        #endregion

        #region RGB <-> CIE Luv

        [Test]
        public void CieLuvToRGB_converts_correctly()
        {
            float r, g, b;
            RGBUtils.SRGB.CieLuvToRGB(0.42390f, -0.24764f, -0.70208f, out r, out g, out b);

            Assert.That(r, Is.EqualTo(0.01f).Within(Epsilon));
            Assert.That(g, Is.EqualTo(0.4f).Within(Epsilon));
            Assert.That(b, Is.EqualTo(0.7f).Within(Epsilon));
        }

        [Test]
        public void RGBToCieLuv_converts_correctly()
        {
            float l, u, v;
            RGBUtils.SRGB.RGBToCieLuv(0.01f, 0.4f, 0.7f, out l, out u, out v);

            Assert.That(l, Is.EqualTo(0.42390f).Within(Epsilon));
            Assert.That(u, Is.EqualTo(-0.24764f).Within(Epsilon));
            Assert.That(v, Is.EqualTo(-0.70208f).Within(Epsilon));
        }

        #endregion

        #region RGB <-> LCh

        [Test]
        public void LChToRGB_converts_correctly()
        {
            float r, g, b;
            RGBUtils.SRGB.LChToRGB(0.42390f, 0.47648f, 276.109f / 360.0f, out r, out g, out b);

            Assert.That(r, Is.EqualTo(0.01f).Within(Epsilon));
            Assert.That(g, Is.EqualTo(0.4f).Within(Epsilon));
            Assert.That(b, Is.EqualTo(0.7f).Within(Epsilon));
        }

        [Test]
        public void RGBToLCh_converts_correctly()
        {
            float l, c, h;
            RGBUtils.SRGB.RGBToLCh(0.01f, 0.4f, 0.7f, out l, out c, out h);

            Assert.That(l, Is.EqualTo(0.42390f).Within(Epsilon));
            Assert.That(c, Is.EqualTo(0.47648f).Within(Epsilon));
            Assert.That(h, Is.EqualTo(276.109f / 360.0).Within(Epsilon));
        }

        #endregion
    }
}
