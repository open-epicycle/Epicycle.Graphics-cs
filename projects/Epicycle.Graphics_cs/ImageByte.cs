using System;
using System.Collections.Generic;
using System.Linq;

using Epicycle.Commons.Unsafe;
using Epicycle.Math.Geometry;

namespace Epicycle.Graphics
{
    public sealed class ImageByte<TType> : Image<TType, byte>, IImageByte<TType>
         where TType : IImageType, new()
    {
        public ImageByte(Vector2i dimensions) : base(dimensions) { }

        public ImageByte(int width, int height) : base(width, height) { }

        public ImageByte(byte[,,] data) : base(data) { }

        public PinnedByteBuffer Open()
        {
            return new PinnedByteBuffer(_data);
        }
    }
}
