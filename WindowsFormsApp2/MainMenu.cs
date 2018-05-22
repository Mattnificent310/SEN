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
    public partial class frmMainMenu : Form
    {
        private static Staff staf;
        public frmMainMenu()
        {
           InitializeComponent();
        }      

        private void btnClientDept_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCustomerService cust = new frmCustomerService();
            cust.Login(staf);
            cust.Show();
        }

        private void btnProdDept_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmProductManagement prod = new frmProductManagement();
            prod.Login(staf);
            prod.Show();
        }

        private void btnTechSupport_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTechnicalSupport tech = new frmTechnicalSupport();
            tech.Login(staf);
            tech.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeService emp = new EmployeeService();
            emp.Login(staf);
            emp.Show();
        }
        public void Login(Staff staff)
        {
            staf = staff;
            lblLogin.Text += string.Format("{0}  {1}  {2}", staff.Title, staff.Name, staff.Surname);
        }
        private void frmMainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
