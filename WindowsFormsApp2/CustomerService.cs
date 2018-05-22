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

       // public Client client;
        //Product prod;

        private static Client client;
        private static Product prod;
        private static frmMainMenu menu = new frmMainMenu();     
        private static Client client;
        private static Product prod;
        private static frmMainMenu menu = new frmMainMenu();

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
            lblLogin.Text = string.Format("Welcome {0} {1}            {2}    {3}", staf.Name, staf.Surname, DateTime.Now.ToLongDateString(), DateTime.Now.ToShortTimeString());

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
            //client = new Client();
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
        //{
        //   this.Hide();
        //    menu.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu.Show();
        }
        #endregion

        #region Search

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbProdType.Text)
                && string.IsNullOrEmpty(cmbProdModel.Text)
                && string.IsNullOrEmpty(txtProdName.Text.Trim()))
                {
                    client = new Client();
                    data.DataSource = client[
                    string.IsNullOrEmpty(txtCSName.Text.Trim()) ? null : txtCSName.Text.Trim(),
                    string.IsNullOrEmpty(txtCSSurname.Text.Trim()) ? null : txtCSSurname.Text.Trim(),
                    string.IsNullOrEmpty(txtCSEmail.Text.Trim()) ? null : txtCSEmail.Text.Trim()];
                    dgvSales.DataSource = data;
                    txtCSName.DataBindings.Clear();
                    txtCSSurname.DataBindings.Clear();
                    txtCSPhone.DataBindings.Clear();
                    txtCSEmail.DataBindings.Clear();
                    txtCSName.DataBindings.Add("Text", data, "Name");
                    txtCSSurname.DataBindings.Add("Text", data, "Surname");
                    txtCSPhone.DataBindings.Add("Text", data, "ContactNumber");
                    txtCSEmail.DataBindings.Add("Text", data, "EmailAddress");

                }
                else
                {

                    new Product();
                    data = new BindingSource();
                    data.DataSource = Product.prods.Where(x => x.ProductType == cmbProdType.Text 
                    || x.ProductModel == cmbProdModel.Text 
                    || x.ProductName == txtProdName.Text.Trim()).ToList();
                    dgvSales.DataSource = data;
                    cmbProdType.DataBindings.Clear();
                    cmbProdModel.DataBindings.Clear();
                    lblUnitPrice.DataBindings.Clear();
                    lblUnitPrice.DataBindings.Add("Text", data, "UnitPrice");
                    lblTotal.Text = "R "+ decimal.Parse(lblUnitPrice.Text) * numQuantity.Value;
                    txtProdName.DataBindings.Clear();
                    cmbProdType.DataBindings.Add("Text", data, "ProductType");
                    cmbProdModel.DataBindings.Add("Text", data, "ProductModel");
                    txtProdName.DataBindings.Add("Text", data, "ProductName");
                }
            }
            catch (KeyNotFoundException knf)
            {
                MessageBox.Show("There were 0 search results found.");

            }

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
        private void btnInsert_Click(object sender, EventArgs e)
        {

        }
        private void radioCol_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCol.Checked)
            {
                dtpColDel.Value = DateTime.Now.AddDays(1.0);
            }
        }

        private void radioDel_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDel.Checked)
            {
                dtpColDel.Value = DateTime.Now.AddDays(new Random().Next(2, 14));
            }


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
        #endregion

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            lblTotal.Text = "R " + decimal.Parse(lblUnitPrice.Text) * numQuantity.Value;
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMain_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmMainMenu main = new frmMainMenu();
            main.Show();
        }
    }
}
