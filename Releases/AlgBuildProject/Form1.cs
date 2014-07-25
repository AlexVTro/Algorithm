using System;
using System.Windows.Forms;
using AlgBuild.Engine;

namespace AlgBuild
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Executor _executor;
        protected Executor Executor
        {
            get { return _executor ?? (_executor = new Executor()); }
        }

        private void WriteTestSettingsButtonClick(object sender, EventArgs e)
        {
            Executor.WriteTestSettings();

            MessageBox.Show("Write test settings success");
        }
        
        private void MsBuildButtonClick(object sender, EventArgs e)
        {
            Executor.RunAlgBuildSettings();

            MessageBox.Show("Build success");
        }

        private void MoveButtonClick(object sender, EventArgs e)
        {
            Executor.RunPathSettings();

            MessageBox.Show("Move success");
        }

        private void ButtonInstallClick(object sender, EventArgs e)
        {
            Executor.RunInstallSettings();

            MessageBox.Show("Install success");
        }

        private void PublishButton_Click(object sender, EventArgs e)
        {
            Executor.RunPublishSettings();

            MessageBox.Show("Publish success");
        }

        private void BuildAndPublishButton_Click(object sender, EventArgs e)
        {
            Executor.RunAlgBuildSettings();
            Executor.RunPathSettings();
            Executor.RunInstallSettings();
            Executor.RunPublishSettings();

            MessageBox.Show("Build & Publish success");
        }

        private void publishCustomInstallButton_Click(object sender, EventArgs e)
        {
            var customInstallLink = Executor.RunCustomInstallSettings(customInstallNameTextbox.Text);
            customInstallNameTextbox.Text = "Ваш дистрибутив: " + customInstallLink;
            MessageBox.Show("Custom Install success. Link copy to clipboard");
            Clipboard.SetText(customInstallNameTextbox.Text);
        }
    }
}
