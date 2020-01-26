using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;
using System.IO;

namespace MegaDesk
{
    public partial class AddQuote : Form
    {
        DeskQuote DeskQuote = new DeskQuote();
        Desk Desk = new Desk();
        

        public AddQuote()
        {
            InitializeComponent();
            materialInput.DataSource = Enum.GetValues(typeof(Desk.Materials));
        }


        public int GetDepth() { return Int32.Parse(depthInput.Text); }
        public int GetWidth() { return Int32.Parse(widthInput.Text); }
        private void NavMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu viewMenu = (MainMenu)Tag;
            viewMenu.Show();
            Close();
        }

        private void DrawerInput_ValueChanged(object sender, EventArgs e)
        {
            if (drawerInput.Value > 7) drawerInput.Value = 7;
            if (drawerInput.Value < 0) drawerInput.Value = 0;
            
            decimal amount = drawerInput.Value * 50;
            drawerCost.Text = amount.ToString("N1");
        }

        

        private void DepthInput_Validating(object sender, CancelEventArgs e)
        {
            if (!depthInput.Text.All(Char.IsDigit))
            {
                depthInput.Text = "";
                depthInput.Focus();
            } 
            else if (depthInput.Text != "" || depthInput.Text != String.Empty) 
            {
                int depth = GetDepth();
                if (depth < (int)Desk.DeskSize.minDepth) depthInput.Text = (int)Desk.DeskSize.minDepth + "";
                if (depth > (int)Desk.DeskSize.maxDepth) depthInput.Text = (int)Desk.DeskSize.maxDepth + "";
            }
        }

        private void WidthInput_Validating(object sender, CancelEventArgs e)
        {
            if (!widthInput.Text.All(Char.IsDigit))
            {
                widthInput.Text = "";
                widthInput.Focus();
            }
            else if (widthInput.Text != "" || widthInput.Text != String.Empty)
            {
                int width = Int32.Parse(widthInput.Text);
                if (width < (int)Desk.DeskSize.minWidth) widthInput.Text = (int)Desk.DeskSize.minWidth + "";
                if (width > (int)Desk.DeskSize.maxWidth) widthInput.Text = (int)Desk.DeskSize.maxWidth + "";
            }
        }

        private void getQuoteValue()
        {
            int depth = GetDepth();
            int width = GetWidth();
            areaOutput.Text =
                "Area: " + DeskQuote.AreaCalculate(depth, width) + " in\xB2";
            areaCost.Text =
                DeskQuote.AreaCost(depth, width).ToString("C2");
            shippingCost.Text =
                DeskQuote.ShippingCost(shippingInput.Text, DeskQuote.AreaCalculate(depth, width)).ToString("C2");
            materialCost.Text =
                Desk.DeskMaterialCost(materialInput.Text).ToString("C2");

            CalculateTotal();
        }

        private void ChangeValues()
        {

            try
            {
                getQuoteValue();
            } 
            catch (Exception ex)
            {
                ShowDialog("Please fill out the request and try again!");
                Console.WriteLine("{0} Exception caught.", ex);
            }
        }

        private void ShippingInput_Validating(object sender, CancelEventArgs e)
        {
            if (!shippingInput.Items.Contains(shippingInput.Text))
            {
                shippingInput.Text = "";
                shippingCost.Text = "$";
            }
        }

        private void MaterialInput_Validating(object sender, CancelEventArgs e)
        {
            if (!Enum.IsDefined(typeof(Desk.Materials), materialInput.Text)) 
            {    
                ShowDialog("Please enter a valid material");
                materialInput.Text = "";
                materialCost.Text = "$";
            }
        }

        private void CalculateTotal()
        {
            int area, drawers, shipping, materials;

            area = DeskQuote.AreaCost(GetDepth(), GetWidth());
            drawers = Int32.Parse(drawerInput.Text)*50;
            shipping = DeskQuote.ShippingCost(shippingInput.Text, area);
            materials = Desk.DeskMaterialCost(materialInput.Text);
            
            int total = (area + drawers + shipping + materials);
            quoteTotal.Text = total.ToString("C2");
        }

        private void NameInput_Validating(object sender, CancelEventArgs e)
        {
            //Content to go here in line with submission!
        }

        private void SubmitQuote_Click(object sender, EventArgs e)
        {

            ShowDialog("Will be implemented next week!");
            /*DeskQuote DeskQuote = new DeskQuote
            {
                id = Guid.NewGuid(),
                date = DateTime.Today,
                depth = Int32.Parse(depthInput.Text),
                width = Int32.Parse(widthInput.Text),
                drawers = Int32.Parse(drawerInput.Text),
                drawerCost = Int32.Parse(drawerInput.Text) * 50,
                area = Int32.Parse(depthInput.Text) * Int32.Parse(widthInput.Text),
                material = materialInput.Text,
                customerName = nameInput.Text,
                quote = Int32.Parse(quoteTotal.Text),
                rush = shippingInput.Text
            };*/
        }

        private void ShowDialog(string v)
        {
            MessageBox.Show(v, "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            this.materialInput.DataSource = Enum.GetValues(typeof(Desk.Materials));
        }

        private void getQuote_Click(object sender, EventArgs e)
        {
            ChangeValues();
        }
    }
}
