using System.Collections.Generic;
using AlgBuild.BuildSettings.Item;

namespace AlgBuild.BuildSettings
{
    public class PathSettingItem : SettingItem
    {
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }

        public List<string> Directories { get; set; }
        public List<string> Files { get; set; }
    }
}
