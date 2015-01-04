using System;
using System.Collections.Generic;
using System.Linq;

using Epicycle.Commons.Unsafe;

namespace Epicycle.Graphics
{
    public interface IImageByte<TType> : IReadOnlyImageByte<TType>, IImage<TType, byte>
    {
        
    }
}