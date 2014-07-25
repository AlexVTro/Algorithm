using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using AlgBuild.BuildSettings;
using AlgBuild.BuildTypes;
using AlgBuild.Engine;

namespace AlgBuild.Executors
{
    public class InstallSettingExecutor 
    {
        private static readonly List<Tuple<VersionType, Lang>> NeededVersions =
            new List<Tuple<VersionType, Lang>>
                {
                    new Tuple<VersionType, Lang>(VersionType.Free, Lang.Ru),
                    new Tuple<VersionType, Lang>(VersionType.Free, Lang.En),
                    new Tuple<VersionType, Lang>(VersionType.Full, Lang.Ru),
                    new Tuple<VersionType, Lang>(VersionType.Full, Lang.En),
                };

        private readonly InstallSetting _installSetting;

        public InstallSettingExecutor(InstallSetting installSetting)
        {
            _installSetting = installSetting;
        }

        public void Execute(string rootPath)
        {
            foreach (var neededVersion in NeededVersions)
            {
                var installSetupScriptName = string.Format(Constants.InstallsScriptNamePattern,
                                                        neededVersion.Item1.ToString(),
                                                        neededVersion.Item2.ToString());

                CreateInstall(rootPath, installSetupScriptName, _installSetting);
            }
        }

        public static void CreateInstall(string rootPath, string installSetupScriptName, InstallSetting installSetting)
        {
            
            var installSetupScript = Path.Combine(rootPath, Constants.InstallsScriptFolderName,
                                                  installSetupScriptName);

            var processStartInfo = new ProcessStartInfo(installSetting.InnoSetupCompilerPath, installSetupScript);
            var process = Process.Start(processStartInfo);

            process.WaitForExit();

            if (process.ExitCode == 1)
            {
                throw new Exception("command line parameters were invalid: " + installSetupScript);
            }

            if (process.ExitCode == 2)
            {
                throw new Exception("the compile failed: " + installSetupScript);
            }
        }
    }
}
