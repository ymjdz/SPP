using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePointPositioning
{
    class NameAndPassword
    {
        public string[] name
        {
            get;
            set;
        }
        public string[] password
        {
            get;
            set;
        }

        public void LogIn()
        {
            name = new string[] { "student", "teacher", "admin","1","password" };
            password = new string[] { "student", "teacher", "admin","1","password" };
        }
    }
}
