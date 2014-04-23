using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AlgBuild.BuildSettings;
using AlgBuild.BuildTypes;
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
        
        private void ButtonBuildClick(object sender, EventArgs e)
        {
            //Executor.RunPathSettings();
            Executor.RunInstallSettings();

            MessageBox.Show("Build success");
        }

        private void ButtonPublishClick(object sender, EventArgs e)
        {
            Executor.RunPublishSettings();

            MessageBox.Show("Publish success");
        }

        private void ButtonWriteTestSettings_Click(object sender, EventArgs e)
        {
            var testPathSettings = new PathSetting()
            {
                PathSettings =
                    new List<PathSettingItem>
                                       {
                                           new PathSettingItem
                                               {
                                                   Name = "CompilExe",
                                                   VersionType = VersionType.All,
                                                   Lang = Lang.Ru,
                                                   SourcePath = "sf",
                                                   TargetPath = "",
                                                   Directories = new List<string>{"a","b"},
                                                   Files = new List<string>{"dfa","bdf"},
                                               }
                                       }
            };

            var testInstallSettings = new InstallSetting()
            {
                InnoSetupCompilerPath = @"C:\Program Files (x86)\Inno Setup 5"
            };

            var testPublishSettings = new PublishSetting
                                          {
                                              PublishFtpSetting = new PublishFtpSetting
                                                                      {
                                                                          FtpUrl = "ftp://algoritm2.ru/www/algoritm2.ru",
                                                                          FtpUsername = "alg",
                                                                          FtpPassword = "tT2NI2gP",
                                                                      },

                                              PublishSettings =
                                                  new List<PublishSettingItem>
                                                      {
                                                          new PublishSettingItem
                                                              {
                                                                  VersionType = VersionType.Free,
                                                                  Lang = Lang.Ru,
                                                                  TargetPath = "download",
                                                                  TargetName = "Algoritm2RuLastTest.exe"
                                                              },
                                                      }
                                          };

            SettingsIO.WriteSetting("TestPathSettings.txt", testPathSettings);
            SettingsIO.WriteSetting("TestInstallSettings.txt", testInstallSettings);
            SettingsIO.WriteSetting("TestPublishSettings.txt", testPublishSettings);
        }

    }
}
