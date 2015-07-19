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
    // [### ColorINT.cs.TEMPLATE> type = int16, channels = rgb


    public struct ColorRGB16 : IEquatable<ColorRGB16>
    {
        #region consts
    
        public const ushort MinChannelValue = 0;
        public const ushort MaxChannelValue = ((ushort) 0xffff);
    
        #endregion

        #region Named colors
    
    
        #endregion
    
        #region Members
     
        private readonly ulong _rgb;
    
        #endregion
    
        #region Construction and conversion
    
     
        public ColorRGB16(ulong rgb)
        {
            _rgb = rgb & ((ulong) 0xffffffffffff);
        }
    
        public ColorRGB16(ushort r, ushort g, ushort b)
        {
            _rgb = ((ulong) r << 32) | ((ulong) g << 16) | ((ulong) b << 0);
        }
    
    
    
    
    
    
        #endregion
    
        #region Properties
    
    
        public ushort R
        {
            get { return (ushort) ((_rgb >> 32) & MaxChannelValue); }
        }
    
        public ushort G
        {
            get { return (ushort) ((_rgb >> 16) & MaxChannelValue); }
        }
    
        public ushort B
        {
            get { return (ushort) ((_rgb >> 0) & MaxChannelValue); }
        }
    
        #endregion
    
        #region Mutation
    
        #endregion
    
        #region Equality & HashCode

        public bool Equals(ColorRGB16 c)
        {
            return _rgb == c._rgb;
        }

        public override bool Equals(object obj)
        {
        
            var c = obj as ColorRGB16?;

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

        public static bool operator ==(ColorRGB16 v, ColorRGB16 w)
        {
            return v.Equals(w);
        }

        public static bool operator !=(ColorRGB16 v, ColorRGB16 w)
        {
            return !v.Equals(w);
        }

        #endregion
    
        #region ToString
    
        public override string ToString()
        {
            return string.Format("ColorRGB16(R={0}, G={1}, B={2})", R, G, B);
        }
    
        #endregion
    }
    // ###]
}

