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

using Epicycle.Commons.TestUtils;
using Epicycle.Math.Geometry;
using NUnit.Framework;
using System.Drawing;

namespace Epicycle.Graphics.Platform.SystemDrawing.Math.Geometry
{
    [TestFixture]
    public class Vector2UtilsTest
    {
        [Test]
        public void ToVector2_Point_returns_correct_vector()
        {
            var point = new Point(10, 20);
            var vector = point.ToVector2();

            Assert.That(vector.X, Is.EqualTo(10.0));
            Assert.That(vector.Y, Is.EqualTo(20.0));
        }

        [Test]
        public void ToVector2_PointF_returns_correct_vector()
        {
            var point = new PointF(10.1f, 20.8f);
            var vector = point.ToVector2();

            NumericTestUtils.AssertAreEqual(10.1, vector.X);
            NumericTestUtils.AssertAreEqual(20.8, vector.Y);
        }

        [Test]
        public void ToPoint_Vector2_returns_correct_point()
        {
            var vector = new Vector2(10.1, 20.8);
            var point = vector.ToPoint();

            Assert.That(point.X, Is.EqualTo(10));
            Assert.That(point.Y, Is.EqualTo(21));
        }

        [Test]
        public void ToPointF_Vector2_returns_correct_point()
        {
            var vector = new Vector2(10.1, 20.8);
            var point = vector.ToPointF();

            Assert.That(point.X, Is.EqualTo(10.1f));
            Assert.That(point.Y, Is.EqualTo(20.8f));
        }
    }
}
