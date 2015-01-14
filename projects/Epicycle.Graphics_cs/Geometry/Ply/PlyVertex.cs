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
using System.Collections.Generic;

namespace Epicycle.Graphics.Geometry.Ply
{
    public class PlyVertex : PlyElement
    {
        private readonly Vector3 _position;
        private readonly Vector3 _normal;
        private readonly Color4b? _color;
        private readonly float _radius;
        private readonly int? _materialIndex;

        public PlyVertex(Vector3 position, Vector3 normal = null, Color4b? color = null, float radius = float.NaN, int? materialIndex = null)
        {
            _position = position;
            _normal = normal;
            _color = color;
            _radius = radius;
            _materialIndex = materialIndex;
        }

        public Vector3 Position
        {
            get { return _position; }
        }

        public Vector3 Normal
        {
            get { return _normal; }
        }

        public Color4b? Color
        {
            get { return _color; }
        }

        public float Radius
        {
            get { return _radius; }
        }

        public int? MaterialIndex
        {
            get { return _materialIndex; }
        }

        protected override void PopulateProperties(IList<string> properties)
        {
            properties.Add("float x");
            properties.Add("float y");
            properties.Add("float z");

            if(Normal != null)
            {
                properties.Add("float nx");
                properties.Add("float ny");
                properties.Add("float nz");
            }

            if(Color.HasValue)
            {
                properties.Add("uchar red");
                properties.Add("uchar green");
                properties.Add("uchar blue");
                properties.Add("uchar alpha");
            }

            if (!double.IsNaN(Radius))
            {
                properties.Add("float radius");
            }

            if (MaterialIndex.HasValue)
            {
                properties.Add("int material_index");
            }
        }

        protected override void PopulateSerializedValues(IList<string> serializedValues)
        {
            SerializeToFloat(serializedValues, Position.X);
            SerializeToFloat(serializedValues, Position.Y);
            SerializeToFloat(serializedValues, Position.Z);

            if (Normal != null)
            {
                SerializeToFloat(serializedValues, Normal.X);
                SerializeToFloat(serializedValues, Normal.Y);
                SerializeToFloat(serializedValues, Normal.Z);
            }

            if (Color.HasValue)
            {
                Serialize(serializedValues, Color.Value.R);
                Serialize(serializedValues, Color.Value.G);
                Serialize(serializedValues, Color.Value.B);
                Serialize(serializedValues, Color.Value.A);
            }

            if (!double.IsNaN(Radius))
            {
                Serialize(serializedValues, Radius);
            }

            if (MaterialIndex.HasValue)
            {
                Serialize(serializedValues, MaterialIndex.Value);
            }
        }
    }
}
