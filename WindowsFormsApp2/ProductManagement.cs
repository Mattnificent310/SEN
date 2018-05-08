using Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{

    public partial class frmProductManagement : Form
    {
        BindingSource data = new BindingSource();
        private Product prod;
       

        public frmProductManagement()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Populate();
            if (!BindData())
            {
                MessageBox.Show("No products were found.");
            }
        }
        private void Populate()
        {
            data = new BindingSource();
            prod = new Product();
            data.DataSource = Product.prods;
            dvgProducts.DataSource = data;

        }
        private bool BindData()
        {
            if (data.DataSource != null)
            {
                txtProdId.DataBindings.Add("Text", data, "ProductID");
                txtProdModels.DataBindings.Add("Text", data, "ProductModel");
                txtProdDesc.DataBindings.Add("Text", data, "ProductDetail");
                txtUnitPrice.DataBindings.Add("Text", data, "UnitPrice");
                return true;
            }
            return false;
        }

        private void dvgProducts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainMenu main = new frmMainMenu();
            main.Show();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            prod = new Product(
           0,
           txtProdModels.Text,
           txtProdDetails.Text,
           decimal.Parse(txtUnitPrice.Text.ToString()),
           false

       );
            if (!Product.Insert(prod))
            {
                MessageBox.Show("Product could not be added.");
            }
            else
            {
                MessageBox.Show("Product was added successfully.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProdDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            decimal price = 0;
            decimal.TryParse(txtUnitPrice.Text, out price);

            prod = new Product(
               int.Parse(txtProdId.Text),
               txtProdModels.Text,
               txtProdDetails.Text,
               price,
               cbxDiscontinue.Checked

           );
            if (!Product.Update(prod))
            {
                MessageBox.Show("Product information could not be changed");
            }
            Populate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Product.Delete(txtProdId.Text))
            {
                MessageBox.Show("The product could not be removed.");
            }
            else
            {
                MessageBox.Show("The product was successfully removed");
                Populate();
            }
            
        }
    }
}
