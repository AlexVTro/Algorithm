using System.Collections.Generic;
using System.Xml.Serialization;
using AlgBuild.BuildTypes;
using AlgBuild.Engine;

namespace AlgBuild.BuildSettings
{
    public class PublishSettingItem
    {
        [XmlAttribute]
        public string Name { get; set; }
        
        [XmlAttribute]
        public VersionType VersionType { get; set; }
        
        [XmlAttribute]
        public Lang Lang { get; set; }

        public string TargetPath { get; set; }
        public string TargetName { get; set; }
    }
}
