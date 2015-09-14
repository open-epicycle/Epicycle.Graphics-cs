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
    public static class ReferenceWhiteUtils
    {
        // Based on http://www.brucelindbloom.com/index.html?Eqn_ChromAdapt.html

        public static float[] ReferenceWhite_XYZ_A   = new float[] { 1.09850f, 1.00000f, 0.35585f };
        public static float[] ReferenceWhite_XYZ_B   = new float[] { 0.99072f, 1.00000f, 0.85223f };
        public static float[] ReferenceWhite_XYZ_C   = new float[] { 0.98074f, 1.00000f, 1.18232f };
        public static float[] ReferenceWhite_XYZ_D50 = new float[] { 0.96422f, 1.00000f, 0.82521f };
        public static float[] ReferenceWhite_XYZ_D55 = new float[] { 0.95682f, 1.00000f, 0.92149f };
        public static float[] ReferenceWhite_XYZ_D65 = new float[] { 0.95047f, 1.00000f, 1.08883f };
        public static float[] ReferenceWhite_XYZ_D75 = new float[] { 0.94972f, 1.00000f, 1.22638f };
        public static float[] ReferenceWhite_XYZ_E   = new float[] { 1.00000f, 1.00000f, 1.00000f };
        public static float[] ReferenceWhite_XYZ_F2  = new float[] { 0.99186f, 1.00000f, 0.67393f };
        public static float[] ReferenceWhite_XYZ_F7  = new float[] { 0.95041f, 1.00000f, 1.08747f };
        public static float[] ReferenceWhite_XYZ_F11 = new float[] { 1.00962f, 1.00000f, 0.64350f };

        public static float[] GetStandardReferenceWhiteXYZ(StandardReferenceWhite referenceWhite)
        {
            switch(referenceWhite)
            {
                case StandardReferenceWhite.A:
                    return ReferenceWhite_XYZ_A;
                case StandardReferenceWhite.B:
                    return ReferenceWhite_XYZ_B;
                case StandardReferenceWhite.C:
                    return ReferenceWhite_XYZ_C;
                case StandardReferenceWhite.D50:
                    return ReferenceWhite_XYZ_D50;
                case StandardReferenceWhite.D55:
                    return ReferenceWhite_XYZ_D55;
                case StandardReferenceWhite.D65:
                    return ReferenceWhite_XYZ_D65;
                case StandardReferenceWhite.D75:
                    return ReferenceWhite_XYZ_D75;
                case StandardReferenceWhite.E:
                    return ReferenceWhite_XYZ_E;
                case StandardReferenceWhite.F2:
                    return ReferenceWhite_XYZ_F2;
                case StandardReferenceWhite.F7:
                    return ReferenceWhite_XYZ_F7;
                case StandardReferenceWhite.F11:
                    return ReferenceWhite_XYZ_F11;
                default:
                    throw new ArgumentException("Illegal reference white");
            }
        }
    }
}
