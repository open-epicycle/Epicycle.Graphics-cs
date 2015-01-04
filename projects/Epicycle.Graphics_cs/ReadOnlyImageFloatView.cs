using System;
using System.Collections.Generic;
using System.Linq;

using Epicycle.Commons.Unsafe;
using Epicycle.Math.Geometry;

namespace Epicycle.Graphics
{
    public sealed class ReadOnlyImageFloatView<TType, UType> : ReadOnlyImageView<TType, float, UType>, IReadOnlyImageFloat<TType>
        where TType : IImageType, new()
        where UType : IImageType, new()
    {
        public ReadOnlyImageFloatView(IReadOnlyImageFloat<UType> image, Vector2i topLeft, Vector2i step, Vector2i dimensions, int channel = 0)
            : base(image, topLeft, step, dimensions, channel)
        {
            _image = image;
        }

        public ReadOnlyImageFloatView(IReadOnlyImageFloat<UType> image, Box2i roi, int channel = 0)
            : base(image, roi, channel)
        {
            _image = image;
        }

        private readonly IReadOnlyImageFloat<UType> _image;

        public PinnedFloatBuffer Open()
        {
            var data = _image.Open();

            data.MoveOffset(_image.Step * _viewTopLeft);

            return data;
        }
    }
}
