using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AlgBuild.BuildSettings;
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
            //var publishSetting = SettingsIO.ReadSetting<InstallSetting>(Path.Combine(_rootPath, Constants.SettingFolderName, Constants.PathSettingFileName));
            var executor = new PublishSettingExecutor(new PublishSetting());
            executor.Execute(_rootPath);
        }
    }
}
