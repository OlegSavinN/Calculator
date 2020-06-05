using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class CalculatorService : ICalculate
    {
        private NumberSystem _numberSystem;
        public void SetNumberSystem(NumberSystem numberSystem)
        {
            _numberSystem = numberSystem;

        }

        public void inputnumber()
        {
            double _number3 = _numberSystem.ServicesFactory.GetInputValidator().InputValidator(_number2);
            _number2 = _number3;
            
        }

        public void outputnumber()
        {
            double _number3 = _numberSystem.ServicesFactory.GetOutputFormatter().OutputFormatter(_number1);
            _number1 = _number3;
        }

        double _number1; 
        double _number2;
        double _result;
        double _memory;  // число в памяти
        Sign _action;   // какой символ нажат
        CommaFractions _comma; 
        int _degree;
        string _sign { get; set; }

       


        public CalculatorService()
        {
            _number1 = 0;
            _number2 = 0;
            _memory = 0;
            _result = 0;
            _action = Sign.Start;
            _comma = CommaFractions.No;
        }

        public void ArithmeticAction()
        {
            
            if (_number2 != 0)
            {
                switch (_action)
                {
                    case Sign.Start:
                        _number1 = _number2;
                        break;
                    case Sign.Equal:
                        _number1 = _number2;
                        break;

                    case Sign.Plus:
                        _number1 += _number2;
                        break;

                    case Sign.Minus:
                        _number1 -= _number2;
                        break;

                    case Sign.Div:
                        _number1 /= _number2;
                        break;

                    case Sign.Mult:
                        _number1 *= _number2;
                        break;


                }
            }
            _number2 = 0;
            _comma = CommaFractions.No;
            _degree = 0;

        }
        public void PercentAction()
        {
            _number2 = _number1 / 100 * _number2;
        }
        public string EqualAction(Sign action)
        {
            _result = _number1;
            return _result.ToString();
            _comma = CommaFractions.No;
            _degree = 0;
        }
        public void state(Sign i)
        {
            _action = i;
        }
        public void EnterVariable(double i) // Вводимое число
        {
            if (_comma == CommaFractions.No)
            {
                _number2 = (_number2 * 10) + i;
            }
            else
            {
                _degree++;
                _number2 += i / Math.Pow(10, _degree);
            }

        }
        public void ClearAll()
        {
            _number1 = 0;
            _number2 = 0;
            _memory = 0;
            _result = 0;
            _action = Sign.Start;
            _comma = CommaFractions.No;
            _degree = 0;
        } //Очищаем все
        public void Clear()
        {
            if (_degree == 0) //удаление с простым числом
            {
                int i = (int)_number2 / 10;
                _number2 = (double)i;
            }
            else   //удаление с десятичным числом
            {
                _degree--;
                int i = (int)(_number2 * Math.Pow(10, _degree));
                _number2 = i / Math.Pow(10, _degree);
            }
        }   //Удаление по 1 элементу.
        public void ClearTwoNumber()
        {
            _number2 = 0;
        }
        public bool Save()
        {
            if (_number2 != 0)
            {
                _memory = _number2;
                return true;
            }
            if (_result != 0)
            {
                _memory = _result;
                return true;
            }
            return false;
        }
        public double OutpudSaveNumber()
        {
            _number2 = _memory;
            return _number2;
        }
        public void ClearMemory()
        {
            _memory = 0;
        }
        public void AddToMemory()
        {
            _memory += _number2;
        }
        public void SubToMemory()
        {
            _memory -= _number2;
        }
        public void CommaOn()
        {
            _comma = CommaFractions.Yes;
        }
        public void NegPos()
        {
            _number2 *= -1;
        }

        public void InBinary(double currect)
        {
 
            
        }
    }       
 }
