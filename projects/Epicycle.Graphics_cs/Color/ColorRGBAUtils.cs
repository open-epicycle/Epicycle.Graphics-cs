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

namespace Epicycle.Graphics.Color
{
    public static class ColorRGBAUtils
    {
        public sealed class YamlSerialization
        {
            public int R { get; set; }
            public int G { get; set; }
            public int B { get; set; }
            public int A { get; set; }

            public YamlSerialization() { }

            public YamlSerialization(ColorRGBA color)
            {
                R = color.R;
                G = color.G;
                B = color.B;
                A = color.A;
            }

            public ColorRGBA Deserialize()
            {
                return new ColorRGBA((byte)R, (byte)G, (byte)B, (byte)A);
            }
        }
    }
}
