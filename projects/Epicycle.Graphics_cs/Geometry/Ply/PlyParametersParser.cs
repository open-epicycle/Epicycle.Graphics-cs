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
using Epicycle.Math.Geometry;
using System;
using System.Collections.Generic;

namespace Epicycle.Graphics.Geometry.Ply
{
    internal sealed class PlyParametersParser : IPlyParametersParser
    {
        private readonly IReadOnlyList<Tuple<string, string>> _parametersConfiguration;
        private readonly Dictionary<string, object> _parameters;

        public PlyParametersParser(IEnumerable<Tuple<string, string>> parametersConfiguration)
        {
            _parametersConfiguration = parametersConfiguration.ToReadOnlyList();
            _parameters = new Dictionary<string, object>();
        }

        public void SetParameters(string[] parameters)
        {
            var parameterIndex = 0;
            for(var i = 0; i < _parametersConfiguration.Count; i++)
            {
                if (parameterIndex >= parameters.Length)
                {
                    throw new PlyParsingExcpetion("Too few value in line");
                }
                
                var config = _parametersConfiguration[i];

                _parameters[config.Item2] = ReadParameter(config.Item1, parameters, ref parameterIndex);
            }

            if (parameterIndex < parameters.Length)
            {
                throw new PlyParsingExcpetion("Too many value in line");
            }
        }

        private object ReadParameter(string type, string[] parameters, ref int index)
        {
            if (type.StartsWith("list"))
            {
                return ParseIntList(type, parameters, ref index);
            }
            else
            {
                var value = parameters[index];
                index++;

                return ParseScalar(type, value);
            }
        }

        private object ParseIntList(string type, string[] parameters, ref int index)
        {
            var parts = type.Split(':');
            var indexType = parts[1];
            var elemnentType = parts[2];

            var count = Convert.ToInt32(ParseScalar(indexType, parameters[index]));
            index++;

            var list = new int[count];

            for (var i = 0; i < count; i++)
            {
                list[i] = Convert.ToInt32(ParseScalar(elemnentType, parameters[index]));
                index++;
            }

            return list;
        }

        private object ParseScalar(string type, string value)
        {
            switch (type)
            {
                case "char":
                    return sbyte.Parse(value);
                case "uchar":
                    return byte.Parse(value);
                case "short":
                    return short.Parse(value);
                case "ushort ":
                    return ushort.Parse(value);
                case "int":
                    return int.Parse(value);
                case "uint":
                    return uint.Parse(value);
                case "float":
                    return float.Parse(value);
                case "double":
                    return double.Parse(value);
                default:
                    throw new PlyParsingExcpetion(string.Format("Unsupported property type: {0}", type));
            }
        }

        public bool HasParameter(string name)
        {
            return _parameters.ContainsKey(name);
        }

        public byte? GetByte(string name, bool required)
        {
            if (!required && !HasParameter(name))
            {
                return null;
            }

            return Convert.ToByte(GetParameter(name));
        }

        public int? GetInt(string name, bool required)
        {
            if (!required && !HasParameter(name))
            {
                return null;
            }

            return Convert.ToInt32(GetParameter(name));
        }

        public float GetFloat(string name, bool required)
        {
            if (!required && !HasParameter(name))
            {
                return float.NaN;
            }

            return Convert.ToSingle(GetParameter(name));
        }


        public double GetDouble(string name, bool required)
        {
            if (!required && !HasParameter(name))
            {
                return double.NaN;
            }

            return Convert.ToDouble(GetParameter(name));
        }

        public int[] GetIntArray(string name, bool required)
        {
            if (!required && !HasParameter(name))
            {
                return null;
            }

            return (int[])(GetParameter(name));
        }

        public Vector3 GetVector3(string namePrefix, bool required)
        {
            var nameX = namePrefix + "x";
            var nameY = namePrefix + "y";
            var nameZ = namePrefix + "z";

            if (!required && !HasParameter(nameX))
            {
                return null;
            }

            return new Vector3(
                GetDouble(nameX, true),
                GetDouble(nameY, true),
                GetDouble(nameZ, true)
                );
        }

        public Rotation3? GetRotation3(string namePrefix, bool required)
        {
            var nameAngle = namePrefix + "a";

            if (!required && !HasParameter(nameAngle))
            {
                return null;
            }

            return new Rotation3(GetDouble(nameAngle, true), GetVector3(namePrefix, true));
        }

        public Color4b? GetColor4b(string namePrefix, bool required)
        {
            var nameR = namePrefix + "red";
            var nameG = namePrefix + "green";
            var nameB = namePrefix + "blue";
            var nameA = namePrefix + "alpha";

            if(!HasParameter(nameR) && !HasParameter(nameA))
            {
                if(!required)
                {
                    return null;
                }
                else
                {
                    throw new PlyParsingExcpetion(string.Format("Expected parameter: {0} or {1}", nameR, nameA));
                }
            }

            var r = HasParameter(nameR) ? GetByte(nameR, true).Value : byte.MaxValue;
            var g = HasParameter(nameR) ? GetByte(nameG, true).Value : byte.MaxValue;
            var b = HasParameter(nameR) ? GetByte(nameB, true).Value : byte.MaxValue;
            var a = HasParameter(nameR) ? GetByte(nameA, true).Value : byte.MaxValue;

            return new Color4b(r, g, b, a);
        }

        public object GetParameter(string name)
        {
            if (!HasParameter(name))
            {
                throw new PlyParsingExcpetion(string.Format("Expected parameter: {0}", name));
            }

            return _parameters[name];
        }
    }
}
