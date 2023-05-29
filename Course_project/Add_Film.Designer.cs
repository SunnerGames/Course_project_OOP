namespace Course_project
{
    partial class Add_Film
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Film));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Title = new System.Windows.Forms.TextBox();
            this.tb_RatesNumber = new System.Windows.Forms.TextBox();
            this.tb_AvgRate = new System.Windows.Forms.TextBox();
            this.tb_ProductionYear = new System.Windows.Forms.TextBox();
            this.cb_FilmGenre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.tb_Nomination = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(54, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Добавление нового фильма";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tb_Title
            // 
            this.tb_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Title.Location = new System.Drawing.Point(235, 63);
            this.tb_Title.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Title.Name = "tb_Title";
            this.tb_Title.Size = new System.Drawing.Size(160, 26);
            this.tb_Title.TabIndex = 1;
            this.tb_Title.TextChanged += new System.EventHandler(this.tb_Title_TextChanged);
            // 
            // tb_RatesNumber
            // 
            this.tb_RatesNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_RatesNumber.Location = new System.Drawing.Point(235, 134);
            this.tb_RatesNumber.Margin = new System.Windows.Forms.Padding(4);
            this.tb_RatesNumber.Name = "tb_RatesNumber";
            this.tb_RatesNumber.Size = new System.Drawing.Size(160, 26);
            this.tb_RatesNumber.TabIndex = 1;
            this.tb_RatesNumber.TextChanged += new System.EventHandler(this.tb_RatesNumber_TextChanged);
            // 
            // tb_AvgRate
            // 
            this.tb_AvgRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_AvgRate.Location = new System.Drawing.Point(235, 169);
            this.tb_AvgRate.Margin = new System.Windows.Forms.Padding(4);
            this.tb_AvgRate.Name = "tb_AvgRate";
            this.tb_AvgRate.Size = new System.Drawing.Size(160, 26);
            this.tb_AvgRate.TabIndex = 1;
            this.tb_AvgRate.TextChanged += new System.EventHandler(this.tb_AvgRate_TextChanged);
            // 
            // tb_ProductionYear
            // 
            this.tb_ProductionYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_ProductionYear.Location = new System.Drawing.Point(235, 203);
            this.tb_ProductionYear.Margin = new System.Windows.Forms.Padding(4);
            this.tb_ProductionYear.Name = "tb_ProductionYear";
            this.tb_ProductionYear.Size = new System.Drawing.Size(160, 26);
            this.tb_ProductionYear.TabIndex = 1;
            this.tb_ProductionYear.TextChanged += new System.EventHandler(this.tb_ProductionYear_TextChanged);
            // 
            // cb_FilmGenre
            // 
            this.cb_FilmGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FilmGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_FilmGenre.FormattingEnabled = true;
            this.cb_FilmGenre.Items.AddRange(new object[] {
            "Комедия",
            "Триллер",
            "Боевик",
            "Ужасы"});
            this.cb_FilmGenre.Location = new System.Drawing.Point(235, 97);
            this.cb_FilmGenre.Margin = new System.Windows.Forms.Padding(4);
            this.cb_FilmGenre.Name = "cb_FilmGenre";
            this.cb_FilmGenre.Size = new System.Drawing.Size(160, 28);
            this.cb_FilmGenre.TabIndex = 2;
            this.cb_FilmGenre.SelectedIndexChanged += new System.EventHandler(this.cb_FilmGenre_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(45, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Название";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(45, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Жанр фильма";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(45, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Количество оценок";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(45, 172);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Средняя оценка";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(45, 207);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Год выхода";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Add.Location = new System.Drawing.Point(49, 279);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(113, 39);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "Добавить";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Back.Location = new System.Drawing.Point(283, 279);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(113, 39);
            this.btn_Back.TabIndex = 4;
            this.btn_Back.Text = "Назад";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // tb_Nomination
            // 
            this.tb_Nomination.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Nomination.Location = new System.Drawing.Point(235, 238);
            this.tb_Nomination.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Nomination.Name = "tb_Nomination";
            this.tb_Nomination.Size = new System.Drawing.Size(160, 26);
            this.tb_Nomination.TabIndex = 1;
            this.tb_Nomination.TextChanged += new System.EventHandler(this.tb_Nomination_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(45, 241);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Номинация";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Add_Film
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(443, 324);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_FilmGenre);
            this.Controls.Add(this.tb_Nomination);
            this.Controls.Add(this.tb_ProductionYear);
            this.Controls.Add(this.tb_AvgRate);
            this.Controls.Add(this.tb_RatesNumber);
            this.Controls.Add(this.tb_Title);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(461, 371);
            this.MinimumSize = new System.Drawing.Size(461, 371);
            this.Name = "Add_Film";
            this.Text = "Добавление нового фильма";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Title;
        private System.Windows.Forms.TextBox tb_RatesNumber;
        private System.Windows.Forms.TextBox tb_AvgRate;
        private System.Windows.Forms.TextBox tb_ProductionYear;
        private System.Windows.Forms.ComboBox cb_FilmGenre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.TextBox tb_Nomination;
        private System.Windows.Forms.Label label7;
    }
}