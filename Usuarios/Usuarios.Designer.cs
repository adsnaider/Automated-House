namespace Usuarios
{
    partial class Usuarios
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuarios));
            this.cmbAccion = new System.Windows.Forms.ComboBox();
            this.cmbDia = new System.Windows.Forms.ComboBox();
            this.dgvAcciones = new System.Windows.Forms.DataGridView();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.txtMinutos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNewDay = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewHour = new System.Windows.Forms.TextBox();
            this.txtNewMinute = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCuartos = new System.Windows.Forms.ComboBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.chkTurnOn = new System.Windows.Forms.CheckBox();
            this.tmrSpeech = new System.Windows.Forms.Timer(this.components);
            this.lblInput = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcciones)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAccion
            // 
            this.cmbAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccion.ForeColor = System.Drawing.Color.Black;
            this.cmbAccion.FormattingEnabled = true;
            this.cmbAccion.Location = new System.Drawing.Point(226, 14);
            this.cmbAccion.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAccion.Name = "cmbAccion";
            this.cmbAccion.Size = new System.Drawing.Size(112, 24);
            this.cmbAccion.TabIndex = 4;
            // 
            // cmbDia
            // 
            this.cmbDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDia.ForeColor = System.Drawing.Color.Black;
            this.cmbDia.FormattingEnabled = true;
            this.cmbDia.Location = new System.Drawing.Point(102, 13);
            this.cmbDia.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDia.Name = "cmbDia";
            this.cmbDia.Size = new System.Drawing.Size(112, 24);
            this.cmbDia.TabIndex = 3;
            // 
            // dgvAcciones
            // 
            this.dgvAcciones.AllowUserToAddRows = false;
            this.dgvAcciones.AllowUserToDeleteRows = false;
            this.dgvAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcciones.Location = new System.Drawing.Point(16, 50);
            this.dgvAcciones.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAcciones.Name = "dgvAcciones";
            this.dgvAcciones.ReadOnly = true;
            this.dgvAcciones.Size = new System.Drawing.Size(545, 171);
            this.dgvAcciones.TabIndex = 13;
            // 
            // txtHora
            // 
            this.txtHora.ForeColor = System.Drawing.Color.Silver;
            this.txtHora.Location = new System.Drawing.Point(16, 15);
            this.txtHora.Margin = new System.Windows.Forms.Padding(4);
            this.txtHora.MaxLength = 2;
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(35, 23);
            this.txtHora.TabIndex = 1;
            this.txtHora.Text = "HH";
            this.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHora.Enter += new System.EventHandler(this.txtHora_Enter);
            this.txtHora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHora_KeyPress);
            this.txtHora.Leave += new System.EventHandler(this.txtHora_Leave);
            // 
            // txtMinutos
            // 
            this.txtMinutos.ForeColor = System.Drawing.Color.Silver;
            this.txtMinutos.Location = new System.Drawing.Point(60, 15);
            this.txtMinutos.Margin = new System.Windows.Forms.Padding(4);
            this.txtMinutos.MaxLength = 2;
            this.txtMinutos.Name = "txtMinutos";
            this.txtMinutos.Size = new System.Drawing.Size(35, 23);
            this.txtMinutos.TabIndex = 2;
            this.txtMinutos.Text = "MM";
            this.txtMinutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinutos.Enter += new System.EventHandler(this.txtMinutos_Enter);
            this.txtMinutos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinutos_KeyPress);
            this.txtMinutos.Leave += new System.EventHandler(this.txtMinutos_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(51, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = ":";
            // 
            // cmbNewDay
            // 
            this.cmbNewDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewDay.ForeColor = System.Drawing.Color.Black;
            this.cmbNewDay.FormattingEnabled = true;
            this.cmbNewDay.Location = new System.Drawing.Point(569, 197);
            this.cmbNewDay.Margin = new System.Windows.Forms.Padding(4);
            this.cmbNewDay.Name = "cmbNewDay";
            this.cmbNewDay.Size = new System.Drawing.Size(94, 24);
            this.cmbNewDay.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(600, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = ":";
            // 
            // txtNewHour
            // 
            this.txtNewHour.ForeColor = System.Drawing.Color.Silver;
            this.txtNewHour.Location = new System.Drawing.Point(565, 130);
            this.txtNewHour.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewHour.MaxLength = 2;
            this.txtNewHour.Name = "txtNewHour";
            this.txtNewHour.Size = new System.Drawing.Size(35, 23);
            this.txtNewHour.TabIndex = 10;
            this.txtNewHour.Text = "HH";
            this.txtNewHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewHour.Enter += new System.EventHandler(this.txtNewHour_Enter);
            this.txtNewHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHora_KeyPress);
            this.txtNewHour.Leave += new System.EventHandler(this.txtNewHour_Leave);
            // 
            // txtNewMinute
            // 
            this.txtNewMinute.ForeColor = System.Drawing.Color.Silver;
            this.txtNewMinute.Location = new System.Drawing.Point(611, 130);
            this.txtNewMinute.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewMinute.MaxLength = 2;
            this.txtNewMinute.Name = "txtNewMinute";
            this.txtNewMinute.Size = new System.Drawing.Size(35, 23);
            this.txtNewMinute.TabIndex = 11;
            this.txtNewMinute.Text = "MM";
            this.txtNewMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewMinute.Enter += new System.EventHandler(this.txtNewMinute_Enter);
            this.txtNewMinute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinutos_KeyPress);
            this.txtNewMinute.Leave += new System.EventHandler(this.txtNewMinute_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(578, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "New day";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(568, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "New time";
            // 
            // cmbCuartos
            // 
            this.cmbCuartos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuartos.Enabled = false;
            this.cmbCuartos.FormattingEnabled = true;
            this.cmbCuartos.Location = new System.Drawing.Point(352, 14);
            this.cmbCuartos.Name = "cmbCuartos";
            this.cmbCuartos.Size = new System.Drawing.Size(112, 24);
            this.cmbCuartos.TabIndex = 9;
            this.cmbCuartos.Visible = false;
            this.cmbCuartos.SelectedIndexChanged += new System.EventHandler(this.cmbCuartos_SelectedIndexChanged);
            // 
            // btnHome
            // 
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(594, 19);
            this.btnHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(45, 41);
            this.btnHome.TabIndex = 11;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // chkTurnOn
            // 
            this.chkTurnOn.AutoSize = true;
            this.chkTurnOn.BackColor = System.Drawing.Color.Transparent;
            this.chkTurnOn.Location = new System.Drawing.Point(482, 15);
            this.chkTurnOn.Name = "chkTurnOn";
            this.chkTurnOn.Size = new System.Drawing.Size(79, 21);
            this.chkTurnOn.TabIndex = 5;
            this.chkTurnOn.Text = "ON/OFF";
            this.chkTurnOn.UseVisualStyleBackColor = false;
            // 
            // tmrSpeech
            // 
            this.tmrSpeech.Interval = 8000;
            this.tmrSpeech.Tick += new System.EventHandler(this.tmrSpeech_Tick);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(597, 67);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(0, 17);
            this.lblInput.TabIndex = 14;
            // 
            // btnModificar
            // 
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.Location = new System.Drawing.Point(452, 228);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(109, 53);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(240, 228);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(109, 53);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = true;
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(20, 228);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(112, 56);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(668, 282);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.chkTurnOn);
            this.Controls.Add(this.cmbCuartos);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.txtNewMinute);
            this.Controls.Add(this.txtMinutos);
            this.Controls.Add(this.txtNewHour);
            this.Controls.Add(this.txtHora);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAcciones);
            this.Controls.Add(this.cmbNewDay);
            this.Controls.Add(this.cmbDia);
            this.Controls.Add(this.cmbAccion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Usuarios";
            this.Text = "Usuarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Usuarios_FormClosing);
            this.Load += new System.EventHandler(this.Usuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAccion;
        private System.Windows.Forms.ComboBox cmbDia;
        private System.Windows.Forms.DataGridView dgvAcciones;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.TextBox txtMinutos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.ComboBox cmbNewDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewHour;
        private System.Windows.Forms.TextBox txtNewMinute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCuartos;
        private System.Windows.Forms.CheckBox chkTurnOn;
        private System.Windows.Forms.Timer tmrSpeech;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
    }
}

