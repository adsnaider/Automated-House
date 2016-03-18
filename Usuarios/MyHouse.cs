using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Usuarios
{
    public partial class MyHouse : Form
    {
        public MyHouse()
        {
            InitializeComponent();
        }
        bool home = false;
        private void lblBedroom_Click(object sender, EventArgs e)
        {
            if (Var.UserRoom == 6) {
                home = true;
                this.Close();
                Var.room = "Bedroom";
                Var.Id_room = 4;
                Var.aparato = "Cooler";
                Cuarto cuarto = new Cuarto();
                cuarto.Show();
            }
            else if (Var.UserRoom == 4)
            {
                home = true;
                this.Close();
                Var.room = "Bedroom";
                Var.Id_room = 4;
                Var.aparato = "Cooler";
                Cuarto cuarto = new Cuarto();
                cuarto.Show();
            }
            else MessageBox.Show("You can't manage that room");
        }

        private void lblBathroom_Click(object sender, EventArgs e)
        {
            if (Var.UserRoom == 6)
            {
                home = true;
                this.Close();
                Var.room = "Bathroom";
                Var.Id_room = 3;
                Var.aparato = null;
                Cuarto cuarto = new Cuarto();
                cuarto.Show();
            }
            else if (Var.UserRoom == 3)
            {
                home = true;
                this.Close();
                Var.room = "Bathroom";
                Var.Id_room = 3;
                Var.aparato = null;
                Cuarto cuarto = new Cuarto();
                cuarto.Show();
            }
            else MessageBox.Show("You can't manage that room");
        }

        private void lblHall_Click(object sender, EventArgs e)
        {
            if (Var.UserRoom == 6)
            {
                home = true;
                this.Close();
                Var.room = "Hall";
                Var.Id_room = 2;
                Var.aparato = null;
                Cuarto cuarto = new Cuarto();
                cuarto.Show();
            }
            else if (Var.UserRoom == 2)
            {
                home = true;
                this.Close();
                Var.room = "Hall";
                Var.Id_room = 2;
                Var.aparato = null;
                Cuarto cuarto = new Cuarto();
                cuarto.Show();
            }
            else MessageBox.Show("You can't manage that room");
        }

        private void lblKitchen_Click(object sender, EventArgs e)
        {
            if (Var.UserRoom == 6)
            {
                home = true;
                this.Close();
                Var.room = "Kitchen";
                Var.Id_room = 1;
                Var.aparato = "Alarm";
                Cuarto cuarto = new Cuarto();
                cuarto.Show();
            }
            else if (Var.UserRoom == 1)
            {
                home = true;
                this.Close();
                Var.room = "Kitchen";
                Var.Id_room = 1;
                Var.aparato = "Alarm";
                Cuarto cuarto = new Cuarto();
                cuarto.Show();
            }
            else MessageBox.Show("You can't manage that room");
        }

        private void lblLiving_Click(object sender, EventArgs e)
        {
            if (Var.UserRoom == 6)
            {
                home = true;
                this.Close();
                Var.room = "Living";
                Var.Id_room = 5;
                Var.aparato = "Lock";
                Cuarto cuarto = new Cuarto();
                cuarto.Show();
            }
            else if (Var.UserRoom == 5)
            {
                home = true;
                this.Close();
                Var.room = "Living";
                Var.Id_room = 5;
                Var.aparato = "Lock";
                Cuarto cuarto = new Cuarto();
                cuarto.Show();
            }
            else MessageBox.Show("You can't manage that room");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            home = true;
            this.Close();
            Inicio inicio = new Inicio();
            inicio.Show();
        }

        private void MyHouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!home)
                Application.Exit();
        }
    }
}
