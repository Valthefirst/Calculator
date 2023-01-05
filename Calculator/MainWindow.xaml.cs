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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double result;
        public double lastNumber;
        public SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            //if (selectedOperator != null || currentNumber != "")
            //{
            //    result = 0;
            //    Result.Text = string.Empty;
            //}
            string num = (sender as Button).Name;
            string currentNumber = "";
            switch (num)
            {
                case "Zero":
                    currentNumber += "0";
                    break;
                case "One":
                    currentNumber += "1";
                    break;
                case "Two":
                    currentNumber += "2";
                    break;
                case "Three":
                    currentNumber += "3";
                    break;
                case "Four":
                    currentNumber += "4";
                    break;
                case "Five":
                    currentNumber += "5";
                    break;
                case "Six":
                    currentNumber += "6";
                    break;
                case "Seven":
                    currentNumber += "7";
                    break;
                case "Eight":
                    currentNumber += "8";
                    break;
                case "Nine":
                    currentNumber += "9";
                    break;
            }
            Result.Text += currentNumber;
            result = Convert.ToDouble(Result.Text);
        }

        private void BtnDot_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool flag = false;
                string currentNumber = result.ToString();
                for (var i = 0; i < currentNumber.Length; i++)
                {
                    if (currentNumber[i] != '.')
                    {
                        flag = true;
                    }
                    else
                        flag = false;
                }
                if (flag == true)
                {
                    currentNumber += '.';
                    Result.Text = currentNumber;
                    result = Convert.ToDouble(Result.Text);
                }
            }
            catch
            {
                Result.Text = "ERROR";
            }

        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            string op = (sender as Button).Name;
            if (selectedOperator == SelectedOperator.Addition)
                result = Logic.Addition(lastNumber, result);

            if (selectedOperator == SelectedOperator.Substraction)
                result = Logic.Substraction(lastNumber, result);

            if (selectedOperator == SelectedOperator.Multiplication)
                result = Logic.Multiplication(lastNumber, result);

            if (selectedOperator == SelectedOperator.Division)
                result = Logic.Division(lastNumber, result);

            Result.Text = result.ToString();
            lastNumber = 0;
            result = 0;
        }

        private void BtnOperation_Click(object sender, RoutedEventArgs e)
        {
            lastNumber = result;
            result = 0;
            string op = (sender as Button).Name;
            switch (op)
            {
                case "Addition":
                    selectedOperator = SelectedOperator.Addition;
                    break;
                case "Substraction":
                    selectedOperator = SelectedOperator.Substraction;
                    break;
                case "Multiplication":
                    selectedOperator = SelectedOperator.Multiplication;
                    break;
                case "Division":
                    selectedOperator = SelectedOperator.Division;
                    break;
            }

            Result.Text = result.ToString();

        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            result = 0.0;
            lastNumber = 0.0;
            Result.Text = result.ToString();
        }

        //private void BtnSquare_Root_Click(object sender, RoutedEventArgs e)
        //{
        //    result = Math.Sqrt(result);
        //    Result.Text = result.ToString();
        //}

        private void BtnSwitch_Click(object sender, RoutedEventArgs e)
        {
            string x = result.ToString();
            for (var i = 0; i < 1; i++)
            {
                if (x[0] != '-')
                    x = "-" + x;
                else
                    x = x.Substring(1);
            }
            result = Convert.ToDouble(x);
            Result.Text = result.ToString();
        }

        private void BtnPercent_Click(object sender, RoutedEventArgs e)
        {
            if (lastNumber != 0 && selectedOperator != null)
            {
                result = lastNumber * (result / 100.0);
            }
            else
            {
                result = result / 100.0;
            }
            Result.Text = result.ToString();
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }
}
