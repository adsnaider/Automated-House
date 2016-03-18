namespace Usuarios
{
    partial class MyHouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyHouse));
            this.btnHome = new System.Windows.Forms.Button();
            this.lblBedroom = new System.Windows.Forms.Label();
            this.lblBathroom = new System.Windows.Forms.Label();
            this.lblLiving = new System.Windows.Forms.Label();
            this.lblHall = new System.Windows.Forms.Label();
            this.lblKitchen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(622, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(47, 530);
            this.btnHome.TabIndex = 2;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // lblBedroom
            // 
            this.lblBedroom.BackColor = System.Drawing.Color.Transparent;
            this.lblBedroom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBedroom.Location = new System.Drawing.Point(7, 4);
            this.lblBedroom.Name = "lblBedroom";
            this.lblBedroom.Size = new System.Drawing.Size(255, 260);
            this.lblBedroom.TabIndex = 1;
            this.lblBedroom.Text = "Bedroom";
            this.lblBedroom.Click += new System.EventHandler(this.lblBedroom_Click);
            // 
            // lblBathroom
            // 
            this.lblBathroom.BackColor = System.Drawing.Color.Transparent;
            this.lblBathroom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBathroom.Location = new System.Drawing.Point(268, 5);
            this.lblBathroom.Name = "lblBathroom";
            this.lblBathroom.Size = new System.Drawing.Size(183, 259);
            this.lblBathroom.TabIndex = 1;
            this.lblBathroom.Text = "Bathroom";
            this.lblBathroom.Click += new System.EventHandler(this.lblBathroom_Click);
            // 
            // lblLiving
            // 
            this.lblLiving.BackColor = System.Drawing.Color.Transparent;
            this.lblLiving.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLiving.Location = new System.Drawing.Point(227, 264);
            this.lblLiving.Name = "lblLiving";
            this.lblLiving.Size = new System.Drawing.Size(390, 266);
            this.lblLiving.TabIndex = 1;
            this.lblLiving.Text = "Living";
            this.lblLiving.Click += new System.EventHandler(this.lblLiving_Click);
            // 
            // lblHall
            // 
            this.lblHall.BackColor = System.Drawing.Color.Transparent;
            this.lblHall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHall.Location = new System.Drawing.Point(460, 5);
            this.lblHall.Name = "lblHall";
            this.lblHall.Size = new System.Drawing.Size(160, 262);
            this.lblHall.TabIndex = 1;
            this.lblHall.Text = "Hall";
            this.lblHall.Click += new System.EventHandler(this.lblHall_Click);
            // 
            // lblKitchen
            // 
            this.lblKitchen.BackColor = System.Drawing.Color.Transparent;
            this.lblKitchen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblKitchen.Location = new System.Drawing.Point(6, 264);
            this.lblKitchen.Name = "lblKitchen";
            this.lblKitchen.Size = new System.Drawing.Size(224, 266);
            this.lblKitchen.TabIndex = 1;
            this.lblKitchen.Text = "Kitchen";
            this.lblKitchen.Click += new System.EventHandler(this.lblKitchen_Click);
            // 
            // MyHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(669, 530);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.lblBedroom);
            this.Controls.Add(this.lblBathroom);
            this.Controls.Add(this.lblLiving);
            this.Controls.Add(this.lblHall);
            this.Controls.Add(this.lblKitchen);
            this.Name = "MyHouse";
            this.Text = "MyHouse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyHouse_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblKitchen;
        private System.Windows.Forms.Label lblHall;
        private System.Windows.Forms.Label lblLiving;
        private System.Windows.Forms.Label lblBathroom;
        private System.Windows.Forms.Label lblBedroom;
        private System.Windows.Forms.Button btnHome;

    }
}