namespace scmpoo
{
    partial class FormPoo
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
            this.SuspendLayout();
            // 
            // FormPoo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(40, 40);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPoo";
            this.ShowInTaskbar = false;
            this.Text = "FormPoo";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.Load += new System.EventHandler(this.FormPoo_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormPoo_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormPoo_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormPoo_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion


    }
}