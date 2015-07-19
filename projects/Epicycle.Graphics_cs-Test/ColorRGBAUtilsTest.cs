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

using Epicycle.Commons;
using NUnit.Framework;

namespace Epicycle.Graphics
{
    [TestFixture]
    public class ColorRGBAUtilsTest
    {
        private ColorRGBA _yamlColor;
        private string _yamlData;

        [SetUp]
        public void SetUp()
        {
            _yamlColor = new ColorRGBA(10, 20, 30, 40);
            _yamlData =
                "R: 10\r\n" +
                "G: 20\r\n" +
                "B: 30\r\n" +
                "A: 40\r\n";
        }

        [Test]
        public void YamlSerialization_serialization_produces_correct_yaml()
        {
            var yaml = YamlUtils.Serialize(new ColorRGBAUtils.YamlSerialization(_yamlColor));
            Assert.That(yaml, Is.EqualTo(_yamlData));
        }

        [Test]
        public void YamlSerialization_deserialization_produces_correct_color()
        {
            var color = YamlUtils.Deserialize<ColorRGBAUtils.YamlSerialization>(_yamlData).Deserialize();
            Assert.That(color, Is.EqualTo(_yamlColor));
        }
    }
}
