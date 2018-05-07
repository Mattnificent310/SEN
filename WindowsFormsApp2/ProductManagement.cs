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
        private static Product prod;

        public frmProductManagement()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Product prod = new Product();
            data.DataSource = Product.prods;
            dvgProducts.DataSource = data;
            if (data.DataSource != null)
            {
                txtProdModels.DataBindings.Add("Text", data, "ProductModel");
                txtProdDesc.DataBindings.Add("Text", data, "ProductDetail");
                txtUnitPrice.DataBindings.Add("Text", data, "UnitPrice");
            }


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
           decimal.Parse(txtProdPrice.Text.ToString()),
           false

       );
            //if (Product.Insert(prod))
            //{
            //    MessageBox.Show("Product inserted.");
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProdDesc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
