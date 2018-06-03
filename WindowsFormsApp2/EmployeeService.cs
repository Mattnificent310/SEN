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
        private static frmMainMenu menu = new frmMainMenu();
        public EmployeeService()
        {
            InitializeComponent();
            BindData();
            timer1.Start();

        }

        #region Login
        public void Login(Staff staf)
        {
            if (!staf.Department.Equals("Administrator"))
            {
                this.btnMainMenu.Text = "Log Out";
            }
            menu.Login(staf);
            lblLogin.Text = string.Format("Welcome:  {0} {1} {2}", staff.Title, staf.Name, staf.Surname);

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
                txtEmpId.DataBindings.Add("Text", data, "Identity");
                cmbEmpTitle.DataBindings.Add("Text", data, "Title");
                txtEmpName.DataBindings.Add("Text", data, "Name");
                txtEmpSurname.DataBindings.Add("Text", data, "Surname");
                dtpEmpDOB.DataBindings.Add("Text", data, "BirthDate");
                cmbEmpGender.DataBindings.Add("Text", data, "Gender");
                txtEmpPhone.DataBindings.Add("Text", data, "ContactNumber");
                txtEmpEmail.DataBindings.Add("Text", data, "EmailAddress");
                cmbJobDescription.DataBindings.Add("Text", data, "JobDesc");
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
            cmbJobDescription.DataBindings.Clear();
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
                BindingSource jobDescs = new BindingSource();
                jobDescs.DataSource = Job.jobs.Select(x => x.JobDesc);
                cmbJobDescription.DataSource = jobDescs;
                cmbJobDesc.DataSource = jobDescs;
                //cmbECountry.Items.Clear();
                cmbECountry.DataSource = Business_Logic_Layer.Location.countries.Select(x => x.Country).ToList();
                cmbEmpCountry.DataSource = Business_Logic_Layer.Location.countries.Select(x => x.Country).ToList();
                return true;
            }
            return false;
        }
        #endregion

        #region Main
        private void btnMainMenu_Click(object sender, EventArgs e)
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
        #endregion

        #region Insert
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (ValidateAll(this.tabPage2))
            {
                staff = new Staff(
                    string.Empty,
                    cmbETitle.Text,
                    txtEName.Text.Trim(),
                    txtESurname.Text.Trim(),
                    cmbEGender.Text,
                    dtpEBD.Value,
                    txtEPhone.Text.Trim(),
                    txtEEmail.Text.Trim(),
                    cmbJobDesc.Text,
                    cmbECountry.Text,
                    cmbECity.Text,
                    txtEAddress.Text.Trim()
                );
                if (!CRUD.InsertStaff(staff))
                {
                    MessageBox.Show("Employee could not be added.");
                }
                else
                {
                    Clear();
                    BindData();
                    ClearAll(this.tabPage2);
                    MessageBox.Show("Employee was added successfully.");
                }
            }

        }
        #endregion

        #region Update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateAll(this.tabPage1))
            {
                staff = new Staff()
                {
                    Identity = txtEmpId.Text,
                    Title = cmbEmpTitle.Text.Trim(),
                    Name = txtEmpName.Text.Trim(),
                    Surname = txtEmpSurname.Text.Trim(),
                    Gender = cmbEmpGender.Text.Trim(),
                    BirthDate = dtpEmpDOB.Value,
                    ContactNumber = txtEmpPhone.Text.Trim(),
                    EmailAddress = txtEmpEmail.Text.Trim(),
                    JobDesc = cmbJobDesc.Text,
                    Country = cmbEmpCountry.Text.Trim(),
                    City = cmbEmpCity.Text.Trim(),
                    Street = txtEmpStreet.Text.Trim()
                };
                if (!CRUD.UpdateStaff(staff))
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

        }
        #endregion

        #region Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!CRUD.DeleteStaff(int.Parse(txtEmpId.Text)))
            {
                MessageBox.Show("Employee could not be deleted.");
            }
            else
            {
                Clear();
                BindData();
                MessageBox.Show("Employee was deleted successfully");
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
        private void cmbETitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void txtEName_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void txtESurname_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void cmbEGender_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void cmbJobDesc_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void txtEPhone_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void txtEEmail_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void txtEAddress_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void cmbECity_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }

        private void cmbECountry_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this.tabPage2);
        }
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
        #endregion

        #region Empty
        private void txtEmpPhone_TextChanged(object sender, EventArgs e)
        {

        }
        private void EmployeeService_Load(object sender, EventArgs e)
        {

        }
        #endregion

        private void cmbEmpTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmpCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
