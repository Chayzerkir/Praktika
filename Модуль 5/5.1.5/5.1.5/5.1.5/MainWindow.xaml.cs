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

namespace _5._1._5
{
    public partial class MainWindow : Window
    {
        private double num1 = 0;
        private string operation = "";
        private bool newNumber = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (newNumber)
            {
                Display.Text = button.Content.ToString();
                newNumber = false;
            }
            else
            {
                Display.Text += button.Content.ToString();
            }
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            num1 = double.Parse(Display.Text);
            operation = button.Content.ToString();
            newNumber = true;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double num2 = double.Parse(Display.Text);
            double result = 0;
            switch (operation)
            {
                case "+": result = num1 + num2; break;
                case "-": result = num1 - num2; break;
                case "*": result = num1 * num2; break;
                case "/": result = num1 / num2; break;
            }
            Display.Text = result.ToString();
            newNumber = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            num1 = 0;
            operation = "";
            newNumber = true;
        }
    }
}