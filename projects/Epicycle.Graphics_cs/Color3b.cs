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
using Epicycle.Commons;

namespace Epicycle.Graphics
{
    // [### ColorN.cs.TEMPLATE> type = int8, channels = rgb


    public struct Color3b : IEquatable<Color3b>
    {
        #region consts
    
        public const byte MinChannelValue = 0;
        public const byte MaxChannelValue = ((byte) 0xff);
    
        #endregion

        #region Named colors
    
        public static readonly Color3b AliceBlue = new Color3b(0xF0F8FF);
    
        public static readonly Color3b AntiqueWhite = new Color3b(0xFAEBD7);
    
        public static readonly Color3b Aqua = new Color3b(0x00FFFF);
    
        public static readonly Color3b Aquamarine = new Color3b(0x7FFFD4);
    
        public static readonly Color3b Azure = new Color3b(0xF0FFFF);
    
        public static readonly Color3b Beige = new Color3b(0xF5F5DC);
    
        public static readonly Color3b Bisque = new Color3b(0xFFE4C4);
    
        public static readonly Color3b Black = new Color3b(0x000000);
    
        public static readonly Color3b BlanchedAlmond = new Color3b(0xFFEBCD);
    
        public static readonly Color3b Blue = new Color3b(0x0000FF);
    
        public static readonly Color3b BlueViolet = new Color3b(0x8A2BE2);
    
        public static readonly Color3b Brown = new Color3b(0xA52A2A);
    
        public static readonly Color3b BurlyWood = new Color3b(0xDEB887);
    
        public static readonly Color3b CadetBlue = new Color3b(0x5F9EA0);
    
        public static readonly Color3b Chartreuse = new Color3b(0x7FFF00);
    
        public static readonly Color3b Chocolate = new Color3b(0xD2691E);
    
        public static readonly Color3b Coral = new Color3b(0xFF7F50);
    
        public static readonly Color3b CornflowerBlue = new Color3b(0x6495ED);
    
        public static readonly Color3b Cornsilk = new Color3b(0xFFF8DC);
    
        public static readonly Color3b Crimson = new Color3b(0xDC143C);
    
        public static readonly Color3b Cyan = new Color3b(0x00FFFF);
    
        public static readonly Color3b DarkBlue = new Color3b(0x00008B);
    
        public static readonly Color3b DarkCyan = new Color3b(0x008B8B);
    
        public static readonly Color3b DarkGoldenrod = new Color3b(0xB8860B);
    
        public static readonly Color3b DarkGray = new Color3b(0xA9A9A9);
    
        public static readonly Color3b DarkGreen = new Color3b(0x006400);
    
        public static readonly Color3b DarkKhaki = new Color3b(0xBDB76B);
    
        public static readonly Color3b DarkMagenta = new Color3b(0x8B008B);
    
        public static readonly Color3b DarkOliveGreen = new Color3b(0x556B2F);
    
        public static readonly Color3b DarkOrange = new Color3b(0xFF8C00);
    
        public static readonly Color3b DarkOrchid = new Color3b(0x9932CC);
    
        public static readonly Color3b DarkRed = new Color3b(0x8B0000);
    
        public static readonly Color3b DarkSalmon = new Color3b(0xE9967A);
    
        public static readonly Color3b DarkSeaGreen = new Color3b(0x8FBC8F);
    
        public static readonly Color3b DarkSlateBlue = new Color3b(0x483D8B);
    
        public static readonly Color3b DarkSlateGray = new Color3b(0x2F4F4F);
    
        public static readonly Color3b DarkTurquoise = new Color3b(0x00CED1);
    
        public static readonly Color3b DarkViolet = new Color3b(0x9400D3);
    
        public static readonly Color3b DeepPink = new Color3b(0xFF1493);
    
        public static readonly Color3b DeepSkyBlue = new Color3b(0x00BFFF);
    
        public static readonly Color3b DimGray = new Color3b(0x696969);
    
        public static readonly Color3b DodgerBlue = new Color3b(0x1E90FF);
    
        public static readonly Color3b Firebrick = new Color3b(0xB22222);
    
        public static readonly Color3b FloralWhite = new Color3b(0xFFFAF0);
    
        public static readonly Color3b ForestGreen = new Color3b(0x228B22);
    
        public static readonly Color3b Fuchsia = new Color3b(0xFF00FF);
    
        public static readonly Color3b Gainsboro = new Color3b(0xDCDCDC);
    
        public static readonly Color3b GhostWhite = new Color3b(0xF8F8FF);
    
        public static readonly Color3b Gold = new Color3b(0xFFD700);
    
        public static readonly Color3b Goldenrod = new Color3b(0xDAA520);
    
        public static readonly Color3b Gray = new Color3b(0x808080);
    
        public static readonly Color3b Green = new Color3b(0x008000);
    
        public static readonly Color3b GreenYellow = new Color3b(0xADFF2F);
    
        public static readonly Color3b Honeydew = new Color3b(0xF0FFF0);
    
        public static readonly Color3b HotPink = new Color3b(0xFF69B4);
    
        public static readonly Color3b IndianRed = new Color3b(0xCD5C5C);
    
        public static readonly Color3b Indigo = new Color3b(0x4B0082);
    
        public static readonly Color3b Ivory = new Color3b(0xFFFFF0);
    
        public static readonly Color3b Khaki = new Color3b(0xF0E68C);
    
        public static readonly Color3b Lavender = new Color3b(0xE6E6FA);
    
        public static readonly Color3b LavenderBlush = new Color3b(0xFFF0F5);
    
        public static readonly Color3b LawnGreen = new Color3b(0x7CFC00);
    
        public static readonly Color3b LemonChiffon = new Color3b(0xFFFACD);
    
        public static readonly Color3b LightBlue = new Color3b(0xADD8E6);
    
        public static readonly Color3b LightCoral = new Color3b(0xF08080);
    
        public static readonly Color3b LightCyan = new Color3b(0xE0FFFF);
    
        public static readonly Color3b LightGoldenrodYellow = new Color3b(0xFAFAD2);
    
        public static readonly Color3b LightGray = new Color3b(0xD3D3D3);
    
        public static readonly Color3b LightGreen = new Color3b(0x90EE90);
    
        public static readonly Color3b LightPink = new Color3b(0xFFB6C1);
    
        public static readonly Color3b LightSalmon = new Color3b(0xFFA07A);
    
        public static readonly Color3b LightSeaGreen = new Color3b(0x20B2AA);
    
        public static readonly Color3b LightSkyBlue = new Color3b(0x87CEFA);
    
        public static readonly Color3b LightSlateGray = new Color3b(0x778899);
    
        public static readonly Color3b LightSteelBlue = new Color3b(0xB0C4DE);
    
        public static readonly Color3b LightYellow = new Color3b(0xFFFFE0);
    
        public static readonly Color3b Lime = new Color3b(0x00FF00);
    
        public static readonly Color3b LimeGreen = new Color3b(0x32CD32);
    
        public static readonly Color3b Linen = new Color3b(0xFAF0E6);
    
        public static readonly Color3b Magenta = new Color3b(0xFF00FF);
    
        public static readonly Color3b Maroon = new Color3b(0x800000);
    
        public static readonly Color3b MediumAquamarine = new Color3b(0x66CDAA);
    
        public static readonly Color3b MediumBlue = new Color3b(0x0000CD);
    
        public static readonly Color3b MediumOrchid = new Color3b(0xBA55D3);
    
        public static readonly Color3b MediumPurple = new Color3b(0x9370DB);
    
        public static readonly Color3b MediumSeaGreen = new Color3b(0x3CB371);
    
        public static readonly Color3b MediumSlateBlue = new Color3b(0x7B68EE);
    
        public static readonly Color3b MediumSpringGreen = new Color3b(0x00FA9A);
    
        public static readonly Color3b MediumTurquoise = new Color3b(0x48D1CC);
    
        public static readonly Color3b MediumVioletRed = new Color3b(0xC71585);
    
        public static readonly Color3b MidnightBlue = new Color3b(0x191970);
    
        public static readonly Color3b MintCream = new Color3b(0xF5FFFA);
    
        public static readonly Color3b MistyRose = new Color3b(0xFFE4E1);
    
        public static readonly Color3b Moccasin = new Color3b(0xFFE4B5);
    
        public static readonly Color3b NavajoWhite = new Color3b(0xFFDEAD);
    
        public static readonly Color3b Navy = new Color3b(0x000080);
    
        public static readonly Color3b OldLace = new Color3b(0xFDF5E6);
    
        public static readonly Color3b Olive = new Color3b(0x808000);
    
        public static readonly Color3b OliveDrab = new Color3b(0x6B8E23);
    
        public static readonly Color3b Orange = new Color3b(0xFFA500);
    
        public static readonly Color3b OrangeRed = new Color3b(0xFF4500);
    
        public static readonly Color3b Orchid = new Color3b(0xDA70D6);
    
        public static readonly Color3b PaleGoldenrod = new Color3b(0xEEE8AA);
    
        public static readonly Color3b PaleGreen = new Color3b(0x98FB98);
    
        public static readonly Color3b PaleTurquoise = new Color3b(0xAFEEEE);
    
        public static readonly Color3b PaleVioletRed = new Color3b(0xDB7093);
    
        public static readonly Color3b PapayaWhip = new Color3b(0xFFEFD5);
    
        public static readonly Color3b PeachPuff = new Color3b(0xFFDAB9);
    
        public static readonly Color3b Peru = new Color3b(0xCD853F);
    
        public static readonly Color3b Pink = new Color3b(0xFFC0CB);
    
        public static readonly Color3b Plum = new Color3b(0xDDA0DD);
    
        public static readonly Color3b PowderBlue = new Color3b(0xB0E0E6);
    
        public static readonly Color3b Purple = new Color3b(0x800080);
    
        public static readonly Color3b Red = new Color3b(0xFF0000);
    
        public static readonly Color3b RosyBrown = new Color3b(0xBC8F8F);
    
        public static readonly Color3b RoyalBlue = new Color3b(0x4169E1);
    
        public static readonly Color3b SaddleBrown = new Color3b(0x8B4513);
    
        public static readonly Color3b Salmon = new Color3b(0xFA8072);
    
        public static readonly Color3b SandyBrown = new Color3b(0xF4A460);
    
        public static readonly Color3b SeaGreen = new Color3b(0x2E8B57);
    
        public static readonly Color3b SeaShell = new Color3b(0xFFF5EE);
    
        public static readonly Color3b Sienna = new Color3b(0xA0522D);
    
        public static readonly Color3b Silver = new Color3b(0xC0C0C0);
    
        public static readonly Color3b SkyBlue = new Color3b(0x87CEEB);
    
        public static readonly Color3b SlateBlue = new Color3b(0x6A5ACD);
    
        public static readonly Color3b SlateGray = new Color3b(0x708090);
    
        public static readonly Color3b Snow = new Color3b(0xFFFAFA);
    
        public static readonly Color3b SpringGreen = new Color3b(0x00FF7F);
    
        public static readonly Color3b SteelBlue = new Color3b(0x4682B4);
    
        public static readonly Color3b Tan = new Color3b(0xD2B48C);
    
        public static readonly Color3b Teal = new Color3b(0x008080);
    
        public static readonly Color3b Thistle = new Color3b(0xD8BFD8);
    
        public static readonly Color3b Tomato = new Color3b(0xFF6347);
    
        public static readonly Color3b Turquoise = new Color3b(0x40E0D0);
    
        public static readonly Color3b Violet = new Color3b(0xEE82EE);
    
        public static readonly Color3b Wheat = new Color3b(0xF5DEB3);
    
        public static readonly Color3b White = new Color3b(0xFFFFFF);
    
        public static readonly Color3b WhiteSmoke = new Color3b(0xF5F5F5);
    
        public static readonly Color3b Yellow = new Color3b(0xFFFF00);
    
        public static readonly Color3b YellowGreen = new Color3b(0x9ACD32);
    
    
    
        #endregion
    
        #region Members
     
        private readonly uint _rgb;
    
        #endregion
    
        #region Construction and conversion
    
     
        public Color3b(uint rgb)
        {
            _rgb = rgb & ((uint) 0xffffff);
        }
    
        public Color3b(byte r, byte g, byte b)
        {
            _rgb = ((uint) r << 16) | ((uint) g << 8) | ((uint) b << 0);
        }
    
    
    
    
    
    
        #endregion
    
        #region Properties
    
    
        public byte R
        {
            get { return (byte) ((_rgb >> 16) & MaxChannelValue); }
        }
    
        public byte G
        {
            get { return (byte) ((_rgb >> 8) & MaxChannelValue); }
        }
    
        public byte B
        {
            get { return (byte) ((_rgb >> 0) & MaxChannelValue); }
        }
    
        #endregion
    
        #region Mutation
    
        #endregion
    
        #region Equality & HashCode

        public bool Equals(Color3b c)
        {
            return _rgb == c._rgb;
        }

        public override bool Equals(object obj)
        {
        
            var c = obj as Color3b?;

            if(!c.HasValue)
            {
                return false;
            }

            return Equals(c.Value);
        
        }

        public override int GetHashCode()
        {
            return _rgb.GetHashCode();
        }

        public static bool operator ==(Color3b v, Color3b w)
        {
            return v.Equals(w);
        }

        public static bool operator !=(Color3b v, Color3b w)
        {
            return !v.Equals(w);
        }

        #endregion
    
        #region ToString
    
        public override string ToString()
        {
            return string.Format("Color3b(R={0}, G={1}, B={2})", R, G, B);
        }
    
        #endregion
    }
    // ###]
}

