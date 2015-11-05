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
            this.ux_RunPlugin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ux_QueueAllPlugins = new System.Windows.Forms.Button();
            this.ux_QueueItemMessageBody = new System.Windows.Forms.TextBox();
            this.ux_ListOfPlugins = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ux_LoadAndRun
            // 
            this.ux_LoadAndRun.Location = new System.Drawing.Point(22, 23);
            this.ux_LoadAndRun.Name = "ux_LoadAndRun";
            this.ux_LoadAndRun.Size = new System.Drawing.Size(87, 23);
            this.ux_LoadAndRun.TabIndex = 0;
            this.ux_LoadAndRun.Text = "LoadAllPlugins";
            this.ux_LoadAndRun.UseVisualStyleBackColor = true;
            this.ux_LoadAndRun.Click += new System.EventHandler(this.ux_LoadAndRun_Click);
            // 
            // ux_RunPlugin
            // 
            this.ux_RunPlugin.Location = new System.Drawing.Point(22, 117);
            this.ux_RunPlugin.Name = "ux_RunPlugin";
            this.ux_RunPlugin.Size = new System.Drawing.Size(75, 23);
            this.ux_RunPlugin.TabIndex = 2;
            this.ux_RunPlugin.Text = "Run Plugin";
            this.ux_RunPlugin.UseVisualStyleBackColor = true;
            this.ux_RunPlugin.Click += new System.EventHandler(this.ux_RunPlugin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Plugin Name (Folder Name)";
            // 
            // ux_QueueAllPlugins
            // 
            this.ux_QueueAllPlugins.Location = new System.Drawing.Point(25, 194);
            this.ux_QueueAllPlugins.Name = "ux_QueueAllPlugins";
            this.ux_QueueAllPlugins.Size = new System.Drawing.Size(181, 23);
            this.ux_QueueAllPlugins.TabIndex = 4;
            this.ux_QueueAllPlugins.Text = "Process Queue Item";
            this.ux_QueueAllPlugins.UseVisualStyleBackColor = true;
            // 
            // ux_QueueItemMessageBody
            // 
            this.ux_QueueItemMessageBody.Location = new System.Drawing.Point(25, 168);
            this.ux_QueueItemMessageBody.Name = "ux_QueueItemMessageBody";
            this.ux_QueueItemMessageBody.Size = new System.Drawing.Size(247, 20);
            this.ux_QueueItemMessageBody.TabIndex = 5;
            this.ux_QueueItemMessageBody.Text = "Sarasota, FL";
            // 
            // ux_ListOfPlugins
            // 
            this.ux_ListOfPlugins.FormattingEnabled = true;
            this.ux_ListOfPlugins.Location = new System.Drawing.Point(25, 90);
            this.ux_ListOfPlugins.Name = "ux_ListOfPlugins";
            this.ux_ListOfPlugins.Size = new System.Drawing.Size(247, 21);
            this.ux_ListOfPlugins.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ux_ListOfPlugins);
            this.Controls.Add(this.ux_QueueItemMessageBody);
            this.Controls.Add(this.ux_QueueAllPlugins);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ux_RunPlugin);
            this.Controls.Add(this.ux_LoadAndRun);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ux_LoadAndRun;
        private System.Windows.Forms.Button ux_RunPlugin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ux_QueueAllPlugins;
        private System.Windows.Forms.TextBox ux_QueueItemMessageBody;
        private System.Windows.Forms.ComboBox ux_ListOfPlugins;
    }
}

