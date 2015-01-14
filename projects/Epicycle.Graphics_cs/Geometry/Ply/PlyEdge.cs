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
using System.Linq;

namespace Epicycle.Graphics.Geometry.Ply
{
    public class PlyEdge : PlyElement
    {
        private readonly int _vertexIndex1;
        private readonly int _vertexIndex2;
        private readonly Color4b? _color;
        private readonly float _radius;
        private readonly byte? _creaseTag;

        public PlyEdge(int vertexIndex1, int vertexIndex2, Color4b? color = null, float radius = float.NaN, byte? creaseTag = null)
        {
            _vertexIndex1 = vertexIndex1;
            _vertexIndex2 = vertexIndex2;
            _color = color;
            _radius = radius;
            _creaseTag = creaseTag;
        }

        public int VertexIndex1
        {
            get { return _vertexIndex1; }
        }

        public int VertexIndex2
        {
            get { return _vertexIndex2; }
        }

        public Color4b? Color
        {
            get { return _color; }
        }

        public float Radius
        {
            get { return _radius; }
        }

        public byte? CreaseTag
        {
            get { return _creaseTag; }
        }

        protected override void PopulateProperties(IList<string> properties)
        {
            properties.Add("int face1");
            properties.Add("int face2");

            if (Color.HasValue)
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

            if (CreaseTag.HasValue)
            {
                properties.Add("uchar crease_tag");
            }
        }

        protected override void PopulateSerializedValues(IList<string> serializedValues)
        {
            Serialize(serializedValues, VertexIndex1);
            Serialize(serializedValues, VertexIndex2);

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

            if (CreaseTag.HasValue)
            {
                Serialize(serializedValues, CreaseTag.Value);
            }
        }
    }
}
