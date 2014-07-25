﻿namespace AlgBuild
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
            this.MoveButton = new System.Windows.Forms.Button();
            this.InstallButton = new System.Windows.Forms.Button();
            this.WriteTestSettingsButton = new System.Windows.Forms.Button();
            this.MsBuildButton = new System.Windows.Forms.Button();
            this.PublishButton = new System.Windows.Forms.Button();
            this.BuildAndPublishButton = new System.Windows.Forms.Button();
            this.publishCustomInstallButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.customInstallNameTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MoveButton
            // 
            this.MoveButton.Location = new System.Drawing.Point(228, 12);
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(102, 23);
            this.MoveButton.TabIndex = 0;
            this.MoveButton.Text = "2. Move all files";
            this.MoveButton.UseVisualStyleBackColor = true;
            this.MoveButton.Click += new System.EventHandler(this.MoveButtonClick);
            // 
            // InstallButton
            // 
            this.InstallButton.Location = new System.Drawing.Point(336, 12);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(102, 23);
            this.InstallButton.TabIndex = 1;
            this.InstallButton.Text = "3. Install";
            this.InstallButton.UseVisualStyleBackColor = true;
            this.InstallButton.Click += new System.EventHandler(this.ButtonInstallClick);
            // 
            // WriteTestSettingsButton
            // 
            this.WriteTestSettingsButton.Location = new System.Drawing.Point(12, 12);
            this.WriteTestSettingsButton.Name = "WriteTestSettingsButton";
            this.WriteTestSettingsButton.Size = new System.Drawing.Size(102, 23);
            this.WriteTestSettingsButton.TabIndex = 2;
            this.WriteTestSettingsButton.Text = "WriteTestSettings";
            this.WriteTestSettingsButton.UseVisualStyleBackColor = true;
            this.WriteTestSettingsButton.Click += new System.EventHandler(this.WriteTestSettingsButtonClick);
            // 
            // MsBuildButton
            // 
            this.MsBuildButton.Location = new System.Drawing.Point(120, 12);
            this.MsBuildButton.Name = "MsBuildButton";
            this.MsBuildButton.Size = new System.Drawing.Size(102, 23);
            this.MsBuildButton.TabIndex = 0;
            this.MsBuildButton.Text = "1. MsBuild";
            this.MsBuildButton.UseVisualStyleBackColor = true;
            this.MsBuildButton.Click += new System.EventHandler(this.MsBuildButtonClick);
            // 
            // PublishButton
            // 
            this.PublishButton.Location = new System.Drawing.Point(444, 12);
            this.PublishButton.Name = "PublishButton";
            this.PublishButton.Size = new System.Drawing.Size(102, 23);
            this.PublishButton.TabIndex = 1;
            this.PublishButton.Text = "4. Publish";
            this.PublishButton.UseVisualStyleBackColor = true;
            this.PublishButton.Click += new System.EventHandler(this.PublishButton_Click);
            // 
            // BuildAndPublishButton
            // 
            this.BuildAndPublishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BuildAndPublishButton.Location = new System.Drawing.Point(12, 60);
            this.BuildAndPublishButton.Name = "BuildAndPublishButton";
            this.BuildAndPublishButton.Size = new System.Drawing.Size(534, 132);
            this.BuildAndPublishButton.TabIndex = 3;
            this.BuildAndPublishButton.Text = "Build && Publish";
            this.BuildAndPublishButton.UseVisualStyleBackColor = true;
            this.BuildAndPublishButton.Click += new System.EventHandler(this.BuildAndPublishButton_Click);
            // 
            // publishCustomInstallButton
            // 
            this.publishCustomInstallButton.Location = new System.Drawing.Point(471, 206);
            this.publishCustomInstallButton.Name = "publishCustomInstallButton";
            this.publishCustomInstallButton.Size = new System.Drawing.Size(75, 23);
            this.publishCustomInstallButton.TabIndex = 4;
            this.publishCustomInstallButton.Text = "Publish";
            this.publishCustomInstallButton.UseVisualStyleBackColor = true;
            this.publishCustomInstallButton.Click += new System.EventHandler(this.publishCustomInstallButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Create custom install";
            // 
            // customInstallNameTextbox
            // 
            this.customInstallNameTextbox.Location = new System.Drawing.Point(120, 208);
            this.customInstallNameTextbox.Name = "customInstallNameTextbox";
            this.customInstallNameTextbox.Size = new System.Drawing.Size(345, 20);
            this.customInstallNameTextbox.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 239);
            this.Controls.Add(this.customInstallNameTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.publishCustomInstallButton);
            this.Controls.Add(this.BuildAndPublishButton);
            this.Controls.Add(this.WriteTestSettingsButton);
            this.Controls.Add(this.PublishButton);
            this.Controls.Add(this.InstallButton);
            this.Controls.Add(this.MsBuildButton);
            this.Controls.Add(this.MoveButton);
            this.Name = "Form1";
            this.Text = "AlgBuild";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MoveButton;
        private System.Windows.Forms.Button InstallButton;
        private System.Windows.Forms.Button WriteTestSettingsButton;
        private System.Windows.Forms.Button MsBuildButton;
        private System.Windows.Forms.Button PublishButton;
        private System.Windows.Forms.Button BuildAndPublishButton;
        private System.Windows.Forms.Button publishCustomInstallButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox customInstallNameTextbox;
    }
}

