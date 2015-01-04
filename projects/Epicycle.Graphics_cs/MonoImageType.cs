using System;
using System.Collections.Generic;
using System.Linq;

namespace Epicycle.Graphics
{
    public struct MonoImageType : IImageType
    {
        public int ChannelsCount
        {
            get { return 1; }
        }
    }
}
