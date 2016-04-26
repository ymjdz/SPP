using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePointPositioning
{
    class Constant
    {
        public static double Pi
        {
            get;
            set;
        }
        public static double SpeedOfLight
        {
            get;
            set;
        }
        public static double GM
        {
            get;
            set;
        }
        public static double OmegaDotE
        {
            get;
            set;
        }
        static Constant()
        {
            Pi = 3.1415926535898;
            SpeedOfLight = 2.99792458 * Math.Pow(10, 8);
            GM = 3.986005 * Math.Pow(10, 14);
            OmegaDotE = 7.2921151467 * Math.Pow(10, -5);
        }
    }
}
