using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderingSegmentImageGenerator
{
    public enum HoldsType
    {
        Holds,
        Volume,
        Background,
    }

    public class Paint
    {


        public Paint()
        {

        }

        private void setSelectedType(HoldsType t)
        {
            this.selectedHold = t;
        }

        public void selectHolds()
        {
            setSelectedType(HoldsType.Holds);
        }

        public void selectVolume()
        {
            setSelectedType(HoldsType.Volume);
        }

        public void selectBackground()
        {
            setSelectedType(HoldsType.Background);
        }
        HoldsType selectedHold;
    }
}
