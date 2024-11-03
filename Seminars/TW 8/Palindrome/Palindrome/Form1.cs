using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Palindrome
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            var input = tbxInput.Text;

            // validation
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Input cannot be empty or whitespace. Please enter some text.");
                return;
            }

            // remove spaces and convert to lowercase for a case-insensitive comparison
            var cleanedText = input.ToLower().Replace(" ", "");
            var chars = cleanedText.ToCharArray();

            // get the reversed string
            Array.Reverse(chars);
            var reversedText = new string(chars);

            // check if we have a palindrome
            if (cleanedText == reversedText)
            {
                MessageBox.Show("It's a palindrome");
            }
            else
            {
                MessageBox.Show("It's NOT a palindrome");
            }
        }
    }
}
