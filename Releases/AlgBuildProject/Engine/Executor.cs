using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AlgBuild.BuildSettings;
using AlgBuild.BuildTypes;
using AlgBuild.Executors;

namespace AlgBuild.Engine
{
    public class Executor
    {
        private readonly string _rootPath;

        public Executor()
        {
            _rootPath = SettingsIO.FindSettingsRoot(Environment.CurrentDirectory, Constants.SettingFolderName);
        }

        public void RunAlgBuildSettings()
        {
            var algBuildSetting = SettingsIO.ReadSetting<AlgBuildSetting>(Path.Combine(_rootPath, Constants.SettingFolderName, Constants.AlgBuildSettingFileName));
            var executor = new AlgBuildSettingExecutor(algBuildSetting);
            executor.Execute(_rootPath);
        }
        
        public void RunPathSettings()
        {
            var pathSetting = SettingsIO.ReadSetting<PathSetting>(Path.Combine(_rootPath, Constants.SettingFolderName, Constants.PathSettingFileName));
            var executor = new PathSettingExecutor(pathSetting);
            executor.Execute(_rootPath);
        }

        public void RunInstallSettings()
        {
            var installSetting = SettingsIO.ReadSetting<InstallSetting>(Path.Combine(_rootPath, Constants.SettingFolderName, Constants.InstallSettingFileName));
            var executor = new InstallSettingExecutor(installSetting);
            executor.Execute(_rootPath);
        }

        public void RunPublishSettings()
        {
            var publishSetting = SettingsIO.ReadSetting<PublishSetting>(Path.Combine(_rootPath, Constants.SettingFolderName, Constants.PublishSettingFileName));
            var executor = new PublishSettingExecutor(publishSetting);
            executor.Execute(_rootPath);
        }

        public void WriteTestSettings()
        {
            var testAlgBuildSettings =
                new AlgBuildSetting
                {
                    RegeditFrameworkPath = @"SOFTWARE\Microsoft\MSBuild\ToolsVersions\2.0",
                    RegeditFrameworkKey = "MSBuildToolsPath",

                    AlgMsBuildSetting = new AlgMsBuildSetting
                    {
                        SolutionPath = @"Algoritm 2\Algoritm 2.sln",
                        BaseMsBuildParams = "/p:Configuration=Release /t:Rebuild /clp:ErrorsOnly",
                        FinalExePath = @"Algoritm 2\Slot\bin\Release",
                    },


                    BuildSettingItems = new List<AlgBuildSettingItem>
                                                {
                                                    new AlgBuildSettingItem
                                                        {
                                                            VersionType = VersionType.Free,
                                                            Lang = Lang.Ru,
                                                            AddMsBuilsParams = "/p:DefineConstants=\"Ver=Free;Lang=Ru\""
                                                        }
                                                }
                };

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


            var testSettingPath = Path.Combine(_rootPath, Constants.SettingFolderName, "Test{0}");
            SettingsIO.WriteSetting(string.Format(testSettingPath, Constants.AlgBuildSettingFileName), testAlgBuildSettings);
            SettingsIO.WriteSetting(string.Format(testSettingPath, Constants.PathSettingFileName), testPathSettings);
            SettingsIO.WriteSetting(string.Format(testSettingPath, Constants.InstallSettingFileName), testInstallSettings);
            SettingsIO.WriteSetting(string.Format(testSettingPath, Constants.PublishSettingFileName), testPublishSettings);
        }
    }
}
