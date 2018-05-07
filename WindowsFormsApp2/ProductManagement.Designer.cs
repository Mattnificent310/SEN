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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProdPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProdDetails = new System.Windows.Forms.TextBox();
            this.txtProdModel = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dvgProducts = new System.Windows.Forms.DataGridView();
            this.txtProdModels = new System.Windows.Forms.TextBox();
            this.txtProdDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProducts)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-4, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(907, 456);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._50_Beautiful_and_Minimalist_Presentation_Backgrounds_08;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtProdPrice);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtProdDetails);
            this.tabPage2.Controls.Add(this.txtProdModel);
            this.tabPage2.Controls.Add(this.btnInsert);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(899, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manage Products";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(390, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Unit Price";
            // 
            // txtProdPrice
            // 
            this.txtProdPrice.Location = new System.Drawing.Point(390, 221);
            this.txtProdPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdPrice.Name = "txtProdPrice";
            this.txtProdPrice.Size = new System.Drawing.Size(217, 20);
            this.txtProdPrice.TabIndex = 38;
            this.txtProdPrice.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(390, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Product Description";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(390, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Product Model";
            // 
            // txtProdDetails
            // 
            this.txtProdDetails.Location = new System.Drawing.Point(390, 101);
            this.txtProdDetails.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdDetails.Multiline = true;
            this.txtProdDetails.Name = "txtProdDetails";
            this.txtProdDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtProdDetails.Size = new System.Drawing.Size(217, 88);
            this.txtProdDetails.TabIndex = 32;
            // 
            // txtProdModel
            // 
            this.txtProdModel.Location = new System.Drawing.Point(390, 54);
            this.txtProdModel.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdModel.Name = "txtProdModel";
            this.txtProdModel.Size = new System.Drawing.Size(217, 20);
            this.txtProdModel.TabIndex = 30;
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Location = new System.Drawing.Point(408, 336);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(174, 37);
            this.btnInsert.TabIndex = 26;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._50_Beautiful_and_Minimalist_Presentation_Backgrounds_08;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(899, 430);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Orders";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dvgProducts
            // 
            this.dvgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgProducts.Location = new System.Drawing.Point(21, 14);
            this.dvgProducts.Margin = new System.Windows.Forms.Padding(2);
            this.dvgProducts.Name = "dvgProducts";
            this.dvgProducts.RowTemplate.Height = 28;
            this.dvgProducts.Size = new System.Drawing.Size(650, 138);
            this.dvgProducts.TabIndex = 16;
            // 
            // txtProdModels
            // 
            this.txtProdModels.Location = new System.Drawing.Point(110, 229);
            this.txtProdModels.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdModels.Name = "txtProdModels";
            this.txtProdModels.Size = new System.Drawing.Size(217, 20);
            this.txtProdModels.TabIndex = 17;
            // 
            // txtProdDesc
            // 
            this.txtProdDesc.Location = new System.Drawing.Point(110, 277);
            this.txtProdDesc.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdDesc.Multiline = true;
            this.txtProdDesc.Name = "txtProdDesc";
            this.txtProdDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtProdDesc.Size = new System.Drawing.Size(217, 87);
            this.txtProdDesc.TabIndex = 19;
            this.txtProdDesc.TextChanged += new System.EventHandler(this.txtProdDesc_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Product Model";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Product Description";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(700, 14);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(174, 33);
            this.btnUpdate.TabIndex = 26;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(700, 73);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(174, 33);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(406, 229);
            this.txtUnitPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(217, 20);
            this.txtUnitPrice.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Unit Price";
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.Location = new System.Drawing.Point(700, 132);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(174, 33);
            this.btnMainMenu.TabIndex = 30;
            this.btnMainMenu.Text = "MainMenu";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._50_Beautiful_and_Minimalist_Presentation_Backgrounds_08;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.checkBox2);
            this.tabPage1.Controls.Add(this.btnMainMenu);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtUnitPrice);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.btnUpdate);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtProdDesc);
            this.tabPage1.Controls.Add(this.txtProdModels);
            this.tabPage1.Controls.Add(this.dvgProducts);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(899, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(390, 268);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.Text = "Discontinue";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox2.Location = new System.Drawing.Point(406, 277);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(86, 17);
            this.checkBox2.TabIndex = 31;
            this.checkBox2.Text = "Discontinued";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // frmProductManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(897, 433);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmProductManagement";
            this.Text = "Product Management";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProducts)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProdPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProdDetails;
        private System.Windows.Forms.TextBox txtProdModel;
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
        private System.Windows.Forms.DataGridView dvgProducts;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;

    }
}

