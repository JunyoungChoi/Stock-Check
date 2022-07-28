
namespace JY.StockChecker
{
    partial class FormConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_IndiPath = new System.Windows.Forms.TextBox();
            this.button_Browse = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox_Config = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_Config.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "실행파일 위치";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_IndiPath
            // 
            this.textBox_IndiPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_IndiPath.Location = new System.Drawing.Point(90, 3);
            this.textBox_IndiPath.Name = "textBox_IndiPath";
            this.textBox_IndiPath.ReadOnly = true;
            this.textBox_IndiPath.Size = new System.Drawing.Size(190, 21);
            this.textBox_IndiPath.TabIndex = 1;
            // 
            // button_Browse
            // 
            this.button_Browse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Browse.Location = new System.Drawing.Point(286, 3);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(79, 23);
            this.button_Browse.TabIndex = 2;
            this.button_Browse.Text = "찾기";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Browse, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_IndiPath, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(368, 55);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // button_Save
            // 
            this.button_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_Save.Location = new System.Drawing.Point(224, 0);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 33);
            this.button_Save.TabIndex = 4;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            // 
            // button_Close
            // 
            this.button_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_Close.Location = new System.Drawing.Point(299, 0);
            this.button_Close.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 33);
            this.button_Close.TabIndex = 5;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_Save);
            this.panel1.Controls.Add(this.button_Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 33);
            this.panel1.TabIndex = 6;
            // 
            // groupBox_Config
            // 
            this.groupBox_Config.AutoSize = true;
            this.groupBox_Config.Controls.Add(this.tableLayoutPanel1);
            this.groupBox_Config.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Config.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Config.Name = "groupBox_Config";
            this.groupBox_Config.Size = new System.Drawing.Size(374, 75);
            this.groupBox_Config.TabIndex = 7;
            this.groupBox_Config.TabStop = false;
            this.groupBox_Config.Text = "설정";
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 108);
            this.Controls.Add(this.groupBox_Config);
            this.Controls.Add(this.panel1);
            this.Name = "FormConfig";
            this.Text = "설정";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox_Config.ResumeLayout(false);
            this.groupBox_Config.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_IndiPath;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox_Config;
    }
}