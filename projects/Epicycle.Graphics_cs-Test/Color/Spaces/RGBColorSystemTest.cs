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
    public class RGBColorSystemTest
    {
        private const float Epsilon = 1e-3f;
        private const float Step = 1.0f / 70; 
        
        private RGBColorSystem _rgbSystem;

        [SetUp]
        public void SetUp()
        {
            var transform = new float[,] {
                { 0.5f, 0,      0.2f },
                { 0,    0.75f, -0.2f },
                { 0.5f, 0f,     1 },
            };

            _rgbSystem = new RGBColorSystem(transform, null, ColorCompandingFunction.Gamma, 2);
        }

        #region CIE XYZ <-> Linear RGB

        [Test]
        public void CieXYZToLinearRgb_converts_correctly()
        {
            TestCieXYZToLinearRgb(0.145f, 0.1175f, 0.425f, 0.15f, 0.25f, 0.35f);
        }

        [Test]
        public void LinearRgbToCieXYZ_converts_correctly()
        {
            TestLinearRgbToCieXYZ(0.15f, 0.25f, 0.35f, 0.145f, 0.1175f, 0.425f);
        }

        private void TestCieXYZToLinearRgb(float x, float y, float z, float expectedR, float expectedG, float expectedB)
        {
            float r, g, b;
            _rgbSystem.CieXYZToLinearRgb(x, y, z, out r, out g, out b);

            Assert.That(r, Is.EqualTo(expectedR).Within(Epsilon));
            Assert.That(g, Is.EqualTo(expectedG).Within(Epsilon));
            Assert.That(b, Is.EqualTo(expectedB).Within(Epsilon));
        }

        private void TestLinearRgbToCieXYZ(float r, float g, float b, float expectedX, float expectedY, float expectedZ)
        {
            float x, y, z;
            _rgbSystem.LinearRgbToCieXYZ(r, g, b, out x, out y, out z);

            Assert.That(x, Is.EqualTo(expectedX).Within(Epsilon));
            Assert.That(y, Is.EqualTo(expectedY).Within(Epsilon));
            Assert.That(z, Is.EqualTo(expectedZ).Within(Epsilon));
        }

        #endregion

        #region Linear RGB <-> Companded RGB

        [Test]
        public void LinearRgbToCompandedRgb_converts_correctly()
        {
            TestLinearRgbToCompandedRgb(0.15f, 0.25f, 0.35f, 0.3873f, 0.5f, 0.5916f);
        }

        [Test]
        public void CompandedRgbToLinearRgb_converts_correctly()
        {
            TestCompandedRgbToLinearRgb(0.15f, 0.25f, 0.35f, 0.0225f, 0.0625f, 0.1225f);
        }

        private void TestLinearRgbToCompandedRgb(float r, float g, float b, float expectedR, float expectedG, float expectedB)
        {
            float outR, outG, outB;
            _rgbSystem.LinearRgbToCompandedRgb(r, g, b, out outR, out outG, out outB);

            Assert.That(outR, Is.EqualTo(expectedR).Within(Epsilon));
            Assert.That(outG, Is.EqualTo(expectedG).Within(Epsilon));
            Assert.That(outB, Is.EqualTo(expectedB).Within(Epsilon));
        }

        private void TestCompandedRgbToLinearRgb(float r, float g, float b, float expectedR, float expectedG, float expectedB)
        {
            float outR, outG, outB;
            _rgbSystem.CompandedRgbToLinearRgb(r, g, b, out outR, out outG, out outB);

            Assert.That(outR, Is.EqualTo(expectedR).Within(Epsilon));
            Assert.That(outG, Is.EqualTo(expectedG).Within(Epsilon));
            Assert.That(outB, Is.EqualTo(expectedB).Within(Epsilon));
        }

        #endregion
    }
}
