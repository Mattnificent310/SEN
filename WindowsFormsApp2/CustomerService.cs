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
        public Client client;
        public frmCustomerService()
        {
            InitializeComponent();
        }

        private void CustomerService_Load(object sender, EventArgs e)
        {

            if (!BindData())
            {
                MessageBox.Show("No customers could be found.");
            }
        }
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
                txtCustCountry.DataBindings.Add("Text", data, "Country");
                cmbCustCity.DataBindings.Add("Text", data, "City");
                txtCustStreet.DataBindings.Add("Text", data, "Street");
                return true;
            }
            return false;
        }
        private bool Populate()
        {
            client = new Client();
            if (Client.clients.Any())
            {
                data.DataSource = Client.clients;
                dgvClient.DataSource = data;
                return true;
            }
            return false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
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
                Country = txtCustCountry.Text,
                City = cmbCustCity.Text,
                Street = txtCustStreet.Text
            };
            if (!Client.Insert(client))
            {
                MessageBox.Show("Customer could not be added.");
            }
            else
                MessageBox.Show("Customer was added successfully.");
            Populate();
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

        private void btnUpdate_Click(object sender, EventArgs e)
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
                Country = txtCustCountry.Text,
                City = cmbCustCity.Text,
                Street = txtCustStreet.Text
            };
            if (!Client.Update(client))
            {
                MessageBox.Show("Customer information could not be changed.");
            }
            else
                MessageBox.Show("Customer information was updated successfully.");
            Populate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Client.Delete(txtClientId.Text))
            {
                MessageBox.Show("Customer could not be deleted.");
            }
            else
                MessageBox.Show("Customer was deleted successfully");
            Populate();
        }
    }
}
