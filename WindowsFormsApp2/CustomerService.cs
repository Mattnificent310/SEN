using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Logic_Layer;

namespace WindowsFormsApp2
{
    public partial class frmCustomerService : Form
    {
        #region Declarations
        BindingSource data = new BindingSource();
        private static Client client;
        private static Product prod;
        private static Category cat;
        private static frmMainMenu menu = new frmMainMenu();
        private static Sale sale;
        private static Order order;
        private static OrderDetail detail;
        private static List<OrderDetail> items = new List<OrderDetail>();
        private BackgroundWorker worker = new BackgroundWorker();
        static Thread thread;
        private static BackgroundWorker blinker;
        #endregion

        public frmCustomerService()
        {
            InitializeComponent();
            timer1.Start();
            blinker = new BackgroundWorker();
            blinker.DoWork += Blinker_DoWork;
        }

        private void CustomerService_Load(object sender, EventArgs e)
        {
            PopulateSales();
            if (!BindData())
            {
                MessageBox.Show("No customers could be found.");
            }
        }

        #region Login
        public void Login(Staff staf)
        {
            if (!staf.Department.Equals("Administrator"))
            {
                this.btnMain.Text = "Log Out";
                this.btnMainMenu.Text = "Log Out";
            }
            menu.Login(staf);
            lblLogin.Text = string.Format("Welcome:  {0}  {1}  {2}", staf.Title, staf.Name, staf.Surname);

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
                closed = false;
                answered = false;
                missed = false;
                hold = false;
                played = false;
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
            client = new Client();

            if (Client.clients.Any())
            {
                data.DataSource = Client.clients;
                dgvClient.DataSource = data;
                return true;
            }
            return false;
        }
        private bool PopulateSales()
        {
            try
            {
                cat = new Category();
                prod = new Product();
                if (Category.cats.Any())
                {
                    cmbProdType.Items.Clear();
                    cmbProdType.DataSource = Category.cats.Select(x => x.CategoryName).ToList();
                    cmbProdType.Text = "";
                }
                if (Product.prods.Any())
                {
                    cmbProdModel.Items.Clear();
                    cmbProdModel.DataSource = Product.prods.Select(x => x.ProductModel).ToList();
                    cmbProdModel.Text = "";
                }
                cmbPayment.Items.Clear();
                cmbPayment.Items.AddRange(new object[] { "EFT", "SWIFT", "Credit/Debit", "Layby" });
                cmbProdType.Enabled = false;
                cmbProdModel.Enabled = false;
                txtProdName.Enabled = false;
                numQuantity.Enabled = false;
                radioCol.Enabled = false;
                radioDel.Enabled = false;
                dtpColDel.Enabled = false;
                cmbPayment.Enabled = false;
                btnOrder.Enabled = false;
                dgvItems.Hide();

                return true;

            }
            catch (Exception e) { MessageBox.Show("Unexpected problems were detected."); }
            return false;
        }
        #endregion        

        #region Main
        private void btnMainMenu_Click_2(object sender, EventArgs e)
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
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.btnMain.Text.StartsWith("Log Out"))
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

        private void btnMain_Click(object sender, EventArgs e)
        {
            if (this.btnMain.Text.StartsWith("Log Out"))
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

        #region Calls

        #region Declarations
        static bool played = false;
        static bool answered = false;
        static bool missed;
        static bool closed = false;
        static bool hold = false;
        static bool unhold = false;
        static int x = 0;
        private delegate void DisplayCountDelegate(int i);
        #endregion

        #region Blink
        private void Blink()
        {
            //if (lblCall.Visible == true)
            //    lblCall.Visible = false;
            //else
            //{
            //    lblCall.Visible = true;
            string path = @"C:\Users\MC\Desktop\SEN 321\Assignments\Project\SHS Management System\WindowsFormsApplication1\Images\WinPhoneIn.wav";
            string path2 = @"C:\Users\MC\Desktop\SEN 321\Assignments\Project\SHS Management System\WindowsFormsApplication1\Images\WinPhoneOut.wav";

            if (!played && !answered && !closed && !missed)
            {
                PlaySound(path);
                played = true;
            }
            else
            {
                if (!answered && !closed && !missed)
                {

                    Client c = new Client();
                    List<Client> entities = new List<Client>();
                    foreach (var item in Client.clients.Where(x => x == c))
                    {
                        //Add Callers
                    }
                    PopulateSales();
                    PlaySound(path2);
                    played = false;
                }
            }
            if (missed)
            {
                Disable();
            }

        }
        #endregion

        #region Do Work
        private void Blinker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Random r = new Random();
                Random rn = new Random();
                Random rnd = new Random(1000);
                Thread.Sleep(rn.Next(8000, 30000));
                //string[] calls = new string[obh.CallCenter().Count()];
                for (int i = 0; i < 1000; i++)
                {
                    //calls[i] = obh.ShowClient()[i].ContactNumber;
                }
                r = new Random();

                //phone = calls[r.Next(0, calls.Length)];
                for (int i = 0; i <= 60 * 60 * 24; i++)
                {
                    if (i == 20)
                    {
                        missed = true;
                        btnCall.Invoke((Action)Disable);
                        i = 60 * 60 * 24;
                    }
                    if (missed)
                    {
                        missed = false;
                        i = 0;
                        rn = new Random();
                        //phone = calls[rn.Next(0, calls.Length)];
                        rn = new Random();
                        Thread.Sleep(rn.Next(8000, 30000));
                    }
                    Thread.Sleep(1400); // Set fast to slow.

                    blinker.WorkerSupportsCancellation = true;
                    if (/*lblCall.InvokeRequired*/true)
                    {
                        //lblCall.Invoke((Action)blink);
                        btnCall.Invoke((Action)Enable);
                    }
                    else
                    {
                        Blink();
                    }

                    if (blinker.CancellationPending && blinker.IsBusy)
                    {
                        e.Cancel = true;

                        return;
                    }

                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Connection Lost to Call Distribution System (CDS)", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region Play Sound
        private void PlaySound(string path)
        {
            System.Media.SoundPlayer player =
                new System.Media.SoundPlayer();
            player.SoundLocation = path;
            player.Load();
            player.Play();
        }
        #endregion

        #region Simulate
        private void SimulateCall()
        {

            if (blinker.IsBusy == false)
            {

                answered = false;

                blinker.RunWorkerAsync();

            }
        }
        #endregion

        #region Enable / Disable
        private void Enable()
        {
            if (btnCall.Enabled == false)
            {
                btnCall.Enabled = true;
                //lblElapsed.Visible = false;
                //btnHoldCall.Enabled = false;
                //btnDivertCall.Enabled = false;
            }
            if (answered)
            {
                //lblElapsed.Visible = true;
                btnCall.Enabled = false;
                //btnHoldCall.Enabled = true;
                //btnDivertCall.Enabled = true;
            }


        }
        private void Disable()
        {
            if (missed)
            {
                btnCall.Enabled = false;
                //lblCall.Visible = false;
                if (blinker.IsBusy)
                {

                    btnCall.Enabled = false;
                    //lblCall.Visible = false;

                }

            }
        }
        #endregion

        #region End Session
        private void EndSession()
        {
            if (blinker.IsBusy)
            {
                blinker.WorkerSupportsCancellation = true;
                blinker.CancelAsync();
                this.Close();
                this.Dispose();
                closed = true;
            }
        }
        #endregion

        #region Start Counting
        private void StartCounting()
        {
            try
            {


                for (var i = 0; i < 100000; i++)
                {

                    //lblElapsed.Invoke(new DisplayCountDelegate(DisplayCount), i);
                    Thread.Sleep(1000);


                }
            }
            catch (Exception e)
            {
                MessageBox.Show("A call is still in progress\nWould you like to end it?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }
        #endregion

        #region Display Count
        private void DisplayCount(int i)
        {

            if (/*lblCall.Visible == false*/true)
            {
                //lblAnswer.Visible = true;
            }
            if (/*btnHoldCall.Enabled == false*/true)
            {
                //lblElapsed.Text = SecondsToMinutes(x++);
            }
            if (unhold == true)
            {
                //lblElapsed.Text = SecondsToMinutes(i);
            }
        }
        public static string SecondsToMinutes(int seconds)
        {
            var ts = new TimeSpan(0, 0, seconds);
            return new DateTime(ts.Ticks).ToString(seconds >= 3600 ? "hh:mm:ss" : "mm:ss");
        }
        #endregion

        #region Answer Call
        private void btnCall_Click(object sender, EventArgs e)
        {
            try
            {
                if (blinker.IsBusy)
                {
                    blinker.CancelAsync();
                    thread = new Thread(StartCounting);
                    thread.IsBackground = true;
                    thread.Start();
                    btnCall.Enabled = false;
                    btnEndCall.Enabled = true;
                    //btnHoldCall.Enabled = true;
                    //btnDivertCall.Enabled = true;
                    unhold = true;
                    //lblElapsed.Visible = true;
                    answered = true;
                }
                if (hold)
                {
                    unhold = true;
                    btnCall.Enabled = false;
                    //btnHoldCall.Enabled = true;
                    //lblHold.Visible = false;
                    //lblEnd.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Incoming Calls Detected", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        #endregion

        #region End Call
        private void btnEndCall_Click_1(object sender, EventArgs e)
        {
            //lblEnd.Visible = true;
            thread.Abort();
            btnCall.Enabled = true;
            btnEndCall.Enabled = false;
            //lblCall.Visible = false;
            //lblAnswer.Visible = false;
            //lblHold.Visible = false;
            //btnHoldCall.Enabled = false;
            //btnDivertCall.Enabled = false;
            //btnAnswerCall.Enabled = false;
            if (blinker.IsBusy)
            {
                blinker.WorkerSupportsCancellation = true;
                blinker.CancelAsync();
            }
            x = 0;
            Thread.Sleep(15000);
            //lblElapsed.Visible = false;
            //lblEnd.Visible = false;
            answered = false;
            SimulateCall();
        }
        #endregion

        #endregion

        #region Sales
        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            lblTotal.Text = string.Format("{0:C}", decimal.Parse(lblUnitPrice.Text) * numQuantity.Value);
        }
        private void radioCol_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCol.Checked)
            {
                order = new Order(
                    "Collection Order",
                    DateTime.Now,
                    "N/A"
                    );
                dtpColDel.Value = DateTime.Now.AddDays(1.0);
                btnOrder.Enabled = true;
            }
        }

        private void radioDel_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDel.Checked)
            {
                order = new Order(
                   "Delivery Order",
                    DateTime.Now,
                    "N/A"
                    );
                dtpColDel.Value = DateTime.Now.AddDays(new Random().Next(2, 14));
                btnOrder.Enabled = true;
            }


        }

        bool columns = false, ordered = false;
        List<object[]> vals = new List<object[]>();
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (ValidateAll(this.tabPage3))
            {

                items.Add(new OrderDetail(
                0,
                int.Parse(lblProdId.Text),
                1,
                (int)numQuantity.Value,
                decimal.Parse(lblTotal.Text.Substring(1)),
                0.1));

                #region Values
                object[] values =
                {
                cmbProdModel.Text,
                txtProdName.Text,
                 radioCol.Checked ? "Collection" : "Delivery",
                dtpColDel.Value.ToShortDateString(),
                double.Parse(lblUnitPrice.Text),
                numQuantity.Value.ToString(),
                double.Parse(lblTotal.Text.Substring(1))
                };
                #endregion

                #region Clear
                cmbProdType.Text = "";
                cmbProdModel.Text = "";
                txtProdName.Text = "";
                radioCol.Enabled = false;
                radioDel.Enabled = false;
                numQuantity.Value = 1;
                numQuantity.Enabled = false;
                dtpColDel.Enabled = false;
                #endregion

                if (!columns)
                {
                    #region Columns
                    dgvItems.DataSource = null;
                    dgvItems.DataBindings.Clear();
                    dgvItems.Columns.Add("ProductModel", "Product Model");
                    dgvItems.Columns.Add("ProductName", "Product Name");
                    dgvItems.Columns.Add("OrderType", "Order Type");
                    dgvItems.Columns.Add("OrderDate", "Estimated Date");
                    dgvItems.Columns.Add("UnitPrice", "Unit Price");
                    dgvItems.Columns.Add("ItemQuantity", "Item Quantity");
                    dgvItems.Columns.Add("Total", "Total");
                    #endregion 

                    columns = true;
                    ordered = true;
                }
                if (vals.Any(x => x.ElementAt(0).Equals(values.ElementAt(0))
                && x.ElementAt(1).Equals(values.ElementAt(1))
                && x.ElementAt(2).Equals(values.ElementAt(2))
                && x.ElementAt(3).Equals(values.ElementAt(3))
                && x.ElementAt(4).Equals(values.ElementAt(4))
                && !x.ElementAt(5).Equals(values.ElementAt(5))
                && !x.ElementAt(6).Equals(values.ElementAt(6))))
                {
                    int index = vals.IndexOf(vals.Where(x =>
                   x.ElementAt(0).Equals(values.ElementAt(0))
                && x.ElementAt(1).Equals(values.ElementAt(1))
                && x.ElementAt(2).Equals(values.ElementAt(2))
                && x.ElementAt(3).Equals(values.ElementAt(3))
                && x.ElementAt(4).Equals(values.ElementAt(4))).FirstOrDefault());
                    vals[index] = values;
                    dgvItems.Rows[index].SetValues(values);
                    dgvItems.Show();
                    lblTotal.Text = string.Format("{0:C}", 0.00);
                    lblGrandTotal.Text = string.Format("{0:C}", vals.Sum(x => x.ElementAt(6).GetType() == typeof(double) ? (double)x.ElementAt(6) : 0));

                }
                else if (!vals.Any(x => x.ElementAt(1).Equals(values.ElementAt(1))))
                {
                    vals.Add(values);
                    dgvItems.Rows.Add(values);
                    dgvItems.Show();
                    lblTotal.Text = string.Format("{0:C}", 0.00);
                    lblGrandTotal.Text = string.Format("{0:C}", vals.Sum(x => x.ElementAt(6).GetType() == typeof(double) ? (double)x.ElementAt(6) : 0));
                }
                else
                {
                    MessageBox.Show("That item was already added.");
                }
            }
        }
        private void lblUnitPrice_TextChanged(object sender, EventArgs e)
        {
            lblTotal.Text = string.Format("{0:C}", decimal.Parse(lblUnitPrice.Text) * numQuantity.Value);
        }
        private void btnCheckOut_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Search

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    !string.IsNullOrEmpty(txtCSName.Text.Trim())
                    && !string.IsNullOrEmpty(txtCSSurname.Text.Trim())
                    && !string.IsNullOrEmpty(txtCSPhone.Text.Trim())
                    && !string.IsNullOrEmpty(txtCSEmail.Text.Trim()))
                {

                    new Product();
                    data = new BindingSource();

                    dgvItems.Hide();

                    #region Find Product Type
                    if (!string.IsNullOrEmpty(cmbProdType.Text.Trim()))
                    {
                        data.DataSource = Product.prods.Where(x => x.ProductType == cmbProdType.Text.Trim()).ToList();

                    }
                    #endregion

                    #region Find Product Model
                    if (!string.IsNullOrEmpty(cmbProdModel.Text.Trim()))
                    {
                        data.DataSource = Product.prods.Where(x => x.ProductModel == cmbProdModel.Text.Trim()).ToList();

                    }
                    #endregion

                    #region Find Product Name
                    if (!string.IsNullOrEmpty(txtProdName.Text.Trim()))
                    {
                        data.DataSource = Product.prods.Where(x => x.ProductName == txtProdName.Text.Trim()).ToList();

                    }
                    #endregion

                    #region Find Product Type & Product Model
                    if (!string.IsNullOrEmpty(cmbProdModel.Text.Trim()) && !string.IsNullOrEmpty(cmbProdType.Text.Trim()))
                    {
                        data.DataSource = Product.prods.Where(x => x.ProductType == cmbProdType.Text.Trim()
                       && x.ProductModel == cmbProdModel.Text.Trim()).ToList();

                    }
                    #endregion

                    #region Find Product Type, Model & Name
                    if (!string.IsNullOrEmpty(cmbProdModel.Text.Trim())
                    && !string.IsNullOrEmpty(cmbProdType.Text.Trim())
                    && !string.IsNullOrEmpty(txtProdName.Text.Trim()))
                    {
                        data.DataSource = Product.prods.Where(x => x.ProductType == cmbProdType.Text.Trim()
                           && x.ProductModel == cmbProdModel.Text.Trim()
                           && x.ProductName == txtProdName.Text.Trim()).ToList();

                    }
                    #endregion



                    dgvSales.DataSource = data;

                    #region Clear
                    cmbProdType.DataBindings.Clear();
                    cmbProdModel.DataBindings.Clear();
                    lblUnitPrice.DataBindings.Clear();
                    lblProdId.DataBindings.Clear();
                    txtProdName.DataBindings.Clear();
                    cmbPayment.Text = "--Choose Method--";
                    cmbPayment.Enabled = true;

                    if (!ordered)
                    {
                        txtCSName.Enabled = false;
                        txtCSSurname.Enabled = false;
                        txtCSPhone.Enabled = false;
                        txtCSEmail.Enabled = false;
                        radioCol.Enabled = true;
                        radioDel.Enabled = true;
                        dtpColDel.Enabled = true;
                    }
                    #endregion

                    #region Bind
                    if (data.Count != 0)
                    {
                        numQuantity.Enabled = true;
                        lblProdId.DataBindings.Add("Text", data, "ProductID");
                        cmbProdType.DataBindings.Add("Text", data, "ProductType");
                        cmbProdModel.DataBindings.Add("Text", data, "ProductModel");
                        txtProdName.DataBindings.Add("Text", data, "ProductName");
                        lblUnitPrice.DataBindings.Add("Text", data, "UnitPrice");
                        lblTotal.Text = string.Format("{0:C}", decimal.Parse(lblUnitPrice.Text) * numQuantity.Value);
                    }

                    #endregion


                }
                else if (!string.IsNullOrEmpty(txtCSName.Text.Trim())
                || !string.IsNullOrEmpty(txtCSSurname.Text.Trim())
                || !string.IsNullOrEmpty(txtCSPhone.Text.Trim())
                || !string.IsNullOrEmpty(txtCSEmail.Text.Trim())
                && string.IsNullOrEmpty(txtProdName.Text.Trim()))
                {
                    client = new Client();

                    dgvItems.Hide();
                    data.DataSource = client[
                    string.IsNullOrEmpty(txtCSName.Text.Trim()) ? null : txtCSName.Text.Trim(),
                    string.IsNullOrEmpty(txtCSSurname.Text.Trim()) ? null : txtCSSurname.Text.Trim(),
                    string.IsNullOrEmpty(txtCSEmail.Text.Trim()) ? null : txtCSEmail.Text.Trim()];
                    dgvSales.DataSource = data;

                    #region Clear
                    lblCSId.DataBindings.Clear();
                    txtCSName.DataBindings.Clear();
                    txtCSSurname.DataBindings.Clear();
                    txtCSPhone.DataBindings.Clear();
                    txtCSEmail.DataBindings.Clear();
                    txtProdName.DataBindings.Clear();
                    cmbProdType.Enabled = true;
                    cmbProdModel.Enabled = true;
                    txtProdName.Enabled = true;
                    numQuantity.Enabled = false;
                    #endregion

                    #region Bind
                    lblCSId.DataBindings.Add("Text", data, "Identity");
                    txtCSName.DataBindings.Add("Text", data, "Name");
                    txtCSSurname.DataBindings.Add("Text", data, "Surname");
                    txtCSPhone.DataBindings.Add("Text", data, "ContactNumber");
                    txtCSEmail.DataBindings.Add("Text", data, "EmailAddress");
                    #endregion
                }

                else
                {
                    MessageBox.Show("There were 0 search results found.");
                }
            }
            catch (KeyNotFoundException knf)
            {
                MessageBox.Show("There were 0 search results found.");

            }

        }
        private void cmbProdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProdModel.Text = "";
            txtProdName.Text = "";
            cmbProdModel.DataBindings.Clear();
            txtProdName.DataBindings.Clear();
        }

        private void cmbProdModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProdName.Text = "";
            cmbProdType.DataBindings.Clear();
            txtProdName.DataBindings.Clear();
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
        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnInsert_Click(object sender, EventArgs e)
        {

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





        private void cmbProdType_TextChanged(object sender, EventArgs e)
        {

        }




        #endregion


    }
}
