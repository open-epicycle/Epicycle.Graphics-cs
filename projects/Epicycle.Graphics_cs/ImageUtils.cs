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

using Epicycle.Commons;
using Epicycle.Math.Geometry;

namespace Epicycle.Graphics
{

    public static class ImageUtils
    {
        public static int Width<TType, TDepth>(this IReadOnlyImage<TType, TDepth> @this)
        {
            return @this.Dimensions.X;
        }

        public static int Height<TType, TDepth>(this IReadOnlyImage<TType, TDepth> @this)
        {
            return @this.Dimensions.Y;
        }

        public static Box2i Box<TType, TDepth>(this IReadOnlyImage<TType, TDepth> @this)
        {
            return new Box2i(0, 0, @this.Width(), @this.Height());
        }

        public static unsafe IImageFloat<TType> ToFloat<TType>(this IReadOnlyImageByte<TType> @this)
            where TType : IImageType, new()
        {
            var answer = new ImageFloat<TType>(@this.Dimensions);

            var inStep = @this.Step;
            var outStep = answer.Step;

            var dimensions = @this.Dimensions;
            var channelsCount = Singleton<TType>.Instance.ChannelsCount;

            using (var pinInput = @this.Open())
            {
                using (var pinOutput = answer.Open())
                {
                    var inPtr = pinInput.Ptr;
                    var outPtr = pinOutput.Ptr;

                    for (var j = 0; j < dimensions.Y; j++)
                    {
                        var inPixelPtr = inPtr;
                        var outPixelPtr = outPtr;

                        for (var i = 0; i < dimensions.X; i++)
                        {
                            for (var c = 0; c < channelsCount; c++)
                            {
                                outPixelPtr[c] = inPixelPtr[c];
                            }

                            inPixelPtr += inStep.X;
                            outPixelPtr += outStep.X;
                        }

                        inPtr += inStep.Y;
                        outPtr += outStep.Y;
                    }
                }                
            }

            return answer;
        }

        public static unsafe IImageFloat<TType> ToFloatNormalized<TType>(this IReadOnlyImageByte<TType> @this)
            where TType : IImageType, new()
        {
            var answer = new ImageFloat<TType>(@this.Dimensions);

            var inStep = @this.Step;
            var outStep = answer.Step;

            var dimensions = @this.Dimensions;
            var channelsCount = Singleton<TType>.Instance.ChannelsCount;

            using (var pinInput = @this.Open())
            {
                using (var pinOutput = answer.Open())
                {
                    var inPtr = pinInput.Ptr;
                    var outPtr = pinOutput.Ptr;

                    for (var j = 0; j < dimensions.Y; j++)
                    {
                        var inPixelPtr = inPtr;
                        var outPixelPtr = outPtr;

                        for (var i = 0; i < dimensions.X; i++)
                        {
                            for (var c = 0; c < channelsCount; c++)
                            {
                                outPixelPtr[c] = inPixelPtr[c] / 255f;
                            }                                

                            inPixelPtr += inStep.X;
                            outPixelPtr += outStep.X;
                        }

                        inPtr += inStep.Y;
                        outPtr += outStep.Y;
                    }
                }
            }

            return answer;
        }

        public static unsafe IImageByte<TType> ToByteNormalized<TType>(this IReadOnlyImageFloat<TType> @this)
            where TType : IImageType, new()
        {
            var answer = new ImageByte<TType>(@this.Dimensions);

            var inStep = @this.Step;
            var outStep = answer.Step;

            var dimensions = @this.Dimensions;
            var channelsCount = Singleton<TType>.Instance.ChannelsCount;

            using (var pinInput = @this.Open())
            {
                using (var pinOutput = answer.Open())
                {
                    var inPtr = pinInput.Ptr;
                    var outPtr = pinOutput.Ptr;

                    for (var j = 0; j < dimensions.Y; j++)
                    {
                        var inPixelPtr = inPtr;
                        var outPixelPtr = outPtr;

                        for (var i = 0; i < dimensions.X; i++)
                        {
                            for (var c = 0; c < channelsCount; c++)
                            {
                                outPixelPtr[c] = (byte)BasicMath.Round(inPixelPtr[c] * 255);
                            }

                            inPixelPtr += inStep.X;
                            outPixelPtr += outStep.X;
                        }

                        inPtr += inStep.Y;
                        outPtr += outStep.Y;
                    }
                }
            }

            return answer;
        }

        public static unsafe IImageFloat<TType> Add<TType>(this IReadOnlyImageFloat<TType> @this, float x)
            where TType : IImageType, new()
        {
            var answer = new ImageFloat<TType>(@this.Dimensions);

            var inStep = @this.Step;
            var outStep = answer.Step;

            var dimensions = @this.Dimensions;
            var channelsCount = Singleton<TType>.Instance.ChannelsCount;

            using (var pinInput = @this.Open())
            {
                using (var pinOutput = answer.Open())
                {
                    var inPtr = pinInput.Ptr;
                    var outPtr = pinOutput.Ptr;

                    for (var j = 0; j < dimensions.Y; j++)
                    {
                        var inPixelPtr = inPtr;
                        var outPixelPtr = outPtr;

                        for (var i = 0; i < dimensions.X; i++)
                        {
                            for (var c = 0; c < channelsCount; c++)
                            {
                                outPixelPtr[c] = inPixelPtr[c] + x;
                            }

                            inPixelPtr += inStep.X;
                            outPixelPtr += outStep.X;
                        }

                        inPtr += inStep.Y;
                        outPtr += outStep.Y;
                    }
                }
            }

            return answer;
        }

        public static unsafe IImageFloat<TType> Subtract<TType>(this IReadOnlyImageFloat<TType> @this, float x)
            where TType : IImageType, new()
        {
            var answer = new ImageFloat<TType>(@this.Dimensions);

            var inStep = @this.Step;
            var outStep = answer.Step;

            var dimensions = @this.Dimensions;
            var channelsCount = Singleton<TType>.Instance.ChannelsCount;

            using (var pinInput = @this.Open())
            {
                using (var pinOutput = answer.Open())
                {
                    var inPtr = pinInput.Ptr;
                    var outPtr = pinOutput.Ptr;

                    for (var j = 0; j < dimensions.Y; j++)
                    {
                        var inPixelPtr = inPtr;
                        var outPixelPtr = outPtr;

                        for (var i = 0; i < dimensions.X; i++)
                        {
                            for (var c = 0; c < channelsCount; c++)
                            {
                                outPixelPtr[c] = inPixelPtr[c] - x;
                            }

                            inPixelPtr += inStep.X;
                            outPixelPtr += outStep.X;
                        }

                        inPtr += inStep.Y;
                        outPtr += outStep.Y;
                    }
                }
            }

            return answer;
        }

        public static unsafe IImageFloat<TType> Multiply<TType> (this IReadOnlyImageFloat<TType> @this, float x)
            where TType : IImageType, new()
        {
            var answer = new ImageFloat<TType>(@this.Dimensions);

            var inStep = @this.Step;
            var outStep = answer.Step;

            var dimensions = @this.Dimensions;
            var channelsCount = Singleton<TType>.Instance.ChannelsCount;

            using (var pinInput = @this.Open())
            {
                using (var pinOutput = answer.Open())
                {
                    var inPtr = pinInput.Ptr;
                    var outPtr = pinOutput.Ptr;

                    for (var j = 0; j < dimensions.Y; j++)
                    {
                        var inPixelPtr = inPtr;
                        var outPixelPtr = outPtr;

                        for (var i = 0; i < dimensions.X; i++)
                        {
                            for (var c = 0; c < channelsCount; c++)
                            {
                                outPixelPtr[c] = inPixelPtr[c] * x;
                            }

                            inPixelPtr += inStep.X;
                            outPixelPtr += outStep.X;
                        }

                        inPtr += inStep.Y;
                        outPtr += outStep.Y;
                    }
                }
            }

            return answer;
        }

        public static unsafe IImageFloat<TType> Divide<TType>(this IReadOnlyImageFloat<TType> @this, float x)
            where TType : IImageType, new()
        {
            var answer = new ImageFloat<TType>(@this.Dimensions);

            var inStep = @this.Step;
            var outStep = answer.Step;

            var dimensions = @this.Dimensions;
            var channelsCount = Singleton<TType>.Instance.ChannelsCount;

            using (var pinInput = @this.Open())
            {
                using (var pinOutput = answer.Open())
                {
                    var inPtr = pinInput.Ptr;
                    var outPtr = pinOutput.Ptr;

                    for (var j = 0; j < dimensions.Y; j++)
                    {
                        var inPixelPtr = inPtr;
                        var outPixelPtr = outPtr;

                        for (var i = 0; i < dimensions.X; i++)
                        {
                            for (var c = 0; c < channelsCount; c++)
                            {
                                outPixelPtr[c] = inPixelPtr[c] / x;
                            }

                            inPixelPtr += inStep.X;
                            outPixelPtr += outStep.X;
                        }

                        inPtr += inStep.Y;
                        outPtr += outStep.Y;
                    }
                }
            }

            return answer;
        }

        public static unsafe void FindMaximum(this IReadOnlyImageFloat<MonoImageType> @this, Box2i box, out Vector2i location, out float value)
        {
            value = float.NegativeInfinity;
            location = new Vector2i();

            var step = @this.Step;

            using (var pin = @this.Open())
            {
                var ptr = pin.Ptr + box.MinCorner * step;

                for (var j = box.MinY; j <= box.MaxY; j++)
                {
                    var pixelPtr = ptr;

                    for (var i = box.MinX; i <= box.MaxX; i++)
                    {
                        if (*pixelPtr > value)
                        {
                            location = new Vector2i(i, j);
                            value = *pixelPtr;
                        }

                        pixelPtr += step.X;
                    }

                    ptr += step.Y;
                }
            }
        }        

        public static Vector2i ArgMax(this IReadOnlyImageFloat<MonoImageType> @this, Box2i box)
        {
            Vector2i answer;
            float maxValue;

            @this.FindMaximum(box, out answer, out maxValue);

            return answer;
        }

        public static float Max(this IReadOnlyImageFloat<MonoImageType> @this, Box2i box)
        {
            Vector2i maxLocation;
            float answer;

            @this.FindMaximum(box, out maxLocation, out answer);

            return answer;
        }

        public static void FindMaximum(this IReadOnlyImageFloat<MonoImageType> @this, out Vector2i location, out float value)
        {
            @this.FindMaximum(@this.Box(), out location, out value);
        }

        public static Vector2i ArgMax(this IReadOnlyImageFloat<MonoImageType> @this)
        {
            return @this.ArgMax(@this.Box());
        }        

        public static float Max(this IReadOnlyImageFloat<MonoImageType> @this)
        {
            return @this.Max(@this.Box());
        }

        public static unsafe void FindMinimum(this IReadOnlyImageFloat<MonoImageType> @this, Box2i box, out Vector2i location, out float value)
        {
            value = float.PositiveInfinity;
            location = new Vector2i();

            var step = @this.Step;

            using (var pin = @this.Open())
            {
                var ptr = pin.Ptr + box.MinCorner * step;

                for (var j = box.MinY; j <= box.MaxY; j++)
                {
                    var pixelPtr = ptr;

                    for (var i = box.MinX; i <= box.MaxX; i++)
                    {
                        if (*pixelPtr < value)
                        {
                            location = new Vector2i(i, j);
                            value = *pixelPtr;
                        }

                        pixelPtr += step.X;
                    }

                    ptr += step.Y;
                }
            }
        }

        public static Vector2i ArgMin(this IReadOnlyImageFloat<MonoImageType> @this, Box2i box)
        {
            Vector2i answer;
            float minValue;

            @this.FindMinimum(box, out answer, out minValue);

            return answer;
        }

        public static float Min(this IReadOnlyImageFloat<MonoImageType> @this, Box2i box)
        {
            Vector2i minLocation;
            float answer;

            @this.FindMinimum(box, out minLocation, out answer);

            return answer;
        }

        public static void FindMinimum(this IReadOnlyImageFloat<MonoImageType> @this, out Vector2i location, out float value)
        {
            @this.FindMinimum(@this.Box(), out location, out value);
        }

        public static Vector2i ArgMin(this IReadOnlyImageFloat<MonoImageType> @this)
        {
            return @this.ArgMin(@this.Box());
        }

        public static float Min(this IReadOnlyImageFloat<MonoImageType> @this)
        {
            return @this.Min(@this.Box());
        }

        public static IImageFloat<MonoImageType> NormalizeMaximum(this IReadOnlyImageFloat<MonoImageType> @this)
        {
            return @this.Divide(@this.Max());
        }
    }
}
