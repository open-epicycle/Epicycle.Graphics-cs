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

namespace Epicycle.Graphics.Color.Spaces
{
    public static class RGBUtils
    {
        #region Standard systems

        // Based on data from http://www.brucelindbloom.com/index.html?Eqn_RGB_XYZ_Matrix.html

        public static readonly RGBColorSystem AdobeRGB_1998 = new RGBColorSystem(
            new float[,] {
                {0.5767309f,  0.1855540f,  0.1881852f },
                { 0.2973769f,  0.6273491f,  0.0752741f },
                { 0.0270343f,  0.0706872f,  0.9911085f }},
            new float[,] {
                { 2.0413690f, -0.5649464f, -0.3446944f },
                {-0.9692660f,  1.8760108f,  0.0415560f },
                { 0.0134474f, -0.1183897f,  1.0154096f }},
            StandardReferenceWhite.D65,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem AppleRGB = new RGBColorSystem(
            new float[,] {
                { 0.4497288f,  0.3162486f,  0.1844926f },
                { 0.2446525f,  0.6720283f,  0.0833192f },
                { 0.0251848f,  0.1411824f,  0.9224628f }},
            new float[,] {
                { 2.9515373f, -1.2894116f, -0.4738445f },
                {-1.0851093f,  1.9908566f,  0.0372026f },
                { 0.0854934f, -0.2694964f,  1.0912975f }},
            StandardReferenceWhite.D65,
            ColorCompandingFunction.Gamma, 1.8f);

        public static readonly RGBColorSystem BestRGB = new RGBColorSystem(
            new float[,] {
                { 0.6326696f,  0.2045558f,  0.1269946f },
                { 0.2284569f,  0.7373523f,  0.0341908f },
                { 0.0000000f,  0.0095142f,  0.8156958f }},
            new float[,] {
                { 1.7552599f, -0.4836786f, -0.2530000f },
                {-0.5441336f,  1.5068789f,  0.0215528f },
                { 0.0063467f, -0.0175761f,  1.2256959f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem BetaRGB = new RGBColorSystem(
            new float[,] {
                { 0.6712537f,  0.1745834f,  0.1183829f },
                { 0.3032726f,  0.6637861f,  0.0329413f },
                { 0.0000000f,  0.0407010f,  0.7845090f }},
            new float[,] {
                { 1.6832270f, -0.4282363f, -0.2360185f },
                {-0.7710229f,  1.7065571f,  0.0446900f },
                { 0.0400013f, -0.0885376f,  1.2723640f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem BruceRGB = new RGBColorSystem(
            new float[,] {
                { 0.4674162f,  0.2944512f,  0.1886026f },
                { 0.2410115f,  0.6835475f,  0.0754410f },
                { 0.0219101f,  0.0736128f,  0.9933071f }},
            new float[,] {
                { 2.7454669f, -1.1358136f, -0.4350269f },
                {-0.9692660f,  1.8760108f,  0.0415560f },
                { 0.0112723f, -0.1139754f,  1.0132541f }},
            StandardReferenceWhite.D65,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem CIE_RGB = new RGBColorSystem(
            new float[,] {
                { 0.4887180f,  0.3106803f,  0.2006017f },
                { 0.1762044f,  0.8129847f,  0.0108109f },
                { 0.0000000f,  0.0102048f,  0.9897952f }},
            new float[,] {
                { 2.3706743f, -0.9000405f, -0.4706338f },
                {-0.5138850f,  1.4253036f,  0.0885814f },
                { 0.0052982f, -0.0146949f,  1.0093968f }},
            StandardReferenceWhite.E,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem ColorMatchRGB = new RGBColorSystem(
            new float[,] {
                { 0.5093439f,  0.3209071f,  0.1339691f },
                { 0.2748840f,  0.6581315f,  0.0669845f },
                { 0.0242545f,  0.1087821f,  0.6921735f }},
            new float[,] {
                { 2.6422874f, -1.2234270f, -0.3930143f },
                {-1.1119763f,  2.0590183f,  0.0159614f },
                { 0.0821699f, -0.2807254f,  1.4559877f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.Gamma, 1.8f);

        public static readonly RGBColorSystem DonRGB4 = new RGBColorSystem(
            new float[,] {
                { 0.6457711f,  0.1933511f,  0.1250978f },
                { 0.2783496f,  0.6879702f,  0.0336802f },
                { 0.0037113f,  0.0179861f,  0.8035125f }},
            new float[,] {
                { 1.7603902f, -0.4881198f, -0.2536126f },
                {-0.7126288f,  1.6527432f,  0.0416715f },
                { 0.0078207f, -0.0347411f,  1.2447743f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem ECI_RGB = new RGBColorSystem(
            new float[,] {
                { 0.6502043f,  0.1780774f,  0.1359384f },
                { 0.3202499f,  0.6020711f,  0.0776791f },
                { 0.0000000f,  0.0678390f,  0.7573710f }},
            new float[,] {
                { 1.7827618f, -0.4969847f, -0.2690101f },
                {-0.9593623f,  1.9477962f, -0.0275807f },
                { 0.0859317f, -0.1744674f,  1.3228273f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.LStar);

        public static readonly RGBColorSystem EktaSpacePS5 = new RGBColorSystem(
            new float[,] {
                { 0.5938914f,  0.2729801f,  0.0973485f },
                { 0.2606286f,  0.7349465f,  0.0044249f },
                { 0.0000000f,  0.0419969f,  0.7832131f }},
            new float[,] {
                { 2.0043819f, -0.7304844f, -0.2450052f },
                {-0.7110285f,  1.6202126f,  0.0792227f },
                { 0.0381263f, -0.0868780f,  1.2725438f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem NTSC_RGB = new RGBColorSystem(
            new float[,] {
                { 0.6068909f,  0.1735011f,  0.2003480f },
                { 0.2989164f,  0.5865990f,  0.1144845f },
                { 0.0000000f,  0.0660957f,  1.1162243f }},
            new float[,] {
                { 1.9099961f, -0.5324542f, -0.2882091f },
                {-0.9846663f,  1.9991710f, -0.0283082f },
                { 0.0583056f, -0.1183781f,  0.8975535f }},
            StandardReferenceWhite.C,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem PAL_SECAM_RGB = new RGBColorSystem(
            new float[,] {
                { 0.4306190f,  0.3415419f,  0.1783091f },
                { 0.2220379f,  0.7066384f,  0.0713236f },
                { 0.0201853f,  0.1295504f,  0.9390944f }},
            new float[,] {
                { 3.0628971f, -1.3931791f, -0.4757517f },
                {-0.9692660f,  1.8760108f,  0.0415560f },
                { 0.0678775f, -0.2288548f,  1.0693490f }},
            StandardReferenceWhite.D65,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem ProPhotoRGB = new RGBColorSystem(
            new float[,] {
                { 0.7976749f,  0.1351917f,  0.0313534f },
                { 0.2880402f,  0.7118741f,  0.0000857f },
                { 0.0000000f,  0.0000000f,  0.8252100f }},
            new float[,] {
                { 1.3459433f, -0.2556075f, -0.0511118f },
                {-0.5445989f,  1.5081673f,  0.0205351f },
                { 0.0000000f,  0.0000000f,  1.2118128f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.Gamma, 1.8f);

        public static readonly RGBColorSystem SMPTE_C_RGB = new RGBColorSystem(
            new float[,] {
                { 0.3935891f,  0.3652497f,  0.1916313f },
                { 0.2124132f,  0.7010437f,  0.0865432f },
                { 0.0187423f,  0.1119313f,  0.9581563f }},
            new float[,] {
                { 3.5053960f, -1.7394894f, -0.5439640f },
                {-1.0690722f,  1.9778245f,  0.0351722f },
                { 0.0563200f, -0.1970226f,  1.0502026f }},
            StandardReferenceWhite.D65,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem SRGB = new RGBColorSystem(
            new float[,] {
                { 0.4124564f,  0.3575761f,  0.1804375f },
                { 0.2126729f,  0.7151522f,  0.0721750f },
                { 0.0193339f,  0.1191920f,  0.9503041f }},
            new float[,] {
                { 3.2404542f, -1.5371385f, -0.4985314f },
                {-0.9692660f,  1.8760108f,  0.0415560f },
                { 0.0556434f, -0.2040259f,  1.0572252f }},
            StandardReferenceWhite.D65,
            ColorCompandingFunction.SRGB);

        public static readonly RGBColorSystem WideGamutRGB = new RGBColorSystem(
            new float[,] {
                { 0.7161046f,  0.1009296f,  0.1471858f },
                { 0.2581874f,  0.7249378f,  0.0168748f },
                { 0.0000000f,  0.0517813f,  0.7734287f }},
            new float[,] {
                { 1.4628067f, -0.1840623f, -0.2743606f },
                {-0.5217933f,  1.4472381f,  0.0677227f },
                { 0.0349342f, -0.0968930f,  1.2884099f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem AdobeRGB_1998_D50Adapted = new RGBColorSystem(
            new float[,] {
                { 0.6097559f,  0.2052401f,  0.1492240f },
                { 0.3111242f,  0.6256560f,  0.0632197f },
                { 0.0194811f,  0.0608902f,  0.7448387f }},
            new float[,] {
                { 1.9624274f, -0.6105343f, -0.3413404f },
                {-0.9787684f,  1.9161415f,  0.0334540f },
                { 0.0286869f, -0.1406752f,  1.3487655f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem AppleRGB_D50Adapted = new RGBColorSystem(
            new float[,] {
                { 0.4755678f,  0.3396722f,  0.1489800f },
                { 0.2551812f,  0.6725693f,  0.0722496f },
                { 0.0184697f,  0.1133771f,  0.6933632f }},
            new float[,] {
                { 2.8510695f, -1.3605261f, -0.4708281f },
                {-1.0927680f,  2.0348871f,  0.0227598f },
                { 0.1027403f, -0.2964984f,  1.4510659f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.Gamma, 1.8f);

        public static readonly RGBColorSystem BruceRGB_D50Adapted = new RGBColorSystem(
            new float[,] {
                { 0.4941816f,  0.3204834f,  0.1495550f },
                { 0.2521531f,  0.6844869f,  0.0633600f },
                { 0.0157886f,  0.0629304f,  0.7464909f }},
            new float[,] {
                { 2.6502856f, -1.2014485f, -0.4289936f },
                {-0.9787684f,  1.9161415f,  0.0334540f },
                { 0.0264570f, -0.1361227f,  1.3458542f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem CIE_RGB_D50Adapted = new RGBColorSystem(
            new float[,] {
                { 0.4868870f,  0.3062984f,  0.1710347f },
                { 0.1746583f,  0.8247541f,  0.0005877f },
                {-0.0012563f,  0.0169832f,  0.8094831f }},
            new float[,] {
                { 2.3638081f, -0.8676030f, -0.4988161f },
                {-0.5005940f,  1.3962369f,  0.1047562f },
                { 0.0141712f, -0.0306400f,  1.2323842f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem NTSC_RGB_D50Adapted = new RGBColorSystem(
            new float[,] {
                { 0.6343706f,  0.1852204f,  0.1446290f },
                { 0.3109496f,  0.5915984f,  0.0974520f },
                {-0.0011817f,  0.0555518f,  0.7708399f }},
            new float[,] {
                { 1.8464881f, -0.5521299f, -0.2766458f },
                {-0.9826630f,  2.0044755f, -0.0690396f },
                { 0.0736477f, -0.1453020f,  1.3018376f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem PAL_SECAM_RGB_D50Adapted = new RGBColorSystem(
            new float[,] {
                { 0.4552773f,  0.3675500f,  0.1413926f },
                { 0.2323025f,  0.7077956f,  0.0599019f },
                { 0.0145457f,  0.1049154f,  0.7057489f }},
            new float[,] {
                { 2.9603944f, -1.4678519f, -0.4685105f },
                {-0.9787684f,  1.9161415f,  0.0334540f },
                { 0.0844874f, -0.2545973f,  1.4216174f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem SMPTE_C_RGB_D50Adapted = new RGBColorSystem(
            new float[,] {
                { 0.4163290f,  0.3931464f,  0.1547446f },
                { 0.2216999f,  0.7032549f,  0.0750452f },
                { 0.0136576f,  0.0913604f,  0.7201920f }},
            new float[,] {
                { 3.3921940f, -1.8264027f, -0.5385522f },
                {-1.0770996f,  2.0213975f,  0.0207989f },
                { 0.0723073f, -0.2217902f,  1.3960932f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.Gamma, 2.2f);

        public static readonly RGBColorSystem SRGB_D50Adapted = new RGBColorSystem(
            new float[,] {
                { 0.4360747f,  0.3850649f,  0.1430804f },
                { 0.2225045f,  0.7168786f,  0.0606169f },
                { 0.0139322f,  0.0971045f,  0.7141733f }},
            new float[,] {
                { 3.1338561f, -1.6168667f, -0.4906146f },
                {-0.9787684f,  1.9161415f,  0.0334540f },
                { 0.0719453f, -0.2289914f,  1.4052427f }},
            StandardReferenceWhite.D50,
            ColorCompandingFunction.SRGB);
        #endregion

        #region CIE XYZ <-> RGB

        public static void CieXYZToRGB(this RGBColorSystem @this, float x, float y, float z, out float r, out float g, out float b)
        {
            float lr, lg, lb;

            @this.CieXYZToLinearRgb(x, y, z, out lr, out lg, out lb);
            @this.LinearRgbToCompandedRgb(lr, lg, lb, out r, out g, out b);
        }

        public static void RGBToCieXYZ(this RGBColorSystem @this, float r, float g, float b, out float x, out float y, out float z)
        {
            float lr, lg, lb;

            @this.CompandedRgbToLinearRgb(r, g, b, out lr, out lg, out lb);
            @this.LinearRgbToCieXYZ(lr, lg, lb, out x, out y, out z);
        }

        #endregion

        #region RGB <-> CIE Lab

        public static void CieLabToRGB(this RGBColorSystem @this, float l, float a, float b, out float rgbR, out float rgbG, out float rgbB, float[] referenceWhite = null)
        {
            float x, y, z;

            CieLabUtils.LabToCieXYZ(l, a, b, out x, out y, out z, referenceWhite);
            @this.CieXYZToRGB(x, y, z, out rgbR, out rgbG, out rgbB);
        }

        public static void RGBToCieLab(this RGBColorSystem @this, float r, float g, float b, out float labL, out float labA, out float labB, float[] referenceWhite = null)
        {
            float x, y, z;

            @this.RGBToCieXYZ(r, g, b, out x, out y, out z);
            CieLabUtils.CieXYZToLab(x, y, z, out labL, out labA, out labB, referenceWhite);
        }

        #endregion
    }
}
