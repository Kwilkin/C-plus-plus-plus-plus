using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Visible = false;
            if (!Directory.Exists(@"C:\MathGame"))
            {
                Directory.CreateDirectory(@"C:\MathGame");
            }
            if(File.Exists(@"C:\MathGame\HighScores.ky"))
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\MathGame\HighScores.ky");
                Console.WriteLine(lines[0]);
            }
            else
            {
                using (StreamWriter sw = File.CreateText(@"C:\MathGame\HighScores.ky"))
                {
                    sw.WriteLine("0");
                    sw.WriteLine("0");
                    sw.WriteLine("0");
                    sw.WriteLine("0");
                    sw.WriteLine("0");
                    sw.WriteLine("0");
                }
            }
            comboBox1.Text = "20 Rounds";
        }

        private void setTheButtons()
        {
            int maxRounds = 0;
            switch (comboBox1.SelectedIndex) // Could have done one if statement to set case 5 to -1 then just did if((cB1.sI + 1)*10 == MR)
            {
                case 0:
                    maxRounds = 10;
                    break;
                case 1:
                    maxRounds = 20;
                    break;
                case 2:
                    maxRounds = 30;
                    break;
                case 3:
                    maxRounds = 40;
                    break;
                case 4:
                    maxRounds = 50;
                    break;
                case 5:
                    maxRounds = -1;
                    break;
            }
            if (System.Convert.ToInt16(label8.Text) == maxRounds)
            {
                label2.Text = "Game Over!!";
                return;
            }
            label8.Text = System.Convert.ToString(System.Convert.ToInt16(label8.Text) + 1);
            label5.Text = "3";
            button1.BackColor = SystemColors.ControlLight;
            button2.BackColor = SystemColors.ControlLight;
            button3.BackColor = SystemColors.ControlLight;
            System.Random random = new System.Random();
            int var1 = random.Next(0, 21);
            int var2 = random.Next(0, 21);
            int correctAnswer = var1 + var2;
            label4.Text = correctAnswer.ToString();
            int incorrectAnswer1 = correctAnswer + 1;
            int incorrectAnswer2 = correctAnswer - 1;
            label2.Text = System.Convert.ToString(var1) + " + " + System.Convert.ToString(var2);

            int displayChoice1 = random.Next(0, 3);
            int displayChoice2 = displayChoice1;
            int displayChoice3 = displayChoice1;
            while (displayChoice2 == displayChoice1)
            {
                displayChoice2 = random.Next(0, 3);
            }
            while ((displayChoice3 == displayChoice1) || (displayChoice3 == displayChoice2))
            {
                // This is dumb. You already know the first two so you can just pick the last one.
                displayChoice3 = random.Next(0, 3);
            }
            switch(displayChoice1)
            {
                case 0:
                    button1.Text = System.Convert.ToString(correctAnswer);
                    break;
                case 1:
                    button1.Text = System.Convert.ToString(incorrectAnswer1);
                    break;
                case 2:
                    button1.Text = System.Convert.ToString(incorrectAnswer2);
                    break;
            }
            switch (displayChoice2)
            {
                case 0:
                    button2.Text = System.Convert.ToString(correctAnswer);
                    break;
                case 1:
                    button2.Text = System.Convert.ToString(incorrectAnswer1);
                    break;
                case 2:
                    button2.Text = System.Convert.ToString(incorrectAnswer2);
                    break;
            }
            switch (displayChoice3)
            {
                case 0:
                    button3.Text = System.Convert.ToString(correctAnswer);
                    break;
                case 1:
                    button3.Text = System.Convert.ToString(incorrectAnswer1);
                    break;
                case 2:
                    button3.Text = System.Convert.ToString(incorrectAnswer2);
                    break;
            }
            
            //return correctAnswer;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\MathGame\HighScores.ky");
            label10.Text = lines[comboBox1.SelectedIndex];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button4.Visible)
            {
                return;
            }
            else
            {
                if (System.Convert.ToInt16(button1.Text) == System.Convert.ToInt16(label4.Text))
                {
                    label3.Text = System.Convert.ToString(System.Convert.ToInt16(label3.Text) + System.Convert.ToInt16(label5.Text));
                    setTheButtons();
                }
                else
                {
                    button1.BackColor = System.Drawing.Color.Red;
                    label5.Text = System.Convert.ToString(System.Convert.ToInt16(label5.Text) - 1);
                }
            }
            updateHighScore();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button4.Visible)
            {
                return;
            }
            else
            {
                if (System.Convert.ToInt16(button2.Text) == System.Convert.ToInt16(label4.Text))
                {
                    label3.Text = System.Convert.ToString(System.Convert.ToInt16(label3.Text) + System.Convert.ToInt16(label5.Text));
                    setTheButtons();
                }
                else
                {
                    button2.BackColor = System.Drawing.Color.Red;
                    label5.Text = System.Convert.ToString(System.Convert.ToInt16(label5.Text) - 1);
                }
            }
            updateHighScore();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button4.Visible)
            {
                return;
            }
            else
            {
                if (System.Convert.ToInt16(button3.Text) == System.Convert.ToInt16(label4.Text))
                {
                    label3.Text = System.Convert.ToString(System.Convert.ToInt16(label3.Text) + System.Convert.ToInt16(label5.Text));
                    setTheButtons();
                }
                else
                {
                    button3.BackColor = System.Drawing.Color.Red;
                    label5.Text = System.Convert.ToString(System.Convert.ToInt16(label5.Text) - 1);
                }
            }
            updateHighScore();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setTheButtons();

            button4.Visible = false;
            comboBox1.Visible = false;
            restartButton.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
        }

        private void updateHighScore()
        {
            
            // Add per round high score here later. Actually probably better to switch the high score when round is changed.
            if (System.Convert.ToInt16(label10.Text) < System.Convert.ToInt16(label3.Text))
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\MathGame\HighScores.ky");
                label10.Text = label3.Text;
                lines[comboBox1.SelectedIndex] = label3.Text;
                File.WriteAllLines(@"C:\MathGame\HighScores.ky", lines);
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            buttonsGoBye();
            label8.Text = "0";
            label3.Text = "0";
            label2.Text = "Press Start to Play Again!";
            comboBox1.Visible = true;
        }

        private void buttonsGoBye()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            restartButton.Visible = false;
        }
    }
}
