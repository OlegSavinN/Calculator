using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.Servieces_Factory
{
    class HexadecimalCalculatorServicesFactory : INumberSystemServicesFactory
    {
        public IInputValidator GetInputValidator()
        {
            return new he
        }

        public IOutputFormatter GetOutputFormatter()
        {
            return new BinaryOutputFormatter();
        }
    }
}
