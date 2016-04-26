using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePointPositioning
{
    class O_FileHead
    {
        public Position Approx_Position = new Position();
        public double AntennaDeltaH
        {
            get;
            set;
        }
        public double AntennaDeltaE
        {
            get;
            set;
        }
        public double AntennaDeltaN
        {
            get;
            set;
        }
        public int L1WaveLength
        {
            get;
            set;
        }
        public int L2WaveLength
        {
            get;
            set;
        }
        public int ObservDataTypeSum
        {
            get;
            set;
        }
        public string[] TypeOfObserv
        {
            get;
            set;
        }
        public double Interval
        {
            get;
            set;
        }
        public Time TimeOfFirstObs = new Time();
        public Time TimeOfLastObs = new Time();
    }
}
