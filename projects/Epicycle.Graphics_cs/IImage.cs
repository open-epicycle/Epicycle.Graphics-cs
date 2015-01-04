using System;
using System.Collections.Generic;
using System.Linq;

using Epicycle.Math.Geometry;

namespace Epicycle.Graphics
{
    public interface IImage<TType, TDepth> : IReadOnlyImage<TType, TDepth>
    {
        new TDepth this[Vector2i pixel, int channel] { get; set; }
    }
}
