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

namespace Epicycle.Graphics
{
    [TestFixture]
    public class Color4bTest
    {
        [Test]
        public void Ctor_default_ctor_sets_all_colors_to_zero()
        {
            var color = new Color4b();

            Assert.That(color.A, Is.EqualTo(0));
            Assert.That(color.R, Is.EqualTo(0));
            Assert.That(color.G, Is.EqualTo(0));
            Assert.That(color.B, Is.EqualTo(0));
        }

        private void ValidateColor(byte expectedR, byte expectedG, byte expectedB, byte expectedA, Color4b color)
        {
            Assert.That(color.R, Is.EqualTo(expectedR));
            Assert.That(color.G, Is.EqualTo(expectedG));
            Assert.That(color.B, Is.EqualTo(expectedB));
            Assert.That(color.A, Is.EqualTo(expectedA));
        }

        [Test]
        public void Ctor_argb_construction_parses_input_correctly()
        {
            ValidateColor(0x34, 0x56, 0x78, 0x12, new Color4b(0x12345678u));
        }

        [Test]
        public void Ctor_rgb_parameterized_construction_sets_correct_colors()
        {
            var color = new Color4b(10, 20, 30);

            Assert.That(color.A, Is.EqualTo(0xFF));
            Assert.That(color.R, Is.EqualTo(10));
            Assert.That(color.G, Is.EqualTo(20));
            Assert.That(color.B, Is.EqualTo(30));
        }

        [Test]
        public void Ctor_rgba_parameterized_construction_sets_correct_colors()
        {
            var color = new Color4b(10, 20, 30, 40);

            Assert.That(color.A, Is.EqualTo(40));
            Assert.That(color.R, Is.EqualTo(10));
            Assert.That(color.G, Is.EqualTo(20));
            Assert.That(color.B, Is.EqualTo(30));
        }

        [Test]
        public void IsTransparent_zero_alpha_yields_true()
        {
            var color = new Color4b(10, 20, 30, 0);
            Assert.That(color.IsTransparent, Is.True);
        }

        [Test]
        public void IsTransparent_little_alpha_yields_false()
        {
            var color = new Color4b(10, 20, 30, 1);
            Assert.That(color.IsTransparent, Is.False);
        }

        [Test]
        public void IsTransparent_full_alpha_yields_false()
        {
            var color = new Color4b(10, 20, 30, 1);
            Assert.That(color.IsTransparent, Is.False);
        }

        [Test]
        public void ChangeAlpha_replaces_alpha_while_keeping_other_colors()
        {
            ValidateColor(10, 20, 30, 60, new Color4b(10, 20, 30, 40).ChangeAlpha(60));
        }

        [Test]
        public void Equals_Color4b_different_color_yields_falsee()
        {
            var color = new Color4b(10, 20, 30, 40);
            var colorDiff1 = new Color4b(11, 20, 30, 40);
            var colorDiff2 = new Color4b(10, 21, 30, 40);
            var colorDiff3 = new Color4b(10, 20, 31, 40);
            var colorDiff4 = new Color4b(10, 20, 30, 41);

            Assert.That(color.Equals(colorDiff1), Is.False);
            Assert.That(color.Equals(colorDiff2), Is.False);
            Assert.That(color.Equals(colorDiff3), Is.False);
            Assert.That(color.Equals(colorDiff4), Is.False);
        }

        [Test]
        public void Equals_Color4b_same_color_yields_true()
        {
            var color1 = new Color4b(10, 20, 30, 40);
            var color2 = new Color4b(10, 20, 30, 40);

            Assert.That(color1.Equals(color2), Is.True);
        }

        [Test]
        public void Equals_Object_null_yields_false()
        {
            var color = new Color4b(10, 20, 30, 40);
            var colorDiff = new Color4b(11, 20, 30, 40);

            Assert.That(color.Equals(null), Is.False);
        }

        [Test]
        public void Equals_Object_different_type_yields_false()
        {
            var color = new Color4b(10, 20, 30, 40);

            Assert.That(color.Equals(123), Is.False);
        }

        [Test]
        public void Equals_Object_different_color_yields_false()
        {
            var color = new Color4b(10, 20, 30, 40);
            var colorDiff = new Color4b(11, 20, 30, 40);

            Assert.That(color.Equals((object)colorDiff), Is.False);
        }

        [Test]
        public void Equals_Object_same_color_yields_true()
        {
            var color1 = new Color4b(10, 20, 30, 40);
            var color2 = new Color4b(10, 20, 30, 40);

            Assert.That(color1.Equals((object)color2), Is.True);
        }
    }
}
