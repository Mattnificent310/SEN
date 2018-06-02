namespace WindowsFormsApp2
{
    partial class frmProductManagement
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
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numProdStock = new System.Windows.Forms.NumericUpDown();
            this.cmbProdModel = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbProdType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dvgProducts = new System.Windows.Forms.DataGridView();
            this.txtProdId = new System.Windows.Forms.TextBox();
            this.cbxDiscontinue = new System.Windows.Forms.CheckBox();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.lblPDesc = new System.Windows.Forms.Label();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.cmbProductModel = new System.Windows.Forms.ComboBox();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errors = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProdStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProducts)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errors)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(-4, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(993, 591);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._50_Beautiful_and_Minimalist_Presentation_Backgrounds_081;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.numPrice);
            this.tabPage1.Controls.Add(this.numProdStock);
            this.tabPage1.Controls.Add(this.cmbProdModel);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cmbProdType);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dvgProducts);
            this.tabPage1.Controls.Add(this.txtProdId);
            this.tabPage1.Controls.Add(this.cbxDiscontinue);
            this.tabPage1.Controls.Add(this.btnMainMenu);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.btnUpdate);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtProdName);
            this.tabPage1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(985, 555);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(411, 296);
            this.numPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(217, 22);
            this.numPrice.TabIndex = 50;
            this.numPrice.ThousandsSeparator = true;
            this.numPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numProdStock
            // 
            this.numProdStock.Location = new System.Drawing.Point(411, 246);
            this.numProdStock.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numProdStock.Name = "numProdStock";
            this.numProdStock.Size = new System.Drawing.Size(217, 22);
            this.numProdStock.TabIndex = 46;
            // 
            // cmbProdModel
            // 
            this.cmbProdModel.FormattingEnabled = true;
            this.cmbProdModel.Items.AddRange(new object[] {
            "Samsung",
            "LG",
            "Sony",
            "Lenovo"});
            this.cmbProdModel.Location = new System.Drawing.Point(120, 295);
            this.cmbProdModel.Name = "cmbProdModel";
            this.cmbProdModel.Size = new System.Drawing.Size(213, 24);
            this.cmbProdModel.TabIndex = 39;
            this.cmbProdModel.SelectedIndexChanged += new System.EventHandler(this.cmbProdModel_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(767, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 33);
            this.button1.TabIndex = 38;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "Stock Quantity";
            // 
            // cmbProdType
            // 
            this.cmbProdType.FormattingEnabled = true;
            this.cmbProdType.Location = new System.Drawing.Point(120, 243);
            this.cmbProdType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProdType.Name = "cmbProdType";
            this.cmbProdType.Size = new System.Drawing.Size(213, 24);
            this.cmbProdType.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Product Type";
            // 
            // dvgProducts
            // 
            this.dvgProducts.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dvgProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dvgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgProducts.Location = new System.Drawing.Point(22, 14);
            this.dvgProducts.Margin = new System.Windows.Forms.Padding(2);
            this.dvgProducts.Name = "dvgProducts";
            this.dvgProducts.RowTemplate.Height = 28;
            this.dvgProducts.Size = new System.Drawing.Size(711, 191);
            this.dvgProducts.TabIndex = 33;
            // 
            // txtProdId
            // 
            this.txtProdId.Location = new System.Drawing.Point(45, 116);
            this.txtProdId.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdId.Name = "txtProdId";
            this.txtProdId.Size = new System.Drawing.Size(8, 22);
            this.txtProdId.TabIndex = 32;
            // 
            // cbxDiscontinue
            // 
            this.cbxDiscontinue.AutoSize = true;
            this.cbxDiscontinue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxDiscontinue.Location = new System.Drawing.Point(411, 343);
            this.cbxDiscontinue.Name = "cbxDiscontinue";
            this.cbxDiscontinue.Size = new System.Drawing.Size(100, 20);
            this.cbxDiscontinue.TabIndex = 31;
            this.cbxDiscontinue.Text = "Discontinued";
            this.cbxDiscontinue.UseVisualStyleBackColor = true;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.Location = new System.Drawing.Point(767, 14);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(174, 33);
            this.btnMainMenu.TabIndex = 30;
            this.btnMainMenu.Text = "MainMenu";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Unit Price";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(767, 120);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(174, 33);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(767, 68);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(174, 33);
            this.btnUpdate.TabIndex = 26;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Product Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Product Model";
            // 
            // txtProdName
            // 
            this.txtProdName.Location = new System.Drawing.Point(115, 343);
            this.txtProdName.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtProdName.Size = new System.Drawing.Size(213, 22);
            this.txtProdName.TabIndex = 19;
            this.txtProdName.TextChanged += new System.EventHandler(this.txtProdDesc_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._50_Beautiful_and_Minimalist_Presentation_Backgrounds_081;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.numUnitPrice);
            this.tabPage2.Controls.Add(this.lblPDesc);
            this.tabPage2.Controls.Add(this.txtPName);
            this.tabPage2.Controls.Add(this.cmbProductModel);
            this.tabPage2.Controls.Add(this.numStock);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.cmbPType);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.btnInsert);
            this.tabPage2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(985, 555);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "New Products";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // numUnitPrice
            // 
            this.numUnitPrice.DecimalPlaces = 2;
            this.numUnitPrice.Location = new System.Drawing.Point(349, 182);
            this.numUnitPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUnitPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUnitPrice.Name = "numUnitPrice";
            this.numUnitPrice.Size = new System.Drawing.Size(217, 22);
            this.numUnitPrice.TabIndex = 49;
            this.numUnitPrice.ThousandsSeparator = true;
            this.numUnitPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPDesc
            // 
            this.lblPDesc.AutoSize = true;
            this.lblPDesc.Location = new System.Drawing.Point(347, 268);
            this.lblPDesc.Name = "lblPDesc";
            this.lblPDesc.Size = new System.Drawing.Size(91, 16);
            this.lblPDesc.TabIndex = 48;
            this.lblPDesc.Text = "Product Name";
            // 
            // txtPName
            // 
            this.txtPName.Location = new System.Drawing.Point(347, 291);
            this.txtPName.Margin = new System.Windows.Forms.Padding(2);
            this.txtPName.Name = "txtPName";
            this.txtPName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPName.Size = new System.Drawing.Size(217, 22);
            this.txtPName.TabIndex = 47;
            // 
            // cmbProductModel
            // 
            this.cmbProductModel.FormattingEnabled = true;
            this.cmbProductModel.Items.AddRange(new object[] {
            "Samsung",
            "LG",
            "Sony",
            "Lenovo"});
            this.cmbProductModel.Location = new System.Drawing.Point(347, 133);
            this.cmbProductModel.Name = "cmbProductModel";
            this.cmbProductModel.Size = new System.Drawing.Size(217, 24);
            this.cmbProductModel.TabIndex = 46;
            // 
            // numStock
            // 
            this.numStock.Location = new System.Drawing.Point(347, 239);
            this.numStock.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numStock.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(217, 22);
            this.numStock.TabIndex = 45;
            this.numStock.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(347, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 16);
            this.label8.TabIndex = 44;
            this.label8.Text = "Stock Quantity";
            // 
            // cmbPType
            // 
            this.cmbPType.FormattingEnabled = true;
            this.cmbPType.Location = new System.Drawing.Point(347, 79);
            this.cmbPType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPType.Name = "cmbPType";
            this.cmbPType.Size = new System.Drawing.Size(217, 24);
            this.cmbPType.TabIndex = 42;
            this.cmbPType.TextChanged += new System.EventHandler(this.cmbPType_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(347, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 16);
            this.label10.TabIndex = 41;
            this.label10.Text = "Product Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(347, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 39;
            this.label6.Text = "Unit Price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(347, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "Product Model";
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Location = new System.Drawing.Point(647, 362);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(216, 26);
            this.btnInsert.TabIndex = 26;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._50_Beautiful_and_Minimalist_Presentation_Backgrounds_081;
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(985, 555);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Warehouse";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(355, 3);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(184, 15);
            this.lblLogin.TabIndex = 86;
            this.lblLogin.Text = "Welcome: Mr BlahBlah BlahBlah";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(578, 4);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(130, 15);
            this.lblDate.TabIndex = 88;
            this.lblDate.Text = "15 May 2018 08:46 PM";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // errors
            // 
            this.errors.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errors.ContainerControl = this;
            // 
            // frmProductManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(913, 487);
            this.ControlBox = false;
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmProductManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Management";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProdStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProducts)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.CheckBox cbxDiscontinue;
        private System.Windows.Forms.TextBox txtProdId;
        private System.Windows.Forms.DataGridView dvgProducts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbProdType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbPType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errors;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.ComboBox cmbProdModel;
        private System.Windows.Forms.ComboBox cmbProductModel;
        private System.Windows.Forms.Label lblPDesc;
        private System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.NumericUpDown numProdStock;
        private System.Windows.Forms.NumericUpDown numUnitPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
    }
}

