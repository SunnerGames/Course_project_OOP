namespace Course_project
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btn_films = new System.Windows.Forms.Button();
            this.btn_partcp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_others = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_films
            // 
            this.btn_films.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_films.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_films.Location = new System.Drawing.Point(127, 113);
            this.btn_films.Margin = new System.Windows.Forms.Padding(4);
            this.btn_films.Name = "btn_films";
            this.btn_films.Size = new System.Drawing.Size(227, 74);
            this.btn_films.TabIndex = 0;
            this.btn_films.Text = "Фильмы";
            this.btn_films.UseVisualStyleBackColor = true;
            this.btn_films.Click += new System.EventHandler(this.btn_films_Click);
            // 
            // btn_partcp
            // 
            this.btn_partcp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_partcp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_partcp.Location = new System.Drawing.Point(127, 195);
            this.btn_partcp.Margin = new System.Windows.Forms.Padding(4);
            this.btn_partcp.Name = "btn_partcp";
            this.btn_partcp.Size = new System.Drawing.Size(227, 74);
            this.btn_partcp.TabIndex = 1;
            this.btn_partcp.Text = "Участники";
            this.btn_partcp.UseVisualStyleBackColor = true;
            this.btn_partcp.Click += new System.EventHandler(this.btn_partcp_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(131, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Главное меню";
            // 
            // btn_others
            // 
            this.btn_others.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_others.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_others.Location = new System.Drawing.Point(127, 277);
            this.btn_others.Margin = new System.Windows.Forms.Padding(4);
            this.btn_others.Name = "btn_others";
            this.btn_others.Size = new System.Drawing.Size(227, 74);
            this.btn_others.TabIndex = 3;
            this.btn_others.Text = "Жюри и гости";
            this.btn_others.UseVisualStyleBackColor = true;
            this.btn_others.Click += new System.EventHandler(this.btn_others_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(512, 458);
            this.Controls.Add(this.btn_others);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_partcp);
            this.Controls.Add(this.btn_films);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(527, 358);
            this.Name = "Menu";
            this.Text = "Фестиваль фильмов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_films;
        private System.Windows.Forms.Button btn_partcp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_others;
    }
}

