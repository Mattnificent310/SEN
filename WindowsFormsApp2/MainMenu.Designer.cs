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
            this.SuspendLayout();
            // 
            // btnClientDept
            // 
            this.btnClientDept.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClientDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientDept.Location = new System.Drawing.Point(226, 64);
            this.btnClientDept.Name = "btnClientDept";
            this.btnClientDept.Size = new System.Drawing.Size(221, 27);
            this.btnClientDept.TabIndex = 0;
            this.btnClientDept.Text = "Client Department";
            this.btnClientDept.UseVisualStyleBackColor = false;
            this.btnClientDept.Click += new System.EventHandler(this.btnClientDept_Click);
            // 
            // btnProdDept
            // 
            this.btnProdDept.BackColor = System.Drawing.Color.SteelBlue;
            this.btnProdDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdDept.Location = new System.Drawing.Point(226, 141);
            this.btnProdDept.Name = "btnProdDept";
            this.btnProdDept.Size = new System.Drawing.Size(221, 27);
            this.btnProdDept.TabIndex = 1;
            this.btnProdDept.Text = "Product Department";
            this.btnProdDept.UseVisualStyleBackColor = false;
            this.btnProdDept.Click += new System.EventHandler(this.btnProdDept_Click);
            // 
            // btnTechSupport
            // 
            this.btnTechSupport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnTechSupport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTechSupport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTechSupport.Location = new System.Drawing.Point(226, 218);
            this.btnTechSupport.Name = "btnTechSupport";
            this.btnTechSupport.Size = new System.Drawing.Size(221, 27);
            this.btnTechSupport.TabIndex = 2;
            this.btnTechSupport.Text = "Technical Support";
            this.btnTechSupport.UseVisualStyleBackColor = false;
            this.btnTechSupport.Click += new System.EventHandler(this.btnTechSupport_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._50_Beautiful_and_Minimalist_Presentation_Backgrounds_08;
            this.ClientSize = new System.Drawing.Size(681, 327);
            this.Controls.Add(this.btnTechSupport);
            this.Controls.Add(this.btnProdDept);
            this.Controls.Add(this.btnClientDept);
            this.Name = "frmMainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClientDept;
        private System.Windows.Forms.Button btnProdDept;
        private System.Windows.Forms.Button btnTechSupport;
    }
}