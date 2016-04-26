using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePointPositioning
{
    class O_FileDataHead
    {
        public Time Epoch = new Time();
        public int Epoch_Flag
        {
            get;
            set;
        }
        public int Sat_Num
        {
            get;
            set;
        }
        public int[] Sat_PRN
        {
            get;
            set;
        }
        public double RcvrClkBias
        {
            get;
            set;
        }
    }
}
