
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CourseWork
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Size previousClientSize;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            PoetPage = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            PoetsDataGrid = new DataGridView();
            tableLayoutPanel11 = new TableLayoutPanel();
            PoetLastNameInput = new TextBox();
            PoetPhoneNumberInput = new TextBox();
            PoetDateOfBirthInput = new DateTimePicker();
            label9 = new Label();
            label10 = new Label();
            label8 = new Label();
            PoetFirstNameInput = new TextBox();
            label7 = new Label();
            UpdatePoetBtn = new Button();
            AddPoetBtn = new Button();
            DeletePoetBtn = new Button();
            ClearPoetsInputsBtn = new Button();
            DeleteAllPoetsBtn = new Button();
            tableLayoutPanel12 = new TableLayoutPanel();
            PoetSearchInput = new TextBox();
            ClientLogo = new Label();
            PoetSearchBtn = new Button();
            TabControl = new TabControl();
            CriticPage = new TabPage();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel13 = new TableLayoutPanel();
            CriticsDataGrid = new DataGridView();
            tableLayoutPanel14 = new TableLayoutPanel();
            CriticLastNameInput = new TextBox();
            CriticPhoneNumberInput = new TextBox();
            CriticDateOfBirthInput = new DateTimePicker();
            label6 = new Label();
            label14 = new Label();
            label15 = new Label();
            CriticFirstNameInput = new TextBox();
            label16 = new Label();
            UpdateCriticBtn = new Button();
            AddCriticBtn = new Button();
            DeleteCriticBtn = new Button();
            ClearCriticsInputsBtn = new Button();
            DeleteAllCriticsBtn = new Button();
            tableLayoutPanel15 = new TableLayoutPanel();
            CriticSearchInput = new TextBox();
            EmployeeLogo = new Label();
            CriticSearchBtn = new Button();
            PoemPage = new TabPage();
            tableLayoutPanel16 = new TableLayoutPanel();
            tableLayoutPanel17 = new TableLayoutPanel();
            AppointmentLogo = new Label();
            ChoosenPoetLabel = new Label();
            ChoosenCriticLabel = new Label();
            tableLayoutPanel18 = new TableLayoutPanel();
            PoemDataGrid = new DataGridView();
            tableLayoutPanel19 = new TableLayoutPanel();
            DeleteAllAppointmentsBtn = new Button();
            label1 = new Label();
            AddAppointmentBtn = new Button();
            PoemTextData = new RichTextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBox3 = new TextBox();
            label5 = new Label();
            errorProvider = new ErrorProvider(components);
            PoetPage.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PoetsDataGrid).BeginInit();
            tableLayoutPanel11.SuspendLayout();
            tableLayoutPanel12.SuspendLayout();
            TabControl.SuspendLayout();
            CriticPage.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CriticsDataGrid).BeginInit();
            tableLayoutPanel14.SuspendLayout();
            tableLayoutPanel15.SuspendLayout();
            PoemPage.SuspendLayout();
            tableLayoutPanel16.SuspendLayout();
            tableLayoutPanel17.SuspendLayout();
            tableLayoutPanel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PoemDataGrid).BeginInit();
            tableLayoutPanel19.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // PoetPage
            // 
            PoetPage.Controls.Add(tableLayoutPanel2);
            PoetPage.Location = new Point(4, 29);
            PoetPage.Name = "PoetPage";
            PoetPage.Size = new Size(1124, 721);
            PoetPage.TabIndex = 3;
            PoetPage.Text = "поэты";
            PoetPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.FromArgb(224, 224, 224);
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel12, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 6.93481255F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 93.0651855F));
            tableLayoutPanel2.Size = new Size(1124, 721);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel3.Controls.Add(PoetsDataGrid, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel11, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 53);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(1118, 665);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // PoetsDataGrid
            // 
            PoetsDataGrid.AllowUserToAddRows = false;
            PoetsDataGrid.AllowUserToDeleteRows = false;
            PoetsDataGrid.AllowUserToResizeColumns = false;
            PoetsDataGrid.AllowUserToResizeRows = false;
            PoetsDataGrid.BackgroundColor = Color.AliceBlue;
            PoetsDataGrid.BorderStyle = BorderStyle.None;
            PoetsDataGrid.ColumnHeadersHeight = 29;
            PoetsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Ebrima", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.SlateGray;
            dataGridViewCellStyle1.SelectionBackColor = Color.Lavender;
            dataGridViewCellStyle1.SelectionForeColor = Color.SlateGray;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            PoetsDataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            PoetsDataGrid.Dock = DockStyle.Fill;
            PoetsDataGrid.GridColor = Color.Silver;
            PoetsDataGrid.Location = new Point(3, 4);
            PoetsDataGrid.Margin = new Padding(3, 4, 3, 4);
            PoetsDataGrid.MultiSelect = false;
            PoetsDataGrid.Name = "PoetsDataGrid";
            PoetsDataGrid.ReadOnly = true;
            PoetsDataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            PoetsDataGrid.RowHeadersVisible = false;
            PoetsDataGrid.RowHeadersWidth = 51;
            PoetsDataGrid.RowTemplate.Height = 24;
            PoetsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PoetsDataGrid.Size = new Size(812, 657);
            PoetsDataGrid.TabIndex = 9;
            PoetsDataGrid.CellDoubleClick += DataGridPoets_CellDoubleClick;
            // 
            // tableLayoutPanel11
            // 
            tableLayoutPanel11.ColumnCount = 1;
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tableLayoutPanel11.Controls.Add(PoetLastNameInput, 0, 3);
            tableLayoutPanel11.Controls.Add(PoetPhoneNumberInput, 0, 5);
            tableLayoutPanel11.Controls.Add(PoetDateOfBirthInput, 0, 7);
            tableLayoutPanel11.Controls.Add(label9, 0, 6);
            tableLayoutPanel11.Controls.Add(label10, 0, 4);
            tableLayoutPanel11.Controls.Add(label8, 0, 2);
            tableLayoutPanel11.Controls.Add(PoetFirstNameInput, 0, 1);
            tableLayoutPanel11.Controls.Add(label7, 0, 0);
            tableLayoutPanel11.Controls.Add(UpdatePoetBtn, 0, 10);
            tableLayoutPanel11.Controls.Add(AddPoetBtn, 0, 9);
            tableLayoutPanel11.Controls.Add(DeletePoetBtn, 0, 11);
            tableLayoutPanel11.Controls.Add(ClearPoetsInputsBtn, 0, 8);
            tableLayoutPanel11.Controls.Add(DeleteAllPoetsBtn, 0, 12);
            tableLayoutPanel11.Dock = DockStyle.Fill;
            tableLayoutPanel11.Location = new Point(821, 3);
            tableLayoutPanel11.Name = "tableLayoutPanel11";
            tableLayoutPanel11.RowCount = 14;
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 3.49549079F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 5.623181F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 3.191535F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 5.471203F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 3.34351277F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 5.1672473F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 3.64746881F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 5.01526928F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 8.966694F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 7.446915F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 6.839003F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 13.2220745F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 7.58725357F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 21.0925636F));
            tableLayoutPanel11.Size = new Size(294, 659);
            tableLayoutPanel11.TabIndex = 0;
            // 
            // PoetLastNameInput
            // 
            PoetLastNameInput.BackColor = SystemColors.Window;
            PoetLastNameInput.Dock = DockStyle.Left;
            PoetLastNameInput.Location = new Point(3, 85);
            PoetLastNameInput.Margin = new Padding(3, 4, 3, 4);
            PoetLastNameInput.Name = "PoetLastNameInput";
            PoetLastNameInput.Size = new Size(250, 28);
            PoetLastNameInput.TabIndex = 20;
            // 
            // PoetPhoneNumberInput
            // 
            PoetPhoneNumberInput.BackColor = SystemColors.Window;
            PoetPhoneNumberInput.Dock = DockStyle.Left;
            PoetPhoneNumberInput.Location = new Point(3, 143);
            PoetPhoneNumberInput.Margin = new Padding(3, 4, 3, 4);
            PoetPhoneNumberInput.Name = "PoetPhoneNumberInput";
            PoetPhoneNumberInput.Size = new Size(250, 28);
            PoetPhoneNumberInput.TabIndex = 21;
            // 
            // PoetDateOfBirthInput
            // 
            PoetDateOfBirthInput.CalendarForeColor = Color.SlateGray;
            PoetDateOfBirthInput.CalendarTitleForeColor = Color.SlateGray;
            PoetDateOfBirthInput.Dock = DockStyle.Left;
            PoetDateOfBirthInput.Font = new Font("Ebrima", 9F, FontStyle.Regular, GraphicsUnit.Point);
            PoetDateOfBirthInput.Location = new Point(3, 201);
            PoetDateOfBirthInput.Margin = new Padding(3, 4, 3, 4);
            PoetDateOfBirthInput.MaxDate = new DateTime(2022, 1, 1, 0, 0, 0, 0);
            PoetDateOfBirthInput.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            PoetDateOfBirthInput.Name = "PoetDateOfBirthInput";
            PoetDateOfBirthInput.ShowUpDown = true;
            PoetDateOfBirthInput.Size = new Size(250, 28);
            PoetDateOfBirthInput.TabIndex = 22;
            PoetDateOfBirthInput.Value = new DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Location = new Point(3, 175);
            label9.Name = "label9";
            label9.Size = new Size(114, 20);
            label9.TabIndex = 26;
            label9.Text = "дата рождения";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Left;
            label10.AutoSize = true;
            label10.Location = new Point(3, 118);
            label10.Name = "label10";
            label10.Size = new Size(127, 20);
            label10.TabIndex = 25;
            label10.Text = "номер телефона";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Location = new Point(3, 60);
            label8.Name = "label8";
            label8.Size = new Size(74, 20);
            label8.TabIndex = 24;
            label8.Text = "фамилия";
            // 
            // PoetFirstNameInput
            // 
            PoetFirstNameInput.BackColor = SystemColors.Window;
            PoetFirstNameInput.Dock = DockStyle.Left;
            PoetFirstNameInput.Location = new Point(3, 27);
            PoetFirstNameInput.Margin = new Padding(3, 4, 3, 4);
            PoetFirstNameInput.Name = "PoetFirstNameInput";
            PoetFirstNameInput.Size = new Size(250, 28);
            PoetFirstNameInput.TabIndex = 19;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left;
            label7.AutoSize = true;
            label7.ForeColor = Color.SlateGray;
            label7.Location = new Point(3, 1);
            label7.Name = "label7";
            label7.Size = new Size(36, 20);
            label7.TabIndex = 23;
            label7.Text = "имя";
            // 
            // UpdatePoetBtn
            // 
            UpdatePoetBtn.Anchor = AnchorStyles.Left;
            UpdatePoetBtn.BackColor = Color.Gray;
            UpdatePoetBtn.ForeColor = Color.White;
            UpdatePoetBtn.Location = new Point(3, 343);
            UpdatePoetBtn.Margin = new Padding(3, 4, 3, 4);
            UpdatePoetBtn.Name = "UpdatePoetBtn";
            UpdatePoetBtn.Size = new Size(250, 35);
            UpdatePoetBtn.TabIndex = 28;
            UpdatePoetBtn.Text = "редактировать";
            UpdatePoetBtn.UseVisualStyleBackColor = false;
            UpdatePoetBtn.Click += UpdatePoetBtn_Click;
            // 
            // AddPoetBtn
            // 
            AddPoetBtn.Anchor = AnchorStyles.Left;
            AddPoetBtn.BackColor = Color.Gray;
            AddPoetBtn.ForeColor = Color.White;
            AddPoetBtn.Location = new Point(3, 296);
            AddPoetBtn.Margin = new Padding(3, 4, 3, 4);
            AddPoetBtn.Name = "AddPoetBtn";
            AddPoetBtn.Size = new Size(250, 35);
            AddPoetBtn.TabIndex = 27;
            AddPoetBtn.Text = "добавить";
            AddPoetBtn.UseVisualStyleBackColor = false;
            AddPoetBtn.Click += AddPoetBtn_Click;
            // 
            // DeletePoetBtn
            // 
            DeletePoetBtn.Anchor = AnchorStyles.Left;
            DeletePoetBtn.BackColor = Color.Black;
            DeletePoetBtn.ForeColor = Color.White;
            DeletePoetBtn.Location = new Point(3, 409);
            DeletePoetBtn.Margin = new Padding(3, 4, 3, 4);
            DeletePoetBtn.Name = "DeletePoetBtn";
            DeletePoetBtn.Size = new Size(250, 35);
            DeletePoetBtn.TabIndex = 29;
            DeletePoetBtn.Text = "удалить";
            DeletePoetBtn.UseVisualStyleBackColor = false;
            DeletePoetBtn.Click += DeletePoetBtn_Click;
            // 
            // ClearPoetsInputsBtn
            // 
            ClearPoetsInputsBtn.BackColor = Color.Black;
            ClearPoetsInputsBtn.ForeColor = Color.White;
            ClearPoetsInputsBtn.Location = new Point(3, 233);
            ClearPoetsInputsBtn.Name = "ClearPoetsInputsBtn";
            ClearPoetsInputsBtn.Size = new Size(250, 32);
            ClearPoetsInputsBtn.TabIndex = 31;
            ClearPoetsInputsBtn.Text = "очистить поля";
            ClearPoetsInputsBtn.UseVisualStyleBackColor = false;
            ClearPoetsInputsBtn.Click += ClearPoetInputsBtn_Click;
            // 
            // DeleteAllPoetsBtn
            // 
            DeleteAllPoetsBtn.Anchor = AnchorStyles.Left;
            DeleteAllPoetsBtn.BackColor = Color.Black;
            DeleteAllPoetsBtn.ForeColor = Color.White;
            DeleteAllPoetsBtn.Location = new Point(3, 477);
            DeleteAllPoetsBtn.Margin = new Padding(3, 4, 3, 4);
            DeleteAllPoetsBtn.Name = "DeleteAllPoetsBtn";
            DeleteAllPoetsBtn.Size = new Size(250, 35);
            DeleteAllPoetsBtn.TabIndex = 32;
            DeleteAllPoetsBtn.Text = "удалить все";
            DeleteAllPoetsBtn.UseVisualStyleBackColor = false;
            DeleteAllPoetsBtn.Click += DeleteAllPoetsBtn_Click;
            // 
            // tableLayoutPanel12
            // 
            tableLayoutPanel12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel12.ColumnCount = 3;
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85.67931F));
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.3206854F));
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel12.Controls.Add(PoetSearchInput, 0, 0);
            tableLayoutPanel12.Controls.Add(ClientLogo, 2, 0);
            tableLayoutPanel12.Controls.Add(PoetSearchBtn, 1, 0);
            tableLayoutPanel12.Location = new Point(3, 3);
            tableLayoutPanel12.Name = "tableLayoutPanel12";
            tableLayoutPanel12.RowCount = 1;
            tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel12.Size = new Size(1118, 44);
            tableLayoutPanel12.TabIndex = 1;
            // 
            // PoetSearchInput
            // 
            PoetSearchInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PoetSearchInput.Font = new Font("Ebrima", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            PoetSearchInput.Location = new Point(3, 10);
            PoetSearchInput.Name = "PoetSearchInput";
            PoetSearchInput.Size = new Size(694, 31);
            PoetSearchInput.TabIndex = 27;
            // 
            // ClientLogo
            // 
            ClientLogo.AutoSize = true;
            ClientLogo.Dock = DockStyle.Left;
            ClientLogo.Font = new Font("Impact", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            ClientLogo.ForeColor = Color.Black;
            ClientLogo.Location = new Point(820, 0);
            ClientLogo.Name = "ClientLogo";
            ClientLogo.Size = new Size(93, 44);
            ClientLogo.TabIndex = 2;
            ClientLogo.Text = "TTPD";
            ClientLogo.TextAlign = ContentAlignment.BottomCenter;
            // 
            // PoetSearchBtn
            // 
            PoetSearchBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PoetSearchBtn.BackColor = Color.Black;
            PoetSearchBtn.ForeColor = Color.White;
            PoetSearchBtn.Location = new Point(703, 6);
            PoetSearchBtn.Name = "PoetSearchBtn";
            PoetSearchBtn.Size = new Size(111, 35);
            PoetSearchBtn.TabIndex = 28;
            PoetSearchBtn.Text = "поиск";
            PoetSearchBtn.UseVisualStyleBackColor = false;
            PoetSearchBtn.Click += PoetSearchBtn_Click;
            // 
            // TabControl
            // 
            TabControl.Controls.Add(PoetPage);
            TabControl.Controls.Add(CriticPage);
            TabControl.Controls.Add(PoemPage);
            TabControl.Dock = DockStyle.Fill;
            TabControl.Location = new Point(0, 0);
            TabControl.Margin = new Padding(3, 4, 3, 4);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(1132, 754);
            TabControl.TabIndex = 17;
            TabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            // 
            // CriticPage
            // 
            CriticPage.Controls.Add(tableLayoutPanel4);
            CriticPage.Location = new Point(4, 29);
            CriticPage.Name = "CriticPage";
            CriticPage.Size = new Size(1124, 721);
            CriticPage.TabIndex = 4;
            CriticPage.Text = "критики";
            CriticPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.FromArgb(224, 224, 224);
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel13, 0, 1);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel15, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 6.93481255F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 93.0651855F));
            tableLayoutPanel4.Size = new Size(1124, 721);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel13
            // 
            tableLayoutPanel13.ColumnCount = 2;
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel13.Controls.Add(CriticsDataGrid, 0, 0);
            tableLayoutPanel13.Controls.Add(tableLayoutPanel14, 1, 0);
            tableLayoutPanel13.Dock = DockStyle.Fill;
            tableLayoutPanel13.Location = new Point(3, 53);
            tableLayoutPanel13.Name = "tableLayoutPanel13";
            tableLayoutPanel13.RowCount = 1;
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel13.Size = new Size(1118, 665);
            tableLayoutPanel13.TabIndex = 0;
            // 
            // CriticsDataGrid
            // 
            CriticsDataGrid.AllowUserToAddRows = false;
            CriticsDataGrid.AllowUserToDeleteRows = false;
            CriticsDataGrid.AllowUserToResizeColumns = false;
            CriticsDataGrid.AllowUserToResizeRows = false;
            CriticsDataGrid.BackgroundColor = Color.AliceBlue;
            CriticsDataGrid.BorderStyle = BorderStyle.None;
            CriticsDataGrid.ColumnHeadersHeight = 29;
            CriticsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Ebrima", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.SlateGray;
            dataGridViewCellStyle2.SelectionBackColor = Color.Lavender;
            dataGridViewCellStyle2.SelectionForeColor = Color.SlateGray;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            CriticsDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            CriticsDataGrid.Dock = DockStyle.Fill;
            CriticsDataGrid.GridColor = Color.Silver;
            CriticsDataGrid.Location = new Point(3, 4);
            CriticsDataGrid.Margin = new Padding(3, 4, 3, 4);
            CriticsDataGrid.MultiSelect = false;
            CriticsDataGrid.Name = "CriticsDataGrid";
            CriticsDataGrid.ReadOnly = true;
            CriticsDataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            CriticsDataGrid.RowHeadersVisible = false;
            CriticsDataGrid.RowHeadersWidth = 51;
            CriticsDataGrid.RowTemplate.Height = 24;
            CriticsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CriticsDataGrid.Size = new Size(812, 657);
            CriticsDataGrid.TabIndex = 10;
            CriticsDataGrid.CellDoubleClick += CriticDataGrid_CellDoubleClick;
            // 
            // tableLayoutPanel14
            // 
            tableLayoutPanel14.ColumnCount = 1;
            tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tableLayoutPanel14.Controls.Add(CriticLastNameInput, 0, 3);
            tableLayoutPanel14.Controls.Add(CriticPhoneNumberInput, 0, 5);
            tableLayoutPanel14.Controls.Add(CriticDateOfBirthInput, 0, 7);
            tableLayoutPanel14.Controls.Add(label6, 0, 6);
            tableLayoutPanel14.Controls.Add(label14, 0, 4);
            tableLayoutPanel14.Controls.Add(label15, 0, 2);
            tableLayoutPanel14.Controls.Add(CriticFirstNameInput, 0, 1);
            tableLayoutPanel14.Controls.Add(label16, 0, 0);
            tableLayoutPanel14.Controls.Add(UpdateCriticBtn, 0, 10);
            tableLayoutPanel14.Controls.Add(AddCriticBtn, 0, 9);
            tableLayoutPanel14.Controls.Add(DeleteCriticBtn, 0, 11);
            tableLayoutPanel14.Controls.Add(ClearCriticsInputsBtn, 0, 8);
            tableLayoutPanel14.Controls.Add(DeleteAllCriticsBtn, 0, 12);
            tableLayoutPanel14.Dock = DockStyle.Fill;
            tableLayoutPanel14.Location = new Point(821, 3);
            tableLayoutPanel14.Name = "tableLayoutPanel14";
            tableLayoutPanel14.RowCount = 14;
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 3.49549079F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 5.623181F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 3.191535F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 5.471203F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 3.34351277F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 5.1672473F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 3.64746881F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 5.01526928F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 8.966694F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 7.446915F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 6.839003F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 13.2220745F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 7.58725357F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 21.0925636F));
            tableLayoutPanel14.Size = new Size(294, 659);
            tableLayoutPanel14.TabIndex = 0;
            // 
            // CriticLastNameInput
            // 
            CriticLastNameInput.Dock = DockStyle.Left;
            CriticLastNameInput.Location = new Point(3, 85);
            CriticLastNameInput.Margin = new Padding(3, 4, 3, 4);
            CriticLastNameInput.Name = "CriticLastNameInput";
            CriticLastNameInput.Size = new Size(250, 28);
            CriticLastNameInput.TabIndex = 20;
            // 
            // CriticPhoneNumberInput
            // 
            CriticPhoneNumberInput.Dock = DockStyle.Left;
            CriticPhoneNumberInput.Location = new Point(3, 143);
            CriticPhoneNumberInput.Margin = new Padding(3, 4, 3, 4);
            CriticPhoneNumberInput.Name = "CriticPhoneNumberInput";
            CriticPhoneNumberInput.Size = new Size(250, 28);
            CriticPhoneNumberInput.TabIndex = 21;
            // 
            // CriticDateOfBirthInput
            // 
            CriticDateOfBirthInput.CalendarForeColor = Color.SlateGray;
            CriticDateOfBirthInput.CalendarTitleForeColor = Color.SlateGray;
            CriticDateOfBirthInput.Dock = DockStyle.Left;
            CriticDateOfBirthInput.Font = new Font("Ebrima", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CriticDateOfBirthInput.Location = new Point(3, 201);
            CriticDateOfBirthInput.Margin = new Padding(3, 4, 3, 4);
            CriticDateOfBirthInput.MaxDate = new DateTime(2022, 1, 1, 0, 0, 0, 0);
            CriticDateOfBirthInput.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            CriticDateOfBirthInput.Name = "CriticDateOfBirthInput";
            CriticDateOfBirthInput.ShowUpDown = true;
            CriticDateOfBirthInput.Size = new Size(250, 28);
            CriticDateOfBirthInput.TabIndex = 22;
            CriticDateOfBirthInput.Value = new DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(3, 175);
            label6.Name = "label6";
            label6.Size = new Size(114, 20);
            label6.TabIndex = 26;
            label6.Text = "дата рождения";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Left;
            label14.AutoSize = true;
            label14.Location = new Point(3, 118);
            label14.Name = "label14";
            label14.Size = new Size(127, 20);
            label14.TabIndex = 25;
            label14.Text = "номер телефона";
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Left;
            label15.AutoSize = true;
            label15.Location = new Point(3, 60);
            label15.Name = "label15";
            label15.Size = new Size(74, 20);
            label15.TabIndex = 24;
            label15.Text = "фамилия";
            // 
            // CriticFirstNameInput
            // 
            CriticFirstNameInput.BackColor = SystemColors.Window;
            CriticFirstNameInput.Dock = DockStyle.Left;
            CriticFirstNameInput.Location = new Point(3, 27);
            CriticFirstNameInput.Margin = new Padding(3, 4, 3, 4);
            CriticFirstNameInput.Name = "CriticFirstNameInput";
            CriticFirstNameInput.Size = new Size(250, 28);
            CriticFirstNameInput.TabIndex = 19;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Left;
            label16.AutoSize = true;
            label16.Location = new Point(3, 1);
            label16.Name = "label16";
            label16.Size = new Size(36, 20);
            label16.TabIndex = 23;
            label16.Text = "имя";
            // 
            // UpdateCriticBtn
            // 
            UpdateCriticBtn.Anchor = AnchorStyles.Left;
            UpdateCriticBtn.BackColor = Color.Gray;
            UpdateCriticBtn.ForeColor = Color.White;
            UpdateCriticBtn.Location = new Point(3, 343);
            UpdateCriticBtn.Margin = new Padding(3, 4, 3, 4);
            UpdateCriticBtn.Name = "UpdateCriticBtn";
            UpdateCriticBtn.Size = new Size(250, 35);
            UpdateCriticBtn.TabIndex = 28;
            UpdateCriticBtn.Text = "редактировать";
            UpdateCriticBtn.UseVisualStyleBackColor = false;
            UpdateCriticBtn.Click += UpdateCriticBtn_Click;
            // 
            // AddCriticBtn
            // 
            AddCriticBtn.Anchor = AnchorStyles.Left;
            AddCriticBtn.BackColor = Color.Gray;
            AddCriticBtn.ForeColor = Color.White;
            AddCriticBtn.Location = new Point(3, 296);
            AddCriticBtn.Margin = new Padding(3, 4, 3, 4);
            AddCriticBtn.Name = "AddCriticBtn";
            AddCriticBtn.Size = new Size(250, 35);
            AddCriticBtn.TabIndex = 27;
            AddCriticBtn.Text = "добавить";
            AddCriticBtn.UseVisualStyleBackColor = false;
            AddCriticBtn.Click += AddCriticBtn_Click;
            // 
            // DeleteCriticBtn
            // 
            DeleteCriticBtn.Anchor = AnchorStyles.Left;
            DeleteCriticBtn.BackColor = Color.Black;
            DeleteCriticBtn.ForeColor = Color.White;
            DeleteCriticBtn.Location = new Point(3, 409);
            DeleteCriticBtn.Margin = new Padding(3, 4, 3, 4);
            DeleteCriticBtn.Name = "DeleteCriticBtn";
            DeleteCriticBtn.Size = new Size(250, 35);
            DeleteCriticBtn.TabIndex = 29;
            DeleteCriticBtn.Text = "удалить";
            DeleteCriticBtn.UseVisualStyleBackColor = false;
            DeleteCriticBtn.Click += DeleteCriticBtn_Click;
            // 
            // ClearCriticsInputsBtn
            // 
            ClearCriticsInputsBtn.BackColor = Color.Black;
            ClearCriticsInputsBtn.ForeColor = Color.White;
            ClearCriticsInputsBtn.Location = new Point(3, 233);
            ClearCriticsInputsBtn.Name = "ClearCriticsInputsBtn";
            ClearCriticsInputsBtn.Size = new Size(250, 32);
            ClearCriticsInputsBtn.TabIndex = 30;
            ClearCriticsInputsBtn.Text = "очистить поля";
            ClearCriticsInputsBtn.UseVisualStyleBackColor = false;
            ClearCriticsInputsBtn.Click += ClearCriticsInputsBtn_Click;
            // 
            // DeleteAllCriticsBtn
            // 
            DeleteAllCriticsBtn.Anchor = AnchorStyles.Left;
            DeleteAllCriticsBtn.BackColor = Color.Black;
            DeleteAllCriticsBtn.ForeColor = Color.White;
            DeleteAllCriticsBtn.Location = new Point(3, 477);
            DeleteAllCriticsBtn.Margin = new Padding(3, 4, 3, 4);
            DeleteAllCriticsBtn.Name = "DeleteAllCriticsBtn";
            DeleteAllCriticsBtn.Size = new Size(250, 35);
            DeleteAllCriticsBtn.TabIndex = 33;
            DeleteAllCriticsBtn.Text = "удалить все";
            DeleteAllCriticsBtn.UseVisualStyleBackColor = false;
            DeleteAllCriticsBtn.Click += DeleteAllCriticsBtn_Click;
            // 
            // tableLayoutPanel15
            // 
            tableLayoutPanel15.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel15.ColumnCount = 3;
            tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85.67931F));
            tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.3206854F));
            tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel15.Controls.Add(CriticSearchInput, 0, 0);
            tableLayoutPanel15.Controls.Add(EmployeeLogo, 2, 0);
            tableLayoutPanel15.Controls.Add(CriticSearchBtn, 1, 0);
            tableLayoutPanel15.Location = new Point(3, 3);
            tableLayoutPanel15.Name = "tableLayoutPanel15";
            tableLayoutPanel15.RowCount = 1;
            tableLayoutPanel15.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel15.Size = new Size(1118, 44);
            tableLayoutPanel15.TabIndex = 1;
            // 
            // CriticSearchInput
            // 
            CriticSearchInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CriticSearchInput.Font = new Font("Ebrima", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            CriticSearchInput.Location = new Point(3, 10);
            CriticSearchInput.Name = "CriticSearchInput";
            CriticSearchInput.Size = new Size(694, 31);
            CriticSearchInput.TabIndex = 27;
            // 
            // EmployeeLogo
            // 
            EmployeeLogo.AutoSize = true;
            EmployeeLogo.BackColor = Color.Transparent;
            EmployeeLogo.Dock = DockStyle.Left;
            EmployeeLogo.Font = new Font("Impact", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            EmployeeLogo.ForeColor = Color.Black;
            EmployeeLogo.Location = new Point(820, 0);
            EmployeeLogo.Name = "EmployeeLogo";
            EmployeeLogo.Size = new Size(93, 44);
            EmployeeLogo.TabIndex = 2;
            EmployeeLogo.Text = "TTPD";
            EmployeeLogo.TextAlign = ContentAlignment.BottomCenter;
            // 
            // CriticSearchBtn
            // 
            CriticSearchBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CriticSearchBtn.BackColor = Color.Black;
            CriticSearchBtn.ForeColor = Color.White;
            CriticSearchBtn.Location = new Point(703, 6);
            CriticSearchBtn.Name = "CriticSearchBtn";
            CriticSearchBtn.Size = new Size(111, 35);
            CriticSearchBtn.TabIndex = 28;
            CriticSearchBtn.Text = "поиск";
            CriticSearchBtn.UseVisualStyleBackColor = false;
            CriticSearchBtn.Click += CriticSearchBtn_Click;
            // 
            // PoemPage
            // 
            PoemPage.Controls.Add(tableLayoutPanel16);
            PoemPage.Location = new Point(4, 29);
            PoemPage.Name = "PoemPage";
            PoemPage.Size = new Size(1124, 721);
            PoemPage.TabIndex = 5;
            PoemPage.Text = "работы";
            PoemPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel16
            // 
            tableLayoutPanel16.BackColor = Color.FromArgb(224, 224, 224);
            tableLayoutPanel16.ColumnCount = 1;
            tableLayoutPanel16.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel16.Controls.Add(tableLayoutPanel17, 0, 0);
            tableLayoutPanel16.Controls.Add(tableLayoutPanel18, 0, 1);
            tableLayoutPanel16.Dock = DockStyle.Fill;
            tableLayoutPanel16.Location = new Point(0, 0);
            tableLayoutPanel16.Name = "tableLayoutPanel16";
            tableLayoutPanel16.RowCount = 2;
            tableLayoutPanel16.RowStyles.Add(new RowStyle(SizeType.Percent, 6.93481255F));
            tableLayoutPanel16.RowStyles.Add(new RowStyle(SizeType.Percent, 93.0651855F));
            tableLayoutPanel16.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel16.Size = new Size(1124, 721);
            tableLayoutPanel16.TabIndex = 0;
            // 
            // tableLayoutPanel17
            // 
            tableLayoutPanel17.ColumnCount = 3;
            tableLayoutPanel17.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel17.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel17.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel17.Controls.Add(AppointmentLogo, 0, 0);
            tableLayoutPanel17.Controls.Add(ChoosenPoetLabel, 0, 0);
            tableLayoutPanel17.Controls.Add(ChoosenCriticLabel, 0, 0);
            tableLayoutPanel17.Dock = DockStyle.Fill;
            tableLayoutPanel17.Location = new Point(3, 3);
            tableLayoutPanel17.Name = "tableLayoutPanel17";
            tableLayoutPanel17.RowCount = 1;
            tableLayoutPanel17.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel17.Size = new Size(1118, 44);
            tableLayoutPanel17.TabIndex = 0;
            // 
            // AppointmentLogo
            // 
            AppointmentLogo.AutoSize = true;
            AppointmentLogo.Dock = DockStyle.Left;
            AppointmentLogo.Font = new Font("Impact", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            AppointmentLogo.ForeColor = Color.Black;
            AppointmentLogo.Location = new Point(821, 0);
            AppointmentLogo.Name = "AppointmentLogo";
            AppointmentLogo.Size = new Size(93, 44);
            AppointmentLogo.TabIndex = 23;
            AppointmentLogo.Text = "TTPD";
            AppointmentLogo.TextAlign = ContentAlignment.BottomCenter;
            // 
            // ChoosenPoetLabel
            // 
            ChoosenPoetLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ChoosenPoetLabel.AutoSize = true;
            ChoosenPoetLabel.Font = new Font("Ebrima", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            ChoosenPoetLabel.Location = new Point(412, 21);
            ChoosenPoetLabel.Name = "ChoosenPoetLabel";
            ChoosenPoetLabel.Size = new Size(59, 23);
            ChoosenPoetLabel.TabIndex = 22;
            ChoosenPoetLabel.Text = "label4";
            // 
            // ChoosenCriticLabel
            // 
            ChoosenCriticLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ChoosenCriticLabel.AutoSize = true;
            ChoosenCriticLabel.Font = new Font("Ebrima", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            ChoosenCriticLabel.Location = new Point(3, 21);
            ChoosenCriticLabel.Name = "ChoosenCriticLabel";
            ChoosenCriticLabel.Size = new Size(59, 23);
            ChoosenCriticLabel.TabIndex = 21;
            ChoosenCriticLabel.Text = "label4";
            // 
            // tableLayoutPanel18
            // 
            tableLayoutPanel18.ColumnCount = 2;
            tableLayoutPanel18.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel18.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel18.Controls.Add(PoemDataGrid, 0, 0);
            tableLayoutPanel18.Controls.Add(tableLayoutPanel19, 1, 0);
            tableLayoutPanel18.Dock = DockStyle.Fill;
            tableLayoutPanel18.Location = new Point(3, 53);
            tableLayoutPanel18.Name = "tableLayoutPanel18";
            tableLayoutPanel18.RowCount = 1;
            tableLayoutPanel18.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel18.Size = new Size(1118, 665);
            tableLayoutPanel18.TabIndex = 1;
            // 
            // PoemDataGrid
            // 
            PoemDataGrid.AllowUserToAddRows = false;
            PoemDataGrid.AllowUserToDeleteRows = false;
            PoemDataGrid.AllowUserToResizeColumns = false;
            PoemDataGrid.AllowUserToResizeRows = false;
            PoemDataGrid.BackgroundColor = Color.AliceBlue;
            PoemDataGrid.BorderStyle = BorderStyle.None;
            PoemDataGrid.ColumnHeadersHeight = 29;
            PoemDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Ebrima", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.SlateGray;
            dataGridViewCellStyle3.SelectionBackColor = Color.Lavender;
            dataGridViewCellStyle3.SelectionForeColor = Color.SlateGray;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            PoemDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            PoemDataGrid.Dock = DockStyle.Fill;
            PoemDataGrid.GridColor = Color.Silver;
            PoemDataGrid.Location = new Point(3, 4);
            PoemDataGrid.Margin = new Padding(3, 4, 3, 4);
            PoemDataGrid.MultiSelect = false;
            PoemDataGrid.Name = "PoemDataGrid";
            PoemDataGrid.ReadOnly = true;
            PoemDataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            PoemDataGrid.RowHeadersVisible = false;
            PoemDataGrid.RowHeadersWidth = 51;
            PoemDataGrid.RowTemplate.Height = 24;
            PoemDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PoemDataGrid.Size = new Size(812, 657);
            PoemDataGrid.TabIndex = 10;
            PoemDataGrid.CellDoubleClick += PoemDataGrid_CellDoubleClick;
            // 
            // tableLayoutPanel19
            // 
            tableLayoutPanel19.ColumnCount = 1;
            tableLayoutPanel19.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel19.Controls.Add(DeleteAllAppointmentsBtn, 0, 5);
            tableLayoutPanel19.Controls.Add(label1, 0, 2);
            tableLayoutPanel19.Controls.Add(AddAppointmentBtn, 0, 4);
            tableLayoutPanel19.Controls.Add(PoemTextData, 0, 3);
            tableLayoutPanel19.Dock = DockStyle.Fill;
            tableLayoutPanel19.Location = new Point(821, 3);
            tableLayoutPanel19.Name = "tableLayoutPanel19";
            tableLayoutPanel19.RowCount = 6;
            tableLayoutPanel19.RowStyles.Add(new RowStyle(SizeType.Percent, 1.21396053F));
            tableLayoutPanel19.RowStyles.Add(new RowStyle(SizeType.Percent, 1.21396053F));
            tableLayoutPanel19.RowStyles.Add(new RowStyle(SizeType.Percent, 2.8831563F));
            tableLayoutPanel19.RowStyles.Add(new RowStyle(SizeType.Percent, 77.99696F));
            tableLayoutPanel19.RowStyles.Add(new RowStyle(SizeType.Percent, 8.650787F));
            tableLayoutPanel19.RowStyles.Add(new RowStyle(SizeType.Percent, 7.96390152F));
            tableLayoutPanel19.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel19.Size = new Size(294, 659);
            tableLayoutPanel19.TabIndex = 0;
            // 
            // DeleteAllAppointmentsBtn
            // 
            DeleteAllAppointmentsBtn.Anchor = AnchorStyles.Left;
            DeleteAllAppointmentsBtn.BackColor = Color.Black;
            DeleteAllAppointmentsBtn.ForeColor = Color.White;
            DeleteAllAppointmentsBtn.Location = new Point(3, 615);
            DeleteAllAppointmentsBtn.Margin = new Padding(3, 4, 3, 4);
            DeleteAllAppointmentsBtn.Name = "DeleteAllAppointmentsBtn";
            DeleteAllAppointmentsBtn.Size = new Size(250, 35);
            DeleteAllAppointmentsBtn.TabIndex = 33;
            DeleteAllAppointmentsBtn.Text = "удалить все";
            DeleteAllAppointmentsBtn.UseVisualStyleBackColor = false;
            DeleteAllAppointmentsBtn.Click += DeleteAlllPoemsBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(3, 16);
            label1.Name = "label1";
            label1.Size = new Size(106, 19);
            label1.TabIndex = 25;
            label1.Text = "текст работы:";
            // 
            // AddAppointmentBtn
            // 
            AddAppointmentBtn.BackColor = Color.Gray;
            AddAppointmentBtn.ForeColor = Color.White;
            AddAppointmentBtn.Location = new Point(3, 553);
            AddAppointmentBtn.Margin = new Padding(3, 4, 3, 4);
            AddAppointmentBtn.Name = "AddAppointmentBtn";
            AddAppointmentBtn.Size = new Size(250, 35);
            AddAppointmentBtn.TabIndex = 31;
            AddAppointmentBtn.Text = "добавить";
            AddAppointmentBtn.UseVisualStyleBackColor = false;
            AddAppointmentBtn.Click += AddPoemBtn_Click;
            // 
            // PoemTextData
            // 
            PoemTextData.Dock = DockStyle.Fill;
            PoemTextData.Location = new Point(3, 38);
            PoemTextData.Name = "PoemTextData";
            PoemTextData.Size = new Size(288, 508);
            PoemTextData.TabIndex = 34;
            PoemTextData.Text = "";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85.67931F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.3206854F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel1.Controls.Add(textBox3, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(200, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Font = new Font("Ebrima", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(3, 66);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(1, 31);
            textBox3.TabIndex = 27;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Impact", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(255, 112, 165);
            label5.Location = new Point(-96, 27);
            label5.Name = "label5";
            label5.Size = new Size(171, 45);
            label5.TabIndex = 2;
            label5.Text = "MANiCURE";
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(1132, 754);
            Controls.Add(TabControl);
            Font = new Font("Ebrima", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.SlateGray;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(650, 801);
            Name = "MainForm";
            Text = "The Tortured Poets Department";
            PoetPage.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PoetsDataGrid).EndInit();
            tableLayoutPanel11.ResumeLayout(false);
            tableLayoutPanel11.PerformLayout();
            tableLayoutPanel12.ResumeLayout(false);
            tableLayoutPanel12.PerformLayout();
            TabControl.ResumeLayout(false);
            CriticPage.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CriticsDataGrid).EndInit();
            tableLayoutPanel14.ResumeLayout(false);
            tableLayoutPanel14.PerformLayout();
            tableLayoutPanel15.ResumeLayout(false);
            tableLayoutPanel15.PerformLayout();
            PoemPage.ResumeLayout(false);
            tableLayoutPanel16.ResumeLayout(false);
            tableLayoutPanel17.ResumeLayout(false);
            tableLayoutPanel17.PerformLayout();
            tableLayoutPanel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PoemDataGrid).EndInit();
            tableLayoutPanel19.ResumeLayout(false);
            tableLayoutPanel19.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // this.BackColor = Color.FromArgb(255, 255, 192, 203);
            //LinearGradientBrush gradientBrush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(255,255, 192,203), Color.FromArgb(255,255,105,180),
            ///  LinearGradientMode.Vertical);
            //e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);  
        }

        #endregion
        private TabControl TabControl;
        private TabPage EmployeesPage;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label2;
        private TextBox CriticPhoneNumberInput;
        private DateTimePicker DateOfBirthEmployees;
        private TextBox FirstNameEmployeeInput;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox LastNameEmployees;
        private Button DeleteCriticBtn;
        private Button AddCriticBtn;
        private Button EditEmployeeBtn;
        private TextBox textBox1;
        private Label label3;
        private ComboBox comboBox1;
        private Label label4;
        private TabPage PoemPage;
        private TableLayoutPanel tableLayoutPanel10;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel9;
        private TableLayoutPanel tableLayoutPanel8;
        private TabPage PoetPage;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel11;
        private TextBox PoetLastNameInput;
        private TextBox PoetPhoneNumberInput;
        private DateTimePicker PoetDateOfBirthInput;
        private Label label9;
        private Label label10;
        private Label label8;
        private TextBox PoetFirstNameInput;
        private Label label7;
        private Button UpdatePoetBtn;
        private Button AddPoetBtn;
        private Button DeletePoetBtn;
        private TableLayoutPanel tableLayoutPanel12;
        private TextBox PoetSearchInput;
        private Label ClientLogo;
        private Button PoetSearchBtn;
        private TabPage CriticPage;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel13;
        private TableLayoutPanel tableLayoutPanel14;
        private TextBox CriticLastNameInput;
        private TextBox textBox5;
        private DateTimePicker CriticDateOfBirthInput;
        private Label label6;
        private Label label14;
        private Label label15;
        private TextBox CriticFirstNameInput;
        private Label label16;
        private Button UpdateCriticBtn;
        private Button button3;
        private Button button4;
        private TableLayoutPanel tableLayoutPanel15;
        private TextBox CriticSearchInput;
        private Label EmployeeLogo;
        private Button CriticSearchBtn;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBox3;
        private Label label5;
        private TabPage tabPage1;
        private TableLayoutPanel tableLayoutPanel16;
        private TableLayoutPanel tableLayoutPanel17;
        private TableLayoutPanel tableLayoutPanel18;
        private TableLayoutPanel tableLayoutPanel19;
        private Label AppointmentLogo;
        private Label ChoosenPoetLabel;
        private Label ChoosenCriticLabel;
        private Label label1;
        private Button AddAppointmentBtn;
        private Button ClearPoetsInputsBtn;
        private Button ClearCriticsInputsBtn;
        private ErrorProvider errorProvider;
        private Button DeleteAllPoetsBtn;
        private Button DeleteAllCriticsBtn;
        private Button DeleteAllAppointmentsBtn;
        private DataGridView PoetsDataGrid;
        private DataGridView CriticsDataGrid;
        private DataGridView PoemDataGrid;
        private RichTextBox PoemTextData;
    }
}


