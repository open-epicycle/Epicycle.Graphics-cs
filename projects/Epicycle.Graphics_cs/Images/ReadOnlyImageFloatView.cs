// [[[[INFO>
// Copyright 2015 Epicycle (http://epicycle.org, https://github.com/open-epicycle)
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 
// For more information check https://github.com/open-epicycle/Epicycle.Graphics-cs
// ]]]]

using Epicycle.Commons.Unsafe;
using Epicycle.Math.Geometry;

namespace Epicycle.Graphics.Images
{
    // TODO: Test

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
