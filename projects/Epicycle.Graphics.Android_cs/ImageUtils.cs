using System;

using Android.Graphics;

namespace Epicycle.Graphics.Android
{
    public static class ImageUtils
    {
        public static unsafe IImageByte<RgbImageType> ToMetaqubeImage(this Bitmap @this)
        {
            var answer = new ImageByte<RgbImageType>(@this.Width, @this.Height);

            var step = answer.Step;

            var pixels = new int[@this.ByteCount];
            @this.GetPixels(pixels, offset: 0, stride: @this.Width, x: 0, y: 0, width: @this.Width, height: @this.Height);

            using (var pin = answer.Open())
            {
                var ptr = pin.Ptr;

                for (var j = 0; j < @this.Height; j++)
                {
                    var pixelPtr = ptr;

                    for (var i = 0; i < @this.Width; i++)
                    {
                        var argb = pixels[j * @this.Width + i];

                        pixelPtr[0] = (byte)((argb >> 16) % 255);
                        pixelPtr[1] = (byte)((argb >> 8) % 255);
                        pixelPtr[2] = (byte)(argb % 255);

                        pixelPtr += step.X;
                    }

                    ptr += step.Y;
                }
            }

            return answer;
        }
    }
}

