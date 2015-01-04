using System;
using System.Collections.Generic;
using System.Linq;

using Epicycle.Math.Geometry;

namespace Epicycle.Graphics
{
    public abstract class ReadOnlyImageView<TType, TDepth, UType> : IReadOnlyImage<TType, TDepth>
        where TType : IImageType, new()
        where UType : IImageType, new()
    {
        public ReadOnlyImageView(IReadOnlyImage<UType, TDepth> image, Vector2i topLeft, Vector2i step, Vector2i dimensions, int channel = 0)
        {
            _image = image;

            _viewTopLeft = topLeft;
            _viewDimensions = dimensions;
            _viewStep = step;
            _viewChannel = channel;

            _step = Vector2i.Mul(image.Step, step);
        }

        public ReadOnlyImageView(IReadOnlyImage<UType, TDepth> image, Box2i roi, int channel = 0)
        {
            _image = image;

            _viewTopLeft = roi.MinCorner;
            _viewDimensions = roi.Dimensions;
            _viewStep = new Vector2i(1, 1);
            _viewChannel = channel;

            _step = image.Step;
        }

        private readonly IReadOnlyImage<UType, TDepth> _image;
        protected readonly Vector2i _viewTopLeft;
        private readonly Vector2i _viewDimensions;
        private readonly Vector2i _viewStep;
        private readonly int _viewChannel;
        private readonly Vector2i _step;

        public Vector2i Dimensions
        {
            get { return _viewDimensions; }
        }

        public Vector2i Step
        {
            get { return _step; }
        }

        public TDepth this[Vector2i pixel, int channel]
        {
            get { return _image[_viewTopLeft + Vector2i.Mul(_viewStep, pixel), _viewChannel + channel]; }
        }
    }
}
