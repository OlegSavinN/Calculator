using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    interface ICalculate
    {
        
        void ArithmeticAction();
        void PercentAction();
        string EqualAction(Sign action);
        void state(Sign i);
        void EnterVariable(double i);
        void ClearAll();
        void Clear();
        void ClearTwoNumber();
        bool Save();
        double OutpudSaveNumber();
        void ClearMemory();
        void AddToMemory();
        void SubToMemory();
        void CommaOn();
        void NegPos();

    }
}
