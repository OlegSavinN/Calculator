using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class NumberSystemProvider : INumberSystemProvider
    {
        
    public NumberSystem GetBinarySystem()
    {
         return new NumberSystem
         {
             ServicesFactory = new BinaryCalculatorServicesFactory()
         };
    }


    public NumberSystem GetDecimalSystem()
    {
        return new NumberSystem
        {
            ServicesFactory = new DecimalCalculateServicesFactory()
        };
        
    }

        public NumberSystem GetHexadecimalSystem()
        {
            return new NumberSystem
            {
                ServicesFactory = new HexaDecimalCalculateServicesFactory()
            };

        }
    }
}
