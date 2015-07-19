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
    // [### ColorINT.cs.TEMPLATE> type = int8, channels = rgba


    public struct ColorRGBA : IEquatable<ColorRGBA>
    {
        #region consts
    
        public const byte MinChannelValue = 0;
        public const byte MaxChannelValue = ((byte) 0xff);
    
        #endregion

        #region Named colors
     
    
        public static readonly ColorRGBA AliceBlue = (ColorRGBA) ColorRGB.AliceBlue;
    
        public static readonly ColorRGBA AntiqueWhite = (ColorRGBA) ColorRGB.AntiqueWhite;
    
        public static readonly ColorRGBA Aqua = (ColorRGBA) ColorRGB.Aqua;
    
        public static readonly ColorRGBA Aquamarine = (ColorRGBA) ColorRGB.Aquamarine;
    
        public static readonly ColorRGBA Azure = (ColorRGBA) ColorRGB.Azure;
    
        public static readonly ColorRGBA Beige = (ColorRGBA) ColorRGB.Beige;
    
        public static readonly ColorRGBA Bisque = (ColorRGBA) ColorRGB.Bisque;
    
        public static readonly ColorRGBA Black = (ColorRGBA) ColorRGB.Black;
    
        public static readonly ColorRGBA BlanchedAlmond = (ColorRGBA) ColorRGB.BlanchedAlmond;
    
        public static readonly ColorRGBA Blue = (ColorRGBA) ColorRGB.Blue;
    
        public static readonly ColorRGBA BlueViolet = (ColorRGBA) ColorRGB.BlueViolet;
    
        public static readonly ColorRGBA Brown = (ColorRGBA) ColorRGB.Brown;
    
        public static readonly ColorRGBA BurlyWood = (ColorRGBA) ColorRGB.BurlyWood;
    
        public static readonly ColorRGBA CadetBlue = (ColorRGBA) ColorRGB.CadetBlue;
    
        public static readonly ColorRGBA Chartreuse = (ColorRGBA) ColorRGB.Chartreuse;
    
        public static readonly ColorRGBA Chocolate = (ColorRGBA) ColorRGB.Chocolate;
    
        public static readonly ColorRGBA Coral = (ColorRGBA) ColorRGB.Coral;
    
        public static readonly ColorRGBA CornflowerBlue = (ColorRGBA) ColorRGB.CornflowerBlue;
    
        public static readonly ColorRGBA Cornsilk = (ColorRGBA) ColorRGB.Cornsilk;
    
        public static readonly ColorRGBA Crimson = (ColorRGBA) ColorRGB.Crimson;
    
        public static readonly ColorRGBA Cyan = (ColorRGBA) ColorRGB.Cyan;
    
        public static readonly ColorRGBA DarkBlue = (ColorRGBA) ColorRGB.DarkBlue;
    
        public static readonly ColorRGBA DarkCyan = (ColorRGBA) ColorRGB.DarkCyan;
    
        public static readonly ColorRGBA DarkGoldenrod = (ColorRGBA) ColorRGB.DarkGoldenrod;
    
        public static readonly ColorRGBA DarkGray = (ColorRGBA) ColorRGB.DarkGray;
    
        public static readonly ColorRGBA DarkGreen = (ColorRGBA) ColorRGB.DarkGreen;
    
        public static readonly ColorRGBA DarkKhaki = (ColorRGBA) ColorRGB.DarkKhaki;
    
        public static readonly ColorRGBA DarkMagenta = (ColorRGBA) ColorRGB.DarkMagenta;
    
        public static readonly ColorRGBA DarkOliveGreen = (ColorRGBA) ColorRGB.DarkOliveGreen;
    
        public static readonly ColorRGBA DarkOrange = (ColorRGBA) ColorRGB.DarkOrange;
    
        public static readonly ColorRGBA DarkOrchid = (ColorRGBA) ColorRGB.DarkOrchid;
    
        public static readonly ColorRGBA DarkRed = (ColorRGBA) ColorRGB.DarkRed;
    
        public static readonly ColorRGBA DarkSalmon = (ColorRGBA) ColorRGB.DarkSalmon;
    
        public static readonly ColorRGBA DarkSeaGreen = (ColorRGBA) ColorRGB.DarkSeaGreen;
    
        public static readonly ColorRGBA DarkSlateBlue = (ColorRGBA) ColorRGB.DarkSlateBlue;
    
        public static readonly ColorRGBA DarkSlateGray = (ColorRGBA) ColorRGB.DarkSlateGray;
    
        public static readonly ColorRGBA DarkTurquoise = (ColorRGBA) ColorRGB.DarkTurquoise;
    
        public static readonly ColorRGBA DarkViolet = (ColorRGBA) ColorRGB.DarkViolet;
    
        public static readonly ColorRGBA DeepPink = (ColorRGBA) ColorRGB.DeepPink;
    
        public static readonly ColorRGBA DeepSkyBlue = (ColorRGBA) ColorRGB.DeepSkyBlue;
    
        public static readonly ColorRGBA DimGray = (ColorRGBA) ColorRGB.DimGray;
    
        public static readonly ColorRGBA DodgerBlue = (ColorRGBA) ColorRGB.DodgerBlue;
    
        public static readonly ColorRGBA Firebrick = (ColorRGBA) ColorRGB.Firebrick;
    
        public static readonly ColorRGBA FloralWhite = (ColorRGBA) ColorRGB.FloralWhite;
    
        public static readonly ColorRGBA ForestGreen = (ColorRGBA) ColorRGB.ForestGreen;
    
        public static readonly ColorRGBA Fuchsia = (ColorRGBA) ColorRGB.Fuchsia;
    
        public static readonly ColorRGBA Gainsboro = (ColorRGBA) ColorRGB.Gainsboro;
    
        public static readonly ColorRGBA GhostWhite = (ColorRGBA) ColorRGB.GhostWhite;
    
        public static readonly ColorRGBA Gold = (ColorRGBA) ColorRGB.Gold;
    
        public static readonly ColorRGBA Goldenrod = (ColorRGBA) ColorRGB.Goldenrod;
    
        public static readonly ColorRGBA Gray = (ColorRGBA) ColorRGB.Gray;
    
        public static readonly ColorRGBA Green = (ColorRGBA) ColorRGB.Green;
    
        public static readonly ColorRGBA GreenYellow = (ColorRGBA) ColorRGB.GreenYellow;
    
        public static readonly ColorRGBA Honeydew = (ColorRGBA) ColorRGB.Honeydew;
    
        public static readonly ColorRGBA HotPink = (ColorRGBA) ColorRGB.HotPink;
    
        public static readonly ColorRGBA IndianRed = (ColorRGBA) ColorRGB.IndianRed;
    
        public static readonly ColorRGBA Indigo = (ColorRGBA) ColorRGB.Indigo;
    
        public static readonly ColorRGBA Ivory = (ColorRGBA) ColorRGB.Ivory;
    
        public static readonly ColorRGBA Khaki = (ColorRGBA) ColorRGB.Khaki;
    
        public static readonly ColorRGBA Lavender = (ColorRGBA) ColorRGB.Lavender;
    
        public static readonly ColorRGBA LavenderBlush = (ColorRGBA) ColorRGB.LavenderBlush;
    
        public static readonly ColorRGBA LawnGreen = (ColorRGBA) ColorRGB.LawnGreen;
    
        public static readonly ColorRGBA LemonChiffon = (ColorRGBA) ColorRGB.LemonChiffon;
    
        public static readonly ColorRGBA LightBlue = (ColorRGBA) ColorRGB.LightBlue;
    
        public static readonly ColorRGBA LightCoral = (ColorRGBA) ColorRGB.LightCoral;
    
        public static readonly ColorRGBA LightCyan = (ColorRGBA) ColorRGB.LightCyan;
    
        public static readonly ColorRGBA LightGoldenrodYellow = (ColorRGBA) ColorRGB.LightGoldenrodYellow;
    
        public static readonly ColorRGBA LightGray = (ColorRGBA) ColorRGB.LightGray;
    
        public static readonly ColorRGBA LightGreen = (ColorRGBA) ColorRGB.LightGreen;
    
        public static readonly ColorRGBA LightPink = (ColorRGBA) ColorRGB.LightPink;
    
        public static readonly ColorRGBA LightSalmon = (ColorRGBA) ColorRGB.LightSalmon;
    
        public static readonly ColorRGBA LightSeaGreen = (ColorRGBA) ColorRGB.LightSeaGreen;
    
        public static readonly ColorRGBA LightSkyBlue = (ColorRGBA) ColorRGB.LightSkyBlue;
    
        public static readonly ColorRGBA LightSlateGray = (ColorRGBA) ColorRGB.LightSlateGray;
    
        public static readonly ColorRGBA LightSteelBlue = (ColorRGBA) ColorRGB.LightSteelBlue;
    
        public static readonly ColorRGBA LightYellow = (ColorRGBA) ColorRGB.LightYellow;
    
        public static readonly ColorRGBA Lime = (ColorRGBA) ColorRGB.Lime;
    
        public static readonly ColorRGBA LimeGreen = (ColorRGBA) ColorRGB.LimeGreen;
    
        public static readonly ColorRGBA Linen = (ColorRGBA) ColorRGB.Linen;
    
        public static readonly ColorRGBA Magenta = (ColorRGBA) ColorRGB.Magenta;
    
        public static readonly ColorRGBA Maroon = (ColorRGBA) ColorRGB.Maroon;
    
        public static readonly ColorRGBA MediumAquamarine = (ColorRGBA) ColorRGB.MediumAquamarine;
    
        public static readonly ColorRGBA MediumBlue = (ColorRGBA) ColorRGB.MediumBlue;
    
        public static readonly ColorRGBA MediumOrchid = (ColorRGBA) ColorRGB.MediumOrchid;
    
        public static readonly ColorRGBA MediumPurple = (ColorRGBA) ColorRGB.MediumPurple;
    
        public static readonly ColorRGBA MediumSeaGreen = (ColorRGBA) ColorRGB.MediumSeaGreen;
    
        public static readonly ColorRGBA MediumSlateBlue = (ColorRGBA) ColorRGB.MediumSlateBlue;
    
        public static readonly ColorRGBA MediumSpringGreen = (ColorRGBA) ColorRGB.MediumSpringGreen;
    
        public static readonly ColorRGBA MediumTurquoise = (ColorRGBA) ColorRGB.MediumTurquoise;
    
        public static readonly ColorRGBA MediumVioletRed = (ColorRGBA) ColorRGB.MediumVioletRed;
    
        public static readonly ColorRGBA MidnightBlue = (ColorRGBA) ColorRGB.MidnightBlue;
    
        public static readonly ColorRGBA MintCream = (ColorRGBA) ColorRGB.MintCream;
    
        public static readonly ColorRGBA MistyRose = (ColorRGBA) ColorRGB.MistyRose;
    
        public static readonly ColorRGBA Moccasin = (ColorRGBA) ColorRGB.Moccasin;
    
        public static readonly ColorRGBA NavajoWhite = (ColorRGBA) ColorRGB.NavajoWhite;
    
        public static readonly ColorRGBA Navy = (ColorRGBA) ColorRGB.Navy;
    
        public static readonly ColorRGBA OldLace = (ColorRGBA) ColorRGB.OldLace;
    
        public static readonly ColorRGBA Olive = (ColorRGBA) ColorRGB.Olive;
    
        public static readonly ColorRGBA OliveDrab = (ColorRGBA) ColorRGB.OliveDrab;
    
        public static readonly ColorRGBA Orange = (ColorRGBA) ColorRGB.Orange;
    
        public static readonly ColorRGBA OrangeRed = (ColorRGBA) ColorRGB.OrangeRed;
    
        public static readonly ColorRGBA Orchid = (ColorRGBA) ColorRGB.Orchid;
    
        public static readonly ColorRGBA PaleGoldenrod = (ColorRGBA) ColorRGB.PaleGoldenrod;
    
        public static readonly ColorRGBA PaleGreen = (ColorRGBA) ColorRGB.PaleGreen;
    
        public static readonly ColorRGBA PaleTurquoise = (ColorRGBA) ColorRGB.PaleTurquoise;
    
        public static readonly ColorRGBA PaleVioletRed = (ColorRGBA) ColorRGB.PaleVioletRed;
    
        public static readonly ColorRGBA PapayaWhip = (ColorRGBA) ColorRGB.PapayaWhip;
    
        public static readonly ColorRGBA PeachPuff = (ColorRGBA) ColorRGB.PeachPuff;
    
        public static readonly ColorRGBA Peru = (ColorRGBA) ColorRGB.Peru;
    
        public static readonly ColorRGBA Pink = (ColorRGBA) ColorRGB.Pink;
    
        public static readonly ColorRGBA Plum = (ColorRGBA) ColorRGB.Plum;
    
        public static readonly ColorRGBA PowderBlue = (ColorRGBA) ColorRGB.PowderBlue;
    
        public static readonly ColorRGBA Purple = (ColorRGBA) ColorRGB.Purple;
    
        public static readonly ColorRGBA Red = (ColorRGBA) ColorRGB.Red;
    
        public static readonly ColorRGBA RosyBrown = (ColorRGBA) ColorRGB.RosyBrown;
    
        public static readonly ColorRGBA RoyalBlue = (ColorRGBA) ColorRGB.RoyalBlue;
    
        public static readonly ColorRGBA SaddleBrown = (ColorRGBA) ColorRGB.SaddleBrown;
    
        public static readonly ColorRGBA Salmon = (ColorRGBA) ColorRGB.Salmon;
    
        public static readonly ColorRGBA SandyBrown = (ColorRGBA) ColorRGB.SandyBrown;
    
        public static readonly ColorRGBA SeaGreen = (ColorRGBA) ColorRGB.SeaGreen;
    
        public static readonly ColorRGBA SeaShell = (ColorRGBA) ColorRGB.SeaShell;
    
        public static readonly ColorRGBA Sienna = (ColorRGBA) ColorRGB.Sienna;
    
        public static readonly ColorRGBA Silver = (ColorRGBA) ColorRGB.Silver;
    
        public static readonly ColorRGBA SkyBlue = (ColorRGBA) ColorRGB.SkyBlue;
    
        public static readonly ColorRGBA SlateBlue = (ColorRGBA) ColorRGB.SlateBlue;
    
        public static readonly ColorRGBA SlateGray = (ColorRGBA) ColorRGB.SlateGray;
    
        public static readonly ColorRGBA Snow = (ColorRGBA) ColorRGB.Snow;
    
        public static readonly ColorRGBA SpringGreen = (ColorRGBA) ColorRGB.SpringGreen;
    
        public static readonly ColorRGBA SteelBlue = (ColorRGBA) ColorRGB.SteelBlue;
    
        public static readonly ColorRGBA Tan = (ColorRGBA) ColorRGB.Tan;
    
        public static readonly ColorRGBA Teal = (ColorRGBA) ColorRGB.Teal;
    
        public static readonly ColorRGBA Thistle = (ColorRGBA) ColorRGB.Thistle;
    
        public static readonly ColorRGBA Tomato = (ColorRGBA) ColorRGB.Tomato;
    
        public static readonly ColorRGBA Turquoise = (ColorRGBA) ColorRGB.Turquoise;
    
        public static readonly ColorRGBA Violet = (ColorRGBA) ColorRGB.Violet;
    
        public static readonly ColorRGBA Wheat = (ColorRGBA) ColorRGB.Wheat;
    
        public static readonly ColorRGBA White = (ColorRGBA) ColorRGB.White;
    
        public static readonly ColorRGBA WhiteSmoke = (ColorRGBA) ColorRGB.WhiteSmoke;
    
        public static readonly ColorRGBA Yellow = (ColorRGBA) ColorRGB.Yellow;
    
        public static readonly ColorRGBA YellowGreen = (ColorRGBA) ColorRGB.YellowGreen;
    
     
        public static readonly ColorRGBA Transparent = new ColorRGBA(0, 0, 0, 0);
    
    
        #endregion
    
        #region Members
     
        private readonly uint _argb;
    
        #endregion
    
        #region Construction and conversion
    
     
        public ColorRGBA(uint argb)
        {
            _argb = argb & ((uint) 0xffffffff);
        }
    
        public ColorRGBA(byte r, byte g, byte b, byte a)
        {
            _argb = ((uint) a << 24) | ((uint) r << 16) | ((uint) g << 8) | ((uint) b << 0);
        }
    
    
     
        public ColorRGBA(ColorRGB rgb, byte a = MaxChannelValue)
            : this(rgb.R, rgb.G, rgb.B, a) { }
    
    
    
        public static explicit operator ColorRGBA(ColorRGB c)
        {
            return new ColorRGBA(c);
        }
    
    
        #endregion
    
        #region Properties
    
    
        public byte R
        {
            get { return (byte) ((_argb >> 16) & MaxChannelValue); }
        }
    
        public byte G
        {
            get { return (byte) ((_argb >> 8) & MaxChannelValue); }
        }
    
        public byte B
        {
            get { return (byte) ((_argb >> 0) & MaxChannelValue); }
        }
    
        public byte A
        {
            get { return (byte) ((_argb >> 24) & MaxChannelValue); }
        }
    
    
        public ColorRGB RGB
        {
            get { return new ColorRGB(R, G, B); }
        }
    
        public bool IsTransparent
        {
            get { return A <= MinChannelValue; }
        }
     
        public bool IsOpaque
        {
            get { return A >= MaxChannelValue; }
        }
    
        public bool IsTranslucent
        {
            get { return !IsTransparent && !IsOpaque; }
        }
    
        #endregion
    
        #region Mutation
    
        public ColorRGBA ChangeAlpha(byte a)
        {
            return new ColorRGBA(R, G, B, a);
        }
    
        #endregion
    
        #region Equality & HashCode

        public bool Equals(ColorRGBA c)
        {
            return _argb == c._argb;
        }

        public override bool Equals(object obj)
        {
        
            var c = obj as ColorRGBA?;

            if(!c.HasValue)
            {
                return false;
            }

            return Equals(c.Value);
        
        }

        public override int GetHashCode()
        {
            return _argb.GetHashCode();
        }

        public static bool operator ==(ColorRGBA v, ColorRGBA w)
        {
            return v.Equals(w);
        }

        public static bool operator !=(ColorRGBA v, ColorRGBA w)
        {
            return !v.Equals(w);
        }

        #endregion
    
        #region ToString
    
        public override string ToString()
        {
            return string.Format("ColorRGBA(R={0}, G={1}, B={2}, A={3})", R, G, B, A);
        }
    
        #endregion
    }
    // ###]
}

