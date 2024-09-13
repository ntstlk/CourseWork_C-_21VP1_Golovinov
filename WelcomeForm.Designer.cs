using System;

namespace CourseWork
{
    partial class WelcomeForm
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
            if (disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            DataBaseGroupBox = new System.Windows.Forms.GroupBox();
            UseExistingDB = new System.Windows.Forms.RadioButton();
            CreateEmptyDB = new System.Windows.Forms.RadioButton();
            StartBtn = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            NameDB = new System.Windows.Forms.TextBox();
            NameDBLabel = new System.Windows.Forms.Label();
            tableLayoutPanel1.SuspendLayout();
            DataBaseGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(DataBaseGroupBox, 0, 2);
            tableLayoutPanel1.Controls.Add(StartBtn, 0, 5);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(NameDB, 0, 4);
            tableLayoutPanel1.Controls.Add(NameDBLabel, 0, 3);
            tableLayoutPanel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tableLayoutPanel1.Location = new System.Drawing.Point(0, -1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.426967F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.45693F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.6516857F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.307116F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.554307F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.6029968F));
            tableLayoutPanel1.Size = new System.Drawing.Size(801, 534);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // DataBaseGroupBox
            // 
            DataBaseGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            DataBaseGroupBox.Controls.Add(UseExistingDB);
            DataBaseGroupBox.Controls.Add(CreateEmptyDB);
            DataBaseGroupBox.Location = new System.Drawing.Point(216, 232);
            DataBaseGroupBox.Name = "DataBaseGroupBox";
            DataBaseGroupBox.Size = new System.Drawing.Size(368, 147);
            DataBaseGroupBox.TabIndex = 0;
            DataBaseGroupBox.TabStop = false;
            // 
            // UseExistingDB
            // 
            UseExistingDB.AutoSize = true;
            UseExistingDB.Checked = true;
            UseExistingDB.Location = new System.Drawing.Point(25, 91);
            UseExistingDB.Name = "UseExistingDB";
            UseExistingDB.Size = new System.Drawing.Size(302, 22);
            UseExistingDB.TabIndex = 1;
            UseExistingDB.TabStop = true;
            UseExistingDB.Text = "использовать существующую базу данных";
            UseExistingDB.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            UseExistingDB.UseVisualStyleBackColor = true;
            // 
            // CreateEmptyDB
            // 
            CreateEmptyDB.AutoSize = true;
            CreateEmptyDB.Location = new System.Drawing.Point(25, 52);
            CreateEmptyDB.Name = "CreateEmptyDB";
            CreateEmptyDB.Size = new System.Drawing.Size(210, 22);
            CreateEmptyDB.TabIndex = 0;
            CreateEmptyDB.Text = "создать пустую базу данных";
            CreateEmptyDB.UseVisualStyleBackColor = true;
            // 
            // StartBtn
            // 
            StartBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            StartBtn.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            StartBtn.ForeColor = System.Drawing.Color.AliceBlue;
            StartBtn.Location = new System.Drawing.Point(216, 469);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new System.Drawing.Size(369, 35);
            StartBtn.TabIndex = 1;
            StartBtn.Text = "начать";
            StartBtn.UseVisualStyleBackColor = false;
            StartBtn.Click += StartBtn_Click;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(262, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(276, 24);
            label1.TabIndex = 4;
            label1.Text = "ГОЛОВИНОВ 21ВП1 тема: \"Конкурс поэтов\"";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.Black;
            label2.Location = new System.Drawing.Point(135, 62);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(530, 150);
            label2.TabIndex = 5;
            label2.Text = "THE TORTURED POETS DEPARTMENT";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameDB
            // 
            NameDB.Anchor = System.Windows.Forms.AnchorStyles.None;
            NameDB.ForeColor = System.Drawing.Color.SlateGray;
            NameDB.Location = new System.Drawing.Point(216, 409);
            NameDB.Name = "NameDB";
            NameDB.Size = new System.Drawing.Size(369, 26);
            NameDB.TabIndex = 2;
            // 
            // NameDBLabel
            // 
            NameDBLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            NameDBLabel.AutoSize = true;
            NameDBLabel.Location = new System.Drawing.Point(339, 384);
            NameDBLabel.Name = "NameDBLabel";
            NameDBLabel.Size = new System.Drawing.Size(122, 18);
            NameDBLabel.TabIndex = 1;
            NameDBLabel.Text = "имя базы данных";
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 245, 251);
            ClientSize = new System.Drawing.Size(801, 528);
            Controls.Add(tableLayoutPanel1);
            Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.SlateGray;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "WelcomeForm";
            Text = "THE TORTURED POETS DEPARTMENT";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            DataBaseGroupBox.ResumeLayout(false);
            DataBaseGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox DataBaseGroupBox;
        private System.Windows.Forms.RadioButton UseExistingDB;
        private System.Windows.Forms.RadioButton CreateEmptyDB;
        private System.Windows.Forms.TextBox NameDB;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NameDBLabel;
    }
}