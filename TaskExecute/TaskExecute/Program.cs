using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortControl;
using System.IO;

namespace TaskExecute
{
    class Program
    {

        static void Main(string[] args)
        {
            if (Convert.ToInt32(args[0]) == -1)
            {
                string soundsRoot = @"I:\ORT_Pendrive\Proyecto\TaskExecute\TaskExecute\bin\Debug\music";
                Random rand = new Random();
                var soundFiles = Directory.GetFiles(soundsRoot, "*.wav");
                var playSound = soundFiles[rand.Next(0, soundFiles.Length)];
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(playSound);
                if (args[1] == "T")
                {
                    player.Play();
                }
                else
                {
                    player.Stop();
                }
                Console.Read();
            }
            else
            {
                int output = Convert.ToInt32(Math.Pow(2, Convert.ToInt32(args[0])));
                int total = PortControl.PortControl.Input(888);
                if (args[1] == "T")
                {
                    if (((byte)PortControl.PortControl.Input(888) & (byte)output) == (byte)0)
                        PortControl.PortControl.Output(888, total + output);
                }
                else
                    if (((byte)PortControl.PortControl.Input(888) & (byte)output) == output)
                        PortControl.PortControl.Output(888, total - output);
                Environment.Exit(0);
            }
        }
    }
}
