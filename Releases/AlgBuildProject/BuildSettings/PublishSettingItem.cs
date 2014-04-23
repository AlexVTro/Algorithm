using AlgBuild.BuildSettings.Item;

namespace AlgBuild.BuildSettings
{
    public class PublishSettingItem : SettingItem
    {
        public string TargetPath { get; set; }
        public string TargetName { get; set; }
    }
}
