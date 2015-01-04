using System;
using System.Collections.Generic;
using System.Linq;

using Epicycle.Commons.Unsafe;
using Epicycle.Math.Geometry;

namespace Epicycle.Graphics
{
    public sealed class ImageFloat<TType> : Image<TType, float>, IImageFloat<TType>
         where TType : IImageType, new()
    {
        public ImageFloat(Vector2i dimensions) : base(dimensions) { }

        public ImageFloat(int width, int height) : base(width, height) { }

        public ImageFloat(float[,,] data) : base(data) { }

        public PinnedFloatBuffer Open()
        {
            return new PinnedFloatBuffer(_data);
        }
    }
}
