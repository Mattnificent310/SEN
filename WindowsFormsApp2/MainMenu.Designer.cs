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
            this.SuspendLayout();
            // 
            // btnClientDept
            // 
            this.btnClientDept.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClientDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientDept.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientDept.Location = new System.Drawing.Point(264, 74);
            this.btnClientDept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClientDept.Name = "btnClientDept";
            this.btnClientDept.Size = new System.Drawing.Size(258, 31);
            this.btnClientDept.TabIndex = 0;
            this.btnClientDept.Text = "Customer Service";
            this.btnClientDept.UseVisualStyleBackColor = false;
            this.btnClientDept.Click += new System.EventHandler(this.btnClientDept_Click);
            // 
            // btnProdDept
            // 
            this.btnProdDept.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnProdDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdDept.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdDept.Location = new System.Drawing.Point(264, 134);
            this.btnProdDept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnProdDept.Name = "btnProdDept";
            this.btnProdDept.Size = new System.Drawing.Size(258, 31);
            this.btnProdDept.TabIndex = 1;
            this.btnProdDept.Text = "Product Department";
            this.btnProdDept.UseVisualStyleBackColor = false;
            this.btnProdDept.Click += new System.EventHandler(this.btnProdDept_Click);
            // 
            // btnTechSupport
            // 
            this.btnTechSupport.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnTechSupport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTechSupport.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTechSupport.Location = new System.Drawing.Point(264, 196);
            this.btnTechSupport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTechSupport.Name = "btnTechSupport";
            this.btnTechSupport.Size = new System.Drawing.Size(258, 31);
            this.btnTechSupport.TabIndex = 2;
            this.btnTechSupport.Text = "Technical Support";
            this.btnTechSupport.UseVisualStyleBackColor = false;
            this.btnTechSupport.Click += new System.EventHandler(this.btnTechSupport_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(264, 257);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Employee Service";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._50_Beautiful_and_Minimalist_Presentation_Backgrounds_081;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(794, 377);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTechSupport);
            this.Controls.Add(this.btnProdDept);
            this.Controls.Add(this.btnClientDept);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClientDept;
        private System.Windows.Forms.Button btnProdDept;
        private System.Windows.Forms.Button btnTechSupport;
        private System.Windows.Forms.Button button1;
    }
}