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
        public frmMainMenu()
        {
           InitializeComponent();
        }      

        private void btnClientDept_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCustomerService cust = new frmCustomerService();
            cust.Show();
        }

        private void btnProdDept_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmProductManagement prod = new frmProductManagement();
            prod.Show();
        }

        private void btnTechSupport_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTechnicalSupport tech = new frmTechnicalSupport();
            tech.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeService emp = new EmployeeService();
            emp.Show();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
