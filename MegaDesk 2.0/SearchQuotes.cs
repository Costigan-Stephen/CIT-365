using System;
using System.Data;
using System.Windows.Forms;

namespace MegaDesk
{
    public partial class SearchQuotes : Form
    {
        DeskQuote DeskQuote = new DeskQuote();
        AddQuote q = new AddQuote();
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
            displayQuotes();
        }

        private void displayQuotes()
        {
            //create columns for data table
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Date");
            dt.Columns.Add("Depth");
            dt.Columns.Add("Width");
            dt.Columns.Add("Drawers");
            dt.Columns.Add("Shipping");
            dt.Columns.Add("Total");
            dataGridView1.DataSource = dt;
            Desk.Materials selectedMaterial = (Desk.Materials)Enum.Parse(typeof(Desk.Materials), materialInput.SelectedItem.ToString());
            foreach (DeskQuote quote in q.quoteCollection)
                if (selectedMaterial == (Desk.Materials)Enum.Parse(typeof(Desk.Materials), quote.material))
                {
                    //populates rows for datatable
                    dt.Rows.Add(new object[] { quote.customerName,
                                               quote.date.ToString("MM/dd/yyyy h:mm tt"),
                                               quote.depth,
                                               quote.width,
                                               quote.drawers,
                                               quote.rush,
                                               quote.quote.ToString("C2") });
                }
        }
    }
}
