using System.Xml.Serialization;
using AlgBuild.BuildTypes;

namespace AlgBuild.BuildSettings.Item
{
    public abstract class SettingItem
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public VersionType VersionType { get; set; }

        [XmlAttribute]
        public Lang Lang { get; set; }
    }
}