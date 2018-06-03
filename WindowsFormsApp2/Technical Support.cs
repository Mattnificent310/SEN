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
            lblAnswer.Hide();

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
        static bool shown = false;
        static int x = 0;
        static System.Media.SoundPlayer player =
                new System.Media.SoundPlayer();
        static List<Client> callers = new List<Client>();
        private delegate void DisplayCountDelegate(int i);
        #endregion

        #region Blink
        private void Blink()
        {
            string path2 = @"..\..\Sounds\Phone_Ringing_8x-Mike_Koenig-696238708.wav";
            string path1 = @"..\..\Phone_Dialing_With_Dialtone-KevanGC-721344923.wav";


            PlaySound(path1);
            Thread.Sleep(2000);
            PlaySound(path2);


        }
        #endregion

        #region Do Work
        private void Blinker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
              string path2 = @"..\..\Sounds\Phone_Ringing_8x-Mike_Koenig-696238708.wav";
                string path1 = @"..\..\Phone_Dialing_With_Dialtone-KevanGC-721344923.wav";


                PlaySound(path1);
                Thread.Sleep(2000);
                PlaySound(path2);
            }
            catch (Exception es)
            {
            }
        }
        #endregion

        #region Play Sound
        private void PlaySound(string path)
        {
            
            player.SoundLocation = path;
            player.Load();
            player.Play();
        }
        #endregion

        #region Simulate
        private void SimulateCall()
        {
            lblAnswer.Show();
            btnCall.Enabled = false;
            btnEndCall.Enabled = true;
             string path1 = @"..\..\Sounds\Phone_Dialing_With_Dialtone-KevanGC-721344923.wav";


            PlaySound(path1);
            


            answered = true;


            


        }
        #endregion

        #region Enable / Disable
        private void Enable()
        {
            if (btnCall.Enabled == false)
            {
                btnCall.Enabled = true;
                btnEndCall.Enabled = true;
                //btnHoldCall.Enabled = false;
                //btnDivertCall.Enabled = false;
            }

            lblElapsed.Show();
            btnCall.Enabled = false;
            //btnHoldCall.Enabled = true;
            //btnDivertCall.Enabled = true;



        }
        private void Disable()
        {
            if (missed)
            {
                btnCall.Enabled = false;
                shown = false;
                data = new BindingSource();
                ClearAll(this.tabPage1);
                if (blinker.IsBusy)
                {
                    btnCall.Enabled = false;
                }

            }
        }
        #endregion

        #region End Session
        private void EndSession()
        {
            
                this.Close();
                this.Dispose();
                closed = true;
            
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


            lblAnswer.Show();
            lblElapsed.Text = SecondsToMinutes(x++);

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
                SimulateCall();
                string path2 = @"..\..\Sounds\Phone_Ringing_8x-Mike_Koenig-696238708.wav";
                Thread.Sleep(4000);
                PlaySound(path2);
                Thread.Sleep(5000);
                player.Stop();
                thread = new Thread(StartCounting);
                    thread.IsBackground = true;
                    thread.Start();
                    btnCall.Enabled = false;
                    btnEndCall.Enabled = true;

                    //btnHoldCall.Enabled = true;
                    //btnDivertCall.Enabled = true;
                    unhold = true;
                    lblElapsed.Show();

                   

                
                    
                
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

        private void tvTechTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //This makes the login panel start in the middle of the form
            //No matter what the size of the screen is, the login panel will stay in the same position and stay the same size
            tvTechTree.Location = new Point(
            this.ClientSize.Width / 2 - tvTechTree.Size.Width / 2,
            this.ClientSize.Height / 2 - tvTechTree.Size.Height / 2);
            tvTechTree.Anchor = AnchorStyles.None;
        }
    }
}
