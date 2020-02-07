using System;
using System.Data;
using System.Windows.Forms;

namespace MegaDesk
{
    public partial class ViewAllQuotes : Form
    {
        AddQuote q = new AddQuote();
        public ViewAllQuotes()
        {
            InitializeComponent();
            dataGridView1_CellContentClick();
        }

        private void NavMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu viewMenu = (MainMenu)Tag;
            viewMenu.Show();
            Close();
        }

        private void dataGridView1_CellContentClick()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Date");
            dt.Columns.Add("Depth");
            dt.Columns.Add("Width");
            dt.Columns.Add("Drawers");
            dt.Columns.Add("Shipping");
            dt.Columns.Add("Total");

            dataGridView1.DataSource = dt;

            foreach (DeskQuote quote in q.quoteCollection)
                    //populates rows for datatable
                    dt.Rows.Add(new object[] { quote.customerName,
                                               quote.date.ToString("MM/dd/yyyy"),
                                               quote.depth,
                                               quote.width,
                                               quote.drawers,
                                               quote.rush,
                                               quote.quote.ToString("C2") });
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
