using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlgBuild.BuildSettings;
using AlgBuild.BuildTypes;
using AlgBuild.Engine;

namespace AlgBuild.Executors
{
    public class PublishSettingExecutor
    {
        private static readonly List<Tuple<VersionType, Lang>> NeededVersions =
            new List<Tuple<VersionType, Lang>>
                {
                    new Tuple<VersionType, Lang>(VersionType.Free, Lang.Ru),
                    new Tuple<VersionType, Lang>(VersionType.Free, Lang.En),
                    new Tuple<VersionType, Lang>(VersionType.Full, Lang.Ru),
                    new Tuple<VersionType, Lang>(VersionType.Full, Lang.En),
                };

        private readonly PublishSetting _publishSetting;

        public PublishSettingExecutor(PublishSetting publishSetting)
        {
            _publishSetting = publishSetting;
        }

        public void Execute(string rootPath)
        {
            if (!Directory.Exists(Path.Combine(rootPath, Constants.PublishFolderName)))
            {
                Directory.CreateDirectory(Path.Combine(rootPath, Constants.PublishFolderName));
            }

            var executors = _publishSetting.PublishSettings.Select(ps => new PublishSettingItemExecutor(ps)).ToList();

            foreach (var neededVersion in NeededVersions)
            {
                executors.ForEach(
                    e =>
                    e.Execute(rootPath, _publishSetting.PublishFtpSetting, neededVersion.Item1, neededVersion.Item2));
            }
        }

        
    }
}
