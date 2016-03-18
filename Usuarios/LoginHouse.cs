using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Usuarios
{
    public partial class LoginHouse : Form
    {
        public LoginHouse()
        {
            InitializeComponent();
        }
        OleDbCommand cmd;
        OleDbDataAdapter da;
        OleDbConnection cn;
        DataSet ds;

        bool home = false;

        private void btnHome_Click(object sender, EventArgs e)
        {
            home = true;
            this.Close();
            Inicio inicio = new Inicio();
            inicio.Show();
        }

        private void LoginHouse_Load(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cn.ConnectionString = "Provider='Microsoft.ACE.OLEDB.12.0';Data Source='Usuarios.accdb'";
            cn.Open();
            string sql = "SELECT * from Cuartos";
            cmd = new OleDbCommand(sql, cn);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "DataRoom");
            cmbRoom.DataSource = ds.Tables["DataRoom"];
            cmbRoom.ValueMember = "IdCuarto";
            cmbRoom.DisplayMember = "Cuarto";
            cn.Close();
            cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoginHouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!home)
            {
                Application.Exit();
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.ForeColor == Color.Silver)
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
            if (txtPassword.Text == "")
            {
                txtPassword.ForeColor = Color.Silver;
                txtPassword.PasswordChar = '\0';
                txtPassword.Text = "PASSWORD";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.ForeColor == Color.Silver)
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.PasswordChar = '•';
            }
            if (txtUsername.Text == "")
            {
                txtUsername.ForeColor = Color.Silver;
                txtUsername.Text = "USERNAME";
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.ForeColor == Color.Black && txtUsername.Text != "" && txtPassword.ForeColor == Color.Black && txtPassword.Text != "")
            {
                cn = new OleDbConnection();
                cn.ConnectionString = "Provider='Microsoft.ACE.OLEDB.12.0';Data Source='Usuarios.accdb'";
                cn.Open();
                string sql = "Select * from Usuario where Username = '{0}' and Clave = '{1}'";
                sql = String.Format(sql, txtUsername.Text.ToLower(), txtPassword.Text.ToLower());
                cmd = new OleDbCommand(sql, cn);
                da = new OleDbDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "DatosLog");
                if (ds.Tables["DatosLog"].Rows.Count != 0)
                {
                    Var.user = txtUsername.Text.ToLower();
                    Var.UserRoom = Convert.ToInt32(ds.Tables["DatosLog"].Rows[0].ItemArray[2]);
                    home = true;
                    this.Close();
                    MyHouse house = new MyHouse();
                    house.Show();
                }
                else
                    MessageBox.Show("That's not a valid Username/Password");
                cn.Close();
            }
            else
                MessageBox.Show("Fill in every field", "Error");
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.ForeColor == Color.Black && txtUsername.Text != "" && txtPassword.ForeColor == Color.Black && txtPassword.Text != "" && cmbRoom.SelectedIndex != -1)
            {
                cn = new OleDbConnection();
                cn.ConnectionString = "Provider='Microsoft.ACE.OLEDB.12.0';Data Source='Usuarios.accdb'";
                cn.Open();
                string sql = "Select * from Usuario where Username = '{0}'";
                sql = String.Format(sql, txtUsername.Text.ToLower());
                cmd = new OleDbCommand(sql, cn);
                da = new OleDbDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "DatosUsers");
                if (ds.Tables["DatosUsers"].Rows.Count == 0)
                {
                    sql = "INSERT into Usuario(Username,Clave,Cuarto) values('{0}','{1}','{2}')";
                    sql = String.Format(sql, txtUsername.Text.ToLower(), txtPassword.Text.ToLower(), cmbRoom.SelectedValue.ToString());
                    cmd = new OleDbCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("The account was successfully created");
                }
                else
                    MessageBox.Show("I am sorry that username is taken");
                cn.Close();
            }
            else MessageBox.Show("Fill in every field");
        }
    }
}
