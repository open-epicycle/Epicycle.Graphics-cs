using System;
using System.Collections.Generic;
using System.Linq;

using Epicycle.Math.Geometry;

namespace Epicycle.Graphics
{
    public interface IReadOnlyImage<TType, TDepth>
    {
        Vector2i Dimensions { get; }
        Vector2i Step { get; }

        TDepth this[Vector2i pixel, int channel] { get; }
    }
}
