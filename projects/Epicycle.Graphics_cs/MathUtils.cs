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
    }
}
