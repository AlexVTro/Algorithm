using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlgBuild.BuildSettings;
using AlgBuild.BuildTypes;
using AlgBuild.Engine;

namespace AlgBuild.Executors
{
    public class PathSettingExecutor 
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
        
        private readonly PathSetting _pathSetting;

        public PathSettingExecutor(PathSetting pathPathSetting)
        {
            _pathSetting = pathPathSetting;
        }

        public void Execute(string rootPath)
        {
           // получить экзекуторы для каждого сеттинг айтема
            var executors = _pathSetting.PathSettings.Select(ps => new PathSettingItemExecutor(ps)).ToList();

            // Для каждой версии выполнить все эксекуторы
            foreach (var neededVersion in NeededVersions)
            {
                var versionFolderName = neededVersion.Item1.ToString() + neededVersion.Item2.ToString();
                var versionFolderPath = Path.Combine(rootPath, Constants.UnpackedFolderName, versionFolderName);

                if (Directory.Exists(versionFolderPath))
                {
                    Directory.Delete(versionFolderPath, true);
                }

                Directory.CreateDirectory(versionFolderPath);

                executors.ForEach(e =>
                                  e.Execute(rootPath, versionFolderPath, neededVersion.Item1, neededVersion.Item2));
            }
        }
    }
}
