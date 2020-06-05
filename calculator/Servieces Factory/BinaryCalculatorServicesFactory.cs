using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class BinaryCalculatorServicesFactory : INumberSystemServicesFactory
    {
        public IInputValidator GetInputValidator()
        {
            return new BinaryInputValidator();
        }

        public IOutputFormatter GetOutputFormatter()
        {
            return new BinaryOutputFormatter();
        }
    }
}
