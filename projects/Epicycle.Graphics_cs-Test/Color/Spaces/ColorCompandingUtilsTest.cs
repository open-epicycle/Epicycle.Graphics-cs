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
    public class ColorCompandingUtilsTest
    {
        private const float Epsilon = 1e-4f;
        private const float Step = 1.0f / 10000;
        
        #region Gamma Companding

        [Test]
        public void ApplyGammaCompanding_is_correct()
        {
            Assert.That(ColorCompandingUtils.ApplyGammaCompanding(0, 2.2f), Is.EqualTo(0).Within(Epsilon));
            Assert.That(ColorCompandingUtils.ApplyGammaCompanding(1, 2.2f), Is.EqualTo(1).Within(Epsilon));

            Assert.That(ColorCompandingUtils.ApplyGammaCompanding(0.6f, 2.2f), Is.EqualTo(0.792793f).Within(Epsilon));
        }

        [Test]
        public void ApplyInverseGammaCompanding_is_correct()
        {
            Assert.That(ColorCompandingUtils.ApplyInverseGammaCompanding(0, 2.2f), Is.EqualTo(0).Within(Epsilon));
            Assert.That(ColorCompandingUtils.ApplyInverseGammaCompanding(1, 2.2f), Is.EqualTo(1).Within(Epsilon));

            Assert.That(ColorCompandingUtils.ApplyInverseGammaCompanding(0.6f, 2.2f), Is.EqualTo(0.325037f).Within(Epsilon));
        }

        [Test]
        public void ApplyInverseGammaCompanding_is_inverse_of_ApplyGammaCompanding()
        {
            for (float x = 0; x <= 1; x += Step)
            {
                var a = ColorCompandingUtils.ApplyGammaCompanding(x, 2.2f);
                Assert.That(ColorCompandingUtils.ApplyInverseGammaCompanding(a, 2.2f), Is.EqualTo(x).Within(Epsilon));
            }
        }

        #endregion

        #region sRGB Companding

        [Test]
        public void ApplySRGBCompanding_is_correct()
        {
            Assert.That(ColorCompandingUtils.ApplySRGBCompanding(0), Is.EqualTo(0).Within(Epsilon));
            Assert.That(ColorCompandingUtils.ApplySRGBCompanding(1), Is.EqualTo(1).Within(Epsilon));

            Assert.That(ColorCompandingUtils.ApplySRGBCompanding(0.001f), Is.EqualTo(0.01292f).Within(Epsilon));
            Assert.That(ColorCompandingUtils.ApplySRGBCompanding(0.6f), Is.EqualTo(0.797738f).Within(Epsilon));
        }

        [Test]
        public void ApplyInverseSRGBCompanding_is_correct()
        {
            Assert.That(ColorCompandingUtils.ApplyInverseSRGBCompanding(0), Is.EqualTo(0).Within(Epsilon));
            Assert.That(ColorCompandingUtils.ApplyInverseSRGBCompanding(1), Is.EqualTo(1).Within(Epsilon));

            Assert.That(ColorCompandingUtils.ApplyInverseSRGBCompanding(0.01f), Is.EqualTo(0.00077f).Within(Epsilon));
            Assert.That(ColorCompandingUtils.ApplyInverseSRGBCompanding(0.6f), Is.EqualTo(0.318547f).Within(Epsilon));
        }

        [Test]
        public void ApplyInverseGammaCompanding_is_inverse_of_ApplySRGBCompanding()
        {
            for (float x = 0; x <= 1; x += Step)
            {
                var a = ColorCompandingUtils.ApplySRGBCompanding(x);
                Assert.That(ColorCompandingUtils.ApplyInverseSRGBCompanding(a), Is.EqualTo(x).Within(Epsilon));
            }
        }

        #endregion

        #region L* Companding

        [Test]
        public void ApplyLStarCompanding_is_correct()
        {
            Assert.That(ColorCompandingUtils.ApplyLStarCompanding(0), Is.EqualTo(0).Within(Epsilon));
            Assert.That(ColorCompandingUtils.ApplyLStarCompanding(1), Is.EqualTo(1).Within(Epsilon));

            Assert.That(ColorCompandingUtils.ApplyLStarCompanding(0.001f), Is.EqualTo(0.009033f).Within(Epsilon));
            Assert.That(ColorCompandingUtils.ApplyLStarCompanding(0.6f), Is.EqualTo(0.818382f).Within(Epsilon));
        }

        [Test]
        public void ApplyInverseLStarCompanding_is_correct()
        {
            Assert.That(ColorCompandingUtils.ApplyInverseLStarCompanding(0), Is.EqualTo(0).Within(Epsilon));
            Assert.That(ColorCompandingUtils.ApplyInverseLStarCompanding(1), Is.EqualTo(1).Within(Epsilon));

            Assert.That(ColorCompandingUtils.ApplyInverseLStarCompanding(0.01f), Is.EqualTo(0.001107f).Within(Epsilon));
            Assert.That(ColorCompandingUtils.ApplyInverseLStarCompanding(0.6f), Is.EqualTo(0.2812333f).Within(Epsilon));
        }

        [Test]
        public void ApplyInverseLStarCompanding_is_inverse_of_ApplyLStarCompanding()
        {
            for (float x = 0; x <= 1; x += Step)
            {
                var a = ColorCompandingUtils.ApplyLStarCompanding(x);
                Assert.That(ColorCompandingUtils.ApplyInverseLStarCompanding(a), Is.EqualTo(x).Within(Epsilon));
            }
        }

        #endregion
    }
}
