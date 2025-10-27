using System;
using System.Collections.Generic;
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

namespace _8._1
{
    public partial class MainWindow : Window
    {
        private double currentNumber = 0;
        private double previousNumber = 0;
        private string operation = "";
        private bool isNewNumber = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate()
        {
            if (Display.Text == "Ошибка")
            {
                ClearClick(null, null);
                return;
            }

            double result = 0;
            bool error = false;

            switch (operation)
            {
                case "+":
                    result = previousNumber + currentNumber;
                    break;
                case "-":
                    result = previousNumber - currentNumber;
                    break;
                case "×":
                    result = previousNumber * currentNumber;
                    break;
                case "/":
                    if (currentNumber != 0)
                        result = previousNumber / currentNumber;
                    else
                    {
                        Display.Text = "Ошибка";
                        error = true;
                    }
                    break;
                default:
                    return;
            }

            if (!error)
            {
                Display.Text = result.ToString();
                currentNumber = result;
                isNewNumber = true;
            }
        }

        private void NumberClick(object sender, RoutedEventArgs e)
        {
            if (Display.Text == "Ошибка")
            {
                ClearClick(null, null);
            }

            Button button = (Button)sender;
            string number = button.Content.ToString();

            if (Display.Text == "0" || isNewNumber)
            {
                Display.Text = number;
                isNewNumber = false;
            }
            else
            {
                Display.Text += number;
            }

            currentNumber = double.Parse(Display.Text);
        }

        private void OperatorClick(object sender, RoutedEventArgs e)
        {
            if (Display.Text == "Ошибка")
            {
                ClearClick(null, null);
                return;
            }

            if (!isNewNumber && operation != "")
            {
                Calculate();
            }

            Button button = (Button)sender;
            operation = button.Content.ToString();
            previousNumber = currentNumber;
            isNewNumber = true;
        }

        private void EqualsClick(object sender, RoutedEventArgs e)
        {
            if (Display.Text == "Ошибка")
            {
                ClearClick(null, null);
                return;
            }

            if (operation != "")
            {
                Calculate();
                operation = "";
            }
        }

        private void DecimalClick(object sender, RoutedEventArgs e)
        {
            if (Display.Text == "Ошибка")
            {
                ClearClick(null, null);
            }

            if (isNewNumber)
            {
                Display.Text = "0";
                isNewNumber = false;
            }

            if (!Display.Text.Contains("."))
            {
                Display.Text += ".";
            }
        }

        private void BackspaceClick(object sender, RoutedEventArgs e)
        {
            if (Display.Text == "Ошибка")
            {
                ClearClick(null, null);
                return;
            }

            if (Display.Text.Length > 1 && Display.Text != "0")
            {
                Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
                currentNumber = double.Parse(Display.Text);
            }
            else
            {
                Display.Text = "0";
                currentNumber = 0;
            }
        }

        private void PercentClick(object sender, RoutedEventArgs e)
        {
            if (Display.Text == "Ошибка")
            {
                ClearClick(null, null);
                return;
            }

            currentNumber = currentNumber / 100;
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            currentNumber = 0;
            previousNumber = 0;
            operation = "";
            isNewNumber = true;
        }
    }
}
