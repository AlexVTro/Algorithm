using System;
using System.IO;
using AlgBuild.Engine;
using AlgBuild.PathSettings;

namespace AlgBuild.Executors
{
    public class PathSettingItemExecutor 
    {
        private readonly PathSettingItem _settingItem;

        public PathSettingItemExecutor(PathSettingItem settingItem)
        {
            _settingItem = settingItem;
        }

        public void Copy(string fromPath, string toPath, VersionType versionType, Lang lang)
        {
            if (_settingItem.VersionType != versionType && _settingItem.VersionType != VersionType.All)
                return;

            if (_settingItem.Lang != lang && _settingItem.Lang != Lang.All)
                return;

            var sourcePath = Path.Combine(fromPath, _settingItem.SourcePath);
            var targetPath = Path.Combine(toPath, _settingItem.TargetPath);

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            if (_settingItem.Directories != null)
                _settingItem.Directories.ForEach(d =>
                                                     {
                                                         var oldFilePath = Path.Combine(sourcePath, GetOldFileName(d));
                                                         var newFilePath = Path.Combine(targetPath, GetNewFileName(d));

                                                         DirectoryCopy(oldFilePath, newFilePath);
                                                     });

            if (_settingItem.Files != null)
                _settingItem.Files.ForEach(f =>
                                               {
                                                   var oldFilePath = Path.Combine(sourcePath, GetOldFileName(f));
                                                   var newFilePath = Path.Combine(toPath, GetNewFileName(f));

                                                   File.Copy(oldFilePath, newFilePath);
                                               });
        }

        private string GetNewFileName(string filePath)
        {
            var items = filePath.Split('|');

            return items.Length <= 1 ? Path.GetFileName(filePath) : items[1];
        }
        private string GetOldFileName(string filePath)
        {
            return filePath.Split('|')[0];
        }

        protected static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs = true)
        {
            var dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);

                // Copy the file.
                file.CopyTo(temppath, false);
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
