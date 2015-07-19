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

namespace Epicycle.Graphics.Color
{
    // [### ColorINT.cs.TEMPLATE> type = int12, channels = rgba


    public struct ColorRGBA12 : IEquatable<ColorRGBA12>
    {
        #region consts
    
        public const ushort MinChannelValue = 0;
        public const ushort MaxChannelValue = ((ushort) 0xfff);
    
        #endregion

        #region Named colors
     
        public static readonly ColorRGBA12 Transparent = new ColorRGBA12(0, 0, 0, 0);
    
    
        #endregion
    
        #region Members
     
        private readonly ulong _argb;
    
        #endregion
    
        #region Construction and conversion
    
     
        public ColorRGBA12(ulong argb)
        {
            _argb = argb & ((ulong) 0xffffffffffff);
        }
    
        public ColorRGBA12(ushort r, ushort g, ushort b, ushort a)
        {
            _argb = ((ulong) a << 36) | ((ulong) r << 24) | ((ulong) g << 12) | ((ulong) b << 0);
        }
    
    
     
        public ColorRGBA12(ColorRGB12 rgb, ushort a = MaxChannelValue)
            : this(rgb.R, rgb.G, rgb.B, a) { }
    
    
    
        public static explicit operator ColorRGBA12(ColorRGB12 c)
        {
            return new ColorRGBA12(c);
        }
    
    
        #endregion
    
        #region Properties
    
    
        public ushort R
        {
            get { return (ushort) ((_argb >> 24) & MaxChannelValue); }
        }
    
        public ushort G
        {
            get { return (ushort) ((_argb >> 12) & MaxChannelValue); }
        }
    
        public ushort B
        {
            get { return (ushort) ((_argb >> 0) & MaxChannelValue); }
        }
    
        public ushort A
        {
            get { return (ushort) ((_argb >> 36) & MaxChannelValue); }
        }
    
    
        public ColorRGB12 RGB
        {
            get { return new ColorRGB12(R, G, B); }
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
    
        public ColorRGBA12 ChangeAlpha(ushort a)
        {
            return new ColorRGBA12(R, G, B, a);
        }
    
        #endregion
    
        #region Equality & HashCode

        public bool Equals(ColorRGBA12 c)
        {
            return _argb == c._argb;
        }

        public override bool Equals(object obj)
        {
        
            var c = obj as ColorRGBA12?;

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

        public static bool operator ==(ColorRGBA12 v, ColorRGBA12 w)
        {
            return v.Equals(w);
        }

        public static bool operator !=(ColorRGBA12 v, ColorRGBA12 w)
        {
            return !v.Equals(w);
        }

        #endregion
    
        #region ToString
    
        public override string ToString()
        {
            return string.Format("ColorRGBA12(R={0}, G={1}, B={2}, A={3})", R, G, B, A);
        }
    
        #endregion
    }
    // ###]
}

