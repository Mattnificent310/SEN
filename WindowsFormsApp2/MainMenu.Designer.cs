namespace WindowsFormsApp2
{
    partial class frmMainMenu
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
            this.btnClientDept = new System.Windows.Forms.Button();
            this.btnProdDept = new System.Windows.Forms.Button();
            this.btnTechSupport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnAdminTools = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClientDept
            // 
            this.btnClientDept.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClientDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientDept.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientDept.Location = new System.Drawing.Point(226, 62);
            this.btnClientDept.Name = "btnClientDept";
            this.btnClientDept.Size = new System.Drawing.Size(221, 29);
            this.btnClientDept.TabIndex = 0;
            this.btnClientDept.Text = "Customer Service";
            this.btnClientDept.UseVisualStyleBackColor = false;
            this.btnClientDept.Click += new System.EventHandler(this.btnClientDept_Click);
            // 
            // btnProdDept
            // 
            this.btnProdDept.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnProdDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdDept.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdDept.Location = new System.Drawing.Point(226, 114);
            this.btnProdDept.Name = "btnProdDept";
            this.btnProdDept.Size = new System.Drawing.Size(221, 29);
            this.btnProdDept.TabIndex = 1;
            this.btnProdDept.Text = "Product Department";
            this.btnProdDept.UseVisualStyleBackColor = false;
            this.btnProdDept.Click += new System.EventHandler(this.btnProdDept_Click);
            // 
            // btnTechSupport
            // 
            this.btnTechSupport.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnTechSupport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTechSupport.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTechSupport.Location = new System.Drawing.Point(226, 168);
            this.btnTechSupport.Name = "btnTechSupport";
            this.btnTechSupport.Size = new System.Drawing.Size(221, 29);
            this.btnTechSupport.TabIndex = 2;
            this.btnTechSupport.Text = "Technical Support";
            this.btnTechSupport.UseVisualStyleBackColor = false;
            this.btnTechSupport.Click += new System.EventHandler(this.btnTechSupport_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(226, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Employee Service";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(223, 6);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(71, 16);
            this.lblLogin.TabIndex = 4;
            this.lblLogin.Text = "Welcome: ";
            // 
            // btnAdminTools
            // 
            this.btnAdminTools.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAdminTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminTools.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminTools.Location = new System.Drawing.Point(493, 289);
            this.btnAdminTools.Name = "btnAdminTools";
            this.btnAdminTools.Size = new System.Drawing.Size(179, 29);
            this.btnAdminTools.TabIndex = 5;
            this.btnAdminTools.Text = "Admin Tools";
            this.btnAdminTools.UseVisualStyleBackColor = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLogOut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(9, 289);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(179, 29);
            this.btnLogOut.TabIndex = 6;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // frmMainMenu
            // 
            this.AcceptButton = this.btnAdminTools;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._50_Beautiful_and_Minimalist_Presentation_Backgrounds_081;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnLogOut;
            this.ClientSize = new System.Drawing.Size(681, 327);
            this.ControlBox = false;
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnAdminTools);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTechSupport);
            this.Controls.Add(this.btnProdDept);
            this.Controls.Add(this.btnClientDept);
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClientDept;
        private System.Windows.Forms.Button btnProdDept;
        private System.Windows.Forms.Button btnTechSupport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Button btnAdminTools;
        private System.Windows.Forms.Button btnLogOut;
    }
}