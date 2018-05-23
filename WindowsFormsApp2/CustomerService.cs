using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Logic_Layer;

namespace WindowsFormsApp2
{
    public partial class frmCustomerService : Form
    {
        BindingSource data = new BindingSource();
        private static Client client;
        private static Product prod;
        private static Category cat;
        private static frmMainMenu menu = new frmMainMenu();
        private static Sale sale;
        private static Order order;
        private static OrderDetail detail;
        private static Dictionary<Sale, Dictionary<Order, List<OrderDetail>>> cart = new Dictionary<Sale, Dictionary<Order, List<OrderDetail>>>();
        private static List<OrderDetail> items = new List<OrderDetail>();
        public frmCustomerService()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void CustomerService_Load(object sender, EventArgs e)
        {

            if (!BindData())
            {
                MessageBox.Show("No customers could be found.");
            }
        }

        #region Login
        public void Login(Staff staf)
        {
            if (!staf.Department.Equals("Administrator"))
            {
                this.btnMain.Text = "Log Out";
                this.btnMainMenu.Text = "Log Out";
            }
            menu.Login(staf);
            lblLogin.Text = string.Format("Welcome:  {0}  {1}  {2}", staf.Title, staf.Name, staf.Surname);

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format("{0} -- {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToShortTimeString());

        }
        #endregion

        #region Binding
        private bool BindData()
        {
            if (Populate())
            {
                txtClientId.DataBindings.Add("Text", data, "Identity");
                cmbCustTitle.DataBindings.Add("Text", data, "Title");
                txtCustName.DataBindings.Add("Text", data, "Name");
                txtCustSurname.DataBindings.Add("Text", data, "Surname");
                dtpCustDOB.DataBindings.Add("Text", data, "BirthDate");
                cmbCustGender.DataBindings.Add("Text", data, "Gender");
                txtCustPhone.DataBindings.Add("Text", data, "ContactNumber");
                txtCustEmail.DataBindings.Add("Text", data, "EmailAddress");
                cmbCustCountry.DataBindings.Add("Text", data, "Country");
                cmbCustCity.DataBindings.Add("Text", data, "City");
                txtCustStreet.DataBindings.Add("Text", data, "Street");
                return true;
            }
            return false;
        }
        private void Clear()
        {

            txtClientId.DataBindings.Clear();
            cmbCustTitle.DataBindings.Clear();
            txtCustName.DataBindings.Clear();
            txtCustSurname.DataBindings.Clear();
            cmbCustGender.DataBindings.Clear();
            dtpCustDOB.DataBindings.Clear();
            txtCustPhone.DataBindings.Clear();
            txtCustEmail.DataBindings.Clear();
            txtCustStreet.DataBindings.Clear();
            cmbCustCity.DataBindings.Clear();
            cmbCustCountry.DataBindings.Clear();
        }
        private bool Populate()
        {
            client = new Client();
            cat = new Category();
            prod = new Product();
            if (Category.cats.Any())
            {
                cmbProdType.Items.Clear();
                cmbPayment.Items.Clear();
                cmbPayment.Items.AddRange(new object[] { "EFT", "SWIFT", "Credit/Debit", "Layby" });
                cmbProdModel.Items.Clear();
                cmbProdType.DataSource = Category.cats.Select(x => x.CategoryName).ToList();
                cmbProdModel.DataSource = Product.prods.Select(x => x.ProductModel).ToList();
                cmbProdType.Text = "";
                cmbProdModel.Text = "";
                numQuantity.Enabled = false;
            }
            if (Client.clients.Any())
            {
                data.DataSource = Client.clients;
                dgvClient.DataSource = data;
                return true;
            }
            return false;
        }
        #endregion        

        #region Main
        private void btnMainMenu_Click_2(object sender, EventArgs e)
        {
            if (this.btnMainMenu.Text.StartsWith("Log Out"))
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                this.Hide();
                menu.Show();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.btnMain.Text.StartsWith("Log Out"))
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                this.Hide();
                menu.Show();
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            if (this.btnMain.Text.StartsWith("Log Out"))
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                this.Hide();
                menu.Show();
            }
        }
        #endregion

        #region Sales
        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            lblTotal.Text = string.Format("{0:C}", decimal.Parse(lblUnitPrice.Text) * numQuantity.Value);
        }
        private void radioCol_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCol.Checked)
            {
                order = new Order(
                    "Collection Order",
                    DateTime.Now,
                    "N/A"
                    );
                dtpColDel.Value = DateTime.Now.AddDays(1.0);
            }
        }

        private void radioDel_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDel.Checked)
            {
                order = new Order(
                   "Delivery Order",
                    DateTime.Now,
                    "N/A"
                    );
                dtpColDel.Value = DateTime.Now.AddDays(new Random().Next(2, 14));
            }


        }

        bool columns = false;
        List<object[]> vals = new List<object[]>();
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (ValidateAll(this.tabPage3))
            {

                items.Add(new OrderDetail(
                0,
                int.Parse(lblProdId.Text),
                1,
                (int)numQuantity.Value,
                decimal.Parse(lblTotal.Text.Substring(1)),
                0.1));

                #region Values
                object[] values =
                {
                cmbProdModel.Text,
                txtProdName.Text,
                 radioCol.Checked ? "Collection" : "Delivery",
                dtpColDel.Value.ToShortDateString(),
                double.Parse(lblUnitPrice.Text),
                numQuantity.Value.ToString(),
                double.Parse(lblTotal.Text.Substring(1))
                };
                #endregion

                if (!columns)
                {
                    #region Columns
                    dgvItems.DataSource = null;
                    dgvItems.DataBindings.Clear();
                    dgvItems.Columns.Add("ProductModel", "Product Model");
                    dgvItems.Columns.Add("ProductName", "Product Name");
                    dgvItems.Columns.Add("OrderType", "Order Type");
                    dgvItems.Columns.Add("OrderDate", "Estimated Date");
                    dgvItems.Columns.Add("UnitPrice", "Unit Price");
                    dgvItems.Columns.Add("ItemQuantity", "Item Quantity");
                    dgvItems.Columns.Add("Total", "Total");
                    #endregion 

                    columns = true;
                }
                if (!vals.Any(x => x.ElementAt(1).Equals(values.ElementAt(1))))
                {
                    vals.Add(values);
                    dgvItems.Rows.Add(values);
                    dgvItems.Show();
                    lblGrandTotal.Text = string.Format("{0:C}", vals.Sum(x => x.ElementAt(6).GetType() == typeof(double) ? (double)x.ElementAt(6) : 0));
                }
                else
                {
                    MessageBox.Show("That item was already added.");
                }
            }
        }
        private void lblUnitPrice_TextChanged(object sender, EventArgs e)
        {
            lblTotal.Text = string.Format("{0:C}", decimal.Parse(lblUnitPrice.Text) * numQuantity.Value);
        }
        private void btnCheckOut_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Search

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    !string.IsNullOrEmpty(txtCSName.Text.Trim())
                    && !string.IsNullOrEmpty(txtCSSurname.Text.Trim())
                    && !string.IsNullOrEmpty(txtCSPhone.Text.Trim())
                    && !string.IsNullOrEmpty(txtCSEmail.Text.Trim()))
                {

                    new Product();
                    data = new BindingSource();

                    dgvItems.Hide();

                    #region Find Product Type
                    if (!string.IsNullOrEmpty(cmbProdType.Text.Trim()))
                    {
                        data.DataSource = Product.prods.Where(x => x.ProductType == cmbProdType.Text.Trim()).ToList();
                       
                    }
                    #endregion

                    #region Find Product Model
                    if (!string.IsNullOrEmpty(cmbProdModel.Text.Trim()))
                    {
                        data.DataSource = Product.prods.Where(x => x.ProductModel == cmbProdModel.Text.Trim()).ToList();

                    }
                    #endregion

                    #region Find Product Name
                    if (!string.IsNullOrEmpty(txtProdName.Text.Trim()))
                    {
                        data.DataSource = Product.prods.Where(x => x.ProductName == txtProdName.Text.Trim()).ToList();

                    }
                    #endregion

                    #region Find Product Type & Product Model
                    if (!string.IsNullOrEmpty(cmbProdModel.Text.Trim()) && !string.IsNullOrEmpty(cmbProdType.Text.Trim()))
                    {
                        data.DataSource = Product.prods.Where(x => x.ProductType == cmbProdType.Text.Trim()                       
                       && x.ProductModel == cmbProdModel.Text.Trim()).ToList();
                        
                    }
                    #endregion

                    #region Find Product Type, Model & Name
                    if (!string.IsNullOrEmpty(cmbProdModel.Text.Trim()) 
                    && !string.IsNullOrEmpty(cmbProdType.Text.Trim()) 
                    && !string.IsNullOrEmpty(txtProdName.Text.Trim()))
                    {
                        data.DataSource = Product.prods.Where(x => x.ProductType == cmbProdType.Text.Trim()
                           && x.ProductModel == cmbProdModel.Text.Trim()
                           && x.ProductName == txtProdName.Text.Trim()).ToList();
                        
                    }
                    #endregion

                    

                    dgvSales.DataSource = data;

                    #region Clear
                    cmbProdType.DataBindings.Clear();
                    cmbProdModel.DataBindings.Clear();
                    lblUnitPrice.DataBindings.Clear();
                    lblProdId.DataBindings.Clear();
                    txtProdName.DataBindings.Clear();
                    numQuantity.Enabled = true;
                    numQuantity.Value = 1;
                    #endregion

                    #region Bind
                    lblProdId.DataBindings.Add("Text", data, "ProductID");
                    cmbProdType.DataBindings.Add("Text", data, "ProductType");
                    cmbProdModel.DataBindings.Add("Text", data, "ProductModel");
                    txtProdName.DataBindings.Add("Text", data, "ProductName");
                    lblUnitPrice.DataBindings.Add("Text", data, "UnitPrice");
                    lblTotal.Text = string.Format("{0:C}", decimal.Parse(lblUnitPrice.Text) * numQuantity.Value);
                    #endregion


                }
                else if (!string.IsNullOrEmpty(txtCSName.Text.Trim())
                || !string.IsNullOrEmpty(txtCSSurname.Text.Trim())
                || !string.IsNullOrEmpty(txtCSPhone.Text.Trim())
                || !string.IsNullOrEmpty(txtCSEmail.Text.Trim())
                && string.IsNullOrEmpty(txtProdName.Text.Trim()))
                {
                    client = new Client();

                    dgvItems.Hide();
                    data.DataSource = client[
                    string.IsNullOrEmpty(txtCSName.Text.Trim()) ? null : txtCSName.Text.Trim(),
                    string.IsNullOrEmpty(txtCSSurname.Text.Trim()) ? null : txtCSSurname.Text.Trim(),
                    string.IsNullOrEmpty(txtCSEmail.Text.Trim()) ? null : txtCSEmail.Text.Trim()];
                    dgvSales.DataSource = data;

                    #region Clear
                    lblCSId.DataBindings.Clear();
                    txtCSName.DataBindings.Clear();
                    txtCSSurname.DataBindings.Clear();
                    txtCSPhone.DataBindings.Clear();
                    txtCSEmail.DataBindings.Clear();
                    txtProdName.DataBindings.Clear();
                    txtProdName.Clear();
                    numQuantity.Enabled = false;
                    #endregion

                    #region Bind
                    lblCSId.DataBindings.Add("Text", data, "Identity");
                    txtCSName.DataBindings.Add("Text", data, "Name");
                    txtCSSurname.DataBindings.Add("Text", data, "Surname");
                    txtCSPhone.DataBindings.Add("Text", data, "ContactNumber");
                    txtCSEmail.DataBindings.Add("Text", data, "EmailAddress");
                    #endregion
                }
                
                else
                {
                    MessageBox.Show("There were 0 search results found.");
                }
            }
            catch (KeyNotFoundException knf)
            {
                MessageBox.Show("There were 0 search results found.");

            }

        }
        private void cmbProdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProdModel.Text = "";
            txtProdName.Text = "";
            cmbProdModel.DataBindings.Clear();
            txtProdName.DataBindings.Clear();
        }

        private void cmbProdModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProdName.Text = "";
            cmbProdType.DataBindings.Clear();
            txtProdName.DataBindings.Clear();
        }


        #endregion

        #region Insert
        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            if (ValidateAll(this.tabPage2))
            {

                client = new Client(
                    string.Empty,
                    cmbCTitle.Text,
                    txtCName.Text.Trim(),
                    txtCSurname.Text.Trim(),
                    cmbCGender.Text,
                    dtpCBD.Value,
                    txtCPhone.Text.Trim(),
                    txtCEmail.Text.Trim(),
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    cmbCCountry.Text,
                    cmbCCity.Text,
                    txtCAddress.Text.Trim());

                if (!CRUD.InsertClient(client))
                {
                    MessageBox.Show("Customer could not be added.");
                }
                else
                {
                    Clear();
                    BindData();
                    ClearAll(this.tabPage2);
                    MessageBox.Show("Customer was added successfully.");

                }
            }

        }
        #endregion

        #region Update
        private void btnUpdate_Click_2(object sender, EventArgs e)
        {
            if (ValidateAll(this.tabPage1))
            {
                client = new Client()
                {
                    Identity = txtClientId.Text,
                    Title = cmbCustTitle.Text,
                    Name = txtCustName.Text,
                    Surname = txtCustSurname.Text,
                    Gender = cmbCustGender.Text,
                    BirthDate = dtpCustDOB.Value,
                    ContactNumber = txtCustPhone.Text,
                    EmailAddress = txtCustEmail.Text,
                    Country = cmbCustCountry.Text,
                    City = cmbCustCity.Text,
                    Street = txtCustStreet.Text
                };
                if (!CRUD.UpdateClient(client))
                {
                    MessageBox.Show("Customer information could not be changed.");
                }
                else
                {
                    Clear();
                    BindData();
                    MessageBox.Show("Customer information was updated successfully.");
                }
            }

        }
        #endregion

        #region Delete
        private void btnDelete_Click_2(object sender, EventArgs e)
        {

            if (!CRUD.DeleteClient(int.Parse(txtClientId.Text)))
            {
                MessageBox.Show("Customer could not be deleted.");
            }
            else
            {
                Clear();
                BindData();
                MessageBox.Show("Customer was deleted successfully");
            }
        }
        #endregion

        #region Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll(this.tabPage1);
        }
        #endregion       

        #region Validation

        private Dictionary<Type, Action<object>> actions = new Dictionary<Type, Action<object>>
        {
            { typeof(TextBox), ctrl => ((TextBox)ctrl).Text = string.Empty},
            { typeof(ComboBox), ctrl => ((ComboBox)ctrl).Text = string.Empty },
        };
        private bool ValidateAll(Control parent)
        {
            int counter = parent.Controls.Count;
            foreach (Control child in parent.Controls)
            {
                var controlType = child.GetType();

                if (controlType == typeof(TextBox))
                {
                    if (string.IsNullOrEmpty(child.Text))
                    {
                        errors.SetError(child, "This field is required");
                        counter--;

                    }
                    else { errors.SetError(child, ""); }

                }

                if (controlType == typeof(ComboBox))
                {
                    if (string.IsNullOrEmpty(child.Text))
                    {
                        errors.SetError(child, "This field is required");
                        counter--;
                    }
                    else { errors.SetError(child, ""); }

                }
            }
            return counter < parent.Controls.Count ? false : true;
        }
        private void ClearAll(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                var controlType = child.GetType();

                if (actions.ContainsKey(controlType))
                {
                    actions[controlType](child);
                }

                ClearAll(child);
            }
        }
        private void cmbCTitle_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void txtCName_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void txtCSurname_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void txtCPhone_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void txtCEmail_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void txtCAddress_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void cmbCCity_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void cmbCCountry_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void cmbCGender_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        #endregion

        #region Empty
        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnInsert_Click(object sender, EventArgs e)
        {

        }

        private void cmbCustGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }



        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {


        }

        private void btnMainMenu_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }





        private void cmbProdType_TextChanged(object sender, EventArgs e)
        {

        }




        #endregion

       
    }
}
