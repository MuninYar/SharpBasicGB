using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox.Text, out int result))
            {
                try
                {
                    NumericUpDown.Value = result;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Число от {NumericUpDown.Minimum} до {NumericUpDown.Maximum}");
                    textBox.Clear();
                    NumericUpDown.Value = 0;
                }    
               
            }
            else textBox.Clear();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox.Text = NumericUpDown.Value.ToString();
        }
    }
}