
namespace JY.StockChecker.Example
{
    partial class FormExample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExample));
            this.groupBox_LogIn = new System.Windows.Forms.GroupBox();
            this.button_Browse = new System.Windows.Forms.Button();
            this.textBox_IndiPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_AuthPW = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_PW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.axGiExpertControl = new AxGIEXPERTCONTROLLib.AxGiExpertControl();
            this.button_LogIn = new System.Windows.Forms.Button();
            this.groupBox_LogIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGiExpertControl)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_LogIn
            // 
            this.groupBox_LogIn.Controls.Add(this.button_LogIn);
            this.groupBox_LogIn.Controls.Add(this.button_Browse);
            this.groupBox_LogIn.Controls.Add(this.textBox_IndiPath);
            this.groupBox_LogIn.Controls.Add(this.label4);
            this.groupBox_LogIn.Controls.Add(this.textBox_AuthPW);
            this.groupBox_LogIn.Controls.Add(this.label3);
            this.groupBox_LogIn.Controls.Add(this.textBox_PW);
            this.groupBox_LogIn.Controls.Add(this.label2);
            this.groupBox_LogIn.Controls.Add(this.textBox_ID);
            this.groupBox_LogIn.Controls.Add(this.label1);
            this.groupBox_LogIn.Location = new System.Drawing.Point(36, 30);
            this.groupBox_LogIn.Name = "groupBox_LogIn";
            this.groupBox_LogIn.Size = new System.Drawing.Size(216, 206);
            this.groupBox_LogIn.TabIndex = 0;
            this.groupBox_LogIn.TabStop = false;
            this.groupBox_LogIn.Text = "로그인";
            // 
            // button_Browse
            // 
            this.button_Browse.Location = new System.Drawing.Point(121, 116);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(75, 23);
            this.button_Browse.TabIndex = 1;
            this.button_Browse.Text = "Browse";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // textBox_IndiPath
            // 
            this.textBox_IndiPath.Location = new System.Drawing.Point(8, 145);
            this.textBox_IndiPath.Name = "textBox_IndiPath";
            this.textBox_IndiPath.Size = new System.Drawing.Size(188, 21);
            this.textBox_IndiPath.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "실행 파일 경로";
            // 
            // textBox_AuthPW
            // 
            this.textBox_AuthPW.Location = new System.Drawing.Point(96, 82);
            this.textBox_AuthPW.Name = "textBox_AuthPW";
            this.textBox_AuthPW.Size = new System.Drawing.Size(100, 21);
            this.textBox_AuthPW.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Auth PW";
            // 
            // textBox_PW
            // 
            this.textBox_PW.Location = new System.Drawing.Point(96, 55);
            this.textBox_PW.Name = "textBox_PW";
            this.textBox_PW.Size = new System.Drawing.Size(100, 21);
            this.textBox_PW.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(96, 29);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(100, 21);
            this.textBox_ID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // axGiExpertControl
            // 
            this.axGiExpertControl.Enabled = true;
            this.axGiExpertControl.Location = new System.Drawing.Point(1110, 722);
            this.axGiExpertControl.Name = "axGiExpertControl";
            this.axGiExpertControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGiExpertControl.OcxState")));
            this.axGiExpertControl.Size = new System.Drawing.Size(136, 50);
            this.axGiExpertControl.TabIndex = 1;
            // 
            // button_LogIn
            // 
            this.button_LogIn.Location = new System.Drawing.Point(8, 177);
            this.button_LogIn.Name = "button_LogIn";
            this.button_LogIn.Size = new System.Drawing.Size(75, 23);
            this.button_LogIn.TabIndex = 9;
            this.button_LogIn.Text = "로그인";
            this.button_LogIn.UseVisualStyleBackColor = true;
            this.button_LogIn.Click += new System.EventHandler(this.button_LogIn_Click);
            // 
            // FormExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axGiExpertControl);
            this.Controls.Add(this.groupBox_LogIn);
            this.Name = "FormExample";
            this.Text = "FormExample";
            this.Load += new System.EventHandler(this.FormExample_Load);
            this.groupBox_LogIn.ResumeLayout(false);
            this.groupBox_LogIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGiExpertControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_LogIn;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.TextBox textBox_IndiPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_AuthPW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_PW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Label label1;
        private AxGIEXPERTCONTROLLib.AxGiExpertControl axGiExpertControl;
        private System.Windows.Forms.Button button_LogIn;
    }
}