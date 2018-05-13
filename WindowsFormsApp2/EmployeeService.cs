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
    public partial class EmployeeService : Form
    {
        Staff staff;
        BindingSource data;
        public EmployeeService()
        {
            InitializeComponent();
            BindData();
        }
        private bool BindData()
        {
            if (Populate())
            {
                txtEmpId.DataBindings.Add("Text", data, "Identity");
                cmbEmpTitle.DataBindings.Add("Text", data, "Title");
                txtEmpName.DataBindings.Add("Text", data, "Name");
                txtEmpSurname.DataBindings.Add("Text", data, "Surname");
                dtpEmpDOB.DataBindings.Add("Text", data, "BirthDate");
                cmbEmpGender.DataBindings.Add("Text", data, "Gender");
                txtEmpPhone.DataBindings.Add("Text", data, "ContactNumber");
                txtEmpEmail.DataBindings.Add("Text", data, "EmailAddress");
                cmbEmpCountry.DataBindings.Add("Text", data, "Country");
                cmbEmpCity.DataBindings.Add("Text", data, "City");
                txtEmpStreet.DataBindings.Add("Text", data, "Street");
                return true;
            }
            return false;
        }
        private void Clear()
        {

            txtEmpId.DataBindings.Clear();
            cmbEmpTitle.DataBindings.Clear();
            txtEmpName.DataBindings.Clear();
            txtEmpSurname.DataBindings.Clear();
            cmbEmpGender.DataBindings.Clear();
            dtpEmpDOB.DataBindings.Clear();
            txtEmpPhone.DataBindings.Clear();
            txtEmpEmail.DataBindings.Clear();
            txtEmpStreet.DataBindings.Clear();
            cmbEmpCity.DataBindings.Clear();
            cmbEmpCountry.DataBindings.Clear();
        }
        private bool Populate()
        {
            staff = new Staff();
            data = new BindingSource();
            if (Staff.staff.Any())
            {
                data.DataSource = Staff.staff;
                dgvStaff.DataSource = data;
                return true;
            }
            return false;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            staff = new Staff()
            {
                Identity = int.Parse(txtEmpId.Text),
                Title = cmbEmpTitle.Text.Trim(),
                Name = txtEmpName.Text.Trim(),
                Surname = txtEmpSurname.Text.Trim(),
                Gender = cmbEmpGender.Text.Trim(),
                BirthDate = dtpEmpDOB.Value,
                ContactNumber = txtEmpPhone.Text.Trim(),
                EmailAddress = txtEmpEmail.Text.Trim(),
                Country = cmbEmpCountry.Text.Trim(),
                City = cmbEmpCity.Text.Trim(),
                Street = txtEmpStreet.Text.Trim()
            };
            if (!Staff.Update(staff))
            {
                MessageBox.Show("Employee information could not be changed.");
            }
            else
            {
                Clear();
                BindData();
                MessageBox.Show("Employee information was updated successfully.");
            }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainMenu menu = new frmMainMenu();
            menu.Show();
        }

        private void txtEmpPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
