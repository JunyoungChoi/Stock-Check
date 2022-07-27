
namespace JY.Stock
{
    partial class FormRTCheck
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
            this.button_Gamsi = new System.Windows.Forms.Button();
            this.label_Status = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.textBox_ShortCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_RT = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_AllStart = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_ChangePrice = new System.Windows.Forms.Button();
            this.dataGridView_GamsiList = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel_RT.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_GamsiList)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Gamsi
            // 
            this.button_Gamsi.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Gamsi.Location = new System.Drawing.Point(350, 270);
            this.button_Gamsi.Name = "button_Gamsi";
            this.button_Gamsi.Size = new System.Drawing.Size(75, 23);
            this.button_Gamsi.TabIndex = 0;
            this.button_Gamsi.Text = "Start";
            this.button_Gamsi.UseVisualStyleBackColor = true;
            this.button_Gamsi.Visible = false;
            this.button_Gamsi.Click += new System.EventHandler(this.button_Gamsi_Click);
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Status.Location = new System.Drawing.Point(190, -3);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(48, 12);
            this.label_Status.TabIndex = 1;
            this.label_Status.Text = "Status :";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Name.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_Name.Location = new System.Drawing.Point(75, 3);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(198, 21);
            this.textBox_Name.TabIndex = 0;
            // 
            // textBox_Price
            // 
            this.textBox_Price.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Price.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_Price.Location = new System.Drawing.Point(75, 57);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.Size = new System.Drawing.Size(198, 21);
            this.textBox_Price.TabIndex = 2;
            // 
            // textBox_ShortCode
            // 
            this.textBox_ShortCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ShortCode.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_ShortCode.Location = new System.Drawing.Point(75, 30);
            this.textBox_ShortCode.Name = "textBox_ShortCode";
            this.textBox_ShortCode.Size = new System.Drawing.Size(198, 21);
            this.textBox_ShortCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "Short code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "Price";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel_RT);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 150);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "주식";
            // 
            // tableLayoutPanel_RT
            // 
            this.tableLayoutPanel_RT.AutoSize = true;
            this.tableLayoutPanel_RT.ColumnCount = 2;
            this.tableLayoutPanel_RT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_RT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_RT.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel_RT.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel_RT.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel_RT.Controls.Add(this.textBox_Name, 1, 0);
            this.tableLayoutPanel_RT.Controls.Add(this.textBox_ShortCode, 1, 1);
            this.tableLayoutPanel_RT.Controls.Add(this.textBox_Price, 1, 2);
            this.tableLayoutPanel_RT.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel_RT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_RT.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel_RT.Name = "tableLayoutPanel_RT";
            this.tableLayoutPanel_RT.RowCount = 4;
            this.tableLayoutPanel_RT.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_RT.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_RT.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_RT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_RT.Size = new System.Drawing.Size(276, 130);
            this.tableLayoutPanel_RT.TabIndex = 10;
            // 
            // panel1
            // 
            this.tableLayoutPanel_RT.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 43);
            this.panel1.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.button_Add, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_AllStart, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Remove, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_ChangePrice, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(270, 43);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // button_Add
            // 
            this.button_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Add.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Add.Location = new System.Drawing.Point(204, 3);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(63, 37);
            this.button_Add.TabIndex = 3;
            this.button_Add.Text = "추가";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_AllStart
            // 
            this.button_AllStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_AllStart.Location = new System.Drawing.Point(137, 3);
            this.button_AllStart.Name = "button_AllStart";
            this.button_AllStart.Size = new System.Drawing.Size(61, 37);
            this.button_AllStart.TabIndex = 8;
            this.button_AllStart.Text = "All start";
            this.button_AllStart.UseVisualStyleBackColor = true;
            this.button_AllStart.Click += new System.EventHandler(this.button_AllSet_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Remove.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Remove.Location = new System.Drawing.Point(3, 3);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(61, 37);
            this.button_Remove.TabIndex = 4;
            this.button_Remove.Text = "삭제";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_ChangePrice
            // 
            this.button_ChangePrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_ChangePrice.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_ChangePrice.Location = new System.Drawing.Point(70, 3);
            this.button_ChangePrice.Name = "button_ChangePrice";
            this.button_ChangePrice.Size = new System.Drawing.Size(61, 37);
            this.button_ChangePrice.TabIndex = 9;
            this.button_ChangePrice.Text = "변경";
            this.button_ChangePrice.UseVisualStyleBackColor = true;
            this.button_ChangePrice.Click += new System.EventHandler(this.button_ChangePrice_Click);
            // 
            // dataGridView_GamsiList
            // 
            this.dataGridView_GamsiList.AllowUserToAddRows = false;
            this.dataGridView_GamsiList.AllowUserToDeleteRows = false;
            this.dataGridView_GamsiList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_GamsiList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_GamsiList.Location = new System.Drawing.Point(12, 193);
            this.dataGridView_GamsiList.Name = "dataGridView_GamsiList";
            this.dataGridView_GamsiList.ReadOnly = true;
            this.dataGridView_GamsiList.RowHeadersVisible = false;
            this.dataGridView_GamsiList.RowTemplate.Height = 27;
            this.dataGridView_GamsiList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_GamsiList.Size = new System.Drawing.Size(282, 161);
            this.dataGridView_GamsiList.TabIndex = 9;
            this.dataGridView_GamsiList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_GamsiList_MouseDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 344);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(318, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(121, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // FormRTCheck
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(318, 366);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView_GamsiList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Gamsi);
            this.Controls.Add(this.label_Status);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormRTCheck";
            this.Text = "FormRTGamsi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRTGamsi_FormClosed);
            this.Load += new System.EventHandler(this.FormRTGamsi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel_RT.ResumeLayout(false);
            this.tableLayoutPanel_RT.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_GamsiList)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Gamsi;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_Price;
        private System.Windows.Forms.TextBox textBox_ShortCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.DataGridView dataGridView_GamsiList;
        private System.Windows.Forms.Button button_AllStart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button_ChangePrice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_RT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}