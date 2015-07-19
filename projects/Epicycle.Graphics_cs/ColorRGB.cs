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

using System;
using Epicycle.Commons;

namespace Epicycle.Graphics
{
    // [### ColorINT.cs.TEMPLATE> type = int8, channels = rgb


    public struct ColorRGB : IEquatable<ColorRGB>
    {
        #region consts
    
        public const byte MinChannelValue = 0;
        public const byte MaxChannelValue = ((byte) 0xff);
    
        #endregion

        #region Named colors
     
    
        public static readonly ColorRGB AliceBlue = new ColorRGB(0xF0F8FF);
    
        public static readonly ColorRGB AntiqueWhite = new ColorRGB(0xFAEBD7);
    
        public static readonly ColorRGB Aqua = new ColorRGB(0x00FFFF);
    
        public static readonly ColorRGB Aquamarine = new ColorRGB(0x7FFFD4);
    
        public static readonly ColorRGB Azure = new ColorRGB(0xF0FFFF);
    
        public static readonly ColorRGB Beige = new ColorRGB(0xF5F5DC);
    
        public static readonly ColorRGB Bisque = new ColorRGB(0xFFE4C4);
    
        public static readonly ColorRGB Black = new ColorRGB(0x000000);
    
        public static readonly ColorRGB BlanchedAlmond = new ColorRGB(0xFFEBCD);
    
        public static readonly ColorRGB Blue = new ColorRGB(0x0000FF);
    
        public static readonly ColorRGB BlueViolet = new ColorRGB(0x8A2BE2);
    
        public static readonly ColorRGB Brown = new ColorRGB(0xA52A2A);
    
        public static readonly ColorRGB BurlyWood = new ColorRGB(0xDEB887);
    
        public static readonly ColorRGB CadetBlue = new ColorRGB(0x5F9EA0);
    
        public static readonly ColorRGB Chartreuse = new ColorRGB(0x7FFF00);
    
        public static readonly ColorRGB Chocolate = new ColorRGB(0xD2691E);
    
        public static readonly ColorRGB Coral = new ColorRGB(0xFF7F50);
    
        public static readonly ColorRGB CornflowerBlue = new ColorRGB(0x6495ED);
    
        public static readonly ColorRGB Cornsilk = new ColorRGB(0xFFF8DC);
    
        public static readonly ColorRGB Crimson = new ColorRGB(0xDC143C);
    
        public static readonly ColorRGB Cyan = new ColorRGB(0x00FFFF);
    
        public static readonly ColorRGB DarkBlue = new ColorRGB(0x00008B);
    
        public static readonly ColorRGB DarkCyan = new ColorRGB(0x008B8B);
    
        public static readonly ColorRGB DarkGoldenrod = new ColorRGB(0xB8860B);
    
        public static readonly ColorRGB DarkGray = new ColorRGB(0xA9A9A9);
    
        public static readonly ColorRGB DarkGreen = new ColorRGB(0x006400);
    
        public static readonly ColorRGB DarkKhaki = new ColorRGB(0xBDB76B);
    
        public static readonly ColorRGB DarkMagenta = new ColorRGB(0x8B008B);
    
        public static readonly ColorRGB DarkOliveGreen = new ColorRGB(0x556B2F);
    
        public static readonly ColorRGB DarkOrange = new ColorRGB(0xFF8C00);
    
        public static readonly ColorRGB DarkOrchid = new ColorRGB(0x9932CC);
    
        public static readonly ColorRGB DarkRed = new ColorRGB(0x8B0000);
    
        public static readonly ColorRGB DarkSalmon = new ColorRGB(0xE9967A);
    
        public static readonly ColorRGB DarkSeaGreen = new ColorRGB(0x8FBC8F);
    
        public static readonly ColorRGB DarkSlateBlue = new ColorRGB(0x483D8B);
    
        public static readonly ColorRGB DarkSlateGray = new ColorRGB(0x2F4F4F);
    
        public static readonly ColorRGB DarkTurquoise = new ColorRGB(0x00CED1);
    
        public static readonly ColorRGB DarkViolet = new ColorRGB(0x9400D3);
    
        public static readonly ColorRGB DeepPink = new ColorRGB(0xFF1493);
    
        public static readonly ColorRGB DeepSkyBlue = new ColorRGB(0x00BFFF);
    
        public static readonly ColorRGB DimGray = new ColorRGB(0x696969);
    
        public static readonly ColorRGB DodgerBlue = new ColorRGB(0x1E90FF);
    
        public static readonly ColorRGB Firebrick = new ColorRGB(0xB22222);
    
        public static readonly ColorRGB FloralWhite = new ColorRGB(0xFFFAF0);
    
        public static readonly ColorRGB ForestGreen = new ColorRGB(0x228B22);
    
        public static readonly ColorRGB Fuchsia = new ColorRGB(0xFF00FF);
    
        public static readonly ColorRGB Gainsboro = new ColorRGB(0xDCDCDC);
    
        public static readonly ColorRGB GhostWhite = new ColorRGB(0xF8F8FF);
    
        public static readonly ColorRGB Gold = new ColorRGB(0xFFD700);
    
        public static readonly ColorRGB Goldenrod = new ColorRGB(0xDAA520);
    
        public static readonly ColorRGB Gray = new ColorRGB(0x808080);
    
        public static readonly ColorRGB Green = new ColorRGB(0x008000);
    
        public static readonly ColorRGB GreenYellow = new ColorRGB(0xADFF2F);
    
        public static readonly ColorRGB Honeydew = new ColorRGB(0xF0FFF0);
    
        public static readonly ColorRGB HotPink = new ColorRGB(0xFF69B4);
    
        public static readonly ColorRGB IndianRed = new ColorRGB(0xCD5C5C);
    
        public static readonly ColorRGB Indigo = new ColorRGB(0x4B0082);
    
        public static readonly ColorRGB Ivory = new ColorRGB(0xFFFFF0);
    
        public static readonly ColorRGB Khaki = new ColorRGB(0xF0E68C);
    
        public static readonly ColorRGB Lavender = new ColorRGB(0xE6E6FA);
    
        public static readonly ColorRGB LavenderBlush = new ColorRGB(0xFFF0F5);
    
        public static readonly ColorRGB LawnGreen = new ColorRGB(0x7CFC00);
    
        public static readonly ColorRGB LemonChiffon = new ColorRGB(0xFFFACD);
    
        public static readonly ColorRGB LightBlue = new ColorRGB(0xADD8E6);
    
        public static readonly ColorRGB LightCoral = new ColorRGB(0xF08080);
    
        public static readonly ColorRGB LightCyan = new ColorRGB(0xE0FFFF);
    
        public static readonly ColorRGB LightGoldenrodYellow = new ColorRGB(0xFAFAD2);
    
        public static readonly ColorRGB LightGray = new ColorRGB(0xD3D3D3);
    
        public static readonly ColorRGB LightGreen = new ColorRGB(0x90EE90);
    
        public static readonly ColorRGB LightPink = new ColorRGB(0xFFB6C1);
    
        public static readonly ColorRGB LightSalmon = new ColorRGB(0xFFA07A);
    
        public static readonly ColorRGB LightSeaGreen = new ColorRGB(0x20B2AA);
    
        public static readonly ColorRGB LightSkyBlue = new ColorRGB(0x87CEFA);
    
        public static readonly ColorRGB LightSlateGray = new ColorRGB(0x778899);
    
        public static readonly ColorRGB LightSteelBlue = new ColorRGB(0xB0C4DE);
    
        public static readonly ColorRGB LightYellow = new ColorRGB(0xFFFFE0);
    
        public static readonly ColorRGB Lime = new ColorRGB(0x00FF00);
    
        public static readonly ColorRGB LimeGreen = new ColorRGB(0x32CD32);
    
        public static readonly ColorRGB Linen = new ColorRGB(0xFAF0E6);
    
        public static readonly ColorRGB Magenta = new ColorRGB(0xFF00FF);
    
        public static readonly ColorRGB Maroon = new ColorRGB(0x800000);
    
        public static readonly ColorRGB MediumAquamarine = new ColorRGB(0x66CDAA);
    
        public static readonly ColorRGB MediumBlue = new ColorRGB(0x0000CD);
    
        public static readonly ColorRGB MediumOrchid = new ColorRGB(0xBA55D3);
    
        public static readonly ColorRGB MediumPurple = new ColorRGB(0x9370DB);
    
        public static readonly ColorRGB MediumSeaGreen = new ColorRGB(0x3CB371);
    
        public static readonly ColorRGB MediumSlateBlue = new ColorRGB(0x7B68EE);
    
        public static readonly ColorRGB MediumSpringGreen = new ColorRGB(0x00FA9A);
    
        public static readonly ColorRGB MediumTurquoise = new ColorRGB(0x48D1CC);
    
        public static readonly ColorRGB MediumVioletRed = new ColorRGB(0xC71585);
    
        public static readonly ColorRGB MidnightBlue = new ColorRGB(0x191970);
    
        public static readonly ColorRGB MintCream = new ColorRGB(0xF5FFFA);
    
        public static readonly ColorRGB MistyRose = new ColorRGB(0xFFE4E1);
    
        public static readonly ColorRGB Moccasin = new ColorRGB(0xFFE4B5);
    
        public static readonly ColorRGB NavajoWhite = new ColorRGB(0xFFDEAD);
    
        public static readonly ColorRGB Navy = new ColorRGB(0x000080);
    
        public static readonly ColorRGB OldLace = new ColorRGB(0xFDF5E6);
    
        public static readonly ColorRGB Olive = new ColorRGB(0x808000);
    
        public static readonly ColorRGB OliveDrab = new ColorRGB(0x6B8E23);
    
        public static readonly ColorRGB Orange = new ColorRGB(0xFFA500);
    
        public static readonly ColorRGB OrangeRed = new ColorRGB(0xFF4500);
    
        public static readonly ColorRGB Orchid = new ColorRGB(0xDA70D6);
    
        public static readonly ColorRGB PaleGoldenrod = new ColorRGB(0xEEE8AA);
    
        public static readonly ColorRGB PaleGreen = new ColorRGB(0x98FB98);
    
        public static readonly ColorRGB PaleTurquoise = new ColorRGB(0xAFEEEE);
    
        public static readonly ColorRGB PaleVioletRed = new ColorRGB(0xDB7093);
    
        public static readonly ColorRGB PapayaWhip = new ColorRGB(0xFFEFD5);
    
        public static readonly ColorRGB PeachPuff = new ColorRGB(0xFFDAB9);
    
        public static readonly ColorRGB Peru = new ColorRGB(0xCD853F);
    
        public static readonly ColorRGB Pink = new ColorRGB(0xFFC0CB);
    
        public static readonly ColorRGB Plum = new ColorRGB(0xDDA0DD);
    
        public static readonly ColorRGB PowderBlue = new ColorRGB(0xB0E0E6);
    
        public static readonly ColorRGB Purple = new ColorRGB(0x800080);
    
        public static readonly ColorRGB Red = new ColorRGB(0xFF0000);
    
        public static readonly ColorRGB RosyBrown = new ColorRGB(0xBC8F8F);
    
        public static readonly ColorRGB RoyalBlue = new ColorRGB(0x4169E1);
    
        public static readonly ColorRGB SaddleBrown = new ColorRGB(0x8B4513);
    
        public static readonly ColorRGB Salmon = new ColorRGB(0xFA8072);
    
        public static readonly ColorRGB SandyBrown = new ColorRGB(0xF4A460);
    
        public static readonly ColorRGB SeaGreen = new ColorRGB(0x2E8B57);
    
        public static readonly ColorRGB SeaShell = new ColorRGB(0xFFF5EE);
    
        public static readonly ColorRGB Sienna = new ColorRGB(0xA0522D);
    
        public static readonly ColorRGB Silver = new ColorRGB(0xC0C0C0);
    
        public static readonly ColorRGB SkyBlue = new ColorRGB(0x87CEEB);
    
        public static readonly ColorRGB SlateBlue = new ColorRGB(0x6A5ACD);
    
        public static readonly ColorRGB SlateGray = new ColorRGB(0x708090);
    
        public static readonly ColorRGB Snow = new ColorRGB(0xFFFAFA);
    
        public static readonly ColorRGB SpringGreen = new ColorRGB(0x00FF7F);
    
        public static readonly ColorRGB SteelBlue = new ColorRGB(0x4682B4);
    
        public static readonly ColorRGB Tan = new ColorRGB(0xD2B48C);
    
        public static readonly ColorRGB Teal = new ColorRGB(0x008080);
    
        public static readonly ColorRGB Thistle = new ColorRGB(0xD8BFD8);
    
        public static readonly ColorRGB Tomato = new ColorRGB(0xFF6347);
    
        public static readonly ColorRGB Turquoise = new ColorRGB(0x40E0D0);
    
        public static readonly ColorRGB Violet = new ColorRGB(0xEE82EE);
    
        public static readonly ColorRGB Wheat = new ColorRGB(0xF5DEB3);
    
        public static readonly ColorRGB White = new ColorRGB(0xFFFFFF);
    
        public static readonly ColorRGB WhiteSmoke = new ColorRGB(0xF5F5F5);
    
        public static readonly ColorRGB Yellow = new ColorRGB(0xFFFF00);
    
        public static readonly ColorRGB YellowGreen = new ColorRGB(0x9ACD32);
    
    
    
        #endregion
    
        #region Members
     
        private readonly uint _rgb;
    
        #endregion
    
        #region Construction and conversion
    
     
        public ColorRGB(uint rgb)
        {
            _rgb = rgb & ((uint) 0xffffff);
        }
    
        public ColorRGB(byte r, byte g, byte b)
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

        public bool Equals(ColorRGB c)
        {
            return _rgb == c._rgb;
        }

        public override bool Equals(object obj)
        {
        
            var c = obj as ColorRGB?;

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

        public static bool operator ==(ColorRGB v, ColorRGB w)
        {
            return v.Equals(w);
        }

        public static bool operator !=(ColorRGB v, ColorRGB w)
        {
            return !v.Equals(w);
        }

        #endregion
    
        #region ToString
    
        public override string ToString()
        {
            return string.Format("ColorRGB(R={0}, G={1}, B={2})", R, G, B);
        }
    
        #endregion
    }
    // ###]
}

