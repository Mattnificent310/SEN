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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProdStock = new System.Windows.Forms.TextBox();
            this.cmbProdType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dvgProducts = new System.Windows.Forms.DataGridView();
            this.txtProdId = new System.Windows.Forms.TextBox();
            this.cbxDiscontinue = new System.Windows.Forms.CheckBox();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProdDesc = new System.Windows.Forms.TextBox();
            this.txtProdModels = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPStock = new System.Windows.Forms.TextBox();
            this.cmbPType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPDetails = new System.Windows.Forms.TextBox();
            this.txtPModel = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnEndCall = new System.Windows.Forms.Button();
            this.btnCall = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProducts)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-6, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1360, 702);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._50_Beautiful_and_Minimalist_Presentation_Backgrounds_08;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtProdStock);
            this.tabPage1.Controls.Add(this.cmbProdType);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dvgProducts);
            this.tabPage1.Controls.Add(this.txtProdId);
            this.tabPage1.Controls.Add(this.cbxDiscontinue);
            this.tabPage1.Controls.Add(this.btnMainMenu);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtUnitPrice);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.btnUpdate);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtProdDesc);
            this.tabPage1.Controls.Add(this.txtProdModels);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1352, 669);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(620, 255);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Stock Quantity";
            // 
            // txtProdStock
            // 
            this.txtProdStock.Location = new System.Drawing.Point(616, 282);
            this.txtProdStock.Name = "txtProdStock";
            this.txtProdStock.Size = new System.Drawing.Size(324, 26);
            this.txtProdStock.TabIndex = 36;
            // 
            // cmbProdType
            // 
            this.cmbProdType.FormattingEnabled = true;
            this.cmbProdType.Location = new System.Drawing.Point(172, 280);
            this.cmbProdType.Name = "cmbProdType";
            this.cmbProdType.Size = new System.Drawing.Size(317, 28);
            this.cmbProdType.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 255);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Product Type";
            // 
            // dvgProducts
            // 
            this.dvgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgProducts.Location = new System.Drawing.Point(68, 22);
            this.dvgProducts.Name = "dvgProducts";
            this.dvgProducts.RowTemplate.Height = 28;
            this.dvgProducts.Size = new System.Drawing.Size(975, 212);
            this.dvgProducts.TabIndex = 33;
            // 
            // txtProdId
            // 
            this.txtProdId.Location = new System.Drawing.Point(68, 178);
            this.txtProdId.Name = "txtProdId";
            this.txtProdId.Size = new System.Drawing.Size(10, 26);
            this.txtProdId.TabIndex = 32;
            // 
            // cbxDiscontinue
            // 
            this.cbxDiscontinue.AutoSize = true;
            this.cbxDiscontinue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxDiscontinue.Location = new System.Drawing.Point(609, 434);
            this.cbxDiscontinue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxDiscontinue.Name = "cbxDiscontinue";
            this.cbxDiscontinue.Size = new System.Drawing.Size(124, 24);
            this.cbxDiscontinue.TabIndex = 31;
            this.cbxDiscontinue.Text = "Discontinued";
            this.cbxDiscontinue.UseVisualStyleBackColor = true;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.Location = new System.Drawing.Point(1042, 443);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(261, 51);
            this.btnMainMenu.TabIndex = 30;
            this.btnMainMenu.Text = "MainMenu";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(612, 334);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Unit Price";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(609, 360);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(324, 26);
            this.txtUnitPrice.TabIndex = 28;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(1042, 362);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(261, 51);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(1042, 282);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(261, 51);
            this.btnUpdate.TabIndex = 26;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 408);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Product Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 334);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Product Model";
            // 
            // txtProdDesc
            // 
            this.txtProdDesc.Location = new System.Drawing.Point(165, 434);
            this.txtProdDesc.Multiline = true;
            this.txtProdDesc.Name = "txtProdDesc";
            this.txtProdDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtProdDesc.Size = new System.Drawing.Size(324, 112);
            this.txtProdDesc.TabIndex = 19;
            this.txtProdDesc.TextChanged += new System.EventHandler(this.txtProdDesc_TextChanged);
            // 
            // txtProdModels
            // 
            this.txtProdModels.Location = new System.Drawing.Point(165, 360);
            this.txtProdModels.Name = "txtProdModels";
            this.txtProdModels.Size = new System.Drawing.Size(324, 26);
            this.txtProdModels.TabIndex = 17;
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._50_Beautiful_and_Minimalist_Presentation_Backgrounds_08;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtPStock);
            this.tabPage2.Controls.Add(this.cmbPType);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtPPrice);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtPDetails);
            this.tabPage2.Controls.Add(this.txtPModel);
            this.tabPage2.Controls.Add(this.btnInsert);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1352, 669);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manage Products";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(580, 434);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 20);
            this.label8.TabIndex = 44;
            this.label8.Text = "Stock Quantity";
            // 
            // txtPStock
            // 
            this.txtPStock.Location = new System.Drawing.Point(584, 457);
            this.txtPStock.Name = "txtPStock";
            this.txtPStock.Size = new System.Drawing.Size(324, 26);
            this.txtPStock.TabIndex = 43;
            // 
            // cmbPType
            // 
            this.cmbPType.FormattingEnabled = true;
            this.cmbPType.Location = new System.Drawing.Point(584, 48);
            this.cmbPType.Name = "cmbPType";
            this.cmbPType.Size = new System.Drawing.Size(121, 28);
            this.cmbPType.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(580, 25);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 20);
            this.label10.TabIndex = 41;
            this.label10.Text = "Product Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(584, 354);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "Unit Price";
            // 
            // txtPPrice
            // 
            this.txtPPrice.Location = new System.Drawing.Point(584, 380);
            this.txtPPrice.Name = "txtPPrice";
            this.txtPPrice.Size = new System.Drawing.Size(324, 26);
            this.txtPPrice.TabIndex = 38;
            this.txtPPrice.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(584, 169);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "Product Description";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(584, 97);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 20);
            this.label9.TabIndex = 34;
            this.label9.Text = "Product Model";
            // 
            // txtPDetails
            // 
            this.txtPDetails.Location = new System.Drawing.Point(584, 195);
            this.txtPDetails.Multiline = true;
            this.txtPDetails.Name = "txtPDetails";
            this.txtPDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPDetails.Size = new System.Drawing.Size(324, 133);
            this.txtPDetails.TabIndex = 32;
            // 
            // txtPModel
            // 
            this.txtPModel.Location = new System.Drawing.Point(584, 123);
            this.txtPModel.Name = "txtPModel";
            this.txtPModel.Size = new System.Drawing.Size(324, 26);
            this.txtPModel.TabIndex = 30;
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Location = new System.Drawing.Point(612, 517);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(261, 57);
            this.btnInsert.TabIndex = 26;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._50_Beautiful_and_Minimalist_Presentation_Backgrounds_08;
            this.tabPage3.Controls.Add(this.btnEndCall);
            this.tabPage3.Controls.Add(this.btnCall);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Size = new System.Drawing.Size(1352, 669);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Orders";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnEndCall
            // 
            this.btnEndCall.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.hangup;
            this.btnEndCall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEndCall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEndCall.Location = new System.Drawing.Point(1122, 186);
            this.btnEndCall.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEndCall.Name = "btnEndCall";
            this.btnEndCall.Size = new System.Drawing.Size(135, 138);
            this.btnEndCall.TabIndex = 1;
            this.btnEndCall.UseVisualStyleBackColor = true;
            // 
            // btnCall
            // 
            this.btnCall.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.newcall;
            this.btnCall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCall.Location = new System.Drawing.Point(1122, 35);
            this.btnCall.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(135, 138);
            this.btnCall.TabIndex = 0;
            this.btnCall.UseVisualStyleBackColor = true;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(642, 4);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(0, 20);
            this.lblLogin.TabIndex = 86;
            // 
            // frmProductManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1346, 666);
            this.ControlBox = false;
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmProductManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Product Management";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProducts)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPDetails;
        private System.Windows.Forms.TextBox txtPModel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProdDesc;
        private System.Windows.Forms.TextBox txtProdModels;
        private System.Windows.Forms.CheckBox cbxDiscontinue;
        private System.Windows.Forms.TextBox txtProdId;
        private System.Windows.Forms.DataGridView dvgProducts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProdStock;
        private System.Windows.Forms.ComboBox cmbProdType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPStock;
        private System.Windows.Forms.ComboBox cmbPType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnEndCall;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Label lblLogin;
    }
}

