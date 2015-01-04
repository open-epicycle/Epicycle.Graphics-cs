namespace Epicycle.Graphics
{
    public static class Color4bUtils
    {
        public sealed class YamlSerialization
        {
            public int R { get; set; }
            public int G { get; set; }
            public int B { get; set; }
            public int A { get; set; }

            public YamlSerialization() { }

            public YamlSerialization(Color4b color)
            {
                R = color.R;
                G = color.G;
                B = color.B;
                A = color.A;
            }

            public Color4b Deserialize()
            {
                return new Color4b((byte)R, (byte)G, (byte)B, (byte)A);
            }
        }
    }
}
