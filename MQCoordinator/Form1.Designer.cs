namespace MQCoordinator
{
    partial class Form1
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
            this.ux_LoadAndRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ux_LoadAndRun
            // 
            this.ux_LoadAndRun.Location = new System.Drawing.Point(22, 23);
            this.ux_LoadAndRun.Name = "ux_LoadAndRun";
            this.ux_LoadAndRun.Size = new System.Drawing.Size(87, 23);
            this.ux_LoadAndRun.TabIndex = 0;
            this.ux_LoadAndRun.Text = "LoadAndRun";
            this.ux_LoadAndRun.UseVisualStyleBackColor = true;
            this.ux_LoadAndRun.Click += new System.EventHandler(this.ux_LoadAndRun_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ux_LoadAndRun);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ux_LoadAndRun;
    }
}

