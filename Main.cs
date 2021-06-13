using BashSpirt.DataSet1TableAdapters;

using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace BashSpirt
{
    public partial class Main : Form
    {
        public DataSet1.ПользователиRow User { get; }

        public Main(DataSet1.ПользователиRow loginRow)
        {
            User = loginRow;//текущий пользователь

            InitializeComponent();
            Icon = Properties.Resources.Icon1;// Иконка

            this.типы_алкогольных_напитковTableAdapter.Fill(this.dataSet1.Типы_алкогольных_напитков);
            this.алкогольTableAdapter.FillByUser(this.dataSet1.Алкоголь, User.Логин);

            if ( User.Логин == "Admin" ) ПользовательCol.Visible = true;
            button2_Click(null, null);// нажать на кнопку "обновить" для заполнения сводной таблицы
            comboBox1.SelectedIndex = 2;//выбрать "Все" в выпадающем списке с видами движения имущества
            searchToolBar.Show();// отобразить поиск


        }

        private void Main_Load(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            tabControl1.SelectTab(2);
            tabControl1.SelectTab(0);



        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet1.своднаяDataTable ds = new DataSet1().сводная;// создание виртуального набора данных
            new своднаяTableAdapter().Fill(ds);//заполнение таблицы 
            dataGridView8.DataSource = ds;//выбор источника данных для таблицы в виде виртуальной таблицы, которую мы заполнили
            dataGridView8.Columns [ 0 ].Frozen = true;//заморозить первый столбец для удобства просмотра
        }







        private void ExportToExcel_Click(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)tabControl1.SelectedTab.Controls.OfType<DataGridView>().First();//выбор datagridview на текущей вкладке
            String t = tabControl1.SelectedTab.Text;//Текст текущей вкладки
            Enabled = false;//отключить взаимодействие на время экспорта
            ПользовательCol.Visible = списаниеCel.Visible = false;
            //Кнопка экспортировать в эксель
            SaveFileDialog sfd = new SaveFileDialog//диалог выбора места сохранения файла
            {
                Filter = "Excel Documents (*.xlsx)|*.xlsx",//фильтр
                FileName = t + DateTime.Now.ToString(" dd.MM,yyyy")//имя файла
            + ".xlsx"//расширение
            };
            if ( sfd.ShowDialog() == DialogResult.OK )

            {

                Excel.Application excelapp = new Excel.Application//создать новый экземпляр приложения EXCEL для экспорта 
                {
                    SheetsInNewWorkbook = 1//Количество создаваемых листов
                };

                Excel.Workbook workbook = excelapp.Workbooks.Add();//добавить рабочую книгу эксель (файл)
                excelapp.Visible = true;//отобразить Excel
                try
                {
                    Excel.Worksheet wsh = workbook.Sheets[1];//первый лист в книге

                    wsh.Name = t;//имя листа

                    CopyToClipboardWithHeaders(dgv);//скопировать в буфер обмена с header таблицы
                    wsh.Paste();//вставить в лист
                    dgv.ClearSelection();//очистить выделение таблицы
                    Clipboard.Clear();//очистить буфер обмена
                    excelapp.AlertBeforeOverwriting = false;//не предупреждать перед перезаписью
                    workbook.SaveAs(sfd.FileName);//сохранить файл excel
                }
                catch ( Exception )
                {
                    if ( MessageBox.Show("Ошибка при экспорте в эксель, завершить процесс Excel?", "Ошибка при экспорте",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes )
                    {
                        workbook.Close(0);//закрыть без подтверждения
                        excelapp.Quit();//завершить процесс
                    }
                }
            }
            ПользовательCol.Visible = списаниеCel.Visible = true;
            Enabled = true;//включить взаимодействие после экспорта
        }
        public void CopyToClipboardWithHeaders(DataGridView _dgv)
        {
            _dgv.RowHeadersVisible = false;//отключить отображение шапок строк
            _dgv.SelectAll();//выбрать всю таблицу

            //Copy to clipboard
            _dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;//режим копирования
            DataObject dataObj = _dgv.GetClipboardContent();//получить данные для копирования
            if ( dataObj != null )
                Clipboard.SetDataObject(dataObj);//скопировать в буфер обмена
            _dgv.RowHeadersVisible = true;//включить отображение шапок строк

        }

        private void AddImush_Click(object sender, EventArgs e)
        {
            AddOrEdit f = new AddOrEdit(User.Логин){Text="Добавление имущества, Пользователь: "+User.Логин};//создание экземпляра формы AddOrEdit и передача ей МОЛ и корпуса, также смена названия формы на "добавление..."
            if ( f.ShowDialog() == DialogResult.OK )
            {
                string тип = f.Тип.Text;

                // добавление данных в бд
                учетTableAdapter.Insert(тип, f.Пользователь.Text, f.Наименование.Text, short.Parse(f.Крепость.Text), f.date.Value, double.Parse(f.Объем.Text), short.Parse(f.Количество.Text), double.Parse(f.Цена.Text), false);
                // заполнение таблицы из бд
                учетTableAdapter.Fill(dataSet1.Учет);
                алкогольTableAdapter.FillByUser(dataSet1.Алкоголь, User.Логин);
            }
        }

        private void LogOut(object sender, EventArgs e)
        {
            Program.Context.MainForm = new Auth();//смена основной формы на форму входа
            Close();//закрытие текущей формы
            Program.Context.MainForm.Show();//отображение основной формы
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)tabControl1.SelectedTab.Controls.OfType<DataGridView>().First();//выбор datagridview на текущей вкладке

            BindingSource d = (BindingSource)dgv.DataSource;//Источник данных таблицы
            DataSet1.АлкогольRow r = (DataSet1.АлкогольRow)( (DataRowView)d.Current ).Row;//выбранная строка в таблице

            AddOrEdit f = new AddOrEdit(User.Логин,r) {Text = "Редактирование: " + r.Наименование + ", Пользователь: " + User.Логин};//инициализация формы редактирования записи и передача ей необходимых данных

            if ( f.ShowDialog() == DialogResult.OK )//открытие диалогового окна с формой и проверка нажатия на OK
            {
                int i = учетTableAdapter.Update( f.Тип.Text, f.Пользователь.Text, f.Наименование.Text, int.Parse(f.Крепость.Text),r.Дата_постановки_на_учет, decimal.Parse(f.Объем.Text), int.Parse(f.Количество.Text), decimal.Parse(f.Цена.Text),r.Списание, r.__);// редактирование данных в бд
                if ( i > 0 )
                {
                    учетTableAdapter.Fill(dataSet1.Учет);

                    алкогольTableAdapter.FillByUser(dataSet1.Алкоголь, User.Логин);//заполнить таблицу из бд
                }
                else MessageBox.Show("Редактирование не выполнено, обратитесь к администратору");
            }

        }



        private void DeleteRow_Click(object sender, EventArgs e)
        {
            if ( MessageBox.Show("Вы уверены, что хотите удалить данную запись?\nЭто действие невозможно отменить", "Подтверждение удаления",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1) == DialogResult.Yes )
            {                                                                                 //источник таблицы
                DataSet1.АлкогольRow r = ( (DataRowView)( (BindingSource)((DataGridView)tabControl1.SelectedTab.Controls.OfType<DataGridView>().First()).DataSource ).Current ).Row as DataSet1.АлкогольRow;
                учетTableAdapter.Delete(r.__);//обновить данные в бд
                учетTableAdapter.Fill(dataSet1.Учет);//заполнить таблицу из бд
                алкогольTableAdapter.Fill(dataSet1.Алкоголь);
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Validate();//проверка формы(валидация)
            типы_алкогольных_напитковBindingSource.EndEdit();//сообщить источнику о завершении редактирования
            типы_алкогольных_напитковTableAdapter.Update(dataSet1.Типы_алкогольных_напитков);
            типы_алкогольных_напитковTableAdapter.Fill(dataSet1.Типы_алкогольных_напитков);
            алкогольTableAdapter.FillByUser(dataSet1.Алкоголь, User.Логин);
            tableAdapterManager.UpdateAll(dataSet1);// обновить данные в бд, передав в них наш виртульный набор данных

        }

        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            this.алкогольBindingSource.Filter = this.dataGridView.FilterString;//смена фильтра источника при изменении фильтра таблицы
        }

        private void dataGridView_SortStringChanged(object sender, EventArgs e)
        {
            this.алкогольBindingSource.Sort = this.dataGridView.SortString;//смена сортировки источника при изменении сортировки таблицы
        }

        private void searchToolBar1_Search(object sender, ADGV.SearchToolBarSearchEventArgs e)
        {
            int startColumn = 0;
            int startRow = 0;
            if ( !e.FromBegin )
            {
                bool endcol = this.dataGridView.CurrentCell.ColumnIndex + 1 >= this.dataGridView.ColumnCount;
                bool endrow = this.dataGridView.CurrentCell.RowIndex + 1 >= this.dataGridView.RowCount;

                if ( endcol && endrow )
                {
                    startColumn = this.dataGridView.CurrentCell.ColumnIndex;
                    startRow = this.dataGridView.CurrentCell.RowIndex;
                }
                else
                {
                    startColumn = endcol ? 0 : this.dataGridView.CurrentCell.ColumnIndex + 1;
                    startRow = this.dataGridView.CurrentCell.RowIndex + ( endcol ? 1 : 0 );
                }
            }
            DataGridViewCell c = this.dataGridView.FindCell(
                e.ValueToSearch,
                e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                startRow,
                startColumn,
                e.WholeWord,
                e.CaseSensitive);

            if ( c != null )
                this.dataGridView.CurrentCell = c;
        }// поиск взят из dll AdvancedDataGridView

        private void IncomeType_Changed(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)tabControl1.SelectedTab.Controls.OfType<DataGridView>().First();//таблица с текущей вкладки
            String c = ((ComboBox)sender).Text == "Зачисление" ? "False" : ((ComboBox)sender).Text == "Списание" ? "True" : "all";//Выбор списание/зачисление/все, запонение строки для филтра
            ( (BindingSource)dgv.DataSource ).Filter = c == "all" ? "" : String.Format("[Списание]=\'{0}\'", c);//смена фильтра источника данных в соответствии с выбраным элементом списка

        }

        private void Spisanie_Click(object sender, EventArgs e)
        {
            //списание имущества по аналогии с его редактирование, просто количество отрицательное и запись не редактируется, а добавляется
            DataGridView dgv = (DataGridView)tabControl1.SelectedTab.Controls.OfType<DataGridView>().First();
            BindingSource d = (BindingSource)dgv.DataSource;
            DataSet1.АлкогольRow r = (DataSet1.АлкогольRow)( (DataRowView)d.Current ).Row;


            AddOrEdit f = new AddOrEdit(User.Логин,r){Text="Списание: "+r.Наименование };

            if ( f.ShowDialog() == DialogResult.OK )
            {
                учетTableAdapter.Insert(f.Тип.Text, f.Пользователь.Text, f.Наименование.Text, short.Parse(f.Крепость.Text), f.date.Value, double.Parse(f.Объем.Text), -short.Parse(f.Количество.Text), double.Parse(f.Цена.Text), true);
                // заполнение таблицы из бд
                учетTableAdapter.Fill(dataSet1.Учет);
                алкогольTableAdapter.FillByUser(dataSet1.Алкоголь, User.Логин);
            }

        }

        private void алкогольBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            this.searchToolBar.SetColumns(this.dataGridView.Columns);//смена выпадающего списка с колонками при изменении источника данных

        }

        private void UpdateButton_click(object sender, EventArgs e)
        {
            if ( dataSet1.HasChanges() ) типы_алкогольных_напитковTableAdapter.Update(dataSet1.Типы_алкогольных_напитков);
            алкогольTableAdapter.FillByUser(dataSet1.Алкоголь, User.Логин);
        }
    }
}
