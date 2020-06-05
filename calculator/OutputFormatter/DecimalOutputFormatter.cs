using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class DecimalOutputFormatter :IOutputFormatter
    {        

        public double OutputFormatter(double i)
        {
            return i;
        }
    }
}
