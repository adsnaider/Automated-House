namespace Usuarios
{
    partial class Cuarto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cuarto));
            this.lblNombre = new System.Windows.Forms.Label();
            this.chkbLights = new System.Windows.Forms.CheckBox();
            this.tmrCheck = new System.Windows.Forms.Timer(this.components);
            this.chkbMusic = new System.Windows.Forms.CheckBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.tmrSpeech = new System.Windows.Forms.Timer(this.components);
            this.lblBulb = new System.Windows.Forms.PictureBox();
            this.lblHombre = new System.Windows.Forms.PictureBox();
            this.lblMusic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblBulb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMusic)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(207, 35);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(0, 26);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkbLights
            // 
            this.chkbLights.AutoSize = true;
            this.chkbLights.BackColor = System.Drawing.Color.Transparent;
            this.chkbLights.Location = new System.Drawing.Point(390, 28);
            this.chkbLights.Name = "chkbLights";
            this.chkbLights.Size = new System.Drawing.Size(54, 17);
            this.chkbLights.TabIndex = 3;
            this.chkbLights.Text = "Lights";
            this.chkbLights.UseVisualStyleBackColor = false;
            this.chkbLights.CheckedChanged += new System.EventHandler(this.chkbLights_CheckedChanged);
            // 
            // tmrCheck
            // 
            this.tmrCheck.Enabled = true;
            this.tmrCheck.Tick += new System.EventHandler(this.tmrCheck_Tick);
            // 
            // chkbMusic
            // 
            this.chkbMusic.AutoSize = true;
            this.chkbMusic.BackColor = System.Drawing.Color.Transparent;
            this.chkbMusic.Location = new System.Drawing.Point(320, 28);
            this.chkbMusic.Name = "chkbMusic";
            this.chkbMusic.Size = new System.Drawing.Size(54, 17);
            this.chkbMusic.TabIndex = 7;
            this.chkbMusic.Text = "Music";
            this.chkbMusic.UseVisualStyleBackColor = false;
            this.chkbMusic.CheckedChanged += new System.EventHandler(this.chkbMusic_CheckedChanged);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(441, 382);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(44, 43);
            this.btnHome.TabIndex = 4;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // tmrSpeech
            // 
            this.tmrSpeech.Interval = 7000;
            this.tmrSpeech.Tick += new System.EventHandler(this.tmrSpeech_Tick);
            // 
            // lblBulb
            // 
            this.lblBulb.BackColor = System.Drawing.Color.Transparent;
            this.lblBulb.Image = ((System.Drawing.Image)(resources.GetObject("lblBulb.Image")));
            this.lblBulb.Location = new System.Drawing.Point(187, 64);
            this.lblBulb.Name = "lblBulb";
            this.lblBulb.Size = new System.Drawing.Size(64, 98);
            this.lblBulb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lblBulb.TabIndex = 9;
            this.lblBulb.TabStop = false;
            this.lblBulb.Visible = false;
            // 
            // lblHombre
            // 
            this.lblHombre.BackColor = System.Drawing.Color.Transparent;
            this.lblHombre.Image = ((System.Drawing.Image)(resources.GetObject("lblHombre.Image")));
            this.lblHombre.Location = new System.Drawing.Point(156, 286);
            this.lblHombre.Name = "lblHombre";
            this.lblHombre.Size = new System.Drawing.Size(155, 139);
            this.lblHombre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lblHombre.TabIndex = 10;
            this.lblHombre.TabStop = false;
            this.lblHombre.Visible = false;
            // 
            // lblMusic
            // 
            this.lblMusic.BackColor = System.Drawing.Color.Transparent;
            this.lblMusic.Image = ((System.Drawing.Image)(resources.GetObject("lblMusic.Image")));
            this.lblMusic.Location = new System.Drawing.Point(385, 176);
            this.lblMusic.Name = "lblMusic";
            this.lblMusic.Size = new System.Drawing.Size(69, 53);
            this.lblMusic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lblMusic.TabIndex = 11;
            this.lblMusic.TabStop = false;
            this.lblMusic.Visible = false;
            // 
            // Cuarto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 437);
            this.Controls.Add(this.lblMusic);
            this.Controls.Add(this.lblHombre);
            this.Controls.Add(this.lblBulb);
            this.Controls.Add(this.chkbMusic);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.chkbLights);
            this.Controls.Add(this.lblNombre);
            this.Name = "Cuarto";
            this.Text = "Cuarto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cuarto_FormClosing);
            this.Load += new System.EventHandler(this.Cuarto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblBulb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMusic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.CheckBox chkbLights;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Timer tmrCheck;
        private System.Windows.Forms.CheckBox chkbMusic;
        private System.Windows.Forms.Timer tmrSpeech;
        private System.Windows.Forms.PictureBox lblBulb;
        private System.Windows.Forms.PictureBox lblHombre;
        private System.Windows.Forms.PictureBox lblMusic;
    }
}