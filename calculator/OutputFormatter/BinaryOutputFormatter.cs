using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class BinaryOutputFormatter : IOutputFormatter
    {
        public double OutputFormatter(double h)
        {
            int temp = Convert.ToInt32(h);
            int temp1 = 0;
            List<int> s = new List<int>();

            while (temp > 0)
            {
                temp1 = temp % 2;
                temp = temp / 2;
                s.Add(temp1);
            }

            int[] g = new int[s.Count];

            for (int i = s.Count - 1; i >= 0; i--)
            {
                g[s.Count - 1 - i] = s[i];
            }

            return Convert.ToDouble(string.Join<int>("", g));                    ///////////////////////////////////////
        }
    }
}
