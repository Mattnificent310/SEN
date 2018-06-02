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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ValidateAll(this);
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateAll(this))
                {
                    var staff = CRUD.Login(txtUsername.Text, txtPassword.Text);
                    if (staff != null)
                    {
                        switch (staff.Department)
                        {
                            case "Technical Support":
                                {
                                    this.Hide();
                                    frmTechnicalSupport support = new frmTechnicalSupport();
                                    support.Login(staff);
                                    support.Show();
                                    break;
                                }
                            case "Product Management":
                                {
                                    this.Hide();
                                    frmProductManagement prodMng = new frmProductManagement();
                                    prodMng.Login(staff);
                                    prodMng.Show();
                                    break;
                                }
                            case "Customer Support":
                                {
                                    this.Hide();
                                    frmCustomerService custSupport = new frmCustomerService();
                                    custSupport.Login(staff);
                                    custSupport.Show();
                                    break;
                                }
                            case "Employee Services":
                                {
                                    this.Hide();
                                    EmployeeService emp = new EmployeeService();
                                    emp.Login(staff);
                                    emp.Show();
                                    break;
                                }
                            case "Administrator":
                                {
                                    this.Hide();
                                    frmMainMenu menu = new frmMainMenu();
                                    menu.Login(staff);
                                    menu.Show();
                                    break;
                                }
                            default:
                                {

                                    MessageBox.Show("Unauthorized Access Detected!");
                                    break;
                                }
                        }

                    }
                    else
                        MessageBox.Show("Unauthorized Access Detected!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unauthorized Access Detected!");
                // MessageBox.Show(ex.ToString());
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

    }
}

