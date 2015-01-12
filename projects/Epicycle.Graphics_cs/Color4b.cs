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

using System;

namespace Epicycle.Graphics
{
    public struct Color4b : IEquatable<Color4b>
    {
        public static readonly Color4b AliceBlue = new Color4b(0xFFF0F8FF);
        public static readonly Color4b AntiqueWhite = new Color4b(0xFFFAEBD7);
        public static readonly Color4b Aqua = new Color4b(0xFF00FFFF);
        public static readonly Color4b Aquamarine = new Color4b(0xFF7FFFD4);
        public static readonly Color4b Azure = new Color4b(0xFFF0FFFF);
        public static readonly Color4b Beige = new Color4b(0xFFF5F5DC);
        public static readonly Color4b Bisque = new Color4b(0xFFFFE4C4);
        public static readonly Color4b Black = new Color4b(0xFF000000);
        public static readonly Color4b BlanchedAlmond = new Color4b(0xFFFFEBCD);
        public static readonly Color4b Blue = new Color4b(0xFF0000FF);
        public static readonly Color4b BlueViolet = new Color4b(0xFF8A2BE2);
        public static readonly Color4b Brown = new Color4b(0xFFA52A2A);
        public static readonly Color4b BurlyWood = new Color4b(0xFFDEB887);
        public static readonly Color4b CadetBlue = new Color4b(0xFF5F9EA0);
        public static readonly Color4b Chartreuse = new Color4b(0xFF7FFF00);
        public static readonly Color4b Chocolate = new Color4b(0xFFD2691E);
        public static readonly Color4b Coral = new Color4b(0xFFFF7F50);
        public static readonly Color4b CornflowerBlue = new Color4b(0xFF6495ED);
        public static readonly Color4b Cornsilk = new Color4b(0xFFFFF8DC);
        public static readonly Color4b Crimson = new Color4b(0xFFDC143C);
        public static readonly Color4b Cyan = new Color4b(0xFF00FFFF);
        public static readonly Color4b DarkBlue = new Color4b(0xFF00008B);
        public static readonly Color4b DarkCyan = new Color4b(0xFF008B8B);
        public static readonly Color4b DarkGoldenrod = new Color4b(0xFFB8860B);
        public static readonly Color4b DarkGray = new Color4b(0xFFA9A9A9);
        public static readonly Color4b DarkGreen = new Color4b(0xFF006400);
        public static readonly Color4b DarkKhaki = new Color4b(0xFFBDB76B);
        public static readonly Color4b DarkMagenta = new Color4b(0xFF8B008B);
        public static readonly Color4b DarkOliveGreen = new Color4b(0xFF556B2F);
        public static readonly Color4b DarkOrange = new Color4b(0xFFFF8C00);
        public static readonly Color4b DarkOrchid = new Color4b(0xFF9932CC);
        public static readonly Color4b DarkRed = new Color4b(0xFF8B0000);
        public static readonly Color4b DarkSalmon = new Color4b(0xFFE9967A);
        public static readonly Color4b DarkSeaGreen = new Color4b(0xFF8FBC8F);
        public static readonly Color4b DarkSlateBlue = new Color4b(0xFF483D8B);
        public static readonly Color4b DarkSlateGray = new Color4b(0xFF2F4F4F);
        public static readonly Color4b DarkTurquoise = new Color4b(0xFF00CED1);
        public static readonly Color4b DarkViolet = new Color4b(0xFF9400D3);
        public static readonly Color4b DeepPink = new Color4b(0xFFFF1493);
        public static readonly Color4b DeepSkyBlue = new Color4b(0xFF00BFFF);
        public static readonly Color4b DimGray = new Color4b(0xFF696969);
        public static readonly Color4b DodgerBlue = new Color4b(0xFF1E90FF);
        public static readonly Color4b Firebrick = new Color4b(0xFFB22222);
        public static readonly Color4b FloralWhite = new Color4b(0xFFFFFAF0);
        public static readonly Color4b ForestGreen = new Color4b(0xFF228B22);
        public static readonly Color4b Fuchsia = new Color4b(0xFFFF00FF);
        public static readonly Color4b Gainsboro = new Color4b(0xFFDCDCDC);
        public static readonly Color4b GhostWhite = new Color4b(0xFFF8F8FF);
        public static readonly Color4b Gold = new Color4b(0xFFFFD700);
        public static readonly Color4b Goldenrod = new Color4b(0xFFDAA520);
        public static readonly Color4b Gray = new Color4b(0xFF808080);
        public static readonly Color4b Green = new Color4b(0xFF008000);
        public static readonly Color4b GreenYellow = new Color4b(0xFFADFF2F);
        public static readonly Color4b Honeydew = new Color4b(0xFFF0FFF0);
        public static readonly Color4b HotPink = new Color4b(0xFFFF69B4);
        public static readonly Color4b IndianRed = new Color4b(0xFFCD5C5C);
        public static readonly Color4b Indigo = new Color4b(0xFF4B0082);
        public static readonly Color4b Ivory = new Color4b(0xFFFFFFF0);
        public static readonly Color4b Khaki = new Color4b(0xFFF0E68C);
        public static readonly Color4b Lavender = new Color4b(0xFFE6E6FA);
        public static readonly Color4b LavenderBlush = new Color4b(0xFFFFF0F5);
        public static readonly Color4b LawnGreen = new Color4b(0xFF7CFC00);
        public static readonly Color4b LemonChiffon = new Color4b(0xFFFFFACD);
        public static readonly Color4b LightBlue = new Color4b(0xFFADD8E6);
        public static readonly Color4b LightCoral = new Color4b(0xFFF08080);
        public static readonly Color4b LightCyan = new Color4b(0xFFE0FFFF);
        public static readonly Color4b LightGoldenrodYellow = new Color4b(0xFFFAFAD2);
        public static readonly Color4b LightGray = new Color4b(0xFFD3D3D3);
        public static readonly Color4b LightGreen = new Color4b(0xFF90EE90);
        public static readonly Color4b LightPink = new Color4b(0xFFFFB6C1);
        public static readonly Color4b LightSalmon = new Color4b(0xFFFFA07A);
        public static readonly Color4b LightSeaGreen = new Color4b(0xFF20B2AA);
        public static readonly Color4b LightSkyBlue = new Color4b(0xFF87CEFA);
        public static readonly Color4b LightSlateGray = new Color4b(0xFF778899);
        public static readonly Color4b LightSteelBlue = new Color4b(0xFFB0C4DE);
        public static readonly Color4b LightYellow = new Color4b(0xFFFFFFE0);
        public static readonly Color4b Lime = new Color4b(0xFF00FF00);
        public static readonly Color4b LimeGreen = new Color4b(0xFF32CD32);
        public static readonly Color4b Linen = new Color4b(0xFFFAF0E6);
        public static readonly Color4b Magenta = new Color4b(0xFFFF00FF);
        public static readonly Color4b Maroon = new Color4b(0xFF800000);
        public static readonly Color4b MediumAquamarine = new Color4b(0xFF66CDAA);
        public static readonly Color4b MediumBlue = new Color4b(0xFF0000CD);
        public static readonly Color4b MediumOrchid = new Color4b(0xFFBA55D3);
        public static readonly Color4b MediumPurple = new Color4b(0xFF9370DB);
        public static readonly Color4b MediumSeaGreen = new Color4b(0xFF3CB371);
        public static readonly Color4b MediumSlateBlue = new Color4b(0xFF7B68EE);
        public static readonly Color4b MediumSpringGreen = new Color4b(0xFF00FA9A);
        public static readonly Color4b MediumTurquoise = new Color4b(0xFF48D1CC);
        public static readonly Color4b MediumVioletRed = new Color4b(0xFFC71585);
        public static readonly Color4b MidnightBlue = new Color4b(0xFF191970);
        public static readonly Color4b MintCream = new Color4b(0xFFF5FFFA);
        public static readonly Color4b MistyRose = new Color4b(0xFFFFE4E1);
        public static readonly Color4b Moccasin = new Color4b(0xFFFFE4B5);
        public static readonly Color4b NavajoWhite = new Color4b(0xFFFFDEAD);
        public static readonly Color4b Navy = new Color4b(0xFF000080);
        public static readonly Color4b OldLace = new Color4b(0xFFFDF5E6);
        public static readonly Color4b Olive = new Color4b(0xFF808000);
        public static readonly Color4b OliveDrab = new Color4b(0xFF6B8E23);
        public static readonly Color4b Orange = new Color4b(0xFFFFA500);
        public static readonly Color4b OrangeRed = new Color4b(0xFFFF4500);
        public static readonly Color4b Orchid = new Color4b(0xFFDA70D6);
        public static readonly Color4b PaleGoldenrod = new Color4b(0xFFEEE8AA);
        public static readonly Color4b PaleGreen = new Color4b(0xFF98FB98);
        public static readonly Color4b PaleTurquoise = new Color4b(0xFFAFEEEE);
        public static readonly Color4b PaleVioletRed = new Color4b(0xFFDB7093);
        public static readonly Color4b PapayaWhip = new Color4b(0xFFFFEFD5);
        public static readonly Color4b PeachPuff = new Color4b(0xFFFFDAB9);
        public static readonly Color4b Peru = new Color4b(0xFFCD853F);
        public static readonly Color4b Pink = new Color4b(0xFFFFC0CB);
        public static readonly Color4b Plum = new Color4b(0xFFDDA0DD);
        public static readonly Color4b PowderBlue = new Color4b(0xFFB0E0E6);
        public static readonly Color4b Purple = new Color4b(0xFF800080);
        public static readonly Color4b Red = new Color4b(0xFFFF0000);
        public static readonly Color4b RosyBrown = new Color4b(0xFFBC8F8F);
        public static readonly Color4b RoyalBlue = new Color4b(0xFF4169E1);
        public static readonly Color4b SaddleBrown = new Color4b(0xFF8B4513);
        public static readonly Color4b Salmon = new Color4b(0xFFFA8072);
        public static readonly Color4b SandyBrown = new Color4b(0xFFF4A460);
        public static readonly Color4b SeaGreen = new Color4b(0xFF2E8B57);
        public static readonly Color4b SeaShell = new Color4b(0xFFFFF5EE);
        public static readonly Color4b Sienna = new Color4b(0xFFA0522D);
        public static readonly Color4b Silver = new Color4b(0xFFC0C0C0);
        public static readonly Color4b SkyBlue = new Color4b(0xFF87CEEB);
        public static readonly Color4b SlateBlue = new Color4b(0xFF6A5ACD);
        public static readonly Color4b SlateGray = new Color4b(0xFF708090);
        public static readonly Color4b Snow = new Color4b(0xFFFFFAFA);
        public static readonly Color4b SpringGreen = new Color4b(0xFF00FF7F);
        public static readonly Color4b SteelBlue = new Color4b(0xFF4682B4);
        public static readonly Color4b Tan = new Color4b(0xFFD2B48C);
        public static readonly Color4b Teal = new Color4b(0xFF008080);
        public static readonly Color4b Thistle = new Color4b(0xFFD8BFD8);
        public static readonly Color4b Tomato = new Color4b(0xFFFF6347);
        public static readonly Color4b Transparent = new Color4b(0x00000000);
        public static readonly Color4b Turquoise = new Color4b(0xFF40E0D0);
        public static readonly Color4b Violet = new Color4b(0xFFEE82EE);
        public static readonly Color4b Wheat = new Color4b(0xFFF5DEB3);
        public static readonly Color4b White = new Color4b(0xFFFFFFFF);
        public static readonly Color4b WhiteSmoke = new Color4b(0xFFF5F5F5);
        public static readonly Color4b Yellow = new Color4b(0xFFFFFF00);
        public static readonly Color4b YellowGreen = new Color4b(0xFF9ACD32);

        private uint _argb;

        public Color4b(uint argb)
        {
            _argb = argb;
        }

        public Color4b(byte r, byte g, byte b)
            : this(r, g, b, 0xFF) { }

        public Color4b(byte r, byte g, byte b, byte a)
        {
            _argb = (uint) a << 24 | (uint) r << 16 | (uint) g << 8 | (uint) b;
        }

        public byte A
        {
            get { return (byte) (_argb >> 24); }
        }

        public byte R
        {
            get { return (byte) ((_argb >> 16) & 0xFF); }
        }

        public byte G
        {
            get { return (byte) ((_argb >> 8) & 0xFF); }
        }

        public byte B
        {
            get { return (byte) (_argb & 0xFF); }
        }

        public bool IsTransparent
        {
            get { return A == 0; }
        }

        public Color4b ChangeAlpha(byte a)
        {
            return new Color4b(R, G, B, a);
        }

        public override bool Equals(object other)
        {
            if(other == null)
            {
                return false;
            }

            if(!(other is Color4b))
            {
                return false;
            }

            var otherColor = (Color4b)other;

            return Equals(otherColor);
        }
        
        public bool Equals(Color4b other)
        {
            return this._argb == other._argb;
        }

        public override int GetHashCode()
        {
            return _argb.GetHashCode();
        }
    }
}

