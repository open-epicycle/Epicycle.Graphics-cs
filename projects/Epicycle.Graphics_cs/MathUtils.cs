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

namespace Epicycle.Graphics
{
    using System;

    public static class MathUtils
    {
        // TODO: Use BasicMath when ready

        private const float fPI = (float)Math.PI;

        private const double Tau = Math.PI * 2;
        private const float fTau = (float)Tau;

        public static float ClipUnit(float x)
        {
            return BasicMath.Clip(x, 0, 1);
        }

        public static float WrapUnit(float x)
        {
            return (x < 0 || x > 1) ? x - (float)Math.Floor(x) : x;
        }

        public static float Min(float a, float b, float c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        public static float Max(float a, float b, float c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        public static float SafeAcos(float x)
        {
            return (float)Math.Acos(BasicMath.Clip(x, -1, 1));
        }

        public static void TransformVector3(float[,] matrix, float v0, float v1, float v2, out float out0, out float out1, out float out2)
        {
            out0 = matrix[0, 0] * v0 + matrix[0, 1] * v1 + matrix[0, 2] * v2;
            out1 = matrix[1, 0] * v0 + matrix[1, 1] * v1 + matrix[1, 2] * v2;
            out2 = matrix[2, 0] * v0 + matrix[2, 1] * v1 + matrix[2, 2] * v2;
        }

        public static float[,] InvertMatrix3(float[,] matrix)
        {
            var determinant = 
                matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[2, 1] * matrix[1, 2]) -
                matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0]) +
                matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);

            if(determinant == 0)
            {
                throw new ArgumentException("The matrix is not invertable!");
            }

            var invDeterminant = 1 / determinant;

            var result = new float[3, 3];
            result[0, 0] = (matrix[1, 1] * matrix[2, 2] - matrix[2, 1] * matrix[1, 2]) * invDeterminant;
            result[0, 1] = (matrix[0, 2] * matrix[2, 1] - matrix[0, 1] * matrix[2, 2]) * invDeterminant;
            result[0, 2] = (matrix[0, 1] * matrix[1, 2] - matrix[0, 2] * matrix[1, 1]) * invDeterminant;
            result[1, 0] = (matrix[1, 2] * matrix[2, 0] - matrix[1, 0] * matrix[2, 2]) * invDeterminant;
            result[1, 1] = (matrix[0, 0] * matrix[2, 2] - matrix[0, 2] * matrix[2, 0]) * invDeterminant;
            result[1, 2] = (matrix[1, 0] * matrix[0, 2] - matrix[0, 0] * matrix[1, 2]) * invDeterminant;
            result[2, 0] = (matrix[1, 0] * matrix[2, 1] - matrix[2, 0] * matrix[1, 1]) * invDeterminant;
            result[2, 1] = (matrix[2, 0] * matrix[0, 1] - matrix[0, 0] * matrix[2, 1]) * invDeterminant;
            result[2, 2] = (matrix[0, 0] * matrix[1, 1] - matrix[1, 0] * matrix[0, 1]) * invDeterminant;

            return result;
        }

        public static float Atan2Positive(float y, float x)
        {
            var atan2 = (float) Math.Atan2(y, x);
            return atan2 >= 0 ? atan2 : (atan2 + fTau);
        }

        public static float Norm2(float x, float y)
        {
            return (float) Math.Sqrt(x * x + y * y);
        }

        public static void CartesianToPolarCoordinatesPositive(float x, float y, out float r, out float phi, float defaultPhi = 0)
        {
            if (x != 0 || y != 0)
            {
                r = Norm2(x, y);
                phi = MathUtils.Atan2Positive(y, x);
            }
            else
            {
                r = 0;
                phi = defaultPhi;
            }
        }

        public static void PolarToCartesianCoordinates(float r, float phi, out float x, out float y)
        {
            x = r * (float)Math.Cos(phi);
            y = r * (float)Math.Sin(phi);
        }
    }
}
