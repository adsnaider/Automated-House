using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using Microsoft.Win32.TaskScheduler;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.IO;
using PortControl;

namespace Usuarios
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        SpeechRecognitionEngine sRecognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));//new System.Globalization.CultureInfo("en-US")
        SpeechSynthesizer sSynthesizer = new SpeechSynthesizer();
        bool speech = false;
        System.Media.SoundPlayer player=new System.Media.SoundPlayer();
        OleDbConnection cn;
        OleDbCommand cmd;
        OleDbDataAdapter da;
        DataSet ds;
        bool music = false;
        bool inicio = true;
        bool full_house = false;
        bool home = false;

        public void DeleteTask(string name) {
            using (TaskService ts = new TaskService())
            {
                if (ts.GetTask(name) != null)
                {
                    ts.RootFolder.DeleteTask(name);
                }
            }
        }

        public void SaveTask(string name, string time, string day, string route, int posicion, string accion) {
            using (TaskService ts = new TaskService())
            {
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = accion;

                WeeklyTrigger week = new WeeklyTrigger();

                week.StartBoundary = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + time);
                week.WeeksInterval = 1;
                switch (day)
                {
                    case "Monday":
                        week.DaysOfWeek = Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Monday;
                        break;
                    case "Tuesday":
                        week.DaysOfWeek = Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Tuesday;
                        break;
                    case "Wednesday":
                        week.DaysOfWeek = Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Wednesday;
                        break;
                    case "Thursday":
                        week.DaysOfWeek = Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Thursday;
                        break;
                    case "Friday":
                        week.DaysOfWeek = Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Friday;
                        break;
                    case "Saturday":
                        week.DaysOfWeek = Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Saturday;
                        break;
                    case "Sunday":
                        week.DaysOfWeek = Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Sunday;
                        break;
                    default:
                        break;

                }
                td.Triggers.Add(week);
                string turn_on;
                if (chkTurnOn.Checked)
                {
                    turn_on = " T";
                }
                else
                {
                    turn_on = " F";
                }

                if (posicion != -1)
                {
                    td.Actions.Add(new ExecAction(route, posicion.ToString() + turn_on, null));
                }
                else {
                    td.Actions.Add(new ExecAction(route, posicion.ToString() + turn_on, null));
                }
                ts.RootFolder.RegisterTaskDefinition(name, td);
            }
        }
        
        private void Usuarios_Load(object sender, EventArgs e)
        {
            if (Var.UserRoom == 6)
            {
                full_house = true;
                cmbCuartos.Enabled = true;
                cmbCuartos.Visible = true;
            }
            
            //speech recognition
            sRecognizer.SetInputToDefaultAudioDevice();
            sSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
            string[] hours=new string[24];
            string[] minutes = new string[60];
            for (int i = 0; i < 24; i++) {
                hours[i] = i.ToString();
                minutes[i] = i.ToString();
            }
            
            for (int i = 24; i < 60; i++) {
                minutes[i] = i.ToString();
            }
            GrammarBuilder self_destruct = new GrammarBuilder("Self destruct");
            sRecognizer.LoadGrammarAsync(new Grammar(self_destruct));
            Choices hour = new Choices(hours);
            Choices minute = new Choices(minutes);
            Choices day = new Choices(new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
            Choices things = new Choices(new string[] { "Lights", "Music", "Cooler", "Alarm" });
            Choices actions = new Choices(new string[] { "on", "off" });
            Choices SaveDelete = new Choices(new string[] { "Do not turn", "Turn" });
            GrammarBuilder TurnOnOff = new GrammarBuilder();
            TurnOnOff.Append(SaveDelete);
            TurnOnOff.Append(actions);
            TurnOnOff.Append("the");
            TurnOnOff.Append(things);
            TurnOnOff.Append("the day");
            TurnOnOff.Append(day);
            TurnOnOff.Append("at");
            TurnOnOff.Append(hour);
            TurnOnOff.Append(minute);


            if (full_house)
            {
                Choices room = new Choices(new string[] { "Bedroom", "Living", "Kitchen", "Bathroom", "Hall" });
                TurnOnOff.Append("in the");
                TurnOnOff.Append(room);
            }

            Grammar servicesGrammar = new Grammar(TurnOnOff);
            sRecognizer.LoadGrammarAsync(servicesGrammar);
            GrammarBuilder name = new GrammarBuilder("Lili");
            Grammar call = new Grammar(name);
            sRecognizer.LoadGrammarAsync(call);

            GrammarBuilder music = new GrammarBuilder("Turn");
            music.Append(actions);
            music.Append("the music");
            sRecognizer.LoadGrammarAsync(new Grammar(music));

            Choices home = new Choices(new string[] { "go home" });
            sRecognizer.LoadGrammar(new Grammar(home));

            Choices secure = new Choices(new string[] { "Do not Lock", "Do not Unlock", "Lock", "Unlock"});
            GrammarBuilder Lock = new GrammarBuilder(secure);
            Lock.Append("the door");
            Lock.Append("the day");
            Lock.Append(day);
            Lock.Append("at");
            Lock.Append(hour);
            Lock.Append(minute);
            Lock.Append("in the living");

            servicesGrammar = new Grammar(Lock);
            sRecognizer.LoadGrammarAsync(servicesGrammar);
            sRecognizer.RecognizeAsync(RecognizeMode.Multiple);
            sRecognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sRecognizer_SpeechRecognized);
            sRecognizer.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(sRecognizer_SpeechRecognitionRejected);
            sRecognizer.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(sRecognizer_AudioLevelUpdated);
            sRecognizer.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(sRecognizer_RecognizeCompleted);

            cn = new OleDbConnection();
            cn.ConnectionString = "Provider='Microsoft.ACE.OLEDB.12.0';Data Source='Usuarios.accdb'";
            cn.Open();
            cmd = new OleDbCommand("Select Accion from Acciones", cn);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "DatosAcciones");
            cmbAccion.DataSource = ds.Tables["DatosAcciones"];
            cmbAccion.ValueMember = "Accion";
            cmbAccion.DisplayMember = "Accion";
            cmbAccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDia.Items.Add("Monday");
            cmbDia.Items.Add("Tuesday");
            cmbDia.Items.Add("Wednesday");
            cmbDia.Items.Add("Thursday");
            cmbDia.Items.Add("Friday");
            cmbDia.Items.Add("Saturday");
            cmbDia.Items.Add("Sunday");
            cmbDia.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbNewDay.Items.Add("Monday");
            cmbNewDay.Items.Add("Tuesday");
            cmbNewDay.Items.Add("Wednesday");
            cmbNewDay.Items.Add("Thursday");
            cmbNewDay.Items.Add("Friday");
            cmbNewDay.Items.Add("Saturday");
            cmbNewDay.Items.Add("Sunday");
            cmbNewDay.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNewDay.SelectedIndex = 0;

            string sql = "SELECT Calendario.Accion, Calendario.Horario, Calendario.dia, Cuartos.Cuarto,Calendario.TurnOn FROM Calendario INNER JOIN cuartos ON Calendario.Room=Cuartos.IdCuarto where Username='{0}'";
            sql = String.Format(sql,Var.user);
            cmd = new OleDbCommand(sql, cn);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "DataCal");
            dgvAcciones.DataSource = ds.Tables["DataCal"];

            cmbAccion.SelectedIndex = 0;
            cmbDia.SelectedIndex = 0;

            sql = "SELECT * from cuartos where Cuarto<>'Home'";
            cmd = new OleDbCommand(sql, cn);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "DataRooms");
            cmbCuartos.DataSource = ds.Tables["DataRooms"];
            cmbCuartos.ValueMember = "IdCuarto";
            cmbCuartos.DisplayMember = "Cuarto";
            cmbCuartos.DropDownStyle = ComboBoxStyle.DropDownList;
         //   cmbCuartos.SelectedIndex = 0;
            

            if (full_house)
            {
                sql = "SELECT * from acciones where cuarto = {0} or cuarto = 6";
                sql = String.Format(sql, cmbCuartos.SelectedValue.ToString());
                cmd = new OleDbCommand(sql, cn);
                da = new OleDbDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "DataAccion");
            }
            else
            {
                sql = "SELECT Accion, Ruta from acciones where cuarto = {0} or cuarto =6;";
                sql = String.Format(sql, Var.UserRoom);
                cmd = new OleDbCommand(sql, cn);
                da = new OleDbDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "DataAccion");
            }
            cmbAccion.DataSource = ds.Tables["DataAccion"];
            cmbAccion.ValueMember = "Ruta";
            cmbAccion.DisplayMember = "Accion";
            cmbAccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cn.Close();
            inicio = false;
        }

        void sRecognizer_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            if (e.Result!=null && e.Result.Text.ToLower() != "lili")
            {
                if (music)
                {
                    Music(true);
                }
            }
        }

        void sRecognizer_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            lblInput.Text = sRecognizer.AudioLevel.ToString();
            if (speech)
            {
                if (sRecognizer.AudioLevel < 7 && sRecognizer.AudioState!=AudioState.Stopped)
                {
                    tmrSpeech.Enabled = true;
                }
                else
                {
                    tmrSpeech.Stop();//reset
                    tmrSpeech.Start();
                    tmrSpeech.Enabled = false;
                }
            }
        }

        void sRecognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            speech = false;
        }

        private void Music(bool turn_on)
        {
            string soundsRoot = "music";
            Random rand = new Random();
            var soundFiles = Directory.GetFiles(soundsRoot, "*.wav");
            var playSound = soundFiles[rand.Next(0, soundFiles.Length)];
            player = new System.Media.SoundPlayer(playSound);
            if (turn_on)
            {
                player.PlayLooping();
            }
            else
            {
                player.Stop();
            }
        }

        void sRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (speech&&e.Result.Text!="Lili")
            {
                speech = false;
                if (e.Result.Text == "Turn on the music")
                {
                    music = true;
                    Music(true);
                    return;
                }
                else if (e.Result.Text == "Turn off the music")
                {
                    music = false;
                    Music(false);
                    return;
                }
                else if (e.Result.Text == "Self destruct") {
                    MessageBox.Show("Fatal Error", "ERROR");
                    PortControl.PortControl.Output(0, 888);
                    this.Close();
                }
                string[] action = e.Result.Text.Split(' ');
                int delete = 0;
                if (action[0] == "Do") {
                    delete = 2;
                }

                if((action.Length>=12+delete&&full_house)||(action.Length>=9+delete&&!full_house))
                {
                    if (action[0 + delete] != "Lock" && action[0 + delete] != "Unlock")
                    {
                        if (action[3 + delete] == "Lights" || action[3 + delete] == "Music" || (action[3 + delete] == "Cooler" && (Var.UserRoom == 4 || full_house)) || (action[3 + delete] == "Alarm" && (Var.UserRoom == 1 || full_house)))
                        {
                            if ((action.Length == 13 + delete && full_house) || (action.Length == 10 + delete && !full_house))
                            {
                                if (action[1 + delete] == "on")
                                {
                                    chkTurnOn.Checked = true;
                                }
                                else
                                {
                                    chkTurnOn.Checked = false;
                                }
                                if (full_house)
                                {
                                    switch (action[12 + delete])
                                    {
                                        case "Living":
                                            cmbCuartos.SelectedIndex = 0;
                                            break;
                                        case "Kitchen":
                                            cmbCuartos.SelectedIndex = 1;
                                            break;
                                        case "Bedroom":
                                            cmbCuartos.SelectedIndex = 2;
                                            break;
                                        case "Bathroom":
                                            cmbCuartos.SelectedIndex = 3;
                                            break;
                                        case "Hall":
                                            cmbCuartos.SelectedIndex = 4;
                                            break;
                                    }
                                }
                                int i = 0;
                                try
                                {
                                    while (action[3 + delete] != cmbAccion.Text)
                                    {
                                        cmbAccion.SelectedIndex = i;
                                        i++;
                                    }
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    MessageBox.Show("That room does not control that action");
                                    return;
                                }
                                cmbDia.SelectedItem = action[6 + delete];
                                if (action[8 + delete].Length == 1)
                                {
                                    action[8 + delete] = '0' + action[8 + delete];
                                }

                                if (action[9 + delete].Length == 1)
                                {
                                    action[9 + delete] = '0' + action[9 + delete];
                                }
                                txtHora.Focus();
                                txtHora.Text = action[8 + delete];
                                txtMinutos.Focus();
                                txtMinutos.Text = action[9 + delete];
                                if (delete == 0)
                                {
                                    btnGuardar.PerformClick();
                                }
                                else
                                {
                                    btnEliminar.PerformClick();
                                }
                                return;
                            }
                        }
                    }
                    else if (action[0 + delete] == "Lock" && (Var.UserRoom == 5 || full_house))
                    {
                        if ((action.Length == 12 + delete && full_house) || (action.Length == 9 + delete && !full_house))
                        {
                            if (full_house)
                            {
                                cmbCuartos.SelectedIndex = 0;
                            }
                            cmbAccion.SelectedIndex = 1;
                            chkTurnOn.Checked = true;
                            cmbDia.SelectedItem = action[5 + delete];
                            if (action[7 + delete].Length == 1)
                            {
                                action[7 + delete] = "0" + action[7 + delete];
                            }
                            if (action[8 + delete].Length == 1)
                            {
                                action[8 + delete] = "0" + action[8 + delete];
                            }
                            txtHora.Focus();
                            txtHora.Text = action[7 + delete];
                            txtMinutos.Focus();
                            txtMinutos.Text = action[8 + delete];
                            if (delete == 0)
                            {
                                btnGuardar.PerformClick();
                            }
                            else
                            {
                                btnEliminar.PerformClick();
                            }
                            return;
                        }
                    }
                    else if (action[0 + delete] == "Unlock" && (Var.UserRoom == 5 || full_house))
                    {
                        if ((action.Length == 12 + delete && full_house) || (action.Length == 9 + delete && !full_house))
                        {
                            if (full_house)
                            {
                                cmbCuartos.SelectedIndex = 0;
                            }
                            cmbAccion.SelectedIndex = 1;
                            chkTurnOn.Checked = false;
                            cmbDia.SelectedItem = action[5 + delete];
                            if (action[7 + delete].Length == 1)
                            {
                                action[7 + delete] = "0" + action[7 + delete];
                            }
                            if (action[8 + delete].Length == 1)
                            {
                                action[8 + delete] = "0" + action[8 + delete];
                            }
                            txtHora.Focus();
                            txtHora.Text = action[7 + delete];
                            txtMinutos.Focus();
                            txtMinutos.Text = action[8 + delete];

                            if (delete == 0)
                            {
                                btnGuardar.PerformClick();
                            }
                            else
                            {
                                btnEliminar.PerformClick();
                            }
                            return;
                        }
                    }
                    else
                    {
                        sRecognizer.RecognizeAsyncStop();
                        sSynthesizer.Speak("You cannot control that action");
                        sRecognizer.RecognizeAsync(RecognizeMode.Multiple);
                        return;
                    }
                }
                else if (e.Result.Text == "go home")
                {
                    btnHome.PerformClick();
                }
            }
            if (e.Result.Text == "Lili") {
                speech = true;
                Music(false);
                sRecognizer.RecognizeAsyncStop();
                sSynthesizer.Speak("Yes master");
                sRecognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            home = true;
            this.Close();
            Inicio inicio = new Inicio();
            inicio.Show();
        }

        private void txtHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= (char)Keys.D0 && e.KeyChar <= (char)Keys.D9 || e.KeyChar == (char)8 || e.KeyChar == (char)127)
                e.Handled = false;
            else
                e.Handled = true;
            
        }

        private void txtMinutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= (char)Keys.D0 && e.KeyChar <= (char)Keys.D9 || e.KeyChar == (char)8 || e.KeyChar == (char)127)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void Usuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.Dispose();
            sSynthesizer.Dispose();
            sRecognizer.Dispose();
            //sSynthesizer.Dispose();
            if(!home)
                Application.Exit();
        }

        private void txtHora_Enter(object sender, EventArgs e)
        {
            if (txtHora.ForeColor == Color.Silver)
            {
                txtHora.Text = "";
                txtHora.ForeColor = Color.Black;
            }
        }

        private void txtMinutos_Enter(object sender, EventArgs e)
        {
            if (txtMinutos.ForeColor == Color.Silver)
            {
                txtMinutos.Text = "";
                txtMinutos.ForeColor = Color.Black;
            }
        }

        private void txtNewHour_Enter(object sender, EventArgs e)
        {
            if (txtNewHour.ForeColor == Color.Silver)
            {
                txtNewHour.Text = "";
                txtNewHour.ForeColor = Color.Black;
            }
        }

        private void txtNewMinute_Enter(object sender, EventArgs e)
        {
            if (txtNewMinute.ForeColor == Color.Silver)
            {
                txtNewMinute.Text = "";
                txtNewMinute.ForeColor = Color.Black;
            }
        }

        private void txtHora_Leave(object sender, EventArgs e)
        {
            if (txtHora.Text == "") {
                txtHora.ForeColor = Color.Silver;
                txtHora.Text = "HH";        
            }
        }

        private void txtMinutos_Leave(object sender, EventArgs e)
        {
            if (txtMinutos.Text == "")
            {
                txtMinutos.ForeColor = Color.Silver;
                txtMinutos.Text = "MM";
            }
        }

        private void txtNewHour_Leave(object sender, EventArgs e)
        {
            if (txtNewHour.Text == "")
            {
                txtNewHour.ForeColor = Color.Silver;
                txtNewHour.Text = "HH";
            }
        }

        private void txtNewMinute_Leave(object sender, EventArgs e)
        {
            if (txtNewMinute.Text == "")
            {
                txtNewMinute.ForeColor = Color.Silver;
                txtNewMinute.Text = "MM";
            }
        }

        private void cmbCuartos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!inicio)
            {
                string sql;
                sql = "SELECT * from acciones where cuarto = {0} or cuarto = 6";
                sql = String.Format(sql, cmbCuartos.SelectedValue.ToString());
                cmd = new OleDbCommand(sql, cn);
                da = new OleDbDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "DataAccion");
                cmbAccion.DataSource = ds.Tables["DataAccion"];
                cmbAccion.ValueMember = "Ruta";
                cmbAccion.DisplayMember = "Accion";
                cmbAccion.DropDownStyle = ComboBoxStyle.DropDownList;
                cn.Close();
            }
        }

        private void tmrSpeech_Tick(object sender, EventArgs e)
        {
            if (speech)
            {
                speech = false;
                if (music)
                {
                    Music(true);
                }
            }
        }

        private void lblGuardar_Click(object sender, EventArgs e)
        {
            if (txtMinutos.Text != "" && txtHora.Text != "" && txtHora.ForeColor == Color.Black && txtMinutos.ForeColor == Color.Black)
            {
                if (Convert.ToInt32(txtHora.Text) < 24 && Convert.ToInt32(txtHora.Text) >= 0 && Convert.ToInt32(txtMinutos.Text) < 60 && Convert.ToInt16(txtMinutos.Text) >= 0)
                {
                    cn = new OleDbConnection();
                    cn.ConnectionString = "Provider='Microsoft.ACE.OLEDB.12.0';Data Source='Usuarios.accdb'";
                    cn.Open();
                    string x = "Select * from Calendario where Accion='{0}' and Horario='{1}' and Username='{2}' and dia='{3}' and room = {4} and TurnOn={5}";//calendario no se repita.
                    if (full_house)
                    {
                        x = String.Format(x, cmbAccion.Text, txtHora.Text + ':' + txtMinutos.Text + ":00", Var.user, cmbDia.Text, Convert.ToInt32(cmbCuartos.SelectedValue), Convert.ToInt32(chkTurnOn.Checked));
                    }
                    else
                    {
                        x = String.Format(x, cmbAccion.Text, txtHora.Text + ':' + txtMinutos.Text + ":00", Var.user, cmbDia.Text, Var.UserRoom, Convert.ToInt32(chkTurnOn.Checked));
                    }
                    cmd = new OleDbCommand(x, cn);
                    da = new OleDbDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds, "DataCal");
                    if (ds.Tables["DataCal"].Rows.Count == 0)
                    {
                        x = "INSERT into Calendario(Accion,Horario,Username,Dia,Room,TurnOn) values ('{0}','{1}','{2}','{3}',{4},{5})";
                        if (!full_house)
                            x = String.Format(x, cmbAccion.Text, txtHora.Text + ":" + txtMinutos.Text + ":" + "00", Var.user, cmbDia.Text, Var.UserRoom, Convert.ToInt32(chkTurnOn.Checked));
                        else
                            x = String.Format(x, cmbAccion.Text, txtHora.Text + ":" + txtMinutos.Text + ":" + "00", Var.user, cmbDia.Text, Convert.ToInt32(cmbCuartos.SelectedValue), Convert.ToInt32(chkTurnOn.Checked));
                        cmd = new OleDbCommand(x, cn);
                        cmd.ExecuteNonQuery();

                        string sql = "SELECT Calendario.Accion, Calendario.Horario, Calendario.dia, Cuartos.Cuarto,Calendario.TurnOn FROM Calendario INNER JOIN cuartos ON Calendario.Room=Cuartos.IdCuarto where Username='{0}'";
                        sql = String.Format(sql, Var.user);
                        cmd = new OleDbCommand(sql, cn);
                        da = new OleDbDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds, "DataCal");
                        dgvAcciones.DataSource = ds.Tables["DataCal"];
                        sql = "select IdCal from calendario where username='{0}' and accion='{1}' and Horario='{2}' and dia='{3}' and room={4} and TurnOn={5}";
                        if (!full_house)
                            sql = String.Format(sql, Var.user, cmbAccion.Text, txtHora.Text + ':' + txtMinutos.Text + ":00", cmbDia.Text, Var.UserRoom, Convert.ToInt32(chkTurnOn.Checked));
                        else
                            sql = String.Format(sql, Var.user, cmbAccion.Text, txtHora.Text + ':' + txtMinutos.Text + ":00", cmbDia.Text, Convert.ToInt32(cmbCuartos.SelectedValue), Convert.ToInt32(chkTurnOn.Checked));
                        cmd = new OleDbCommand(sql, cn);
                        da = new OleDbDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds, "IdCal");
                        //agregar el task
                        string[] accion_data = cmbAccion.SelectedValue.ToString().Split('#');
                        int posicion;

                        if (cmbAccion.Text != "Lights")
                        {
                            posicion = Convert.ToInt32(accion_data[1]);
                        }
                        else
                        {
                            if (!full_house)
                                posicion = Var.UserRoom;
                            else
                            {
                                posicion = Convert.ToInt32(cmbCuartos.SelectedValue);
                            }
                        }
                        SaveTask(Var.user + ds.Tables["IdCal"].Rows[0].ItemArray[0].ToString(), txtHora.Text + ':' + txtMinutos.Text + ":00", cmbDia.Text, accion_data[0], posicion, cmbAccion.Text);
                        MessageBox.Show("Task saved succesfully");
                    }
                    else
                    {
                        MessageBox.Show("You already have that task created");
                    }
                    cn.Close();
                }
                else
                    MessageBox.Show("Solo Ingrese valores estandar para las horas y minutos(24hs)", "ERROR");
            }
            else MessageBox.Show("Ingrse todos los campos", "ERROR");
        }

        private void lblEliminar_Click(object sender, EventArgs e)
        {

        }

        private void lblModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cn.ConnectionString = "Provider='Microsoft.ACE.OLEDB.12.0';Data Source='Usuarios.accdb'";
            cn.Open();
            string sql = "select IdCal from calendario where username='{0}' and accion='{1}' and Horario='{2}' and dia='{3}' and room ={4} and TurnOn={5}";
            if (!full_house)
                sql = String.Format(sql, Var.user, cmbAccion.Text, txtHora.Text + ':' + txtMinutos.Text + ":00", cmbDia.Text, Var.UserRoom, Convert.ToInt32(chkTurnOn.Checked));
            else
                sql = String.Format(sql, Var.user, cmbAccion.Text, txtHora.Text + ':' + txtMinutos.Text + ":00", cmbDia.Text, Convert.ToInt32(cmbCuartos.SelectedValue), Convert.ToInt32(chkTurnOn.Checked));
            cmd = new OleDbCommand(sql, cn);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "IdCal");
            if (ds.Tables["IdCal"].Rows.Count == 1)
            {
                string name = Var.user + ds.Tables["IdCal"].Rows[0].ItemArray[0].ToString();
                DeleteTask(name);

                string[] accion_data = cmbAccion.SelectedValue.ToString().Split('#');
                int posicion;

                if (cmbAccion.Text != "Lights")
                {
                    posicion = Convert.ToInt32(accion_data[1]);
                }
                else
                {
                    if (!full_house)
                        posicion = Var.UserRoom;
                    else
                    {
                        posicion = Convert.ToInt32(cmbCuartos.SelectedValue);
                    }
                }
                SaveTask(name, txtNewHour.Text + ':' + txtNewMinute.Text + ":00", cmbNewDay.Text, cmbAccion.SelectedValue.ToString(), posicion, cmbAccion.Text);
                sql = "Update Calendario SET horario='{0}',Dia='{1}' where IdCal = {2}";
                sql = String.Format(sql, txtNewHour.Text + ':' + txtNewMinute.Text + ":00", cmbNewDay.Text, ds.Tables["IdCal"].Rows[0].ItemArray[0]);
                cmd = new OleDbCommand(sql, cn);
                cmd.ExecuteNonQuery();
                sql = "SELECT Calendario.Accion, Calendario.Horario, Calendario.dia, Cuartos.Cuarto,Calendario.TurnOn FROM Calendario INNER JOIN cuartos ON Calendario.Room=Cuartos.IdCuarto where Username='{0}'";
                sql = String.Format(sql, Var.user);
                cmd = new OleDbCommand(sql, cn);
                da = new OleDbDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "DataCal");
                dgvAcciones.DataSource = ds.Tables["DataCal"];
                cn.Close();
                MessageBox.Show("Registry updated succesfully");
            }
            else MessageBox.Show("Registry couldn't be found");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cn.ConnectionString = "Provider='Microsoft.ACE.OLEDB.12.0';Data Source='Usuarios.accdb'";
            cn.Open();
            string sql = "select IdCal from calendario where username='{0}' and accion='{1}' and Horario='{2}' and dia='{3}' and room={4} and TurnOn={5}";
            if (!full_house)
                sql = String.Format(sql, Var.user, cmbAccion.Text, txtHora.Text + ':' + txtMinutos.Text + ":00", cmbDia.Text, Var.UserRoom, Convert.ToInt32(chkTurnOn.Checked));
            else
                sql = String.Format(sql, Var.user, cmbAccion.Text, txtHora.Text + ':' + txtMinutos.Text + ":00", cmbDia.Text, Convert.ToInt32(cmbCuartos.SelectedValue), Convert.ToInt32(chkTurnOn.Checked));
            cmd = new OleDbCommand(sql, cn);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "IdCal");
            if (ds.Tables["IdCal"].Rows.Count == 1)
            {
                string name = Var.user + ds.Tables["IdCal"].Rows[0].ItemArray[0].ToString();
                sql = "Delete * from calendario where IdCal={0}";
                sql = String.Format(sql, ds.Tables["IdCal"].Rows[0].ItemArray[0]);
                cmd = new OleDbCommand(sql, cn);
                cmd.ExecuteNonQuery();
                sql = "SELECT Calendario.Accion, Calendario.Horario, Calendario.dia, Cuartos.Cuarto,Calendario.TurnOn FROM Calendario INNER JOIN cuartos ON Calendario.Room=Cuartos.IdCuarto where Username='{0}'";
                sql = String.Format(sql, Var.user);
                cmd = new OleDbCommand(sql, cn);
                da = new OleDbDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "DataCal");
                dgvAcciones.DataSource = ds.Tables["DataCal"];
                cn.Close();
                DeleteTask(name);
                MessageBox.Show("Task deleted succesfully");
            }
            else
                MessageBox.Show("Task couldn't be found");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtMinutos.Text != "" && txtHora.Text != "" && txtHora.ForeColor == Color.Black && txtMinutos.ForeColor == Color.Black)
            {
                if (Convert.ToInt32(txtHora.Text) < 24 && Convert.ToInt32(txtHora.Text) >= 0 && Convert.ToInt32(txtMinutos.Text) < 60 && Convert.ToInt16(txtMinutos.Text) >= 0)
                {
                    cn = new OleDbConnection();
                    cn.ConnectionString = "Provider='Microsoft.ACE.OLEDB.12.0';Data Source='Usuarios.accdb'";
                    cn.Open();
                    string x = "Select * from Calendario where Accion='{0}' and Horario='{1}' and Username='{2}' and dia='{3}' and room = {4} and TurnOn={5}";//calendario no se repita.
                    if (full_house)
                    {
                        x = String.Format(x, cmbAccion.Text, txtHora.Text + ':' + txtMinutos.Text + ":00", Var.user, cmbDia.Text, Convert.ToInt32(cmbCuartos.SelectedValue), Convert.ToInt32(chkTurnOn.Checked));
                    }
                    else
                    {
                        x = String.Format(x, cmbAccion.Text, txtHora.Text + ':' + txtMinutos.Text + ":00", Var.user, cmbDia.Text, Var.UserRoom, Convert.ToInt32(chkTurnOn.Checked));
                    }
                    cmd = new OleDbCommand(x, cn);
                    da = new OleDbDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds, "DataCal");
                    if (ds.Tables["DataCal"].Rows.Count == 0)
                    {
                        x = "INSERT into Calendario(Accion,Horario,Username,Dia,Room,TurnOn) values ('{0}','{1}','{2}','{3}',{4},{5})";
                        if (!full_house)
                            x = String.Format(x, cmbAccion.Text, txtHora.Text + ":" + txtMinutos.Text + ":" + "00", Var.user, cmbDia.Text, Var.UserRoom, Convert.ToInt32(chkTurnOn.Checked));
                        else
                            x = String.Format(x, cmbAccion.Text, txtHora.Text + ":" + txtMinutos.Text + ":" + "00", Var.user, cmbDia.Text, Convert.ToInt32(cmbCuartos.SelectedValue), Convert.ToInt32(chkTurnOn.Checked));
                        cmd = new OleDbCommand(x, cn);
                        cmd.ExecuteNonQuery();

                        string sql = "SELECT Calendario.Accion, Calendario.Horario, Calendario.dia, Cuartos.Cuarto,Calendario.TurnOn FROM Calendario INNER JOIN cuartos ON Calendario.Room=Cuartos.IdCuarto where Username='{0}'";
                        sql = String.Format(sql, Var.user);
                        cmd = new OleDbCommand(sql, cn);
                        da = new OleDbDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds, "DataCal");
                        dgvAcciones.DataSource = ds.Tables["DataCal"];
                        sql = "select IdCal from calendario where username='{0}' and accion='{1}' and Horario='{2}' and dia='{3}' and room={4} and TurnOn={5}";
                        if (!full_house)
                            sql = String.Format(sql, Var.user, cmbAccion.Text, txtHora.Text + ':' + txtMinutos.Text + ":00", cmbDia.Text, Var.UserRoom, Convert.ToInt32(chkTurnOn.Checked));
                        else
                            sql = String.Format(sql, Var.user, cmbAccion.Text, txtHora.Text + ':' + txtMinutos.Text + ":00", cmbDia.Text, Convert.ToInt32(cmbCuartos.SelectedValue), Convert.ToInt32(chkTurnOn.Checked));
                        cmd = new OleDbCommand(sql, cn);
                        da = new OleDbDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds, "IdCal");
                        //agregar el task
                        string[] accion_data = cmbAccion.SelectedValue.ToString().Split('#');
                        int posicion;

                        if (cmbAccion.Text != "Lights")
                        {
                            posicion = Convert.ToInt32(accion_data[1]);
                        }
                        else
                        {
                            if (!full_house)
                                posicion = Var.UserRoom;
                            else
                            {
                                posicion = Convert.ToInt32(cmbCuartos.SelectedValue);
                            }
                        }
                        SaveTask(Var.user + ds.Tables["IdCal"].Rows[0].ItemArray[0].ToString(), txtHora.Text + ':' + txtMinutos.Text + ":00", cmbDia.Text, accion_data[0], posicion, cmbAccion.Text);
                        MessageBox.Show("Task saved succesfully");
                    }
                    else
                    {
                        MessageBox.Show("You already have that task created");
                    }
                    cn.Close();
                }
                else
                    MessageBox.Show("Solo Ingrese valores estandar para las horas y minutos(24hs)", "ERROR");
            }
            else MessageBox.Show("Ingrse todos los campos", "ERROR");
        }
    }
}
