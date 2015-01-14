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

using System.Collections.Generic;

namespace Epicycle.Graphics.Geometry.Ply
{
    public abstract class PlyElement
    {
        public abstract void Parse(IPlyParametersParser parser);

        public IEnumerable<string> GetProperties()
        {
            var properties = new List<string>();

            PopulateProperties(properties);

            return properties;
        }

        protected abstract void PopulateProperties(IList<string> properties);

        public IEnumerable<string> SerializeValues()
        {
            var serializedValues = new List<string>();

            PopulateSerializedValues(serializedValues);

            return serializedValues; 
        }

        protected abstract void PopulateSerializedValues(IList<string> serializedValues);

        protected void SerializeToFloat(IList<string> serializedValues, double value)
        {
            Serialize(serializedValues, (float)value);
        }

        protected void Serialize(IList<string> serializedValues, byte value)
        {
            serializedValues.Add(value.ToString());
        }

        protected void Serialize(IList<string> serializedValues, int value)
        {
            serializedValues.Add(value.ToString());
        }

        protected void Serialize(IList<string> serializedValues, float value)
        {
            serializedValues.Add(value.ToString());
        }
    }
}
