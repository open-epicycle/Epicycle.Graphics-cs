using System;
using System.Collections.Generic;
using System.Linq;

using Epicycle.Commons.Unsafe;
using Epicycle.Math.Geometry;

namespace Epicycle.Graphics
{
    public interface IReadOnlyImageFloat<TType> : IReadOnlyImage<TType, float>
    {
        PinnedFloatBuffer Open();
    }
}
