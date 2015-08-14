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

using Epicycle.Commons;

namespace Epicycle.Graphics.Color.Spaces
{
    public sealed class RGBColorSystem
    {
        private readonly float[,] _rgbToXyzMatrix;
        private readonly float[,] _xyzToRgbMatrix;
        private readonly StandardReferenceWhite _referenceWhite; 
        private readonly ColorCompandingFunction _compandingFunction;
        private readonly float _gamma;

        public RGBColorSystem(
            float[,] rgbToXyzMatrix, float[,] xyzToRgbMatrix, 
            StandardReferenceWhite referenceWhite, 
            ColorCompandingFunction compandingFunction, float gamma = 0)
        {
            MathUtils.EnsureMatrix3AndInvese(rgbToXyzMatrix, xyzToRgbMatrix, out _rgbToXyzMatrix, out _xyzToRgbMatrix);

            _referenceWhite = referenceWhite;
            _compandingFunction = compandingFunction;
            _gamma = gamma;
        }

        public StandardReferenceWhite ReferenceWhite
        {
            get { return _referenceWhite; }
        }

        #region CIE XYZ <-> Linear RGB

        public void CieXYZToLinearRgb(float x, float y, float z, out float linearR, out float linearG, out float linearB)
        {
            float tr, tg, tb;

            MathUtils.TransformVector3(_xyzToRgbMatrix, x, y, z, out tr, out tg, out tb);

            linearR = MathUtils.ClipUnit(tr);
            linearG = MathUtils.ClipUnit(tg);
            linearB = MathUtils.ClipUnit(tb);
        }

        public void LinearRgbToCieXYZ(float linearR, float linearG, float linearB, out float x, out float y, out float z)
        {
            MathUtils.TransformVector3(
                _rgbToXyzMatrix,
                MathUtils.ClipUnit(linearR), MathUtils.ClipUnit(linearG), MathUtils.ClipUnit(linearB), 
                out x, out y, out z);
        }

        #endregion

        #region Linear RGB <-> Companded RGB

        public void LinearRgbToCompandedRgb(
            float linearR, float linearG, float linearB,
            out float compandedR, out float compandedG, out float compandedB)
        {
            switch (_compandingFunction)
            {
                case ColorCompandingFunction.Gamma:
                    compandedR = ColorCompandingUtils.ApplyGammaCompanding(linearR, _gamma);
                    compandedG = ColorCompandingUtils.ApplyGammaCompanding(linearG, _gamma);
                    compandedB = ColorCompandingUtils.ApplyGammaCompanding(linearB, _gamma);
                    break;
                case ColorCompandingFunction.SRGB:
                    compandedR = ColorCompandingUtils.ApplySRGBCompanding(linearR);
                    compandedG = ColorCompandingUtils.ApplySRGBCompanding(linearG);
                    compandedB = ColorCompandingUtils.ApplySRGBCompanding(linearB);
                    break;
                case ColorCompandingFunction.LStar:
                    compandedR = ColorCompandingUtils.ApplyLStarCompanding(linearR);
                    compandedG = ColorCompandingUtils.ApplyLStarCompanding(linearG);
                    compandedB = ColorCompandingUtils.ApplyLStarCompanding(linearB);
                    break;
                default:
                    throw new InternalException("Illegal companding function");
            }
        }

        public void CompandedRgbToLinearRgb(
            float compandedR, float compandedG, float compandedB,
            out float linearR, out float linearG, out float linearB)
        {
            switch (_compandingFunction)
            {
                case ColorCompandingFunction.Gamma:
                    linearR = ColorCompandingUtils.ApplyInverseGammaCompanding(compandedR, _gamma);
                    linearG = ColorCompandingUtils.ApplyInverseGammaCompanding(compandedG, _gamma);
                    linearB = ColorCompandingUtils.ApplyInverseGammaCompanding(compandedB, _gamma);
                    break;
                case ColorCompandingFunction.SRGB:
                    linearR = ColorCompandingUtils.ApplyInverseSRGBCompanding(compandedR);
                    linearG = ColorCompandingUtils.ApplyInverseSRGBCompanding(compandedG);
                    linearB = ColorCompandingUtils.ApplyInverseSRGBCompanding(compandedB);
                    break;
                case ColorCompandingFunction.LStar:
                    linearR = ColorCompandingUtils.ApplyInverseLStarCompanding(compandedR);
                    linearG = ColorCompandingUtils.ApplyInverseLStarCompanding(compandedG);
                    linearB = ColorCompandingUtils.ApplyInverseLStarCompanding(compandedB);
                    break;
                default:
                    throw new InternalException("Illegal companding function");
            }
        }

        #endregion
    }
}
