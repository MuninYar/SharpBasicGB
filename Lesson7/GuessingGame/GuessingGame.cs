using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessingGame
{
    public partial class GuessingGame : Form
    {
        private Random random = new Random();
        private int computerNumber;
        private int userNumber;

        public GuessingGame()
        {
            InitializeComponent();
            computerNumber = random.Next(1, 99);
        }
        private void textBoxUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(textBoxUserInput.Text, out userNumber))
                    textBoxUserInput.Clear();
                else
                {
                    MessageBox.Show("Введите число!");
                    textBoxUserInput.Clear();
                }
                if (userNumber < 1 || userNumber > 99)
                    MessageBox.Show("Введите число от 1 до 99");
                else
                {
                    CheckHigherOrLesser(userNumber, computerNumber);
                    CheckWin(userNumber,computerNumber);
                }
            }
        }
        private void CheckWin(int userNumber, int computerNumber)
        {
            if (userNumber == computerNumber)
            {
                    MessageBox.Show("Ура! Победа!","Угадайка");
                if (MessageBox.Show("Желаете сыграть еще раз?", "Угадайка", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NewGame();
                }
                else
                {
                    Close();
                }
            }
        }
        private void CheckHigherOrLesser(int userNumber, int computerNumber)
        {
            if (userNumber < computerNumber)
            {
                labelLesser.Visible = true;
                labelHigher.Visible = false;
            }
            else
            {
                labelHigher.Visible = true;
                labelLesser.Visible = false;
            }
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        private void NewGame()
        {
            userNumber = 0;
            computerNumber = random.Next(1, 99);
            MessageBox.Show("Загадано новое число!");
            labelLesser.Visible = false;
            labelHigher.Visible = false;
        }
    }
}
