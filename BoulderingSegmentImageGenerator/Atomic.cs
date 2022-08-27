using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderingSegmentImageGenerator
{
    class Atomic
    {

        public Atomic()
        {
            this.flag = false;
        }

        public void Lock(Action action)
        {
            if (flag)
                return;
            flag = true;

            action();

            flag = false;
        }

        // true : Lock中
        // false : lockが解除されている.
        private bool flag;
    }
}

