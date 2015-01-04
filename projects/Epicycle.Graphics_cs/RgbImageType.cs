using System;
using System.Collections.Generic;
using System.Linq;

namespace Epicycle.Graphics
{
    public struct RgbImageType : IImageType
    {
        public int ChannelsCount
        {
            get { return 3; }
        }
    }
}
