using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using PortControl;

namespace Usuarios
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void lblUser_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (Var.user == null)
            {
                Login login;
                login = new Login();
                login.Show();
            }
            else
            {
                Usuarios usuario = new Usuarios();
                usuario.Show();
            }
        }

        private void lblHouse_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (Var.user != null)
            {
                MyHouse mi_casa = new MyHouse();
                mi_casa.Show();
            }
            else
            {
                LoginHouse login = new LoginHouse();
                login.Show();
            }
        }
    }
}
