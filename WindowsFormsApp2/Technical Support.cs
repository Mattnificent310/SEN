using Business_Logic_Layer;
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

namespace WindowsFormsApp2
{
    public partial class frmTechnicalSupport : Form
    {
        #region Declarations
        private static BindingSource data = new BindingSource();
        private static Client client;
        private static Product prod;
        private static frmMainMenu main = new frmMainMenu();
        private BackgroundWorker worker = new BackgroundWorker();
        static Thread thread;
        private static BackgroundWorker blinker;
        #endregion

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
            if (!staf.Department.Equals("Administrator"))
            {                
                this.btnMainMenu.Text = "Log Out";                
            }
            main.Login(staf);
            lblLogin.Text = string.Format("Welcome:  {0}  {1}  {2}", staf.Title, staf.Name, staf.Surname);

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
            if (this.btnMainMenu.Text.StartsWith("Log Out"))
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                this.Hide();                
                main.Show();
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
                    //Populate();
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
                    data.DataSource = prod[txtProdNo.Text];
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
