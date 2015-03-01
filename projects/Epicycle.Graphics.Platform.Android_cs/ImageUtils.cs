using System;

using Android.Graphics;

using Epicycle.Graphics.Images;

namespace Epicycle.Graphics.Platform.Android
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
			var answer = Bitmap.CreateBitmap(@this.Width(), @this.Height(), Bitmap.Config.Argb8888);

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
						var colour = Color.Rgb(pixelPtr[0], pixelPtr[1], pixelPtr[2]);
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
			var answer = Bitmap.CreateBitmap(@this.Width(), @this.Height(), Bitmap.Config.Alpha8);

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
						var colour = Color.Argb(alpha: *pixelPtr, red: 0, blue: 0, green: 0);
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

            var pixels = new int[@this.ByteCount / sizeof(int)];
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

						pixelPtr[0] = (byte)((argb >> 16) & 0xFF);
						pixelPtr[1] = (byte)((argb >> 8) & 0xFF);
                        pixelPtr[2] = (byte)(argb & 0xFF);

                        pixelPtr += step.X;
                    }

                    ptr += step.Y;
                }
            }

            return answer;
        }
    }
}

