namespace AlgBuild.Engine
{
    public static class Constants
    {
        // Common
        public const string SettingFolderName = "Releases";

        public const string AlgBuildSettingFileName = "AlgBuildSettings.xml";
        public const string PathSettingFileName = "PathSettings.xml";
        public const string InstallSettingFileName = "InstallSettings.xml";
        public const string PublishSettingFileName = "PublishSettings.xml";
        public const string CustomInstallSettingFileName = "CustomInstallSettings.xml";

        // AlgBuild
        public const string ExesFolderName = SettingFolderName + @"\Exes";
        public const string ExesNamePattern = "Algoritm{0}{1}.exe";

        // Paths
        public const string UnpackedFolderName = SettingFolderName + @"\Unpacked";

        // Installs
        public const string InstallsFolderName = SettingFolderName + @"\Installs";
        public const string InstallNamePattern = "Algorithm{0}{1}.exe";

        public const string InstallsScriptFolderName = InstallsFolderName + @"\InnoSetups";
        public const string InstallsScriptNamePattern = "{0}{1}.iss";

        // Publish
        public const string PublishFolderName = SettingFolderName + @"\Publish";

        // CustomInstall
        public const string CustomInstallsScriptName = "CustomInstallFreeRu.iss";

    }
}
