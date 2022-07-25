
namespace JY.Stock
{
    partial class FormLogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogIn));
            this.tableLayoutPanel_Login = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_AuthPw = new System.Windows.Forms.TextBox();
            this.textBox_PW = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_SaveId = new System.Windows.Forms.CheckBox();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.axGiExpertControl = new AxGIEXPERTCONTROLLib.AxGiExpertControl();
            this.button_LogIn = new System.Windows.Forms.Button();
            this.button_Config = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGiExpertControl)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_Login
            // 
            this.tableLayoutPanel_Login.AutoSize = true;
            this.tableLayoutPanel_Login.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel_Login.ColumnCount = 3;
            this.tableLayoutPanel_Login.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_Login.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_Login.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_Login.Controls.Add(this.textBox_AuthPw, 0, 2);
            this.tableLayoutPanel_Login.Controls.Add(this.textBox_PW, 1, 1);
            this.tableLayoutPanel_Login.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel_Login.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel_Login.Controls.Add(this.checkBox_SaveId, 2, 0);
            this.tableLayoutPanel_Login.Controls.Add(this.textBox_ID, 1, 0);
            this.tableLayoutPanel_Login.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel_Login.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel_Login.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel_Login.Name = "tableLayoutPanel_Login";
            this.tableLayoutPanel_Login.RowCount = 3;
            this.tableLayoutPanel_Login.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_Login.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_Login.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_Login.Size = new System.Drawing.Size(242, 81);
            this.tableLayoutPanel_Login.TabIndex = 1;
            // 
            // textBox_AuthPw
            // 
            this.textBox_AuthPw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_AuthPw.Enabled = false;
            this.textBox_AuthPw.Location = new System.Drawing.Point(61, 57);
            this.textBox_AuthPw.Name = "textBox_AuthPw";
            this.textBox_AuthPw.ReadOnly = true;
            this.textBox_AuthPw.Size = new System.Drawing.Size(100, 21);
            this.textBox_AuthPw.TabIndex = 9;
            this.textBox_AuthPw.UseSystemPasswordChar = true;
            // 
            // textBox_PW
            // 
            this.textBox_PW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_PW.Location = new System.Drawing.Point(61, 30);
            this.textBox_PW.Name = "textBox_PW";
            this.textBox_PW.Size = new System.Drawing.Size(100, 21);
            this.textBox_PW.TabIndex = 7;
            this.textBox_PW.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "PW";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox_SaveId
            // 
            this.checkBox_SaveId.AutoSize = true;
            this.checkBox_SaveId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_SaveId.Location = new System.Drawing.Point(167, 3);
            this.checkBox_SaveId.Name = "checkBox_SaveId";
            this.checkBox_SaveId.Size = new System.Drawing.Size(72, 21);
            this.checkBox_SaveId.TabIndex = 5;
            this.checkBox_SaveId.Text = "ID 기억";
            this.checkBox_SaveId.UseVisualStyleBackColor = true;
            // 
            // textBox_ID
            // 
            this.textBox_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ID.Location = new System.Drawing.Point(61, 3);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(100, 21);
            this.textBox_ID.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 27);
            this.label3.TabIndex = 8;
            this.label3.Text = "Auth PW";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // axGiExpertControl
            // 
            this.axGiExpertControl.Enabled = true;
            this.axGiExpertControl.Location = new System.Drawing.Point(834, 617);
            this.axGiExpertControl.Name = "axGiExpertControl";
            this.axGiExpertControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGiExpertControl.OcxState")));
            this.axGiExpertControl.Size = new System.Drawing.Size(136, 50);
            this.axGiExpertControl.TabIndex = 6;
            // 
            // button_LogIn
            // 
            this.button_LogIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_LogIn.Location = new System.Drawing.Point(43, 3);
            this.button_LogIn.Name = "button_LogIn";
            this.button_LogIn.Size = new System.Drawing.Size(75, 26);
            this.button_LogIn.TabIndex = 7;
            this.button_LogIn.Text = "로그인";
            this.button_LogIn.UseVisualStyleBackColor = true;
            this.button_LogIn.Click += new System.EventHandler(this.button_LogIn_Click);
            // 
            // button_Config
            // 
            this.button_Config.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_Config.Location = new System.Drawing.Point(124, 3);
            this.button_Config.Name = "button_Config";
            this.button_Config.Size = new System.Drawing.Size(75, 26);
            this.button_Config.TabIndex = 8;
            this.button_Config.Text = "설정";
            this.button_Config.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 30);
            this.label4.TabIndex = 9;
            this.label4.Text = "주식 관리 (신한)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button_LogIn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Config, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 111);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(242, 32);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // FormLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(242, 143);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel_Login);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.axGiExpertControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stocks";
            this.Load += new System.EventHandler(this.FormLogIn_Load);
            this.tableLayoutPanel_Login.ResumeLayout(false);
            this.tableLayoutPanel_Login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGiExpertControl)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Login;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_SaveId;
        private AxGIEXPERTCONTROLLib.AxGiExpertControl axGiExpertControl;
        private System.Windows.Forms.TextBox textBox_PW;
        private System.Windows.Forms.TextBox textBox_AuthPw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_LogIn;
        private System.Windows.Forms.Button button_Config;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}