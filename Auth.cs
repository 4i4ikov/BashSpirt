using BashSpirt.DataSet1TableAdapters;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BashSpirt
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
            Icon = Properties.Resources.Icon1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{

                DataSet1.ПользователиRow loginRow = (DataSet1.ПользователиRow)new ПользователиTableAdapter().Login(textBox1.Text, textBox2.Text).Rows[0];
                Hide();//// скрыть текущую форму
                Splash.ShowSplashScreen();// показать экран загрузки в отдельном потоке
                Program.Context.MainForm = new Main(loginRow);// смена главной формы
                Close();// закрытие текущей формы
                Program.Context.MainForm.Show();// показать главную форму, долгий процесс, поэтому используется экран загрузки
                Splash.CloseForm();// закрыть экран загрузки после открытия главной формы
            //}
            //catch ( Exception )
            //{
            //    MessageBox.Show("Ошибка при входе.\nПроверьте введенные данные");
            //}

        }
    }
}
