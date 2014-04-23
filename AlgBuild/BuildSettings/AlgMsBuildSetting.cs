using System.Collections.Generic;

namespace AlgBuild.BuildSettings
{
    public class AlgMsBuildSetting
    {
        public string SolutionPath { get; set; }
        public string BaseMsBuildParams { get; set; }
        public string FinalExePath { get; set; }
    }
}
