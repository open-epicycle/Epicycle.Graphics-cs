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

namespace Epicycle.Graphics.Color.Spaces
{
    public static class RYBUtils
    {
        private readonly static float[,] RYBInterpolationCube = new float[,]
        {
            {1.000f, 1.000f, 1.000f},
            {1.000f, 1.000f, 0.000f},
            {1.000f, 0.000f, 0.000f},
            {1.000f, 0.500f, 0.000f},
            {0.163f, 0.373f, 0.600f},
            {0.000f, 0.660f, 0.200f},
            {0.500f, 0.000f, 0.500f},
            {0.200f, 0.094f, 0.000f},
        };

        public static void RYBToRGB(float red, float yellow, float blue, out float outRed, out float outGreen, out float outBlue)
        {
            var cr = MathUtils.ClipUnit(red);
            var cy = MathUtils.ClipUnit(yellow);
            var cb = MathUtils.ClipUnit(blue);

            outRed = CalculateRGBComponent(0, cr, cy, cb);
            outGreen = CalculateRGBComponent(1, cr, cy, cb);
            outBlue = CalculateRGBComponent(2, cr, cy, cb);
        }

        private static float CalculateRGBComponent(int componentIndex, float red, float yellow, float blue)
        {
            var x0 = Interpolate(blue, RYBInterpolationCube[0, componentIndex], RYBInterpolationCube[4, componentIndex]);
            var x1 = Interpolate(blue, RYBInterpolationCube[1, componentIndex], RYBInterpolationCube[5, componentIndex]);
            var x2 = Interpolate(blue, RYBInterpolationCube[2, componentIndex], RYBInterpolationCube[6, componentIndex]);
            var x3 = Interpolate(blue, RYBInterpolationCube[3, componentIndex], RYBInterpolationCube[7, componentIndex]);
            var y0 = Interpolate(yellow, x0, x1);
            var y1 = Interpolate(yellow, x2, x3);

            return Interpolate(red, y0, y1);
        }

        private static float Interpolate(float t, float a, float b)
        {
            var weight = t * t * (3 - 2 * t);
            return a + weight * (b - a);
        }
    }
}
