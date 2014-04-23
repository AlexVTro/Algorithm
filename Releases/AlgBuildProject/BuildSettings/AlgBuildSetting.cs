using System.Collections.Generic;

namespace AlgBuild.BuildSettings
{
    public class AlgBuildSetting
    {
        public string RegeditFrameworkPath { get; set; }
        public string RegeditFrameworkKey { get; set; }

        public AlgMsBuildSetting AlgMsBuildSetting { get; set; }

        public List<AlgBuildSettingItem> BuildSettingItems { get; set; }

    }
}
