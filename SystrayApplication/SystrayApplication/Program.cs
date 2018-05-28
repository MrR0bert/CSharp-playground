using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystrayApplication.Properties;

namespace SystrayApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SystemTrayApplication());
        }
    }

    public class SystemTrayApplication : ApplicationContext
    {
        private NotifyIcon trayIcon;

        public SystemTrayApplication()
        {
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.if_bluetooth1_23715,
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Show Debug Form", ShowDebugForm),
                    new MenuItem( "-" ),
                    new MenuItem("Exit", Exit)
            }),
                Visible = true
            };
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;
            Application.Exit();
        }

        void ShowDebugForm(object sender, EventArgs e)
        {
            FormDebugInfo frmDebugForm = new FormDebugInfo();
            frmDebugForm.Show();
        }
    }
}