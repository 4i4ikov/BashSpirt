using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BashSpirt
{
    public partial class AddOrEdit : Form
    {
        public AddOrEdit(String user, DataSet1.АлкогольRow r = null)
        {
            InitializeComponent();
            this.Пользователь.Text = user;// текущий МОЛ
            //this.corpus.SelectedIndex = ( mode == "Основное здание" ) ? 0 : 1;// выбирает корпус в выпадающем списке
            Icon = Properties.Resources.Icon1;// смена иконки
            this.типы_алкогольных_напитковTableAdapter.Fill(this.dataSet1.Типы_алкогольных_напитков);// заполнить виртуальную таблицу данными из БД
            ////dataSet1 - набор данных, содержащий виртуальные таблицы с данными
            ////TableAdapter - адаптер для работы с таблицами - заполнения, выполнения запросов
            if ( r != null )
            {
                //если ведется редактирование записи, заполнить текущие значения
                Тип.SelectedItem = r.Тип_алкогольного_напитка;
                Тип.SelectedValue = r.Тип_алкогольного_напитка;
                Пользователь.Text = r.Пользователь;
                Наименование.Text = r.Наименование;
                Крепость.Text = r._Крепость___.ToString();
                date.Value = r.Дата_постановки_на_учет;
                Объем.Text = r._Объем_бутылки__л.ToString();
                Количество.Text = r.Количество.ToString();
                Цена.Text = r._Цена_бутылки__руб.ToString() ;
            }
        }

        private void AddOrEdit_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Типы_алкогольных_напитков". При необходимости она может быть перемещена или удалена.
           
        }

        private void AddOrEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK && !verifyUI() )
            {
                MessageBox.Show("Вы не заполнили одно из полей!");
                e.Cancel = true;// Отменить действие закрытия формы
            }
        }
        private bool verifyUI()
        {
            return Controls
              .OfType<MaskedTextBox>()
              .All(cTxt => !string.IsNullOrWhiteSpace(cTxt.Text));// проверка на пустой ввод во всех TextBox при помощи LINQ
        }
    }
}
