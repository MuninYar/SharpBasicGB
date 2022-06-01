using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doubler
{
    public partial class Main : Form
    {
        private Random random = new Random();
        private int computerNumber;
        private int userNumber;
        private int commandCounter;
        private Stack<int> userMoves = new Stack<int>();

        public Main()
        {
            InitializeComponent();
            UpdateGameState(userNumber, random.Next(20,40));
        }

        private void UpdateGameState(int userNumber)
        {
            labelUserNubmer.Text = $"Текущее число: {userNumber}";
            labelCommandCounter.Text = $"Ходы: {commandCounter++}";
            userMoves.Push(userNumber);
        }

        private void UpdateGameState(int userNumber, int computerNumber)
        {
            UpdateGameState(userNumber);
            this.computerNumber = computerNumber;
            labelComputerNumber.Text = $"Получите число: {computerNumber}";
        }
        
        private void buttonReset_Click(object sender, EventArgs e)
        {
            userNumber = 0;
            commandCounter = 0;
            userMoves.Clear();
            UpdateGameState(userNumber, random.Next(20));
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            UpdateGameState(userNumber *= 2);
            CheckWin();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            UpdateGameState(++userNumber);
            CheckWin();
        }

        private void CheckWin()
        {
            if (userNumber == computerNumber)
            {
                MessageBox.Show("Вы успешно завершили игру!", "Удвоитель",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("Желаете сыграть еще раз?", "Удвоитель", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    userNumber = 0;
                    UpdateGameState(userNumber, random.Next(20));
                }
                else
                {
                    Close();
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            userMoves.Pop();
            userNumber = userMoves.Pop();
            commandCounter -= 2;
            UpdateGameState(userNumber);
        }
    }
}
