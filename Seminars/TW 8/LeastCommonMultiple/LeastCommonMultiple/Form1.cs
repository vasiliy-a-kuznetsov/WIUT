using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeastCommonMultiple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            var input = tbxInput.Text.Split(",; ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // validation
            var numbers = new int[input.Length];
            for (var i = 0; i < input.Length; i++)
            {
                if (int.TryParse(input[i], out var number))
                {
                    if (number > 0)
                        numbers[i] = number;    
                    else
                    {
                        MessageBox.Show("Invalid input, positive numbers only");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid input, enter numbers only");
                    return;
                }
            }

            // we go over all numbers and calculate the least common multiple for each
            // for now we initialize the result to the first number
            int leastCommonMultiple = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                leastCommonMultiple = LeastCommonMultiple(leastCommonMultiple, numbers[i]);
            }

            MessageBox.Show($"Least common multiple of numbers {string.Join(", ", numbers)} is {leastCommonMultiple}");
        }

        // a method to calculate the least common multiple of two numbers
        private static int LeastCommonMultiple(int a, int b)
        {
            // the formula is: a * b / GreatestCommonDivisor(a, b)
            return a * b / GreatestCommonDivisor(a, b);
        }

        // a method to calculate the greatest common divisor of two numbers
        private static int GreatestCommonDivisor(int a, int b)
        {
            // checking all numbers from the smallest of the two down to 1
            int min = Math.Min(a, b);

            // check each integer from min down to 1
            for (int i = min; i >= 1; i--)
            {
                // if i divides both a and b, it is the result
                if (a % i == 0 && b % i == 0)
                {
                    return i;
                }
            }

            // normally we should not get here, but must return something to make it compile
            return 1;
        }
    }
}
