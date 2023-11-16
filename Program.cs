using DevExpress.UserSkins;
using System;
using System.Windows.Forms;

namespace FluentDesignDevExpress
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            string precessName = "FluentForm";
            // 중복실행 방지
            // 이전 프로세스가 존재하면 CreatedNew = false            
            System.Threading.Mutex mtx = new System.Threading.Mutex(true, precessName, out bool createdNew);

            if (createdNew == true)
            {

                BonusSkins.Register();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);


                Application.Run(new Form1());

                mtx.ReleaseMutex();
            }
            else
            {
                //ActivateApp(precessName);
            }

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //BonusSkins.Register();
            //Application.Run(new Form1());
        }
    }
}