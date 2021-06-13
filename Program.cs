using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BashSpirt
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        public static ApplicationContext Context { get; set; }
        [STAThread]
        static void Main()
        {
            //try
            //{
                Application.EnableVisualStyles();// включает визуальные стили
                Application.SetCompatibleTextRenderingDefault(false);
            Context = new ApplicationContext(new Auth());// Context - содержит главную форму приложения, при закрытии которой само приложение тоже закрывается
                Application.Run(Context);// запустить главную форму
            //}
            //catch (Exception )
            //{
            //    MessageBox.Show("Ошибка во время выполнения программы..");
            //}
}
    }
}
