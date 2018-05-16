namespace WindowsFormsApp2
{
    partial class frmTechnicalSupport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnBookTask = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblFinishDate = new System.Windows.Forms.Label();
            this.cmbSuportType = new System.Windows.Forms.ComboBox();
            this.lblSupCost = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblTaskType = new System.Windows.Forms.Label();
            this.txtProdNo = new System.Windows.Forms.TextBox();
            this.lblProdNo = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCustEmail = new System.Windows.Forms.TextBox();
            this.txtCustPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustSurname = new System.Windows.Forms.TextBox();
            this.dgvTech = new System.Windows.Forms.DataGridView();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTech)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(814, 441);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._50_Beautiful_and_Minimalist_Presentation_Backgrounds_08;
            this.tabPage1.Controls.Add(this.btnReset);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.btnBookTask);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.dateTimePicker2);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.lblFinishDate);
            this.tabPage1.Controls.Add(this.cmbSuportType);
            this.tabPage1.Controls.Add(this.lblSupCost);
            this.tabPage1.Controls.Add(this.lblStartDate);
            this.tabPage1.Controls.Add(this.lblTaskType);
            this.tabPage1.Controls.Add(this.txtProdNo);
            this.tabPage1.Controls.Add(this.lblProdNo);
            this.tabPage1.Controls.Add(this.txtCustName);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtCustEmail);
            this.tabPage1.Controls.Add(this.txtCustPhone);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtCustSurname);
            this.tabPage1.Controls.Add(this.dgvTech);
            this.tabPage1.Controls.Add(this.btnMainMenu);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(806, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(639, 179);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(143, 33);
            this.btnReset.TabIndex = 84;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(639, 122);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(143, 33);
            this.btnSearch.TabIndex = 83;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnBookTask
            // 
            this.btnBookTask.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnBookTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookTask.Location = new System.Drawing.Point(639, 65);
            this.btnBookTask.Name = "btnBookTask";
            this.btnBookTask.Size = new System.Drawing.Size(143, 33);
            this.btnBookTask.TabIndex = 82;
            this.btnBookTask.Text = "Book Task";
            this.btnBookTask.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(320, 321);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 81;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(320, 276);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 80;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(320, 227);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 79;
            // 
            // lblFinishDate
            // 
            this.lblFinishDate.AutoSize = true;
            this.lblFinishDate.Location = new System.Drawing.Point(320, 258);
            this.lblFinishDate.Name = "lblFinishDate";
            this.lblFinishDate.Size = new System.Drawing.Size(60, 13);
            this.lblFinishDate.TabIndex = 78;
            this.lblFinishDate.Text = "Finish Date";
            // 
            // cmbSuportType
            // 
            this.cmbSuportType.FormattingEnabled = true;
            this.cmbSuportType.Items.AddRange(new object[] {
            "Product Support",
            "Customer Support"});
            this.cmbSuportType.Location = new System.Drawing.Point(320, 178);
            this.cmbSuportType.Name = "cmbSuportType";
            this.cmbSuportType.Size = new System.Drawing.Size(200, 21);
            this.cmbSuportType.TabIndex = 77;
            this.cmbSuportType.SelectedIndexChanged += new System.EventHandler(this.cmbSuportType_SelectedIndexChanged);
            this.cmbSuportType.TextChanged += new System.EventHandler(this.cmbSuportType_TextChanged);
            // 
            // lblSupCost
            // 
            this.lblSupCost.AutoSize = true;
            this.lblSupCost.Location = new System.Drawing.Point(320, 305);
            this.lblSupCost.Name = "lblSupCost";
            this.lblSupCost.Size = new System.Drawing.Size(68, 13);
            this.lblSupCost.TabIndex = 76;
            this.lblSupCost.Text = "Support Cost";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(320, 211);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(55, 13);
            this.lblStartDate.TabIndex = 75;
            this.lblStartDate.Text = "Start Date";
            // 
            // lblTaskType
            // 
            this.lblTaskType.AutoSize = true;
            this.lblTaskType.Location = new System.Drawing.Point(320, 164);
            this.lblTaskType.Name = "lblTaskType";
            this.lblTaskType.Size = new System.Drawing.Size(71, 13);
            this.lblTaskType.TabIndex = 74;
            this.lblTaskType.Text = "Support Type";
            // 
            // txtProdNo
            // 
            this.txtProdNo.Location = new System.Drawing.Point(14, 363);
            this.txtProdNo.Name = "txtProdNo";
            this.txtProdNo.Size = new System.Drawing.Size(226, 20);
            this.txtProdNo.TabIndex = 73;
            // 
            // lblProdNo
            // 
            this.lblProdNo.AutoSize = true;
            this.lblProdNo.Location = new System.Drawing.Point(11, 347);
            this.lblProdNo.Name = "lblProdNo";
            this.lblProdNo.Size = new System.Drawing.Size(61, 13);
            this.lblProdNo.TabIndex = 72;
            this.lblProdNo.Text = "Product No";
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(14, 179);
            this.txtCustName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(226, 20);
            this.txtCustName.TabIndex = 71;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(11, 305);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 70;
            this.label8.Text = "Customer Email";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(11, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 69;
            this.label10.Text = "Customer Phone";
            // 
            // txtCustEmail
            // 
            this.txtCustEmail.Location = new System.Drawing.Point(14, 320);
            this.txtCustEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustEmail.Name = "txtCustEmail";
            this.txtCustEmail.Size = new System.Drawing.Size(226, 20);
            this.txtCustEmail.TabIndex = 68;
            // 
            // txtCustPhone
            // 
            this.txtCustPhone.Location = new System.Drawing.Point(14, 276);
            this.txtCustPhone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustPhone.Name = "txtCustPhone";
            this.txtCustPhone.Size = new System.Drawing.Size(226, 20);
            this.txtCustPhone.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(11, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "Customer Surname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(11, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Customer Name";
            // 
            // txtCustSurname
            // 
            this.txtCustSurname.Location = new System.Drawing.Point(14, 226);
            this.txtCustSurname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustSurname.Name = "txtCustSurname";
            this.txtCustSurname.Size = new System.Drawing.Size(226, 20);
            this.txtCustSurname.TabIndex = 64;
            // 
            // dgvTech
            // 
            this.dgvTech.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTech.Location = new System.Drawing.Point(8, 8);
            this.dgvTech.Name = "dgvTech";
            this.dgvTech.Size = new System.Drawing.Size(604, 145);
            this.dgvTech.TabIndex = 2;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.Location = new System.Drawing.Point(639, 8);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(143, 33);
            this.btnMainMenu.TabIndex = 1;
            this.btnMainMenu.Text = "MainMenu";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(806, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manage Tasks";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(315, 3);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(159, 13);
            this.lblLogin.TabIndex = 85;
            this.lblLogin.Text = "Welcome: Mr Blahblah BlahBlah";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(505, 3);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(112, 13);
            this.lblDate.TabIndex = 86;
            this.lblDate.Text = "15 May 2018 8:46 PM";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmTechnicalSupport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(812, 440);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmTechnicalSupport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Technical Support";
            this.Load += new System.EventHandler(this.frmTechnicalSupport_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTech)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.DataGridView dgvTech;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCustEmail;
        private System.Windows.Forms.TextBox txtCustPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustSurname;
        private System.Windows.Forms.TextBox txtProdNo;
        private System.Windows.Forms.Label lblProdNo;
        private System.Windows.Forms.ComboBox cmbSuportType;
        private System.Windows.Forms.Label lblSupCost;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblTaskType;
        private System.Windows.Forms.Label lblFinishDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnBookTask;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer timer1;
    }
}