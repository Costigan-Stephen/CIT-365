using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk
{
    public partial class SearchQuotes : Form
    {
        DeskQuote DeskQuote = new DeskQuote();
        Desk Desk = new Desk();

        public SearchQuotes()
        {
            InitializeComponent();
            materialInput.DataSource = Enum.GetValues(typeof(Desk.Materials));
        }

        private void NavMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu viewMenu = (MainMenu)Tag;
            viewMenu.Show();
            Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            this.materialInput.DataSource = Enum.GetValues(typeof(Desk.Materials));
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
