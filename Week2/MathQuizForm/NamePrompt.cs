using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuizForm
{
    public partial class NamePrompt : Form
    {

        public string nameValue;

        public NamePrompt()
        {
            InitializeComponent();
        }
        public string MyValue
        {
            get 
            {
                return nameValue = nameEntry.Text; 
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
           
            nameValue = nameEntry.Text;
            if (nameValue != "") // Make sure the user inputted a name!
            {
                Quiz quiz = new Quiz();
                quiz.Text = nameValue + " Math Quiz";
                quiz.Show();
                this.Hide();
            } else
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Please enter your full name!";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
