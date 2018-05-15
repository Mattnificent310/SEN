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

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
}
