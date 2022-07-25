
namespace JY.Stock
{
    partial class FormStockFunction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStockFunction));
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_Function4 = new System.Windows.Forms.Label();
            this.button_AlarmStockPrice = new System.Windows.Forms.Button();
            this.button_CheckStockPrice = new System.Windows.Forms.Button();
            this.label_Function3 = new System.Windows.Forms.Label();
            this.label_Function1 = new System.Windows.Forms.Label();
            this.label_Function2 = new System.Windows.Forms.Label();
            this.button_SearchStockCondition = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(301, 30);
            this.label4.TabIndex = 10;
            this.label4.Text = "주식 관리 (신한)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label_Function4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button_AlarmStockPrice, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_CheckStockPrice, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_Function3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_Function1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_Function2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_SearchStockCondition, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(301, 270);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // label_Function4
            // 
            this.label_Function4.AutoSize = true;
            this.label_Function4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Function4.Location = new System.Drawing.Point(153, 258);
            this.label_Function4.Name = "label_Function4";
            this.label_Function4.Size = new System.Drawing.Size(145, 12);
            this.label_Function4.TabIndex = 15;
            this.label_Function4.Text = "label5";
            this.label_Function4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_AlarmStockPrice
            // 
            this.button_AlarmStockPrice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_AlarmStockPrice.BackgroundImage")));
            this.button_AlarmStockPrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_AlarmStockPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_AlarmStockPrice.Location = new System.Drawing.Point(3, 138);
            this.button_AlarmStockPrice.Name = "button_AlarmStockPrice";
            this.button_AlarmStockPrice.Size = new System.Drawing.Size(144, 117);
            this.button_AlarmStockPrice.TabIndex = 13;
            this.button_AlarmStockPrice.UseVisualStyleBackColor = true;
            this.button_AlarmStockPrice.Click += new System.EventHandler(this.button_AlarmStockPrice_Click);
            // 
            // button_CheckStockPrice
            // 
            this.button_CheckStockPrice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_CheckStockPrice.BackgroundImage")));
            this.button_CheckStockPrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_CheckStockPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_CheckStockPrice.Location = new System.Drawing.Point(3, 3);
            this.button_CheckStockPrice.Name = "button_CheckStockPrice";
            this.button_CheckStockPrice.Size = new System.Drawing.Size(144, 117);
            this.button_CheckStockPrice.TabIndex = 14;
            this.button_CheckStockPrice.UseVisualStyleBackColor = true;
            this.button_CheckStockPrice.Click += new System.EventHandler(this.button_CheckStockPrice_Click);
            // 
            // label_Function3
            // 
            this.label_Function3.AutoSize = true;
            this.label_Function3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Function3.Location = new System.Drawing.Point(3, 258);
            this.label_Function3.Name = "label_Function3";
            this.label_Function3.Size = new System.Drawing.Size(144, 12);
            this.label_Function3.TabIndex = 14;
            this.label_Function3.Text = "주가 알람";
            this.label_Function3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Function1
            // 
            this.label_Function1.AutoSize = true;
            this.label_Function1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Function1.Location = new System.Drawing.Point(3, 123);
            this.label_Function1.Name = "label_Function1";
            this.label_Function1.Size = new System.Drawing.Size(144, 12);
            this.label_Function1.TabIndex = 12;
            this.label_Function1.Text = "주가 검색";
            this.label_Function1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Function2
            // 
            this.label_Function2.AutoSize = true;
            this.label_Function2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Function2.Location = new System.Drawing.Point(153, 123);
            this.label_Function2.Name = "label_Function2";
            this.label_Function2.Size = new System.Drawing.Size(145, 12);
            this.label_Function2.TabIndex = 13;
            this.label_Function2.Text = "조건부 주식 찾기";
            this.label_Function2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_SearchStockCondition
            // 
            this.button_SearchStockCondition.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_SearchStockCondition.BackgroundImage")));
            this.button_SearchStockCondition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_SearchStockCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_SearchStockCondition.Location = new System.Drawing.Point(153, 3);
            this.button_SearchStockCondition.Name = "button_SearchStockCondition";
            this.button_SearchStockCondition.Size = new System.Drawing.Size(145, 117);
            this.button_SearchStockCondition.TabIndex = 12;
            this.button_SearchStockCondition.UseVisualStyleBackColor = true;
            this.button_SearchStockCondition.Click += new System.EventHandler(this.button_SearchStockCondition_Click);
            // 
            // FormStockFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(301, 300);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormStockFunction";
            this.Text = "기능";
            this.Load += new System.EventHandler(this.FormStockFunction_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_SearchStockCondition;
        private System.Windows.Forms.Button button_AlarmStockPrice;
        private System.Windows.Forms.Button button_CheckStockPrice;
        private System.Windows.Forms.Label label_Function4;
        private System.Windows.Forms.Label label_Function3;
        private System.Windows.Forms.Label label_Function1;
        private System.Windows.Forms.Label label_Function2;
    }
}