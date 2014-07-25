using System.IO;
using AlgBuild.BuildSettings;
using AlgBuild.BuildTypes;
using AlgBuild.Executors.Item;

namespace AlgBuild.Executors
{
    public class PathSettingItemExecutor : SettingItemExecutor<PathSettingItem>
    {
        public PathSettingItemExecutor(PathSettingItem settingItem)
            : base(settingItem)
        {
        }

        public void Execute(string fromPath, string toPath, VersionType versionType, Lang lang)
        {
            if (!CanExecute(versionType, lang))
                return;

            var sourcePath = Path.Combine(fromPath, SettingItem.SourcePath);
            var targetPath = Path.Combine(toPath, SettingItem.TargetPath);

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            if (SettingItem.Directories != null)
                SettingItem.Directories.ForEach(d =>
                                                    {
                                                        var oldFilePath = Path.Combine(sourcePath, GetOldFileName(d));
                                                        var newFilePath = Path.Combine(targetPath, GetNewFileName(d));

                                                        DirectoryCopy(oldFilePath, newFilePath);
                                                    });

            if (SettingItem.Files != null)
                SettingItem.Files.ForEach(f =>
                                              {
                                                  var oldFilePath = Path.Combine(sourcePath, GetOldFileName(f));
                                                  var newFilePath = Path.Combine(targetPath, GetNewFileName(f));

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

        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs = true)
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
