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
    public partial class frmTechnicalSupport : Form
    {
        private static BindingSource data = new BindingSource();
        private static Client client;
        private static Product prod;

        public frmTechnicalSupport()
        {
            InitializeComponent();
            new Client();
            new Product();
            timer1.Start();

        }

        #region Login
        public void Login(Staff staf)
        {
            lblLogin.Text = string.Format("Welcome:  {0} {1} {2}", staf.Title, staf.Name, staf.Surname);

        }
        private void frmTechnicalSupport_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format("{0} -- {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToShortTimeString());

        }
        #endregion

        #region Main
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainMenu main = new frmMainMenu();
            main.Show();
        }
        #endregion

        #region Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProdNo.Text))
                {
                    client = new Client();
                    data.DataSource = client[
                    string.IsNullOrEmpty(txtCustName.Text.Trim()) ? null : txtCustName.Text.Trim(),
                    string.IsNullOrEmpty(txtCustSurname.Text.Trim()) ? null : txtCustSurname.Text.Trim(),
                    string.IsNullOrEmpty(txtCustEmail.Text.Trim()) ? null : txtCustEmail.Text.Trim()];
                    dgvTech.DataSource = data;

                }
                else
                {
                    prod = new Product();
                    data.DataSource = prod[int.Parse(txtProdNo.Text)];
                    dgvTech.DataSource = data;
                }

            }
            catch (KeyNotFoundException knf)
            {
                MessageBox.Show("There were 0 search results found.");

            }


        }

        private void cmbSuportType_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSuportType.Text)
            {
                case "Product Support":
                    {
                        data = new BindingSource();
                        data.DataSource = Product.prods;
                        dgvTech.DataSource = data;
                        break;
                    }
                case "Customer Support":
                    {
                        data = new BindingSource();
                        data.DataSource = Client.clients;
                        dgvTech.DataSource = data;
                        break;
                    }
                default:
                    break;
            }
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
        #endregion        

        #region Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll(this.tabPage1);
        }
        #endregion

        #region Empty
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSuportType_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        #endregion
    }
}
