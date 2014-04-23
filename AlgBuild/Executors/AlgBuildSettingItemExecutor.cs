using System;
using System.Diagnostics;
using System.IO;
using AlgBuild.BuildSettings;
using AlgBuild.BuildTypes;
using AlgBuild.Engine;
using AlgBuild.Executors.Item;

namespace AlgBuild.Executors
{
    public class AlgBuildSettingItemExecutor:SettingItemExecutor<AlgBuildSettingItem>
    {
        public AlgBuildSettingItemExecutor(AlgBuildSettingItem settingItem)
            : base(settingItem)
        {
        }

        public void Execute(string rootPath, string msbuildPath, AlgMsBuildSetting algMsBuildSetting, VersionType versionType, Lang lang)
        {
            if (!CanExecute(versionType, lang))
                return;

            // compile exe
            var compileArgs = algMsBuildSetting.BaseMsBuildParams + " " + SettingItem.AddMsBuilsParams + " \"" +
                              Path.Combine(rootPath, algMsBuildSetting.SolutionPath) + "\"";

            var processStartInfo = new ProcessStartInfo(msbuildPath, compileArgs)
                                       {
                                           UseShellExecute = false,
                                           RedirectStandardOutput = true,
                                           StandardOutputEncoding = System.Text.Encoding.GetEncoding(866),
                                           RedirectStandardError = true,
                                           StandardErrorEncoding = System.Text.Encoding.GetEncoding(866),
                                       };

            var process = Process.Start(processStartInfo);
            var outputs = process.StandardOutput.ReadToEnd();
            var errors = process.StandardError.ReadToEnd();

            process.WaitForExit();

            if (process.ExitCode > 0)
            {
                throw new Exception("process compil failed\n\n" + outputs + "\n\n" + errors);
            }

            // copy exe to output folder
            var destinationFileName = string.Format(Constants.ExesNamePattern, versionType.ToString(), lang.ToString());
            File.Copy(Path.Combine(rootPath, algMsBuildSetting.FinalExePath),
                      Path.Combine(rootPath, Constants.ExesFolderName, destinationFileName), true);
        }
    }
}