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

using System;

namespace Epicycle.Graphics.Color.Spaces
{
    public static class LChUtils
    {
        #region Lxy <-> LCh

        public static void LxyToLCh(float l, float x, float y, out float lch_l, out float lch_c, out float lch_h)
        {
            float h_rad;
            MathUtils.CartesianToPolarCoordinatesPositive(x, y, out lch_c, out h_rad);

            lch_l = l;
            lch_h = MathUtils.RadToUnit(h_rad);
        }

        public static void LChToLxy(float l, float c, float h, out float lxy_l, out float lxy_x, out float lxy_y)
        {
            lxy_l = l;
            MathUtils.PolarToCartesianCoordinates(c, MathUtils.UnitToRad(h), out lxy_x, out lxy_y);
        }

        #endregion

        #region CIE XYZ <-> LCh

        public static void CieXYZToLCh(
            float x, float y, float z, 
            out float l, out float c, out float h, 
            LxyModel model = LxyModel.Lab, float[] referenceWhiteXyz = null)
        {
            float lxy_l, lxy_x, lxy_y;
            switch(model)
            {
                case LxyModel.Lab:
                    CieLabUtils.CieXYZToLab(x, y, z, out lxy_l, out lxy_x, out lxy_y, referenceWhiteXyz);
                    break;
                case LxyModel.Luv:
                    CieLuvUtils.CieXYZToLuv(x, y, z, out lxy_l, out lxy_x, out lxy_y, referenceWhiteXyz);
                    break;
                default:
                    throw new ArgumentException("Illegal model!");
            }

            LxyToLCh(lxy_l, lxy_x, lxy_y, out l, out c, out h);
        }

        public static void LChToCieXYZ(
            float l, float c, float h, 
            out float x, out float y, out float z, 
            LxyModel model = LxyModel.Lab, float[] referenceWhiteXyz = null)
        {
            float lxy_l, lxy_x, lxy_y;
            LChToLxy(l, c, h, out lxy_l, out lxy_x, out lxy_y);

            switch (model)
            {
                case LxyModel.Lab:
                    CieLabUtils.LabToCieXYZ(lxy_l, lxy_x, lxy_y, out x, out y, out z, referenceWhiteXyz);
                    break;
                case LxyModel.Luv:
                    CieLuvUtils.LuvToCieXYZ(lxy_l, lxy_x, lxy_y, out x, out y, out z, referenceWhiteXyz);
                    break;
                default:
                    throw new ArgumentException("Illegal model!");
            }
        }

        #endregion
    }
}
