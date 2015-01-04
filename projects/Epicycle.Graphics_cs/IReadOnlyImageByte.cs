using System;
using System.Collections.Generic;
using System.Linq;

using Epicycle.Commons.Unsafe;
using Epicycle.Math.Geometry;

namespace Epicycle.Graphics
{
    public interface IReadOnlyImageByte<TType> : IReadOnlyImage<TType, byte>
    {
        PinnedByteBuffer Open();
    }
}
