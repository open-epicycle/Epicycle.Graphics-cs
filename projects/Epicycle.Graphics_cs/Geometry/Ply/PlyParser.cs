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
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epicycle.Graphics.Geometry.Ply
{
    internal static class PlyParser
    {
        public static void Parse<TVertex, TFace, TEdge>(
            string plyData, 
            out IReadOnlyList<TVertex> vertices, 
            out IReadOnlyList<TFace> faces, 
            out IReadOnlyList<TEdge> edges)

            where TVertex : PlyVertex, new()
            where TFace : PlyFace, new()
            where TEdge : PlyEdge, new()
        {
            var verticesList = new List<TVertex>();
            var facesList = new List<TFace>();
            var edgesList = new List<TEdge>();

            var tokenStream = new PlyTokenStream(plyData);

            var elementsConfiguration = ParseHeader(tokenStream);

            foreach (var elementConfiguration in elementsConfiguration)
            {
                var parametersParser = new PlyParametersParser(elementConfiguration.Properties);
                for(int i = 0; i < elementConfiguration.Count; i++)
                {
                    parametersParser.SetParameters(tokenStream.CurLine);

                    var element = CreateElement<TVertex, TFace, TEdge>(
                        verticesList,
                        facesList,
                        edgesList,
                        elementConfiguration.Name);

                    element.Parse(parametersParser);

                    tokenStream.NextLine();
                }
            }

            vertices = verticesList.AsReadOnlyList();
            faces = facesList.AsReadOnlyList();
            edges = edgesList.AsReadOnlyList();
        }

        private static PlyElement CreateElement<TVertex, TFace, TEdge>(
            IList<TVertex> vertices,
            IList<TFace> faces,
            IList<TEdge> edges, 
            string elementType)

            where TVertex : PlyVertex, new()
            where TFace : PlyFace, new()
            where TEdge : PlyEdge, new()
        {
            PlyElement element = null;

            if(elementType == "vertex")
            {
                var vertex = new TVertex();
                vertices.Add(vertex);
                element = vertex;
            }
            else if (elementType == "face")
            {
                var face = new TFace();
                faces.Add(face);
                element = face;
            }
            else if (elementType == "edge")
            {
                var edge = new TEdge();
                edges.Add(edge);
                element = edge;
            }

            return element;
        }

        private static IEnumerable<ElementConfiguration> ParseHeader(PlyTokenStream tokenStream)
        {
            tokenStream.NextTokenExpectValue("ply", "'ply' magic string was expected.");
            tokenStream.NextLineExpectNoMoreTokens();

            tokenStream.NextTokenExpectValue("format", "'format' keyword was expected.");
            tokenStream.NextTokenExpectValue("ascii", "Only ascii format is supported.");
            tokenStream.NextTokenExpectValue("1.0", "Only PLY 1.0 is supported");
            tokenStream.NextLineExpectNoMoreTokens();

            var elementsConfiguration = new List<ElementConfiguration>();

            while (ParseHeaderElement(tokenStream, elementsConfiguration)) { }

            return elementsConfiguration;
        }

        private static bool ParseHeaderElement(PlyTokenStream tokenStream, IList<ElementConfiguration> elementsConfiguration)
        {
            SkipComments(tokenStream);

            if (tokenStream.CurToken == "end_header")
            {
                tokenStream.ReadToken();
                tokenStream.NextLineExpectNoMoreTokens();

                return false;
            }

            tokenStream.NextTokenExpectValue("element", "'element' keyword was expected.");

            var elementName = tokenStream.ReadTokenExpected();

            if (elementName == null || (elementName != "vertex" && elementName != "face" && elementName != "edge"))
            {
                throw new PlyParsingExcpetion(string.Format("Unsupported element {0}", elementName));
            }

            var count = int.Parse(tokenStream.ReadTokenExpected());
            tokenStream.NextLineExpectNoMoreTokens();

            SkipComments(tokenStream);

            var properties = new List<Tuple<string, string>>();

            while (tokenStream.CurToken == "property")
            {
                tokenStream.NextToken();

                var type = tokenStream.ReadTokenExpected();
                string fullType;

                if (type == "list")
                {
                    var listIndexType = tokenStream.ReadTokenExpected();
                    var listValuesType = tokenStream.ReadTokenExpected();

                    fullType = string.Format("{0}:{1}:{2}", type, listIndexType, listValuesType);
                }
                else
                {
                    fullType = type;
                }

                var name = tokenStream.ReadTokenExpected();

                properties.Add(Tuple.Create(fullType, name));

                tokenStream.NextLineExpectNoMoreTokens();
                SkipComments(tokenStream);
            }

            elementsConfiguration.Add(new ElementConfiguration(elementName, properties, count));

            return true;
        }

        private static void SkipComments(PlyTokenStream tokenStream)
        {
            while(tokenStream.CurToken == "comment")
            {
                tokenStream.NextLine();
            }
        }

        private static void ValidateLine(IList<string> lines, int lineIndex, string expected)
        {
            if(lines[lineIndex] != expected)
            {
                    
            }
        }

        private class ElementConfiguration
        {
            private readonly string _name;
            private readonly IEnumerable<Tuple<string, string>> _properties;
            private readonly int _count;

            public ElementConfiguration(string name, IEnumerable<Tuple<string, string>> properties, int count)
            {
                _name = name;
                _properties = properties;
                _count = count;
            }

            public string Name
            {
                get { return _name; }
            }

            public IEnumerable<Tuple<string, string>> Properties
            {
                get { return _properties; }
            }

            public int Count
            {
                get { return _count; }
            }
        }

        private class PlyTokenStream
        {
            private readonly string[][] _tokenizedLines;
            private int _lineCursor;
            private int _tokenCursor;

            public PlyTokenStream(string plyData)
            {
                _tokenizedLines = plyData.Replace("\r", "").Split('\n').Select(x => x.Trim()).Where(x => x != "").Select(x => ParseLine(x)).ToArray();

                _lineCursor = 0;
                _tokenCursor = 0;
            }

            private static string[] ParseLine(string line)
            {
                return line.Split(' ').Select(x => x.Trim()).Where(x => x != "").ToArray();
            }

            public string[] CurLine
            {
                get { return HasLine ? _tokenizedLines[_lineCursor] : null; }
            }

            public string CurToken
            {
                get { return HasToken ? _tokenizedLines[_lineCursor][_tokenCursor] : null; }
            }

            public string[] ReadLine()
            {
                var result = CurLine;
                NextLine();

                return result;
            }

            public string ReadToken()
            {
                var result = CurToken;
                NextToken();

                return result;
            }

            public string ReadTokenExpected(string errorMessage = null)
            {
                if(!HasToken)
                {
                    throw new PlyParsingExcpetion(errorMessage ?? "Unexpected end of line!");
                }

                var result = CurToken;
                NextToken();

                return result;
            }

            public bool HasLine
            {
                get { return _lineCursor < _tokenizedLines.Length; }
            }

            public bool HasToken
            {
                get { return HasLine && _tokenCursor < CurLine.Length; }
            }

            public void NextLine()
            {
                _lineCursor++;
                _tokenCursor = 0;
            }

            public void NextToken()
            {
                _tokenCursor++;
            }

            public void NextTokenExpectValue(string expectedToken, string errorMessage)
            {
                var nextToken = ReadToken();

                if(nextToken == null || nextToken != expectedToken)
                {
                    throw new PlyParsingExcpetion(errorMessage);
                }
            }

            public void NextLineExpectNoMoreTokens(string errorMessage = null)
            {
                if(HasToken)
                {
                    throw new PlyParsingExcpetion(errorMessage ?? "Unexpected end of line!");
                }

                NextLine();
            }
        }
    }
}
