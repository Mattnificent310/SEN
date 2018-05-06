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
        public frmCustomerService()
        {
            InitializeComponent();
        }

        private void CustomerService_Load(object sender, EventArgs e)
        {
            Client client = new Client();
            data.DataSource = Client.clients;
            dgvClient.DataSource = data;
            if (data.DataSource != null)
            {
                cmbCustTitle.DataBindings.Add("Text", data, "Title");
                txtCustName.DataBindings.Add("Text", data, "Name");
                txtCustSurname.DataBindings.Add("Text", data, "Surname");
                dtpCustDOB.DataBindings.Add("Text", data, "BirthDate");
                cmbCustGender.DataBindings.Add("Text", data, "Gender");
                txtCustPhone.DataBindings.Add("Text", data, "ContactNumber");
                txtCustEmail.DataBindings.Add("Text", data, "EmailAddress");
                txtCustCountry.DataBindings.Add("Text", data, "Country");
                cmbCustCity.DataBindings.Add("Text", data, "City");
                txtCustStreet.DataBindings.Add("Text", data, "Street");
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Client client = new Client()
            {
                Title = cmbCustTitle.Text,
                Name = txtCustName.Text,
                Surname = txtCustSurname.Text,
                BirthDate = dtpCustDOB.Value,
                Gender = cmbCustGender.SelectedItem.ToString(),
                ContactNumber = txtCustPhone.Text,
                EmailAddress = txtCustEmail.Text,
                Country = txtCustCountry.Text,
                City = cmbCustCity.Text,
                Street = txtCustStreet.Text
            };
            if(Client.Insert(client))
            {
                MessageBox.Show("Customer Inserted");
            }
        }

        private void cmbCustGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainMenu main = new frmMainMenu();
            main.Show();
        }
    }
}
