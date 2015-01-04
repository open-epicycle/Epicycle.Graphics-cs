using System;
using System.Collections.Generic;
using System.Linq;

using Epicycle.Commons;
using Epicycle.Math.Geometry;

namespace Epicycle.Graphics
{
    public abstract class Image<TType, TDepth> : IImage<TType, TDepth>
        where TType : IImageType, new()
    {
        public Image(Vector2i dimensions)
        {
            var channelsCount = Singleton<TType>.Instance.ChannelsCount;

            _data = new TDepth[dimensions.Y, dimensions.X, channelsCount];
            _dimensions = dimensions;
            _step = channelsCount * new Vector2i(1, _dimensions.X);
        }

        public Image(int width, int height) 
            : this(new Vector2i(width, height)) { }

        public Image(TDepth[,,] data) // shallow copy
        {
            var channelsCount = Singleton<TType>.Instance.ChannelsCount;

            ArgAssert.Equal(data.GetLength(2), "data.GetLength(2)", channelsCount);
            
            _data = data;
            _dimensions = new Vector2i(_data.GetLength(1), _data.GetLength(0));
            _step = channelsCount * new Vector2i(1, _dimensions.X);
        }

        protected readonly TDepth[,,] _data;
        private readonly Vector2i _dimensions;
        private readonly Vector2i _step;

        public Vector2i Dimensions
        {
            get { return _dimensions; }
        }

        public Vector2i Step
        {
            get { return _step; }
        }

        public TDepth this[Vector2i pixel, int channel]
        {
            get { return _data[pixel.Y, pixel.X, channel]; }
            set { _data[pixel.Y, pixel.X, channel] = value; }
        }
    }
}
