using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AlgBuild.Executors;
using AlgBuild.PathSettings;

namespace AlgBuild.Engine
{
    public class Executor
    {
        private const string SettingFolderName = "Releases";
        private const string SettingFileName = "Settings.txt";
        private const string UnpackedFolderName = "Unpacked";

        private static readonly List<Tuple<VersionType, Lang>> NeededVersions =
            new List<Tuple<VersionType, Lang>>
                {
                    new Tuple<VersionType, Lang>(VersionType.Free, Lang.Ru),
                    new Tuple<VersionType, Lang>(VersionType.Free, Lang.En),
                    new Tuple<VersionType, Lang>(VersionType.Full, Lang.Ru),
                    new Tuple<VersionType, Lang>(VersionType.Full, Lang.En),
                    new Tuple<VersionType, Lang>(VersionType.Http, Lang.En),
                };

        private readonly string _settingFilePath;
        private readonly string _rootPath;
        private readonly PathSetting _setting;

        public Executor()
        {
            _settingFilePath = FindSettings(Environment.CurrentDirectory);
            _rootPath = Directory.GetParent(Path.GetDirectoryName(_settingFilePath)).FullName;
            _setting = ReadSettings(_settingFilePath);
        }

        public void RunSettings()
        {
            // получить экзекуторы для каждого сеттинг айтема
            var executors = _setting.PathSettings.Select(ps => new PathSettingItemExecutor(ps)).ToList();

            // Для каждой версии выполнить все эксекуторы
            foreach (var neededVersion in NeededVersions)
            {
                var versionFolderName = neededVersion.Item1.ToString() + neededVersion.Item2.ToString();
                var versionFolderPath = Path.Combine(_rootPath, SettingFolderName, UnpackedFolderName, versionFolderName);

                if (Directory.Exists(versionFolderPath))
                {
                    Directory.Delete(versionFolderPath, true);
                }

                Directory.CreateDirectory(versionFolderPath);

                executors.ForEach(e =>
                                  e.Copy(_rootPath, versionFolderPath, neededVersion.Item1, neededVersion.Item2));
            }
        }


        private string FindSettings(string path)
        {
            if (File.Exists(Path.Combine(path, SettingFileName)))
            {
                return Path.Combine(path, SettingFileName);
            }

            if (Directory.GetDirectories(path).Contains(Path.Combine(path, SettingFolderName)))
            {
                return FindSettings(Path.Combine(path, SettingFolderName));
            }

            try
            {
                return FindSettings(Directory.GetParent(path).FullName);
            }
            catch (Exception ex)
            {
               throw new DirectoryNotFoundException(SettingFolderName, ex);
            }
        }

        private PathSetting ReadSettings(string filePath)
        {
            var fileStream = File.OpenText(filePath);

            var ser = new XmlSerializer(typeof(PathSetting));
            return (PathSetting) ser.Deserialize(fileStream);
        }
    }
}
