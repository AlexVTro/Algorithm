using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlgBuild.BuildSettings;
using AlgBuild.BuildTypes;
using AlgBuild.Engine;

namespace AlgBuild.Executors
{
    public class AlgBuildSettingExecutor
    {
        private static readonly List<Tuple<VersionType, Lang>> NeededVersions =
            new List<Tuple<VersionType, Lang>>
                {
                    new Tuple<VersionType, Lang>(VersionType.Free, Lang.Ru),
                    new Tuple<VersionType, Lang>(VersionType.Free, Lang.En),
                    new Tuple<VersionType, Lang>(VersionType.Full, Lang.Ru),
                    new Tuple<VersionType, Lang>(VersionType.Full, Lang.En),
                    new Tuple<VersionType, Lang>(VersionType.Http, Lang.En),
                };

        private readonly AlgBuildSetting _algBuildSetting;

        public AlgBuildSettingExecutor(AlgBuildSetting algBuildSetting)
        {
            _algBuildSetting = algBuildSetting;
        }

        public void Execute(string rootPath)
        {
            if (!Directory.Exists(Path.Combine(rootPath, Constants.ExesFolderName)))
            {
                Directory.CreateDirectory(Path.Combine(rootPath, Constants.ExesFolderName));
            }

            var executors = _algBuildSetting.BuildSettingItems.Select(bs => new AlgBuildSettingItemExecutor(bs)).ToList();

            var msbuildPath = Microsoft.Win32.Registry.LocalMachine
                .OpenSubKey(_algBuildSetting.RegeditFrameworkPath)
                .GetValue(_algBuildSetting.RegeditFrameworkKey).ToString();

            msbuildPath = Path.Combine(msbuildPath, "msbuild.exe");

            foreach (var neededVersion in NeededVersions)
            {
                executors.ForEach(
                    e =>
                    e.Execute(rootPath, msbuildPath, _algBuildSetting.AlgMsBuildSetting, neededVersion.Item1, neededVersion.Item2));
            }
        }

        
    }
}
