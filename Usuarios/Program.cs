using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//using TaskScheduler;
using PortControl;


namespace Usuarios
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PortControl.PortControl.Output(888, 0);
            Application.Run(new Inicio());
        }
    }
}
