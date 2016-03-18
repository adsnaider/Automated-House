using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.Diagnostics;
using System.Data.OleDb;
using PortControl;
using System.IO;

namespace Usuarios
{
    public partial class Cuarto : Form
    {

        OleDbConnection cn;
        OleDbCommand cmd;
        OleDbDataAdapter da;
        DataSet ds;

        
        public Cuarto()
        {
            InitializeComponent();
        }
        bool home = false;

        //SpeechSynthesizer Synthesizer = new SpeechSynthesizer();
        SpeechRecognitionEngine sRecognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        SpeechSynthesizer sSynthesizer = new SpeechSynthesizer();
        bool speech=false;
        CheckBox Aparato = new CheckBox();
        PictureBox imagen;

        System.Media.SoundPlayer player;

        private void Cuarto_Load(object sender, EventArgs e)
        {
            if (Var.Id_room == 3) {
                lblHombre.Dispose();
                tmrCheck.Enabled = false;
            }
            //=======================================================================================
            lblNombre.Text = Var.room;
            lblNombre.BackColor = Color.Transparent;

            if (Var.room == "Bedroom")
                this.BackgroundImage = Image.FromFile(@"fondos\habitacion.png");
            else if (Var.room == "Kitchen")
                this.BackgroundImage = Image.FromFile(@"fondos\cocina.png");
            else if (Var.room == "Bathroom")
                this.BackgroundImage = Image.FromFile(@"fondos\baño.png");
            else if (Var.room == "Living")
                this.BackgroundImage = Image.FromFile(@"fondos\living.png");
            else if (Var.room == "Hall")
                this.BackgroundImage = Image.FromFile(@"imagenes\escalera.png");

            //========================================SpeechToText================================================

            sRecognizer.SetInputToDefaultAudioDevice();
            sSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
            Choices things = new Choices(new string[] { "lights", "music", "cooler","alarm" });
            Choices actions = new Choices(new string[] { "on", "off" });
            GrammarBuilder TurnOnOff = new GrammarBuilder("Turn");
            TurnOnOff.Append(actions);
            TurnOnOff.Append("the");
            TurnOnOff.Append(things);
            Grammar servicesGrammar = new Grammar(TurnOnOff);
            sRecognizer.LoadGrammarAsync(servicesGrammar);
            Choices name = new Choices(new string[] { "Lili" });
            Grammar call=new Grammar(name);
            sRecognizer.LoadGrammar(call);
            Choices home = new Choices(new string[] { "go home" });
            sRecognizer.LoadGrammar(new Grammar(home));
            Choices secure= new Choices(new string[] { "lock", "unlock" });
            GrammarBuilder Lock = new GrammarBuilder(secure);
            Lock.Append("the door");
            servicesGrammar = new Grammar(Lock);
            sRecognizer.LoadGrammarAsync(servicesGrammar);
            sRecognizer.RecognizeAsync(RecognizeMode.Multiple);
            sRecognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sRecognizer_SpeechRecognized);
            sRecognizer.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(sRecognizer_SpeechRecognitionRejected);
            sRecognizer.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(sRecognizer_AudioLevelUpdated);
            sRecognizer.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(sRecognizer_RecognizeCompleted);
            //+++++++++++++++++++++++++++++++++++++++++++++++++++
            if (Var.aparato != null)
            {
                Aparato.Name = "chk" + Var.aparato;
                Aparato.Location = new Point(12, 28);
                Aparato.Parent = this;
                Aparato.Visible = true;
                Aparato.Enabled = true;
                Aparato.Text = Var.aparato;
                Aparato.CheckedChanged += new EventHandler(Checkbox_CheckedChanged);
                Aparato.BackColor = Color.Transparent;

                imagen = new PictureBox();
                imagen.BringToFront();
                imagen.AutoSize = false;
                imagen.SizeMode = PictureBoxSizeMode.StretchImage;
                imagen.Size = new Size(90, 80);
                imagen.Name = "lblAparato";
                imagen.Visible = false;
                imagen.Location = new Point(29, 131);
                imagen.Parent = this;
                imagen.Enabled = true;
                imagen.BringToFront();
                imagen.BackColor = Color.Transparent;
            }

            if (Var.Id_room == 5)
            { 
                imagen.Image = Image.FromFile(@"fotos\candado.png");
            }
            else if (Var.Id_room == 1)
            {
                imagen.Image = Image.FromFile(@"Dibujos\alarm.png");
            }
            else if (Var.Id_room == 4)
            {
                imagen.Image = Image.FromFile(@"fotos\ventilador.png");
            }
        }

        void sRecognizer_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            if (e.Result != null&&e.Result.Text != "Lili")
            {
                if (chkbMusic.Checked)
                {
                    player.PlayLooping();
                }
            }
        }

        void sRecognizer_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            if (speech)
            {
                if (sRecognizer.AudioLevel < 10)
                {
                    tmrSpeech.Enabled = true;
                }
                else
                {
                    tmrSpeech.Stop();//reset
                    tmrSpeech.Enabled = false;
                    tmrSpeech.Start();
                }
            }
        }

        void sRecognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            speech = false;
        }

        void sRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (speech)
            {
                if (e.Result.Text == "Turn on the lights")
                {
                    chkbLights.Checked = true;
                    tmrSpeech_Tick(tmrSpeech,new EventArgs());
                }
                else if (e.Result.Text == "Turn off the lights")
                {
                    chkbLights.Checked = false;
                    tmrSpeech_Tick(tmrSpeech,new EventArgs());
                }
                else if (e.Result.Text == "Turn on the music")
                {
                    chkbMusic.Checked = true;
                    tmrSpeech_Tick(tmrSpeech,new EventArgs());
                }
                else if (e.Result.Text == "Turn off the music")
                {
                    chkbMusic.Checked = false;
                    tmrSpeech_Tick(tmrSpeech,new EventArgs());
                }

                else if (Var.aparato == "Lock")
                {
                    if (e.Result.Text == "lock the door")
                    {
                        Aparato.Checked = true;
                        tmrSpeech_Tick(tmrSpeech,new EventArgs());
                    }
                    else if (e.Result.Text == "unlock the door")
                    {
                        Aparato.Checked = false;
                        tmrSpeech_Tick(tmrSpeech,new EventArgs());
                    }
                }

                else if (Var.aparato == "Alarm")
                {
                    if (e.Result.Text == "Turn on the alarm")
                    {
                        Aparato.Checked = true;
                        tmrSpeech_Tick(tmrSpeech,new EventArgs());
                    }
                    else if (e.Result.Text == "Turn off the alarm")
                    {
                        Aparato.Checked = false;
                        tmrSpeech_Tick(tmrSpeech,new EventArgs());
                    }
                }
                else if (Var.aparato == "Cooler")
                {
                    if (e.Result.Text == "Turn on the cooler")
                    {
                        Aparato.Checked = true;
                        tmrSpeech_Tick(tmrSpeech,new EventArgs());
                    }
                    else if (e.Result.Text == "Turn off the cooler")
                    {
                        Aparato.Checked = false;
                        tmrSpeech_Tick(tmrSpeech, new EventArgs());
                    }
                }
                else if (e.Result.Text == "go home") {
                    btnHome.PerformClick();
                }
            }
            else
            {
                if (e.Result.Text == "Lili")
                {
                    if (chkbMusic.Checked)
                    {
                        player.Stop();
                    }
                    sRecognizer.RecognizeAsyncStop();
                    sSynthesizer.Speak("Yes");
                    sRecognizer.RecognizeAsync(RecognizeMode.Multiple);
                    speech = true;
                    
                }
            }
        }   

        private void Cuarto_FormClosing(object sender, FormClosingEventArgs e)
        {
            chkbMusic.Checked = false;
            sRecognizer.Dispose();
            //Synthesizer.Dispose();
            if (!home) {
                Application.Exit();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            home = true;
            this.Close();
            Inicio inicio = new Inicio();
            inicio.Show();
        }

        private void startTask(int posicion, bool turn_on) {

            if (posicion != -1)
            {
                int output = Convert.ToInt32(Math.Pow(2, posicion));
                int total = PortControl.PortControl.Input(888);
                if (turn_on)
                {
                    if (((byte)PortControl.PortControl.Input(888) & (byte)output) == (byte)0)
                        PortControl.PortControl.Output(888, total + output);
                }
                else
                    if (((byte)PortControl.PortControl.Input(888) & (byte)output) == output)
                        PortControl.PortControl.Output(888, total - output);
            }
            else
            {
                string soundsRoot = "music";
                Random rand = new Random();
                var soundFiles = Directory.GetFiles(soundsRoot, "*.wav");
                var playSound = soundFiles[rand.Next(0, soundFiles.Length)];
                player = new System.Media.SoundPlayer(playSound);
                player.PlayLooping();
                if (turn_on)
                {
                    player.PlayLooping();
                }
                else {
                    player.Stop();
                }
            }
        }

        private void Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Var.aparato != null)
            {
                bool turn_on = (((CheckBox)sender).Checked);
                imagen.Visible = turn_on;
                cn = new OleDbConnection();
                cn.ConnectionString = "Provider='Microsoft.ACE.OLEDB.12.0';Data Source='Usuarios.accdb'";
                cn.Open();
                string sql = "SELECT Posicion from acciones where accion ='{0}'";
                sql = String.Format(sql, Var.aparato);
                cmd = new OleDbCommand(sql, cn);
                da = new OleDbDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "DataRutas");
                int posicion = (int)ds.Tables["DataRutas"].Rows[0]["Posicion"];
                startTask(posicion, turn_on);
                cn.Close();
            }
        }

        private void tmrCheck_Tick(object sender, EventArgs e)
        {
            int result = PortControl.PortControl.Input(889);
            string cuarto="";
            int numCuarto;
            if (Var.Id_room == 5)
            {
                numCuarto = 1;
            }
            else {
                numCuarto = Var.Id_room;
            }
            for (int i = 0; i < 8; i++) {
                if (i == numCuarto)
                {
                    cuarto = "1" + cuarto;
                }
                else {
                    cuarto = "0" + cuarto;
                }
            }
            if (((byte)result & (byte)(Convert.ToInt32(cuarto))) == (byte)(Convert.ToInt32(cuarto)))
            {
                lblHombre.Visible = true;
                startTask(Var.Id_room, true);
            }
            else
            {
                lblHombre.Visible = false;
                if (!chkbLights.Checked) {
                    startTask(Var.Id_room, false);
                }
            }
        }

        private void chkbMusic_CheckedChanged(object sender, EventArgs e)
        {
            lblMusic.Visible = chkbMusic.Checked;
            startTask(-1, chkbMusic.Checked);
        }

        private void chkbLights_CheckedChanged(object sender, EventArgs e)
        {
            bool turn_on = chkbLights.Checked;
            lblBulb.Visible = turn_on;
            startTask(Var.Id_room, turn_on);
        }

        private void tmrSpeech_Tick(object sender, EventArgs e)
        {
            if (speech)
            {
                speech = false;
                if (chkbMusic.Checked)
                {
                    player.PlayLooping();
                }
            }
        }
    }  
}

