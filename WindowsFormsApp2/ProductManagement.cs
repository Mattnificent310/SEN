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
        private Category cat;
        private Inventory inv;


        public frmProductManagement()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Category();
           

            if (!BindData())
            {
                MessageBox.Show("No products were found.");
            }
        }
        private bool Populate()
        {
            prod = new Product();
            if (Product.prods.Any())
            {
                data.DataSource = Product.prods;
                dvgProducts.DataSource = data;
                BindingSource types = new BindingSource();
                types.DataSource = Category.cats.Select(x => x.CategoryName);
                cmbProdType.DataSource = types;
                cmbPType.DataSource = types;

                return true;
            }

            return false;


        }
        public void Login(Staff staf)
        {
            lblLogin.Text = string.Format("Welcome {0} {1}            {2}    {3}", staf.Name, staf.Surname, DateTime.Now.ToLongDateString(), DateTime.Now.ToShortTimeString());
            
        }
        private bool BindData()
        {
            if (Populate())
            {
                txtProdId.DataBindings.Add("Text", data, "ProductID");
                cmbProdType.DataBindings.Add("Text", data, "ProductType");
                txtProdModels.DataBindings.Add("Text", data, "ProductModel");
                txtProdDesc.DataBindings.Add("Text", data, "ProductDetail");
                txtUnitPrice.DataBindings.Add("Text", data, "UnitPrice");
                txtProdStock.DataBindings.Add("Text", data, "InStock");
                return true;
            }
            return false;
        }

        public void Clear()
        {
            txtProdId.DataBindings.Clear();
            cmbProdType.DataBindings.Clear();
            txtProdModels.DataBindings.Clear();
            txtProdDesc.DataBindings.Clear();
            txtUnitPrice.DataBindings.Clear();
            txtProdStock.DataBindings.Clear();
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
           cmbPType.Text,
           txtPModel.Text,
           txtPDetails.Text,
           decimal.Parse(txtPPrice.Text.ToString()),
           int.Parse(txtPStock.Text),
           false

       );

            if (!CRUD.InsertProduct(prod))
            {
                MessageBox.Show("Product could not be added.");
            }
            else
            {
                Clear();
                BindData();
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
              cmbProdType.Text,
               txtProdModels.Text,
               txtProdDesc.Text,
               price,
               int.Parse(txtProdStock.Text),
               cbxDiscontinue.Checked

           );
            if (!CRUD.UpdateProduct(prod))
            {
                MessageBox.Show("Product information could not be changed");
            }
            else
            {
                Clear();
                BindData();
                MessageBox.Show("Product information was changed");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!CRUD.DeleteProduct(int.Parse(txtProdId.Text)))
            {
                MessageBox.Show("The product could not be removed.");
            }
            else
            {
                Clear();
                BindData();
                MessageBox.Show("The product was successfully removed");

            }

        }
    }
}
