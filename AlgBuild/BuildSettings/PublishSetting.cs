using System.Collections.Generic;

namespace AlgBuild.BuildSettings
{
    public class PublishSetting
    {
        public PublishFtpSetting PublishFtpSetting { get; set; }
        public List<PublishSettingItem> PublishSettings { get; set; }
    }
}
