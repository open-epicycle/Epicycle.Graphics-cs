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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
