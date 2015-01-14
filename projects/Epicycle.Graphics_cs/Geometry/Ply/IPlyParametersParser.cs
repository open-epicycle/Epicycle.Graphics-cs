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

using Epicycle.Math.Geometry;

namespace Epicycle.Graphics.Geometry.Ply
{
    public interface IPlyParametersParser
    {
        bool HasParameter(string name);
        object GetParameter(string name);

        byte? GetByte(string name, bool required);
        int? GetInt(string name, bool required);
        float GetFloat(string name, bool required);
        double GetDouble(string name, bool required);
        int[] GetIntArray(string name, bool required);
        Vector3 GetVector3(string namePrefix, bool required);
        Rotation3? GetRotation3(string namePrefix, bool required);
        Color4b? GetColor4b(string namePrefix, bool required);
    }
}
