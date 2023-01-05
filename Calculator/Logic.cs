using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator
{
    internal class Logic
    {
        public static double Addition(double numberOne, double numberTwo)
        {
            return numberOne + numberTwo;
        }

        public static double Substraction(double numberOne, double numberTwo)
        {
            return numberOne - numberTwo;
        }
        public static double Multiplication(double numberOne, double numberTwo)
        {
            return numberOne * numberTwo;
        }
        public static double Division(double numberOne, double numberTwo)
        {
            if (numberTwo == 0)
            {
                MessageBox.Show("You cannot divide by 0.", "ERROR", MessageBoxButton.OK);
                return 0;
            }
            return numberOne / numberTwo;
        }
    }
}
