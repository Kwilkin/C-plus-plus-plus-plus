using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Visible = false;
        }

        private void setTheButtons()
        {
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
            label2.Text = System.Convert.ToString(var1) + '+' + System.Convert.ToString(var2);

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
            

        }


        private void button4_Click(object sender, EventArgs e)
        {
            setTheButtons();
            button4.Visible = false;
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

        }
    }
}
