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

using Epicycle.Commons.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epicycle.Graphics.Geometry.Ply
{
    public sealed class PlyData : IPlyData
    {
        private readonly IReadOnlyList<PlyVertex> _vertices;
        private readonly IReadOnlyList<PlyFace> _faces;
        private readonly IReadOnlyList<PlyEdge> _edges;

        public PlyData(string plyData)
        {

        }

        public PlyData(IEnumerable<PlyVertex> vertices, IEnumerable<PlyFace> faces, IEnumerable<PlyEdge> edges)
        {
            _vertices = (vertices != null) ? vertices.AsReadOnlyList() : EmptyList<PlyVertex>.Instance;
            _faces = (faces != null) ? faces.AsReadOnlyList() : EmptyList<PlyFace>.Instance;
            _edges = (edges != null) ? edges.AsReadOnlyList() : EmptyList<PlyEdge>.Instance;
        }

        public IReadOnlyList<PlyVertex> Vertices
        {
            get { return _vertices; }
        }

        public IReadOnlyList<PlyFace> Faces
        {
            get { return _faces; }
        }

        public IReadOnlyList<PlyEdge> Edges
        {
            get { return _edges; }
        }

        public string Serialize()
        {
            var plyData = new StringBuilder();

            var vertices = Vertices;
            var faces = Faces;
            var edges = Edges;

            plyData.Append("ply\r\n");
            plyData.Append("format ascii 1.0\r\n");

            SerializeElementConfiguration(plyData, "vertex", vertices);
            SerializeElementConfiguration(plyData, "face", faces);
            SerializeElementConfiguration(plyData, "edge", edges);

            plyData.Append("end_header\r\n");

            SerializeElements(plyData, vertices);
            SerializeElements(plyData, faces);
            SerializeElements(plyData, edges);

            return plyData.ToString();
        }

        private void SerializeElementConfiguration<T>(StringBuilder plyData, string name, IReadOnlyList<T> elements)
            where T : PlyElement
        {
            if (elements.Count > 0)
            {
                plyData.AppendFormat("element {0} {1}\r\n", name, elements.Count);

                foreach (var property in elements[0].GetProperties())
                {
                    plyData.AppendFormat("property {0}\r\n", property);
                }
            }
        }

        private void SerializeElements<T>(StringBuilder plyData, IReadOnlyList<T> elements)
            where T : PlyElement
        {
            foreach (var element in elements)
            {
                plyData.AppendFormat("{0}\r\n", string.Join(" ", element.SerializeValues().ToArray()));
            }
        }
    }
}
