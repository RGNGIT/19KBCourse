namespace _KS
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelInValueTotal = new System.Windows.Forms.Label();
            this.labelInSources = new System.Windows.Forms.Label();
            this.buttonIDelete = new System.Windows.Forms.Button();
            this.buttonInAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInValue = new System.Windows.Forms.TextBox();
            this.textBoxInType = new System.Windows.Forms.TextBox();
            this.dataGridViewIn = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelOutValue = new System.Windows.Forms.Label();
            this.labelOutSource = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonOutDelCategory = new System.Windows.Forms.Button();
            this.textBoxOutCategory = new System.Windows.Forms.TextBox();
            this.buttonOutDelete = new System.Windows.Forms.Button();
            this.buttonOutAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxOutValue = new System.Windows.Forms.TextBox();
            this.textBoxOutType = new System.Windows.Forms.TextBox();
            this.dataGridViewOut = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.labelRemainingBalance = new System.Windows.Forms.Label();
            this.labelTotalOuttake = new System.Windows.Forms.Label();
            this.labelTotalIntake = new System.Windows.Forms.Label();
            this.buttonSummary = new System.Windows.Forms.Button();
            this.tabControlDiag = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.ChartIntake = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ChartOuttakeTypes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ChartOuttakeCategories = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIn)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOut)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabControlDiag.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartIntake)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartOuttakeTypes)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartOuttakeCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(728, 520);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.labelInValueTotal);
            this.tabPage1.Controls.Add(this.labelInSources);
            this.tabPage1.Controls.Add(this.buttonIDelete);
            this.tabPage1.Controls.Add(this.buttonInAdd);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxInValue);
            this.tabPage1.Controls.Add(this.textBoxInType);
            this.tabPage1.Controls.Add(this.dataGridViewIn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(720, 494);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Доходы";
            // 
            // labelInValueTotal
            // 
            this.labelInValueTotal.AutoSize = true;
            this.labelInValueTotal.Location = new System.Drawing.Point(378, 475);
            this.labelInValueTotal.Name = "labelInValueTotal";
            this.labelInValueTotal.Size = new System.Drawing.Size(70, 13);
            this.labelInValueTotal.TabIndex = 9;
            this.labelInValueTotal.Text = "$IntakeValue";
            // 
            // labelInSources
            // 
            this.labelInSources.AutoSize = true;
            this.labelInSources.Location = new System.Drawing.Point(378, 462);
            this.labelInSources.Name = "labelInSources";
            this.labelInSources.Size = new System.Drawing.Size(82, 13);
            this.labelInSources.TabIndex = 8;
            this.labelInSources.Text = "$IntakeSources";
            // 
            // buttonIDelete
            // 
            this.buttonIDelete.Location = new System.Drawing.Point(526, 87);
            this.buttonIDelete.Name = "buttonIDelete";
            this.buttonIDelete.Size = new System.Drawing.Size(188, 23);
            this.buttonIDelete.TabIndex = 6;
            this.buttonIDelete.Text = "Удалить по типу";
            this.buttonIDelete.UseVisualStyleBackColor = true;
            this.buttonIDelete.Click += new System.EventHandler(this.buttonIDelete_Click);
            // 
            // buttonInAdd
            // 
            this.buttonInAdd.Location = new System.Drawing.Point(526, 58);
            this.buttonInAdd.Name = "buttonInAdd";
            this.buttonInAdd.Size = new System.Drawing.Size(188, 23);
            this.buttonInAdd.TabIndex = 5;
            this.buttonInAdd.Text = "Добавить";
            this.buttonInAdd.UseVisualStyleBackColor = true;
            this.buttonInAdd.Click += new System.EventHandler(this.buttonInAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Сумма дохода";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(456, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Тип дохода";
            // 
            // textBoxInValue
            // 
            this.textBoxInValue.Location = new System.Drawing.Point(526, 32);
            this.textBoxInValue.Name = "textBoxInValue";
            this.textBoxInValue.Size = new System.Drawing.Size(188, 20);
            this.textBoxInValue.TabIndex = 2;
            // 
            // textBoxInType
            // 
            this.textBoxInType.Location = new System.Drawing.Point(526, 6);
            this.textBoxInType.Name = "textBoxInType";
            this.textBoxInType.Size = new System.Drawing.Size(188, 20);
            this.textBoxInType.TabIndex = 1;
            // 
            // dataGridViewIn
            // 
            this.dataGridViewIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIn.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewIn.Name = "dataGridViewIn";
            this.dataGridViewIn.Size = new System.Drawing.Size(366, 482);
            this.dataGridViewIn.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.labelOutValue);
            this.tabPage2.Controls.Add(this.labelOutSource);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.buttonOutDelCategory);
            this.tabPage2.Controls.Add(this.textBoxOutCategory);
            this.tabPage2.Controls.Add(this.buttonOutDelete);
            this.tabPage2.Controls.Add(this.buttonOutAdd);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.textBoxOutValue);
            this.tabPage2.Controls.Add(this.textBoxOutType);
            this.tabPage2.Controls.Add(this.dataGridViewOut);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(720, 494);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Расходы";
            // 
            // labelOutValue
            // 
            this.labelOutValue.AutoSize = true;
            this.labelOutValue.Location = new System.Drawing.Point(378, 475);
            this.labelOutValue.Name = "labelOutValue";
            this.labelOutValue.Size = new System.Drawing.Size(78, 13);
            this.labelOutValue.TabIndex = 19;
            this.labelOutValue.Text = "$OuttakeValue";
            // 
            // labelOutSource
            // 
            this.labelOutSource.AutoSize = true;
            this.labelOutSource.Location = new System.Drawing.Point(378, 462);
            this.labelOutSource.Name = "labelOutSource";
            this.labelOutSource.Size = new System.Drawing.Size(90, 13);
            this.labelOutSource.TabIndex = 18;
            this.labelOutSource.Text = "$OuttakeSources";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Категория";
            // 
            // buttonOutDelCategory
            // 
            this.buttonOutDelCategory.Location = new System.Drawing.Point(526, 142);
            this.buttonOutDelCategory.Name = "buttonOutDelCategory";
            this.buttonOutDelCategory.Size = new System.Drawing.Size(188, 23);
            this.buttonOutDelCategory.TabIndex = 16;
            this.buttonOutDelCategory.Text = "Удалить всю категорию";
            this.buttonOutDelCategory.UseVisualStyleBackColor = true;
            this.buttonOutDelCategory.Click += new System.EventHandler(this.buttonOutDelCategory_Click);
            // 
            // textBoxOutCategory
            // 
            this.textBoxOutCategory.Location = new System.Drawing.Point(526, 32);
            this.textBoxOutCategory.Name = "textBoxOutCategory";
            this.textBoxOutCategory.Size = new System.Drawing.Size(188, 20);
            this.textBoxOutCategory.TabIndex = 15;
            // 
            // buttonOutDelete
            // 
            this.buttonOutDelete.Location = new System.Drawing.Point(526, 113);
            this.buttonOutDelete.Name = "buttonOutDelete";
            this.buttonOutDelete.Size = new System.Drawing.Size(188, 23);
            this.buttonOutDelete.TabIndex = 13;
            this.buttonOutDelete.Text = "Удалить по типу";
            this.buttonOutDelete.UseVisualStyleBackColor = true;
            this.buttonOutDelete.Click += new System.EventHandler(this.buttonOutDelete_Click);
            // 
            // buttonOutAdd
            // 
            this.buttonOutAdd.Location = new System.Drawing.Point(526, 84);
            this.buttonOutAdd.Name = "buttonOutAdd";
            this.buttonOutAdd.Size = new System.Drawing.Size(188, 23);
            this.buttonOutAdd.TabIndex = 12;
            this.buttonOutAdd.Text = "Добавить";
            this.buttonOutAdd.UseVisualStyleBackColor = true;
            this.buttonOutAdd.Click += new System.EventHandler(this.buttonOutAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(441, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Сумма расхода";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(456, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Тип расхода";
            // 
            // textBoxOutValue
            // 
            this.textBoxOutValue.Location = new System.Drawing.Point(526, 58);
            this.textBoxOutValue.Name = "textBoxOutValue";
            this.textBoxOutValue.Size = new System.Drawing.Size(188, 20);
            this.textBoxOutValue.TabIndex = 9;
            // 
            // textBoxOutType
            // 
            this.textBoxOutType.Location = new System.Drawing.Point(526, 6);
            this.textBoxOutType.Name = "textBoxOutType";
            this.textBoxOutType.Size = new System.Drawing.Size(188, 20);
            this.textBoxOutType.TabIndex = 8;
            // 
            // dataGridViewOut
            // 
            this.dataGridViewOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOut.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewOut.Name = "dataGridViewOut";
            this.dataGridViewOut.Size = new System.Drawing.Size(366, 482);
            this.dataGridViewOut.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.labelRemainingBalance);
            this.tabPage3.Controls.Add(this.labelTotalOuttake);
            this.tabPage3.Controls.Add(this.labelTotalIntake);
            this.tabPage3.Controls.Add(this.buttonSummary);
            this.tabPage3.Controls.Add(this.tabControlDiag);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(720, 494);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Анализ данных";
            // 
            // labelRemainingBalance
            // 
            this.labelRemainingBalance.AutoSize = true;
            this.labelRemainingBalance.Location = new System.Drawing.Point(7, 34);
            this.labelRemainingBalance.Name = "labelRemainingBalance";
            this.labelRemainingBalance.Size = new System.Drawing.Size(102, 13);
            this.labelRemainingBalance.TabIndex = 25;
            this.labelRemainingBalance.Text = "$RemainingBalance";
            // 
            // labelTotalOuttake
            // 
            this.labelTotalOuttake.AutoSize = true;
            this.labelTotalOuttake.Location = new System.Drawing.Point(7, 20);
            this.labelTotalOuttake.Name = "labelTotalOuttake";
            this.labelTotalOuttake.Size = new System.Drawing.Size(75, 13);
            this.labelTotalOuttake.TabIndex = 24;
            this.labelTotalOuttake.Text = "$TotalOuttake";
            // 
            // labelTotalIntake
            // 
            this.labelTotalIntake.AutoSize = true;
            this.labelTotalIntake.Location = new System.Drawing.Point(7, 7);
            this.labelTotalIntake.Name = "labelTotalIntake";
            this.labelTotalIntake.Size = new System.Drawing.Size(67, 13);
            this.labelTotalIntake.TabIndex = 23;
            this.labelTotalIntake.Text = "$TotalIntake";
            // 
            // buttonSummary
            // 
            this.buttonSummary.Location = new System.Drawing.Point(6, 465);
            this.buttonSummary.Name = "buttonSummary";
            this.buttonSummary.Size = new System.Drawing.Size(336, 23);
            this.buttonSummary.TabIndex = 22;
            this.buttonSummary.Text = "Рассчитать";
            this.buttonSummary.UseVisualStyleBackColor = true;
            this.buttonSummary.Click += new System.EventHandler(this.buttonSummary_Click);
            // 
            // tabControlDiag
            // 
            this.tabControlDiag.Controls.Add(this.tabPage6);
            this.tabControlDiag.Controls.Add(this.tabPage7);
            this.tabControlDiag.Location = new System.Drawing.Point(348, 6);
            this.tabControlDiag.Name = "tabControlDiag";
            this.tabControlDiag.SelectedIndex = 0;
            this.tabControlDiag.Size = new System.Drawing.Size(366, 482);
            this.tabControlDiag.TabIndex = 21;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.ChartIntake);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(358, 456);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "Диаграмма доходов";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // ChartIntake
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartIntake.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartIntake.Legends.Add(legend1);
            this.ChartIntake.Location = new System.Drawing.Point(6, 6);
            this.ChartIntake.Name = "ChartIntake";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ChartIntake.Series.Add(series1);
            this.ChartIntake.Size = new System.Drawing.Size(346, 444);
            this.ChartIntake.TabIndex = 0;
            this.ChartIntake.Text = "Chart1";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.tabControl2);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(358, 456);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Диаграмма расходов";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(6, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(346, 444);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ChartOuttakeTypes);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(338, 418);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "По типам";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ChartOuttakeTypes
            // 
            chartArea2.Name = "ChartArea1";
            this.ChartOuttakeTypes.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ChartOuttakeTypes.Legends.Add(legend2);
            this.ChartOuttakeTypes.Location = new System.Drawing.Point(-4, 6);
            this.ChartOuttakeTypes.Name = "ChartOuttakeTypes";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.ChartOuttakeTypes.Series.Add(series2);
            this.ChartOuttakeTypes.Size = new System.Drawing.Size(346, 425);
            this.ChartOuttakeTypes.TabIndex = 1;
            this.ChartOuttakeTypes.Text = "ChartOuttakeTypes";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ChartOuttakeCategories);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(338, 418);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "По категориям";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ChartOuttakeCategories
            // 
            chartArea3.Name = "ChartArea1";
            this.ChartOuttakeCategories.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.ChartOuttakeCategories.Legends.Add(legend3);
            this.ChartOuttakeCategories.Location = new System.Drawing.Point(-4, 6);
            this.ChartOuttakeCategories.Name = "ChartOuttakeCategories";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.ChartOuttakeCategories.Series.Add(series3);
            this.ChartOuttakeCategories.Size = new System.Drawing.Size(346, 416);
            this.ChartOuttakeCategories.TabIndex = 2;
            this.ChartOuttakeCategories.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 544);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Учет семейного бюджета";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIn)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOut)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControlDiag.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartIntake)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartOuttakeTypes)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartOuttakeCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridViewIn;
        private System.Windows.Forms.TextBox textBoxInValue;
        private System.Windows.Forms.TextBox textBoxInType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonInAdd;
        private System.Windows.Forms.Button buttonIDelete;
        private System.Windows.Forms.Label labelInValueTotal;
        private System.Windows.Forms.Label labelInSources;
        private System.Windows.Forms.DataGridView dataGridViewOut;
        private System.Windows.Forms.Button buttonOutDelCategory;
        private System.Windows.Forms.TextBox textBoxOutCategory;
        private System.Windows.Forms.Button buttonOutDelete;
        private System.Windows.Forms.Button buttonOutAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxOutValue;
        private System.Windows.Forms.TextBox textBoxOutType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelOutValue;
        private System.Windows.Forms.Label labelOutSource;
        private System.Windows.Forms.TabControl tabControlDiag;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button buttonSummary;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartIntake;
        private System.Windows.Forms.Label labelRemainingBalance;
        private System.Windows.Forms.Label labelTotalOuttake;
        private System.Windows.Forms.Label labelTotalIntake;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartOuttakeTypes;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartOuttakeCategories;
    }
}

