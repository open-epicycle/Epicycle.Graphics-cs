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

using Epicycle.Graphics.Color;
using System.Collections.Generic;

namespace Epicycle.Graphics.Geometry.Ply
{
    public class PlyEdge : PlyElement
    {
        public PlyEdge()
        {
            VertexIndex1 = 0;
            VertexIndex2 = 0;
            Color = null;
            Radius = float.NaN;
            CreaseTag = null;
        }

        public override void Parse(IPlyParametersParser parser)
        {
            VertexIndex1 = parser.GetInt("vertex1", true).Value;
            VertexIndex2 = parser.GetInt("vertex2", true).Value;
            Color = parser.GetColorRGBA("", false);
            Radius = parser.GetDouble("radius", false);
            CreaseTag = parser.GetByte("crease_tag", false);
        }

        public int VertexIndex1 { get; set;}

        public int VertexIndex2 { get; set;}

        public ColorRGBA? Color { get; set; }

        public double Radius { get; set;}

        public byte? CreaseTag { get; set;}

        protected override void PopulateProperties(IList<string> properties)
        {
            properties.Add("int vertex1");
            properties.Add("int vertex2");

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
                SerializeToFloat(serializedValues, Radius);
            }

            if (CreaseTag.HasValue)
            {
                Serialize(serializedValues, CreaseTag.Value);
            }
        }
    }
}
