using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePointPositioning
{
    class ReceiverPosition
    {
        public double X
        {
            get;
            set;
        }
        public double Y
        {
            get;
            set;
        }
        public double Z
        {
            get;
            set;
        }
        public double Cdtr
        {
            get;
            set;
        }
        public GPSTime RPTime = new GPSTime();
    }
}
