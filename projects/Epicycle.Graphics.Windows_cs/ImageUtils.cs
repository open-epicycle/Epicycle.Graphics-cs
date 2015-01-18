using System;
using System.Collections.Generic;
using System.Linq;

using System.Drawing;

using Epicycle.Commons;

namespace Epicycle.Graphics.Windows
{
    public static class ImageUtils
    {
        public static Bitmap ToBitmap<TType>(this IReadOnlyImageByte<TType> @this)
        {
            if (typeof(TType).Equals(typeof(MonoImageType)))
            {
                return ((IReadOnlyImageByte<MonoImageType>)@this).ToBitmap();
            }

            if (typeof(TType).Equals(typeof(RgbImageType)))
            {
                return ((IReadOnlyImageByte<RgbImageType>)@this).ToBitmap();
            }

            throw new NotImplementedException(string.Format("Unsupported image type {0}", typeof(TType)));
        }

        public static unsafe Bitmap ToBitmap(this IReadOnlyImageByte<RgbImageType> @this)
        {
            var answer = new Bitmap(@this.Width(), @this.Height());

            var step = @this.Step;
            var dimensions = @this.Dimensions;

            using (var pin = @this.Open())
            {
                var ptr = pin.Ptr;

                for (var j = 0; j < dimensions.Y; j++)
                {
                    var pixelPtr = ptr;

                    for (var i = 0; i < dimensions.X; i++)
                    {
                        var colour = Color.FromArgb(pixelPtr[0], pixelPtr[1], pixelPtr[2]);
                        answer.SetPixel(i, j, colour);

                        pixelPtr += step.X;
                    }

                    ptr += step.Y;
                }
            }

            return answer;
        }

        public static unsafe Bitmap ToBitmap(this IReadOnlyImageByte<MonoImageType> @this)
        {
            var answer = new Bitmap(@this.Width(), @this.Height());

            var step = @this.Step;
            var dimensions = @this.Dimensions;

            using (var pin = @this.Open())
            {
                var ptr = pin.Ptr;

                for (var j = 0; j < dimensions.Y; j++)
                {
                    var pixelPtr = ptr;

                    for (var i = 0; i < dimensions.X; i++)
                    {
                        var colour = Color.FromArgb(*pixelPtr, *pixelPtr, *pixelPtr);
                        answer.SetPixel(i, j, colour);

                        pixelPtr += step.X;
                    }

                    ptr += step.Y;
                }
            }

            return answer;
        }

        public static unsafe IImageByte<RgbImageType> ToMetaqubeImage(this Bitmap @this)
        {
            var answer = new ImageByte<RgbImageType>(@this.Width, @this.Height);

            var step = answer.Step;
            var dimensions = answer.Dimensions;

            using (var pin = answer.Open())
            {
                var ptr = pin.Ptr;

                for (var j = 0; j < dimensions.Y; j++)
                {
                    var pixelPtr = ptr;

                    for (var i = 0; i < dimensions.X; i++)
                    {
                        var colour = @this.GetPixel(i, j); // TODO: Implement using Bitmap.LockBits

                        pixelPtr[0] = colour.R;
                        pixelPtr[1] = colour.G;
                        pixelPtr[2] = colour.B;

                        pixelPtr += step.X;
                    }

                    ptr += step.Y;
                }
            }

            return answer;
        }
    }
}
