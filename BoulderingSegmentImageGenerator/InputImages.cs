using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderingSegmentImageGenerator
{
    internal class InputImages
    {
        public InputImages()
        {

        }

        public void setfiles(List<string> f)
        {
            this.images = f;
        }

        List<string> images = new List<string>();
    }
}
