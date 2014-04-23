using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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

            var filePath = Path.Combine(rootPath, Constants.SettingFolderName, Constants.InstallSettingFileName);
            UploadFile(filePath, "ftp://algoritm2.ru/" + "www/algoritm2.ru/download/" + Constants.InstallSettingFileName, "alg", "tT2NI2gP");
        }

        
    }
}
