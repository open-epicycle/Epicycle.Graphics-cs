﻿// [[[[INFO>
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
using Epicycle.Math.Geometry;
using System.Collections.Generic;
using System.Linq;

namespace Epicycle.Graphics.Geometry.Ply
{
    public class PlyFace : PlyElement
    {
        public PlyFace()
        {
            VertexIndices = new int[0];
            Normal = null;
            Color = null;
            BackColor = null;
        }

        public override void Parse(IPlyParametersParser parser)
        {
            VertexIndices = parser.GetIntArray("vertex_indices", true);
            Normal = parser.GetVector3("n", false);
            Color = parser.GetColorRGBA("", false);
            BackColor = parser.GetColorRGBA("back_", false);
        }

        public int[] VertexIndices { get; set; }

        public Vector3 Normal { get; set; }

        public ColorRGBA? Color { get; set; }

        public ColorRGBA? BackColor { get; set; }

        protected override void PopulateProperties(IList<string> properties)
        {
            properties.Add("list uchar int vertex_indices");

            if (Normal != null)
            {
                properties.Add("float nx");
                properties.Add("float ny");
                properties.Add("float nz");
            }
            
            if (Color.HasValue)
            {
                properties.Add("uchar red");
                properties.Add("uchar green");
                properties.Add("uchar blue");
                properties.Add("uchar alpha");
            }

            if (BackColor.HasValue)
            {
                properties.Add("uchar back_red");
                properties.Add("uchar back_green");
                properties.Add("uchar back_blue");
                properties.Add("uchar back_alpha");
            } 
        }

        protected override void PopulateSerializedValues(IList<string> serializedValues)
        {
            SerializeToFloat(serializedValues, VertexIndices.Count());

            foreach (var index in VertexIndices)
            {
                SerializeToFloat(serializedValues, index);
            }

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

            if (BackColor.HasValue)
            {
                Serialize(serializedValues, Color.Value.R);
                Serialize(serializedValues, Color.Value.G);
                Serialize(serializedValues, Color.Value.B);
                Serialize(serializedValues, Color.Value.A);
            }
        }
    }
}
