using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{ 
    class DecimalCalculateServicesFactory : INumberSystemServicesFactory
    {
        public IInputValidator GetInputValidator()
        {
            return new DecimalInputValidator();
        }

        public IOutputFormatter GetOutputFormatter()
        {
            return new DecimalOutputFormatter();
        }
    }
}
