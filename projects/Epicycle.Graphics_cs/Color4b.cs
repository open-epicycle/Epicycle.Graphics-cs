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
    // [### ColorN.cs.TEMPLATE> type = int8, channels = rgba


    public struct Color4b : IEquatable<Color4b>
    {
        #region consts
    
        public const byte MinChannelValue = 0;
        public const byte MaxChannelValue = ((byte) 0xff);
    
        #endregion

        #region Named colors
    
        public static readonly Color4b AliceBlue = (Color4b) Color3b.AliceBlue;
    
        public static readonly Color4b AntiqueWhite = (Color4b) Color3b.AntiqueWhite;
    
        public static readonly Color4b Aqua = (Color4b) Color3b.Aqua;
    
        public static readonly Color4b Aquamarine = (Color4b) Color3b.Aquamarine;
    
        public static readonly Color4b Azure = (Color4b) Color3b.Azure;
    
        public static readonly Color4b Beige = (Color4b) Color3b.Beige;
    
        public static readonly Color4b Bisque = (Color4b) Color3b.Bisque;
    
        public static readonly Color4b Black = (Color4b) Color3b.Black;
    
        public static readonly Color4b BlanchedAlmond = (Color4b) Color3b.BlanchedAlmond;
    
        public static readonly Color4b Blue = (Color4b) Color3b.Blue;
    
        public static readonly Color4b BlueViolet = (Color4b) Color3b.BlueViolet;
    
        public static readonly Color4b Brown = (Color4b) Color3b.Brown;
    
        public static readonly Color4b BurlyWood = (Color4b) Color3b.BurlyWood;
    
        public static readonly Color4b CadetBlue = (Color4b) Color3b.CadetBlue;
    
        public static readonly Color4b Chartreuse = (Color4b) Color3b.Chartreuse;
    
        public static readonly Color4b Chocolate = (Color4b) Color3b.Chocolate;
    
        public static readonly Color4b Coral = (Color4b) Color3b.Coral;
    
        public static readonly Color4b CornflowerBlue = (Color4b) Color3b.CornflowerBlue;
    
        public static readonly Color4b Cornsilk = (Color4b) Color3b.Cornsilk;
    
        public static readonly Color4b Crimson = (Color4b) Color3b.Crimson;
    
        public static readonly Color4b Cyan = (Color4b) Color3b.Cyan;
    
        public static readonly Color4b DarkBlue = (Color4b) Color3b.DarkBlue;
    
        public static readonly Color4b DarkCyan = (Color4b) Color3b.DarkCyan;
    
        public static readonly Color4b DarkGoldenrod = (Color4b) Color3b.DarkGoldenrod;
    
        public static readonly Color4b DarkGray = (Color4b) Color3b.DarkGray;
    
        public static readonly Color4b DarkGreen = (Color4b) Color3b.DarkGreen;
    
        public static readonly Color4b DarkKhaki = (Color4b) Color3b.DarkKhaki;
    
        public static readonly Color4b DarkMagenta = (Color4b) Color3b.DarkMagenta;
    
        public static readonly Color4b DarkOliveGreen = (Color4b) Color3b.DarkOliveGreen;
    
        public static readonly Color4b DarkOrange = (Color4b) Color3b.DarkOrange;
    
        public static readonly Color4b DarkOrchid = (Color4b) Color3b.DarkOrchid;
    
        public static readonly Color4b DarkRed = (Color4b) Color3b.DarkRed;
    
        public static readonly Color4b DarkSalmon = (Color4b) Color3b.DarkSalmon;
    
        public static readonly Color4b DarkSeaGreen = (Color4b) Color3b.DarkSeaGreen;
    
        public static readonly Color4b DarkSlateBlue = (Color4b) Color3b.DarkSlateBlue;
    
        public static readonly Color4b DarkSlateGray = (Color4b) Color3b.DarkSlateGray;
    
        public static readonly Color4b DarkTurquoise = (Color4b) Color3b.DarkTurquoise;
    
        public static readonly Color4b DarkViolet = (Color4b) Color3b.DarkViolet;
    
        public static readonly Color4b DeepPink = (Color4b) Color3b.DeepPink;
    
        public static readonly Color4b DeepSkyBlue = (Color4b) Color3b.DeepSkyBlue;
    
        public static readonly Color4b DimGray = (Color4b) Color3b.DimGray;
    
        public static readonly Color4b DodgerBlue = (Color4b) Color3b.DodgerBlue;
    
        public static readonly Color4b Firebrick = (Color4b) Color3b.Firebrick;
    
        public static readonly Color4b FloralWhite = (Color4b) Color3b.FloralWhite;
    
        public static readonly Color4b ForestGreen = (Color4b) Color3b.ForestGreen;
    
        public static readonly Color4b Fuchsia = (Color4b) Color3b.Fuchsia;
    
        public static readonly Color4b Gainsboro = (Color4b) Color3b.Gainsboro;
    
        public static readonly Color4b GhostWhite = (Color4b) Color3b.GhostWhite;
    
        public static readonly Color4b Gold = (Color4b) Color3b.Gold;
    
        public static readonly Color4b Goldenrod = (Color4b) Color3b.Goldenrod;
    
        public static readonly Color4b Gray = (Color4b) Color3b.Gray;
    
        public static readonly Color4b Green = (Color4b) Color3b.Green;
    
        public static readonly Color4b GreenYellow = (Color4b) Color3b.GreenYellow;
    
        public static readonly Color4b Honeydew = (Color4b) Color3b.Honeydew;
    
        public static readonly Color4b HotPink = (Color4b) Color3b.HotPink;
    
        public static readonly Color4b IndianRed = (Color4b) Color3b.IndianRed;
    
        public static readonly Color4b Indigo = (Color4b) Color3b.Indigo;
    
        public static readonly Color4b Ivory = (Color4b) Color3b.Ivory;
    
        public static readonly Color4b Khaki = (Color4b) Color3b.Khaki;
    
        public static readonly Color4b Lavender = (Color4b) Color3b.Lavender;
    
        public static readonly Color4b LavenderBlush = (Color4b) Color3b.LavenderBlush;
    
        public static readonly Color4b LawnGreen = (Color4b) Color3b.LawnGreen;
    
        public static readonly Color4b LemonChiffon = (Color4b) Color3b.LemonChiffon;
    
        public static readonly Color4b LightBlue = (Color4b) Color3b.LightBlue;
    
        public static readonly Color4b LightCoral = (Color4b) Color3b.LightCoral;
    
        public static readonly Color4b LightCyan = (Color4b) Color3b.LightCyan;
    
        public static readonly Color4b LightGoldenrodYellow = (Color4b) Color3b.LightGoldenrodYellow;
    
        public static readonly Color4b LightGray = (Color4b) Color3b.LightGray;
    
        public static readonly Color4b LightGreen = (Color4b) Color3b.LightGreen;
    
        public static readonly Color4b LightPink = (Color4b) Color3b.LightPink;
    
        public static readonly Color4b LightSalmon = (Color4b) Color3b.LightSalmon;
    
        public static readonly Color4b LightSeaGreen = (Color4b) Color3b.LightSeaGreen;
    
        public static readonly Color4b LightSkyBlue = (Color4b) Color3b.LightSkyBlue;
    
        public static readonly Color4b LightSlateGray = (Color4b) Color3b.LightSlateGray;
    
        public static readonly Color4b LightSteelBlue = (Color4b) Color3b.LightSteelBlue;
    
        public static readonly Color4b LightYellow = (Color4b) Color3b.LightYellow;
    
        public static readonly Color4b Lime = (Color4b) Color3b.Lime;
    
        public static readonly Color4b LimeGreen = (Color4b) Color3b.LimeGreen;
    
        public static readonly Color4b Linen = (Color4b) Color3b.Linen;
    
        public static readonly Color4b Magenta = (Color4b) Color3b.Magenta;
    
        public static readonly Color4b Maroon = (Color4b) Color3b.Maroon;
    
        public static readonly Color4b MediumAquamarine = (Color4b) Color3b.MediumAquamarine;
    
        public static readonly Color4b MediumBlue = (Color4b) Color3b.MediumBlue;
    
        public static readonly Color4b MediumOrchid = (Color4b) Color3b.MediumOrchid;
    
        public static readonly Color4b MediumPurple = (Color4b) Color3b.MediumPurple;
    
        public static readonly Color4b MediumSeaGreen = (Color4b) Color3b.MediumSeaGreen;
    
        public static readonly Color4b MediumSlateBlue = (Color4b) Color3b.MediumSlateBlue;
    
        public static readonly Color4b MediumSpringGreen = (Color4b) Color3b.MediumSpringGreen;
    
        public static readonly Color4b MediumTurquoise = (Color4b) Color3b.MediumTurquoise;
    
        public static readonly Color4b MediumVioletRed = (Color4b) Color3b.MediumVioletRed;
    
        public static readonly Color4b MidnightBlue = (Color4b) Color3b.MidnightBlue;
    
        public static readonly Color4b MintCream = (Color4b) Color3b.MintCream;
    
        public static readonly Color4b MistyRose = (Color4b) Color3b.MistyRose;
    
        public static readonly Color4b Moccasin = (Color4b) Color3b.Moccasin;
    
        public static readonly Color4b NavajoWhite = (Color4b) Color3b.NavajoWhite;
    
        public static readonly Color4b Navy = (Color4b) Color3b.Navy;
    
        public static readonly Color4b OldLace = (Color4b) Color3b.OldLace;
    
        public static readonly Color4b Olive = (Color4b) Color3b.Olive;
    
        public static readonly Color4b OliveDrab = (Color4b) Color3b.OliveDrab;
    
        public static readonly Color4b Orange = (Color4b) Color3b.Orange;
    
        public static readonly Color4b OrangeRed = (Color4b) Color3b.OrangeRed;
    
        public static readonly Color4b Orchid = (Color4b) Color3b.Orchid;
    
        public static readonly Color4b PaleGoldenrod = (Color4b) Color3b.PaleGoldenrod;
    
        public static readonly Color4b PaleGreen = (Color4b) Color3b.PaleGreen;
    
        public static readonly Color4b PaleTurquoise = (Color4b) Color3b.PaleTurquoise;
    
        public static readonly Color4b PaleVioletRed = (Color4b) Color3b.PaleVioletRed;
    
        public static readonly Color4b PapayaWhip = (Color4b) Color3b.PapayaWhip;
    
        public static readonly Color4b PeachPuff = (Color4b) Color3b.PeachPuff;
    
        public static readonly Color4b Peru = (Color4b) Color3b.Peru;
    
        public static readonly Color4b Pink = (Color4b) Color3b.Pink;
    
        public static readonly Color4b Plum = (Color4b) Color3b.Plum;
    
        public static readonly Color4b PowderBlue = (Color4b) Color3b.PowderBlue;
    
        public static readonly Color4b Purple = (Color4b) Color3b.Purple;
    
        public static readonly Color4b Red = (Color4b) Color3b.Red;
    
        public static readonly Color4b RosyBrown = (Color4b) Color3b.RosyBrown;
    
        public static readonly Color4b RoyalBlue = (Color4b) Color3b.RoyalBlue;
    
        public static readonly Color4b SaddleBrown = (Color4b) Color3b.SaddleBrown;
    
        public static readonly Color4b Salmon = (Color4b) Color3b.Salmon;
    
        public static readonly Color4b SandyBrown = (Color4b) Color3b.SandyBrown;
    
        public static readonly Color4b SeaGreen = (Color4b) Color3b.SeaGreen;
    
        public static readonly Color4b SeaShell = (Color4b) Color3b.SeaShell;
    
        public static readonly Color4b Sienna = (Color4b) Color3b.Sienna;
    
        public static readonly Color4b Silver = (Color4b) Color3b.Silver;
    
        public static readonly Color4b SkyBlue = (Color4b) Color3b.SkyBlue;
    
        public static readonly Color4b SlateBlue = (Color4b) Color3b.SlateBlue;
    
        public static readonly Color4b SlateGray = (Color4b) Color3b.SlateGray;
    
        public static readonly Color4b Snow = (Color4b) Color3b.Snow;
    
        public static readonly Color4b SpringGreen = (Color4b) Color3b.SpringGreen;
    
        public static readonly Color4b SteelBlue = (Color4b) Color3b.SteelBlue;
    
        public static readonly Color4b Tan = (Color4b) Color3b.Tan;
    
        public static readonly Color4b Teal = (Color4b) Color3b.Teal;
    
        public static readonly Color4b Thistle = (Color4b) Color3b.Thistle;
    
        public static readonly Color4b Tomato = (Color4b) Color3b.Tomato;
    
        public static readonly Color4b Turquoise = (Color4b) Color3b.Turquoise;
    
        public static readonly Color4b Violet = (Color4b) Color3b.Violet;
    
        public static readonly Color4b Wheat = (Color4b) Color3b.Wheat;
    
        public static readonly Color4b White = (Color4b) Color3b.White;
    
        public static readonly Color4b WhiteSmoke = (Color4b) Color3b.WhiteSmoke;
    
        public static readonly Color4b Yellow = (Color4b) Color3b.Yellow;
    
        public static readonly Color4b YellowGreen = (Color4b) Color3b.YellowGreen;
    
     
        public static readonly Color4b Transparent = new Color4b(0x00000000);
    
    
        #endregion
    
        #region Members
     
        private readonly uint _argb;
    
        #endregion
    
        #region Construction and conversion
    
     
        public Color4b(uint argb)
        {
            _argb = argb & ((uint) 0xffffffff);
        }
    
        public Color4b(byte r, byte g, byte b, byte a)
        {
            _argb = ((uint) a << 24) | ((uint) r << 16) | ((uint) g << 8) | ((uint) b << 0);
        }
    
    
     
        public Color4b(Color3b rgb, byte a = MaxChannelValue)
            : this(rgb.R, rgb.G, rgb.B, a) { }
    
    
    
        public static explicit operator Color4b(Color3b c)
        {
            return new Color4b(c);
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
    
    
        public Color3b RGB
        {
            get { return new Color3b(R, G, B); }
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
    
        public Color4b ChangeAlpha(byte a)
        {
            return new Color4b(R, G, B, a);
        }
    
        #endregion
    
        #region Equality & HashCode

        public bool Equals(Color4b c)
        {
            return _argb == c._argb;
        }

        public override bool Equals(object obj)
        {
        
            var c = obj as Color4b?;

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

        public static bool operator ==(Color4b v, Color4b w)
        {
            return v.Equals(w);
        }

        public static bool operator !=(Color4b v, Color4b w)
        {
            return !v.Equals(w);
        }

        #endregion
    
        #region ToString
    
        public override string ToString()
        {
            return string.Format("Color4b(R={0}, G={1}, B={2}, A={3})", R, G, B, A);
        }
    
        #endregion
    }
    // ###]
}

