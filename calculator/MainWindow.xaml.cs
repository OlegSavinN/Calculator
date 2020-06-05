using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Sign _step;
        Save _memory = Save.Off;
        NegativePositive _current = NegativePositive.Positive;

        private CalculatorService _calculator;
        private INumberSystemProvider _numberSystemProvider;
        public MainWindow()
        {
            InitializeComponent();
            _calculator = new CalculatorService();
            _numberSystemProvider = new NumberSystemProvider();
            _calculator.SetNumberSystem(_numberSystemProvider.GetBinarySystem());

            List<string> styles = new List<string> { "Ordinary", "Programmer" };

            //Menu.Sele
            //styleBox.SelectionChanged += ThemeChange;
            //styleBox.ItemsSource = styles;
            //styleBox.SelectedItem = "Ordinary";

        }



        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            ////string style = styleBox.SelectedItem as string;
            //string style = Menu.sele
            //// определяем путь к файлу ресурсов
            //var uri = new Uri(style + ".xaml", UriKind.Relative);
            //// загружаем словарь ресурсов
            //ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            //// очищаем коллекцию ресурсов приложения
            //Application.Current.Resources.Clear();
            //// добавляем загруженный словарь ресурсов
            //Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
        private void OnEqualClick(object sender, RoutedEventArgs e)
        {
            _calculator.inputnumber();
            Sign sign = (Sign)((Button)sender).Tag;
            if (_step != sign)
            {
                example.Text += (string)((Button)e.OriginalSource).Content;
                _calculator.ArithmeticAction();
                _calculator.outputnumber();
                result.Text = _calculator.EqualAction(sign);
                example.Text += _calculator.EqualAction(sign); 
                _calculator.state(sign);
                _step = sign;
                _current = NegativePositive.Positive;
            }
        }       
        private void OnCalcBtnClick(object sender, RoutedEventArgs e)
        {
            _calculator.inputnumber();
            Sign sign = (Sign)((Button)sender).Tag;
            if (sign != Sign.Perc)
            {
                _calculator.ArithmeticAction();
                //}  //сначала проверяем action и выполняем соответствующее действие
                _calculator.state(sign); //после меняем action в зависимости от нажатой кнопки
                example.Text += (string)((Button)e.OriginalSource).Content;   //записываем
                _step = sign;
            }
            else // это если нажата кнопка процента
            {
                _calculator.PercentAction();
            }
            result.Text = "";
            _current = NegativePositive.Positive;
        }
        private void OnClearBtnClick(object sender, RoutedEventArgs e)
        {
            Sign sign = (Sign)((Button)sender).Tag;
            switch (sign)
            {
                case Sign.CBtn:
                    _calculator.ClearAll();
                    result.Text = "";
                    example.Text = "";
                    SaveBox.Text = "";
                    break;

                case Sign.CeBtn:
                    _calculator.ClearTwoNumber();
                    example.Text = example.Text.Remove(example.Text.Length - result.Text.Length, result.Text.Length);
                    result.Text = "";
                    _current = NegativePositive.Positive;
                    break;

                case Sign.ClearBtn:
                    if (result.Text.Length != 0)
                    {
                        _calculator.Clear();
                        example.Text = example.Text.Remove(example.Text.Length - 1);
                        result.Text = result.Text.Remove(result.Text.Length - 1);
                    }
                    break;
            }
        }
        private void OnDigitBtnClick(object sender, RoutedEventArgs e)
        {
            if (_step == Sign.Equal)
            {
                _calculator.ClearAll();
                result.Text = "";
                example.Text = "";
                _step = Sign.Start;
            }
            double variable = double.Parse(((Button)sender).Tag.ToString());
            _calculator.EnterVariable(variable);
            example.Text += ((Button)sender).Tag;
            result.Text += ((Button)sender).Tag;
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                
                case Key.NumPad0:
                    OnDigitBtnClick(Num0Btn, null);
                    break;
                case Key.NumPad1:
                    OnDigitBtnClick(Num1Btn, null);
                    break;
                case Key.NumPad2:
                    OnDigitBtnClick(Num2Btn, null);
                    break;
                case Key.NumPad3:
                    OnDigitBtnClick(Num3Btn, null);
                    break;
                case Key.NumPad4:
                    OnDigitBtnClick(Num4Btn, null);
                    break;
                case Key.NumPad5:
                    OnDigitBtnClick(Num5Btn, null);
                    break;
                case Key.NumPad6:
                    OnDigitBtnClick(Num6Btn, null);
                    break;
                case Key.NumPad7:
                    OnDigitBtnClick(Num7Btn, null);
                    break;
                case Key.NumPad8:
                    OnDigitBtnClick(Num8Btn, null);
                    break;
                case Key.NumPad9:
                    OnDigitBtnClick(Num9Btn, null);
                    break;

                case Key.Enter:
                    Sign sign5 = Sign.Equal;
                    if (_step != sign5)
                    {
                        example.Text += "=";
                        _calculator.ArithmeticAction();
                        result.Text = _calculator.EqualAction(sign5);
                        example.Text += _calculator.EqualAction(sign5);
                        _calculator.state(sign5);
                        _step = sign5;
                        _current = NegativePositive.Positive;
                    }           
                    break;

                case Key.Add:
                    Sign sign1 = Sign.Plus;
                    if (sign1 != Sign.Perc)
                    {
                        _calculator.ArithmeticAction();
                        //}  //сначала проверяем action и выполняем соответствующее действие
                        _calculator.state(sign1); //после меняем action в зависимости от нажатой кнопки
                        example.Text += "+";   //записываем
                        _step = sign1;
                    }
                    else // это если нажата кнопка процента
                    {
                        _calculator.PercentAction();
                    }
                    result.Text = "";
                    _current = NegativePositive.Positive; ;
                    break;
                case Key.Subtract:
                    Sign sign2 = Sign.Minus;
                    if (sign2 != Sign.Perc)
                    {
                        _calculator.ArithmeticAction();
                        //}  //сначала проверяем action и выполняем соответствующее действие
                        _calculator.state(sign2); //после меняем action в зависимости от нажатой кнопки
                        example.Text += "-";   //записываем
                        _step = sign2;
                    }
                    else // это если нажата кнопка процента
                    {
                        _calculator.PercentAction();
                    }
                    result.Text = "";
                    _current = NegativePositive.Positive; ;
                    break;
                case Key.Multiply:
                    Sign sign3 = (Sign)((Button)sender).Tag;
                    if (sign3 != Sign.Perc)
                    {
                        _calculator.ArithmeticAction();
                        //}  //сначала проверяем action и выполняем соответствующее действие
                        _calculator.state(sign3); //после меняем action в зависимости от нажатой кнопки
                        example.Text += "*";   //записываем
                        _step = sign3;
                    }
                    else // это если нажата кнопка процента
                    {
                        _calculator.PercentAction();
                    }
                    result.Text = "";
                    _current = NegativePositive.Positive; ;
                    break;
                case Key.Divide:
                    Sign sign4 = Sign.Div;
                    if (sign4 != Sign.Perc)
                    {
                        _calculator.ArithmeticAction();
                        //}  //сначала проверяем action и выполняем соответствующее действие
                        _calculator.state(sign4); //после меняем action в зависимости от нажатой кнопки
                        example.Text += "/";   //записываем
                        _step = sign4;
                    }
                    else // это если нажата кнопка процента
                    {
                        _calculator.PercentAction();
                    }
                    result.Text = "";
                    _current = NegativePositive.Positive; ;
                    break;
                default:
                    break;
            }
        }
        private void OnSaveInMemryClick(object sender, RoutedEventArgs e)
        {
            Sign action = (Sign)((Button)sender).Tag;
            switch (action)
            {
                case Sign.MsBtn:
                    bool i =_calculator.Save();
                    if (i==true)
                    {
                        _memory = Save.On;
                        SaveBox.Text = "M";
                    }
                    break;

                case Sign.MrBtn:
                    if (_memory != Save.Off)
                    {
                        example.Text += _calculator.OutpudSaveNumber().ToString();
                    }
                    break;

                case Sign.McBtn:
                    _calculator.ClearMemory();
                    _memory = Save.On;
                    SaveBox.Text = "";
                    break;

                case Sign.Mplus:
                    _calculator.AddToMemory();
                    break;

                case Sign.Mminus:
                    _calculator.SubToMemory();
                    break;
            }
        }
        private void TextBoxResult_TextChanged(object sender, TextChangedEventArgs e)
        {
            var result = ((TextBox)sender);
        }
        private void TextBoxExample_TextChanged(object sender, TextChangedEventArgs e)
        {
            var example = ((TextBox)sender);
        }
        private void SaveBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var saveBox = ((TextBox)sender);
        }
        private void OnCommaBtnClick(object sender, RoutedEventArgs e)
        {
            _calculator.CommaOn();
            example.Text += ",";
            result.Text += ",";
        }
        private void NegativeNumberBtn_Click(object sender, RoutedEventArgs e)
        {
            if(_current== NegativePositive.Positive)
            {
                example.Text = example.Text.Insert(example.Text.Length - result.Text.Length, "-");
                result.Text = result.Text.Insert(0, "-");
                _calculator.NegPos();
                _current = NegativePositive.Negative;
            }
            else
            {
                example.Text = example.Text.Remove(example.Text.Length - result.Text.Length, 1);
                result.Text = result.Text.Remove(0,1);
                _calculator.NegPos();
                _current = NegativePositive.Positive;
            }

        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void MenuStyle_Click(object sender, RoutedEventArgs e)
        {
            //string style = styleBox.SelectedItem as string;
            //// определяем путь к файлу ресурсов
            //var uri = new Uri(style + ".xaml", UriKind.Relative);
            //// загружаем словарь ресурсов
            //ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            //// очищаем коллекцию ресурсов приложения
            //Application.Current.Resources.Clear();
            //// добавляем загруженный словарь ресурсов
            //Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
        private void OnMenuStyle_Click(object sender, RoutedEventArgs e)
        {
            var binaryNumberSystem = _numberSystemProvider.GetBinarySystem(); 
            _calculator.SetNumberSystem(binaryNumberSystem);

        }
        private void OnMenuStyle2_Click(object sender, RoutedEventArgs e)
        {
            var decimalNumberSystem = _numberSystemProvider.GetDecimalSystem();
            _calculator.SetNumberSystem(decimalNumberSystem);
        }
    }
    public enum Sign
    {
        Start,
        Plus,
        Minus,
        Div,
        Mult,
        Perc,
        Equal,
        MsBtn,
        MrBtn,
        McBtn,
        CeBtn,
        ClearBtn,
        CBtn,
        Mplus,
        Mminus,
        Comma,
        Negativ,
    }
    public enum Save
    {
        On,
        Off,
    }
    public enum CommaFractions
    {
        Yes,
        No,
    } 
    public enum NegativePositive
    {
        Positive,
        Negative,
    }
}
