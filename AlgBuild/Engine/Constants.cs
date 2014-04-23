namespace AlgBuild.Engine
{
    public static class Constants
    {
        // Common
        public const string SettingFolderName = "Releases";

        public const string PathSettingFileName = "PathSettings.txt";
        public const string InstallSettingFileName = "InstallSettings.txt";
        public const string PublishSettingFileName = "PublishSettings.txt";

        // Paths
        public const string UnpackedFolderName = SettingFolderName + @"\Unpacked";

        // Installs
        public const string InstallsFolderName = SettingFolderName + @"\Installs";
        public const string InstallNamePattern = "Algorithm{0}{1}.exe";

        public const string InstallsScriptFolderName = InstallsFolderName + @"\InnoSetups";
        public const string InstallsScriptNamePattern = "{0}{1}.iss";

        // Publish
        public const string PublishFolderName = SettingFolderName + @"\Publish";

    }
}
