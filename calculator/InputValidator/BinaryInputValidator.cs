using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class BinaryInputValidator : IInputValidator
    {

        public double InputValidator(double h)
        {
            string i = h.ToString();
            ulong num = 0, ost = 0, result = 0, count = 0, s = 0;
            num = ulong.Parse(i);
            while (num > 0)
            {
                ost = num % 10;
                s = Convert.ToUInt64(Math.Pow(2, count));
                result = result + ost * s;
                count += 1;
                num = num / 10;
            }

            return result;
        }
    }
}
