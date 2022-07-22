
namespace JY
{
    partial class FormCheckStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCheckStock));
            this.axGiExpertControl = new AxGIEXPERTCONTROLLib.AxGiExpertControl();
            ((System.ComponentModel.ISupportInitialize)(this.axGiExpertControl)).BeginInit();
            this.SuspendLayout();
            // 
            // axGiExpertControl
            // 
            this.axGiExpertControl.Enabled = true;
            this.axGiExpertControl.Location = new System.Drawing.Point(3628, 278);
            this.axGiExpertControl.Name = "axGiExpertControl";
            this.axGiExpertControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGiExpertControl.OcxState")));
            this.axGiExpertControl.Size = new System.Drawing.Size(136, 50);
            this.axGiExpertControl.TabIndex = 0;
            // 
            // FormCheckStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axGiExpertControl);
            this.Name = "FormCheckStock";
            this.Text = "Stocks";
            ((System.ComponentModel.ISupportInitialize)(this.axGiExpertControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxGIEXPERTCONTROLLib.AxGiExpertControl axGiExpertControl;
    }
}