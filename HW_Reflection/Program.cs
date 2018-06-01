using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Service serv = new Service();
            serv.ServiceAddInfo();
        }
    }
}
