namespace VideoGallery.WinApp.Documents.CustomerManager
{
    partial class FrmAddEditCustomer
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
            this.gbCoustomer = new Telerik.WinControls.UI.RadGroupBox();
            this.ddlGender = new Telerik.WinControls.UI.RadDropDownList();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.numDeposite = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gbCoustomer)).BeginInit();
            this.gbCoustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeposite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCoustomer
            // 
            this.gbCoustomer.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbCoustomer.BackColor = System.Drawing.Color.AliceBlue;
            this.gbCoustomer.Controls.Add(this.ddlGender);
            this.gbCoustomer.Controls.Add(this.label1);
            this.gbCoustomer.Controls.Add(this.btnSave);
            this.gbCoustomer.Controls.Add(this.txtName);
            this.gbCoustomer.Controls.Add(this.numDeposite);
            this.gbCoustomer.Controls.Add(this.label2);
            this.gbCoustomer.Controls.Add(this.txtAddress);
            this.gbCoustomer.Controls.Add(this.label6);
            this.gbCoustomer.Controls.Add(this.label3);
            this.gbCoustomer.Controls.Add(this.txtEmail);
            this.gbCoustomer.Controls.Add(this.label11);
            this.gbCoustomer.Controls.Add(this.label4);
            this.gbCoustomer.Controls.Add(this.txtMobile);
            this.gbCoustomer.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCoustomer.HeaderText = "Customer Information";
            this.gbCoustomer.Location = new System.Drawing.Point(33, 38);
            this.gbCoustomer.Name = "gbCoustomer";
            this.gbCoustomer.Size = new System.Drawing.Size(357, 427);
            this.gbCoustomer.TabIndex = 13;
            this.gbCoustomer.Text = "Customer Information";
            // 
            // ddlGender
            // 
            this.ddlGender.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlGender.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlGender.Location = new System.Drawing.Point(149, 241);
            this.ddlGender.Name = "ddlGender";
            this.ddlGender.Size = new System.Drawing.Size(169, 25);
            this.ddlGender.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(130, 367);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(149, 46);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(169, 27);
            this.txtName.TabIndex = 1;
            // 
            // numDeposite
            // 
            this.numDeposite.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDeposite.Location = new System.Drawing.Point(149, 287);
            this.numDeposite.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numDeposite.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numDeposite.Name = "numDeposite";
            this.numDeposite.Size = new System.Drawing.Size(169, 27);
            this.numDeposite.TabIndex = 10;
            this.numDeposite.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address : ";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(149, 95);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(169, 27);
            this.txtAddress.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "Deposite : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email : ";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(149, 143);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(169, 27);
            this.txtEmail.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 241);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 23);
            this.label11.TabIndex = 2;
            this.label11.Text = "Gender : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mobile Number : ";
            // 
            // txtMobile
            // 
            this.txtMobile.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile.Location = new System.Drawing.Point(149, 193);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(169, 27);
            this.txtMobile.TabIndex = 3;
            // 
            // FrmAddEditCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.BackgroundImage = global::VideoGallery.WinApp.Properties.Resources.AllBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(425, 497);
            this.Controls.Add(this.gbCoustomer);
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmAddEditCustomer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Add/Edit Customer";
            this.Load += new System.EventHandler(this.FrmAddEditCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbCoustomer)).EndInit();
            this.gbCoustomer.ResumeLayout(false);
            this.gbCoustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeposite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox gbCoustomer;
        private Telerik.WinControls.UI.RadDropDownList ddlGender;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton btnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown numDeposite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMobile;
    }
}