using System.Collections.Generic;
using System.Xml.Serialization;
using AlgBuild.BuildTypes;
using AlgBuild.Engine;

namespace AlgBuild.BuildSettings
{
    public class PathSettingItem
    {
        [XmlAttribute]
        public string Name { get; set; }
        
        [XmlAttribute]
        public VersionType VersionType { get; set; }
        
        [XmlAttribute]
        public Lang Lang { get; set; }

        public string SourcePath { get; set; }
        public string TargetPath { get; set; }

        public List<string> Directories { get; set; }
        public List<string> Files { get; set; }
    }
}
