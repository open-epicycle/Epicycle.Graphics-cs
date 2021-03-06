﻿// [[[[INFO>
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
