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
        BindingSource data;
        BindingSource dataClient;
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
        }

        private void CustomerService_Load(object sender, EventArgs e)
        {
            timer1.Start();
            blinker = new BackgroundWorker();
            blinker.DoWork += Blinker_DoWork;
            PopulateSales();
            if (!BindData())
            {
                MessageBox.Show("No customers could be found.");
            }
            SimulateCall();
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
                Clear();
                txtClientId.DataBindings.Add("Text", dataClient, "Identity");
                cmbCustTitle.DataBindings.Add("Text", dataClient, "Title");
                txtCustName.DataBindings.Add("Text", dataClient, "Name");
                txtCustSurname.DataBindings.Add("Text", dataClient, "Surname");
                cmbCustGender.DataBindings.Add("Text", dataClient, "Gender");
                txtCustPhone.DataBindings.Add("Text", dataClient, "ContactNumber");
                txtCustEmail.DataBindings.Add("Text", dataClient, "EmailAddress");
                cmbCustCountry.DataBindings.Add("Text", dataClient, "Country");
                cmbCustCity.DataBindings.Add("Text", dataClient, "City");
                txtCustStreet.DataBindings.Add("Text", dataClient, "Street");
                cmbCCountry.DataSource = Business_Logic_Layer.Location.countries.Select(x => x.Country).ToList();
                cmbCustCountry.DataSource = Business_Logic_Layer.Location.countries.Select(x => x.Country).ToList();

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
                dataClient = new BindingSource();
                dataClient.DataSource = Client.clients;
                dgvClient.DataSource = dataClient;
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
                LockProd();
                LockCust();
                numQuantity.Enabled = false;
                radioCol.Enabled = false;
                radioDel.Enabled = false;
                radioCust.Enabled = false;
                radioProd.Enabled = false;
                dtpColDel.Enabled = false;
                cmbPayment.Enabled = false;
                btnOrder.Enabled = false;
                dgvItems.Hide();
                closed = false;
                answered = false;
                missed = false;
                hold = false;
                played = false;
                shown = false;

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
                EndSession();
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                EndSession();
                this.Hide();
                menu.Show();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.btnMain.Text.StartsWith("Log Out"))
            {
                EndSession();
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                EndSession();
                this.Hide();
                menu.Show();
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            if (this.btnMain.Text.StartsWith("Log Out"))
            {
                EndSession();
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                EndSession();
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
        static bool shown = false;
        static int x = 0;
        static List<Client> callers = new List<Client>();
        private delegate void DisplayCountDelegate(int i);
        #endregion

        #region Blink
        private void Blink()
        {
            if (lblCall.Visible == true)
                lblCall.Visible = false;
            else
            {
                lblCall.Visible = true;
            }
            string path = @"..\..\Sounds\WinPhoneIn.wav";
            string path2 = @"..\..\Sounds\WinPhoneOut.wav";

            if (!played && !answered && !closed && !missed)
            {
                PlaySound(path);
                played = true;
            }
            else
            {
                if (!shown)
                {
                    int index = new Random().Next(0, Client.clients.Count() - 1);
                    data = new BindingSource();
                    data.DataSource = Client.clients[index];
                    dgvSales.DataSource = data;
                    ReBindCustomer();
                    dgvSales.Show();
                    shown = true;
                }
                if (!answered && !closed && !missed)
                {
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
                //Random r = new Random();
                Random rn = new Random();
                Random rnd = new Random(1000);
                Thread.Sleep(rn.Next(8000, 30000));
                //r = new Random();


                for (int i = 0; i <= 60 * 60 * 24; i++)
                {
                    if (i == new Random(10000).Next(5, 20))
                    {
                        missed = true;
                        btnCall.Invoke((Action)Disable);
                        i = 60 * 60 * 24;
                    }
                    if (missed)
                    {
                        missed = false;
                        played = false;
                        i = 0;

                        Thread.Sleep(new Random(10000).Next(8000, 30000));
                    }
                    Thread.Sleep(2200); // Set fast to slow.

                    blinker.WorkerSupportsCancellation = true;
                    if (lblCall.InvokeRequired)
                    {
                        lblCall.Invoke((Action)Blink);
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
            lblCall.Hide();
            lblAnswer.Hide();
            btnCall.Enabled = true;
            btnEndCall.Enabled = false;
            if (blinker.IsBusy == false)
            {

                answered = false;
                played = false;
                shown = false;

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
                lblElapsed.Hide();
                //btnHoldCall.Enabled = false;
                //btnDivertCall.Enabled = false;
            }
            if (answered)
            {
                lblElapsed.Show();
                btnCall.Enabled = false;
                lblCall.Hide();
                //btnHoldCall.Enabled = true;
                //btnDivertCall.Enabled = true;
            }


        }
        private void Disable()
        {
            if (missed)
            {
                btnCall.Enabled = false;
                lblCall.Hide();
                shown = false;
                data = new BindingSource();
                dgvSales.DataSource = data;
                ClearAll(this.tabPage3);
                if (blinker.IsBusy)
                {

                    btnCall.Enabled = false;
                    lblCall.Hide();

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

                    lblElapsed.Invoke(new DisplayCountDelegate(DisplayCount), i);
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

            if (lblCall.Visible == false)
            {
                lblAnswer.Show();
            }
            if (/*btnHoldCall.Enabled == false*/true)
            {
                lblElapsed.Text = SecondsToMinutes(x++);
            }
            if (unhold == true)
            {
                lblElapsed.Text = SecondsToMinutes(i);
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
                    radioCust.Enabled = true;
                    radioProd.Enabled = true;
                    radioProd.Checked = true;
                    dgvClient.DataSource = data;
                    //btnHoldCall.Enabled = true;
                    //btnDivertCall.Enabled = true;
                    unhold = true;
                    lblElapsed.Show();
                    lblCall.Hide();
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
            btnEndCall.Enabled = false;
            lblCall.Hide();
            lblAnswer.Hide();
            LockProd();
            vals.Clear();
            dgvItems.Hide();
            //lblHold.Visible = false;
            //btnHoldCall.Enabled = false;
            //btnDivertCall.Enabled = false;
            if (blinker.IsBusy)
            {
                blinker.WorkerSupportsCancellation = true;
                blinker.CancelAsync();
            }
            x = 0;
            Thread.Sleep(15000);
            lblElapsed.Hide();
            //lblEnd.Visible = false;
            ClearAll(this.tabPage3);
            dgvSales.DataSource = null;
            radioCust.Enabled = false;
            radioProd.Enabled = false;
            radioProd.Checked = false;
            radioCust.Checked = false;
            radioProd.Show();
            radioCust.Show();
            radioCol.Checked = false;
            radioDel.Checked = false;
            btnOrder.Enabled = false;
            ordered = false;
            lblGrandTotal.Text = "R 0.00";
            dtpColDel.Value = DateTime.Now;
            SimulateCall();
        }
        #endregion

        #endregion

        #region Sales
        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            lblTotal.Text = string.Format("{0:C}", decimal.Parse(lblUnitPrice.Text) * numQuantity.Value);
            lblStock.Text = string.Format("{0}", int.Parse(lblStock.Text) - int.Parse(numQuantity.Text));
        }
        private void radioCol_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCol.Checked == true)
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
            if (radioDel.Checked == true)
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
                int.Parse(lblProdId.Text.Substring(lblProdId.Text.Count() - 3)),
                1,
                (int)numQuantity.Value,
                decimal.Parse(lblTotal.Text.Substring(1)),
                0.1));

                #region Values
                object[] values =
                {
                lblProdId.Text,
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
                radioCust.Hide();
                radioProd.Hide();
                UnlockProd();
                numQuantity.Value = 1;
                numQuantity.Enabled = false;
                dtpColDel.Enabled = false;
                btnOrder.Enabled = true;

                #endregion

                if (!columns)
                {
                    #region Columns
                    dgvItems.DataSource = null;
                    dgvItems.DataBindings.Clear();
                    dgvItems.Columns.Add("SerialNo", "Serial No");
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

                var inv = new Inventory()[int.Parse(lblProdId.Text.Substring(lblProdId.Text.Length - 3)).ToString()];

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

                    #region Update Stock

                    if ((int.Parse(vals[index].ElementAt(5).ToString()) > int.Parse(values.ElementAt(5).ToString())))
                    {
                        inv.UnitsInStock += (int.Parse(vals[index].ElementAt(5).ToString()) - int.Parse(values.ElementAt(5).ToString()));
                    }
                    else if ((int.Parse(vals[index].ElementAt(5).ToString()) < int.Parse(values.ElementAt(5).ToString())))
                    {
                        inv.UnitsInStock -= (int.Parse(values.ElementAt(5).ToString()) - int.Parse(vals[index].ElementAt(5).ToString()));

                    }
                    CRUD.UpdateInventory(inv);
                    #endregion

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
                    #region Update Stock

                    inv.UnitsInStock -= int.Parse(values.ElementAt(5).ToString());
                    CRUD.UpdateInventory(inv);

                    #endregion
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
            data = new BindingSource();
            try
            {
                if (
                    !string.IsNullOrEmpty(txtCSName.Text.Trim())
                    && !string.IsNullOrEmpty(txtCSSurname.Text.Trim())
                    && !string.IsNullOrEmpty(txtCSPhone.Text.Trim())
                    && !string.IsNullOrEmpty(txtCSEmail.Text.Trim())
                    || radioProd.Checked == true)
                {

                    dgvItems.Hide();
                    new Product();
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
                        data.DataSource = Product.prods.Where(x => x.ProductName.ToLowerInvariant() == txtProdName.Text.Trim().ToLowerInvariant()).ToList();

                    }
                    #endregion

                    #region Find Product Type & Product Model
                    if (!string.IsNullOrEmpty(cmbProdModel.Text.Trim())
                    && !string.IsNullOrEmpty(cmbProdType.Text.Trim())
                    && string.IsNullOrEmpty(txtProdName.Text.Trim()))
                    {
                        data.DataSource = Product.prods.Where(x => x.ProductType == cmbProdType.Text.Trim()
                       && x.ProductModel == cmbProdModel.Text.Trim()).ToList();

                    }
                    #endregion

                    #region Find Product Type, Model & Name
                    if (!string.IsNullOrEmpty(cmbProdType.Text.Trim())
                        && !string.IsNullOrEmpty(txtProdName.Text.Trim())
                        && !string.IsNullOrEmpty(txtProdName.Text.Trim()))
                    {
                        data.DataSource = Product.prods.Where(x => x.ProductType == cmbProdType.Text.Trim()
                           && x.ProductModel == cmbProdModel.Text.Trim()
                           && x.ProductName.ToLowerInvariant() == txtProdName.Text.Trim().ToLowerInvariant()).ToList();

                    }
                    #endregion

                    #region Find Anything
                    if (!string.IsNullOrEmpty(cmbProdType.Text.Trim())
                       || !string.IsNullOrEmpty(txtProdName.Text.Trim())
                       || !string.IsNullOrEmpty(txtProdName.Text.Trim()))
                    {
                        if (data == null)
                            data.DataSource = Product.prods.Where(x => x.ProductType == cmbProdType.Text.Trim()
                               || x.ProductModel == cmbProdModel.Text.Trim()
                               || x.ProductName.ToLowerInvariant() == txtProdName.Text.Trim().ToLowerInvariant()).ToList();
                    }
                    #endregion

                    dgvSales.DataSource = data;

                    cmbPayment.Text = "--Choose Method--";
                    cmbPayment.Enabled = true;

                    if (!ordered)
                    {
                        LockCust();
                        radioCol.Enabled = true;
                        radioDel.Enabled = true;
                        dtpColDel.Enabled = true;
                    }


                    #region Bind
                    if (data.Count != 0)
                    {
                        #region Clear & Bind
                        numQuantity.Enabled = true;
                        ReBindProduct();
                        lblTotal.Text = string.Format("{0:C}", decimal.Parse(lblUnitPrice.Text) * numQuantity.Value);
                        #endregion
                    }

                    #endregion


                }
                else if (radioCust.Checked == true)
                {

                    dgvItems.Hide();

                    #region Find By Name
                    if (!string.IsNullOrEmpty(txtCSName.Text.Trim())
                    && string.IsNullOrEmpty(txtCSSurname.Text.Trim())
                    && string.IsNullOrEmpty(txtCSPhone.Text.Trim())
                    && string.IsNullOrEmpty(txtCSEmail.Text.Trim()))
                    {
                        dataClient.DataSource = data.DataSource = Client.clients.Where(x => x.Name.ToLowerInvariant() == txtCSName.Text.Trim().ToLowerInvariant()).ToList();
                    }
                    #endregion

                    #region Find By Name, Surname
                    if (!string.IsNullOrEmpty(txtCSName.Text.Trim())
                    && !string.IsNullOrEmpty(txtCSSurname.Text.Trim())
                    && string.IsNullOrEmpty(txtCSPhone.Text.Trim())
                    && string.IsNullOrEmpty(txtCSEmail.Text.Trim()))
                    {
                        dataClient.DataSource = data.DataSource = Client.clients.Where(x => x.Name.ToLowerInvariant() == txtCSName.Text.Trim().ToLowerInvariant()
                        && x.Surname.ToLowerInvariant() == txtCSSurname.Text.Trim().ToLowerInvariant()).ToList();
                    }
                    #endregion

                    #region Find By Name, Surname, Phone
                    if (!string.IsNullOrEmpty(txtCSName.Text.Trim())
                    && !string.IsNullOrEmpty(txtCSSurname.Text.Trim())
                    && !string.IsNullOrEmpty(txtCSPhone.Text.Trim())
                    && string.IsNullOrEmpty(txtCSEmail.Text.Trim())
                   )
                    {
                        dataClient.DataSource = data.DataSource = Client.clients.Where(x => x.Name.ToLowerInvariant() == txtCSName.Text.Trim().ToLowerInvariant()
                        && x.Surname.ToLowerInvariant() == txtCSSurname.Text.Trim().ToLowerInvariant()
                        && x.ContactNumber.ToLowerInvariant() == txtCSPhone.Text.Trim().ToLowerInvariant()).ToList();
                    }
                    #endregion

                    #region Find By Name, Surname, Phone, Email
                    if (!string.IsNullOrEmpty(txtCSName.Text.Trim())
                    && !string.IsNullOrEmpty(txtCSSurname.Text.Trim())
                    && !string.IsNullOrEmpty(txtCSPhone.Text.Trim())
                    && !string.IsNullOrEmpty(txtCSEmail.Text.Trim()))
                    {
                        dataClient.DataSource = data.DataSource = Client.clients.Where(x => x.Name.ToLowerInvariant() == txtCSName.Text.Trim().ToLowerInvariant()
                        && x.Surname.ToLowerInvariant() == txtCSSurname.Text.Trim().ToLowerInvariant()
                        && x.ContactNumber.ToLowerInvariant() == txtCSPhone.Text.Trim().ToLowerInvariant()
                        && x.EmailAddress.ToLowerInvariant() == txtCSEmail.Text.Trim().ToLowerInvariant()).ToList();
                    }
                    #endregion

                    #region Find Anything
                    if (!string.IsNullOrEmpty(txtCSName.Text.Trim())
                   || !string.IsNullOrEmpty(txtCSSurname.Text.Trim())
                   || !string.IsNullOrEmpty(txtCSPhone.Text.Trim())
                   || !string.IsNullOrEmpty(txtCSEmail.Text.Trim()))
                    {
                        dataClient.DataSource = data.DataSource = Client.clients.Where(x => x.Name.ToLowerInvariant() == txtCSName.Text.Trim().ToLowerInvariant()
                        || x.Surname.ToLowerInvariant() == txtCSSurname.Text.Trim().ToLowerInvariant()
                        || x.ContactNumber.ToLowerInvariant() == txtCSPhone.Text.Trim().ToLowerInvariant()
                        || x.EmailAddress.ToLowerInvariant() == txtCSEmail.Text.Trim().ToLowerInvariant()).ToList();
                    }
                    #endregion

                    dgvSales.DataSource = data;
                    dgvClient.DataSource = data;

                    #region Clear & Bind
                    if (data.Count != 0)
                    {
                        ReBindCustomer();
                        numQuantity.Enabled = false;
                        radioCust.Checked = false;
                        radioProd.Checked = true;
                    }

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
        private void ClearProd()
        {
            cmbProdType.DataBindings.Clear();
            cmbProdModel.DataBindings.Clear();
            lblUnitPrice.DataBindings.Clear();
            lblProdId.DataBindings.Clear();
            lblStock.DataBindings.Clear();
            txtProdName.DataBindings.Clear();

        }
        private void ReBindProduct()
        {
            ClearProd();
            lblProdId.DataBindings.Add("Text", data, "SerialNo");
            cmbProdType.DataBindings.Add("Text", data, "ProductType");
            cmbProdModel.DataBindings.Add("Text", data, "ProductModel");
            txtProdName.DataBindings.Add("Text", data, "ProductName");
            lblUnitPrice.DataBindings.Add("Text", data, "UnitPrice");
            lblStock.DataBindings.Add("Text", data, "InStock");

        }
        private void ClearCust()
        {
            lblCSId.DataBindings.Clear();
            txtCSName.DataBindings.Clear();
            txtCSSurname.DataBindings.Clear();
            txtCSPhone.DataBindings.Clear();
            txtCSEmail.DataBindings.Clear();
            txtProdName.DataBindings.Clear();

        }
        private void ReBindCustomer()
        {
            ClearCust();
            lblCSId.DataBindings.Add("Text", data, "Identity");
            txtCSName.DataBindings.Add("Text", data, "Name");
            txtCSSurname.DataBindings.Add("Text", data, "Surname");
            txtCSPhone.DataBindings.Add("Text", data, "ContactNumber");
            txtCSEmail.DataBindings.Add("Text", data, "EmailAddress");

        }
        private bool LockCust()
        {
            txtCSName.Enabled = false;
            txtCSSurname.Enabled = false;
            txtCSPhone.Enabled = false;
            txtCSEmail.Enabled = false;
            return true;
        }
        private bool UnlockCust()
        {
            txtCSName.Enabled = true;
            txtCSSurname.Enabled = true;
            txtCSPhone.Enabled = true;
            txtCSEmail.Enabled = true;
            return true;
        }
        private bool LockProd()
        {
            cmbProdType.Enabled = false;
            cmbProdModel.Enabled = false;
            txtProdName.Enabled = false;
            return true;
        }
        private bool UnlockProd()
        {
            cmbProdType.Enabled = true;
            cmbProdModel.Enabled = true;
            txtProdName.Enabled = true;
            return true;
        }
        private void cmbProdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProdModel.Text = "";
            txtProdName.Text = "";
            ClearProd();
        }

        private void cmbProdModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProdName.Text = "";
            ClearProd();
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
                    ContactMethod = cmbCustMethod.Text,
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
        private void txtCSName_TextChanged(object sender, EventArgs e)
        {
            txtCSSurname.Text = string.Empty;
            txtCSPhone.Text = string.Empty;
            txtCSEmail.Text = string.Empty;
            ClearCust();
        }
        private void txtCSSurname_TextChanged(object sender, EventArgs e)
        {
            txtCSPhone.Text = string.Empty;
            txtCSEmail.Text = string.Empty;
            ClearCust();
        }

        private void txtCSPhone_TextChanged(object sender, EventArgs e)
        {
            txtCSEmail.Text = string.Empty;
            ClearCust();
        }
        private void radioCust_CheckedChanged(object sender, EventArgs e)
        {
            LockProd();
            bool locked = radioCust.Checked == true ? UnlockCust() : LockCust();
            btnOrder.Enabled = false;
        }
        private void radioProd_CheckedChanged(object sender, EventArgs e)
        {
            LockCust();
            bool locked = radioProd.Checked == true ? UnlockProd() : LockProd();
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

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void cmbProdType_TextChanged(object sender, EventArgs e)
        {

        }




        #endregion




    }
}
