using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePointPositioning
{
    class N_FlieHead
    {
        public double[] Ion_Alpha
        {
            get;
            set;
        }
        //public double IONA1
        //{
        //    get;
        //    set;
        //}
        //public double IONA2
        //{
        //    get;
        //    set;
        //}
        //public double IONA3
        //{
        //    get;
        //    set;
        //}
        public double[] Ion_Beta
        {
            get;
            set;
        }
        //public double IONB1
        //{
        //    get;
        //    set;
        //}
        //public double IONB2
        //{
        //    get;
        //    set;
        //}
        //public double IONB3
        //{
        //    get;
        //    set;
        //}
        public double A0
        {
            get;
            set;
        }
        public double A1
        {
            get;
            set;
        }
        public int T
        {
            get;
            set;
        }
        public int W
        {
            get;
            set;
        }
        public int Leap_Seconds
        {
            get;
            set;
        }
    }
}
