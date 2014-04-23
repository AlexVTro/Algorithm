using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace AlgBuild.Engine
{
    public class SettingsIO
    {
        public static string FindSettingsRoot(string path, string rootFolderName)
        {
            if (Directory.GetDirectories(path).Contains(Path.Combine(path, rootFolderName)))
            {
                return path;
            }

            try
            {
                return FindSettingsRoot(Directory.GetParent(path).FullName, rootFolderName);
            }
            catch (Exception ex)
            {
                throw new DirectoryNotFoundException(rootFolderName, ex);
            }
        }

        public static T ReadSetting<T>(string filePath) where T : class
        {
            var fileStream = File.OpenText(filePath);

            var ser = new XmlSerializer(typeof(T));
            var result = (T)ser.Deserialize(fileStream);
            fileStream.Close();

            return result;
        }

        public static void WriteSetting<T>(string filePath, T setting) where T : class
        {
            var fileStream = File.CreateText(filePath);

            var ser = new XmlSerializer(typeof(T));
            ser.Serialize(fileStream, setting);
            fileStream.Close();
        }
    }
}
