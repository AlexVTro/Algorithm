using System;
using System.IO;
using System.Linq;
using AlgBuild.BuildSettings;
using AlgBuild.Engine;

namespace AlgBuild.Executors
{
    public class CustomInstallSettingExecutor
    {
        private readonly CustomInstallSetting _customInstallSetting;
        private readonly PublishSetting _publishSetting;
        private readonly InstallSetting _installSetting;

        public CustomInstallSettingExecutor(CustomInstallSetting customInstallSetting, PublishSetting publishSetting, InstallSetting installSetting)
        {
            _customInstallSetting = customInstallSetting;
            _publishSetting = publishSetting;
            _installSetting = installSetting;
        }

        public string Execute(string rootPath, string referralName)
        {
            var sourcePath = Path.Combine(rootPath, Constants.SettingFolderName, _customInstallSetting.SourcePath);
            var destinationPath = Path.Combine(rootPath, Constants.SettingFolderName, _customInstallSetting.DestinationPath);
            var filePath = Path.Combine(destinationPath, _customInstallSetting.ReferralFile);

            if (!Directory.Exists(sourcePath))
                throw new Exception("Can't find " + sourcePath);

            // Copy unpacked
            if (Directory.Exists(destinationPath))
                Directory.Delete(destinationPath, true);
            PathSettingItemExecutor.DirectoryCopy(sourcePath, destinationPath);
            File.WriteAllText(filePath, referralName);

            // Install
            var customInstallPath = Path.Combine(rootPath, Constants.InstallsFolderName, _customInstallSetting.InstallFile);

            if (File.Exists(customInstallPath))
                File.Delete(customInstallPath);

            InstallSettingExecutor.CreateInstall(rootPath, Constants.CustomInstallsScriptName, _installSetting);

            // Publish
            var customInstallPublishFile = "Algoritm_" + referralName + ".exe";
            var customInstallPublishPath = Path.Combine(rootPath, Constants.PublishFolderName, "CustomInstalls",customInstallPublishFile);
            var publishUri = PublishSettingItemExecutor.UriCombine(_publishSetting.PublishFtpSetting.FtpUrl, _customInstallSetting.PublishPath, customInstallPublishFile);

            if (File.Exists(customInstallPublishPath))
                File.Delete(customInstallPublishPath);
            File.Copy(customInstallPath, customInstallPublishPath);

            PublishSettingItemExecutor.UploadFile(customInstallPublishPath, publishUri, _publishSetting.PublishFtpSetting);

            // Result
            return PublishSettingItemExecutor.UriCombine("http://Algoritm2.ru", _customInstallSetting.PublishPath, customInstallPublishFile).AbsoluteUri;
        }

        
    }
}
