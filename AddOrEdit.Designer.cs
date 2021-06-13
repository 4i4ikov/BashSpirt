
namespace BashSpirt
{
    partial class AddOrEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Тип = new System.Windows.Forms.ComboBox();
            this.типыАлкогольныхНапитковBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new BashSpirt.DataSet1();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.Цена = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Пользователь = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Наименование = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Крепость = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Объем = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.типы_алкогольных_напитковTableAdapter = new BashSpirt.DataSet1TableAdapters.Типы_алкогольных_напитковTableAdapter();
            this.Количество = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.типыАлкогольныхНапитковBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // Тип
            // 
            this.Тип.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Тип.DataSource = this.типыАлкогольныхНапитковBindingSource;
            this.Тип.DisplayMember = "Тип алкогольного напитка";
            this.Тип.FormattingEnabled = true;
            this.Тип.Location = new System.Drawing.Point(8, 27);
            this.Тип.Margin = new System.Windows.Forms.Padding(4);
            this.Тип.Name = "Тип";
            this.Тип.Size = new System.Drawing.Size(237, 24);
            this.Тип.TabIndex = 1;
            this.Тип.ValueMember = "Тип алкогольного напитка";
            // 
            // типыАлкогольныхНапитковBindingSource
            // 
            this.типыАлкогольныхНапитковBindingSource.DataMember = "Типы алкогольных напитков";
            this.типыАлкогольныхНапитковBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(266, 27);
            this.date.Margin = new System.Windows.Forms.Padding(4);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(237, 23);
            this.date.TabIndex = 2;
            // 
            // Цена
            // 
            this.Цена.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.Цена.Location = new System.Drawing.Point(266, 184);
            this.Цена.Margin = new System.Windows.Forms.Padding(4);
            this.Цена.Name = "Цена";
            this.Цена.Size = new System.Drawing.Size(237, 23);
            this.Цена.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 163);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Цена бутылки, рублей";
            // 
            // Пользователь
            // 
            this.Пользователь.Enabled = false;
            this.Пользователь.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.Пользователь.Location = new System.Drawing.Point(8, 80);
            this.Пользователь.Margin = new System.Windows.Forms.Padding(4);
            this.Пользователь.Name = "Пользователь";
            this.Пользователь.ReadOnly = true;
            this.Пользователь.Size = new System.Drawing.Size(237, 23);
            this.Пользователь.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пользователь";
            // 
            // Наименование
            // 
            this.Наименование.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.Наименование.Location = new System.Drawing.Point(8, 129);
            this.Наименование.Margin = new System.Windows.Forms.Padding(4);
            this.Наименование.Name = "Наименование";
            this.Наименование.PromptChar = ' ';
            this.Наименование.Size = new System.Drawing.Size(237, 23);
            this.Наименование.TabIndex = 5;
            this.Наименование.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Наименование";
            // 
            // Крепость
            // 
            this.Крепость.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.Крепость.Location = new System.Drawing.Point(8, 184);
            this.Крепость.Margin = new System.Windows.Forms.Padding(4);
            this.Крепость.Name = "Крепость";
            this.Крепость.PromptChar = ' ';
            this.Крепость.Size = new System.Drawing.Size(237, 23);
            this.Крепость.TabIndex = 7;
            this.Крепость.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 163);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Крепость, %";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Дата постановки на учет";
            // 
            // Объем
            // 
            this.Объем.HidePromptOnLeave = true;
            this.Объем.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.Объем.Location = new System.Drawing.Point(266, 80);
            this.Объем.Margin = new System.Windows.Forms.Padding(4);
            this.Объем.Name = "Объем";
            this.Объем.PromptChar = ' ';
            this.Объем.Size = new System.Drawing.Size(237, 23);
            this.Объем.TabIndex = 4;
            this.Объем.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Объем бутылки, литров";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Тип";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(266, 108);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Количество";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(8, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 41);
            this.button1.TabIndex = 9;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(272, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(228, 41);
            this.button2.TabIndex = 10;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // типы_алкогольных_напитковTableAdapter
            // 
            this.типы_алкогольных_напитковTableAdapter.ClearBeforeFill = true;
            // 
            // Количество
            // 
            this.Количество.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.Количество.Location = new System.Drawing.Point(266, 129);
            this.Количество.Margin = new System.Windows.Forms.Padding(4);
            this.Количество.Name = "Количество";
            this.Количество.Size = new System.Drawing.Size(237, 23);
            this.Количество.TabIndex = 8;
            // 
            // AddOrEdit
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(512, 267);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Объем);
            this.Controls.Add(this.Крепость);
            this.Controls.Add(this.Наименование);
            this.Controls.Add(this.Пользователь);
            this.Controls.Add(this.Количество);
            this.Controls.Add(this.Цена);
            this.Controls.Add(this.date);
            this.Controls.Add(this.Тип);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddOrEdit";
            this.Text = "Добавление/Редактирование имущества";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddOrEdit_FormClosing);
            this.Load += new System.EventHandler(this.AddOrEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.типыАлкогольныхНапитковBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataSet1 dataSet1;
        //private System.Windows.Forms.BindingSource имуществоBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ComboBox Тип;
        public System.Windows.Forms.DateTimePicker date;
        public System.Windows.Forms.MaskedTextBox Цена;
        public System.Windows.Forms.MaskedTextBox Пользователь;
        public System.Windows.Forms.MaskedTextBox Наименование;
        public System.Windows.Forms.MaskedTextBox Крепость;
        public System.Windows.Forms.MaskedTextBox Объем;
        private System.Windows.Forms.BindingSource типыАлкогольныхНапитковBindingSource;
        private DataSet1TableAdapters.Типы_алкогольных_напитковTableAdapter типы_алкогольных_напитковTableAdapter;
        public System.Windows.Forms.MaskedTextBox Количество;
    }
}