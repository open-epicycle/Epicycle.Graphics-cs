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
    // [### ColorINT.cs.TEMPLATE> type = int16, channels = rgba


    public struct ColorRGBA16 : IEquatable<ColorRGBA16>
    {
        #region consts
    
        public const ushort MinChannelValue = 0;
        public const ushort MaxChannelValue = ((ushort) 0xffff);
    
        #endregion

        #region Named colors
     
        public static readonly ColorRGBA16 Transparent = new ColorRGBA16(0, 0, 0, 0);
    
    
        #endregion
    
        #region Members
     
        private readonly ulong _argb;
    
        #endregion
    
        #region Construction and conversion
    
     
        public ColorRGBA16(ulong argb)
        {
            _argb = argb & ((ulong) 0xffffffffffffffff);
        }
    
        public ColorRGBA16(ushort r, ushort g, ushort b, ushort a)
        {
            _argb = ((ulong) a << 48) | ((ulong) r << 32) | ((ulong) g << 16) | ((ulong) b << 0);
        }
    
    
     
        public ColorRGBA16(ColorRGB16 rgb, ushort a = MaxChannelValue)
            : this(rgb.R, rgb.G, rgb.B, a) { }
    
    
    
        public static explicit operator ColorRGBA16(ColorRGB16 c)
        {
            return new ColorRGBA16(c);
        }
    
    
        #endregion
    
        #region Properties
    
    
        public ushort R
        {
            get { return (ushort) ((_argb >> 32) & MaxChannelValue); }
        }
    
        public ushort G
        {
            get { return (ushort) ((_argb >> 16) & MaxChannelValue); }
        }
    
        public ushort B
        {
            get { return (ushort) ((_argb >> 0) & MaxChannelValue); }
        }
    
        public ushort A
        {
            get { return (ushort) ((_argb >> 48) & MaxChannelValue); }
        }
    
    
        public ColorRGB16 RGB
        {
            get { return new ColorRGB16(R, G, B); }
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
    
        public ColorRGBA16 ChangeAlpha(ushort a)
        {
            return new ColorRGBA16(R, G, B, a);
        }
    
        #endregion
    
        #region Equality & HashCode

        public bool Equals(ColorRGBA16 c)
        {
            return _argb == c._argb;
        }

        public override bool Equals(object obj)
        {
        
            var c = obj as ColorRGBA16?;

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

        public static bool operator ==(ColorRGBA16 v, ColorRGBA16 w)
        {
            return v.Equals(w);
        }

        public static bool operator !=(ColorRGBA16 v, ColorRGBA16 w)
        {
            return !v.Equals(w);
        }

        #endregion
    
        #region ToString
    
        public override string ToString()
        {
            return string.Format("ColorRGBA16(R={0}, G={1}, B={2}, A={3})", R, G, B, A);
        }
    
        #endregion
    }
    // ###]
}

