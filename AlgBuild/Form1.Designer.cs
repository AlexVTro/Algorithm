namespace AlgBuild
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
            this.BuildButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ButtonWriteTestSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(12, 43);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(260, 87);
            this.BuildButton.TabIndex = 0;
            this.BuildButton.Text = "1. Build installers";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.ButtonBuildClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 87);
            this.button1.TabIndex = 1;
            this.button1.Text = "2. Publish";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonPublishClick);
            // 
            // ButtonWriteTestSettings
            // 
            this.ButtonWriteTestSettings.Location = new System.Drawing.Point(77, 12);
            this.ButtonWriteTestSettings.Name = "ButtonWriteTestSettings";
            this.ButtonWriteTestSettings.Size = new System.Drawing.Size(134, 23);
            this.ButtonWriteTestSettings.TabIndex = 2;
            this.ButtonWriteTestSettings.Text = "WriteTestSettings";
            this.ButtonWriteTestSettings.UseVisualStyleBackColor = true;
            this.ButtonWriteTestSettings.Click += new System.EventHandler(this.ButtonWriteTestSettings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 270);
            this.Controls.Add(this.ButtonWriteTestSettings);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BuildButton);
            this.Name = "Form1";
            this.Text = "AlgBuild";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ButtonWriteTestSettings;
    }
}

