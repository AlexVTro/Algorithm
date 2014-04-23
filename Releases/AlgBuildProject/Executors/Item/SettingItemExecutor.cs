using AlgBuild.BuildSettings.Item;
using AlgBuild.BuildTypes;

namespace AlgBuild.Executors.Item
{
    public abstract class SettingItemExecutor<T> where T:SettingItem
    {
        protected readonly T SettingItem;

        protected SettingItemExecutor(T settingItem)
        {
            SettingItem = settingItem;
        }

        public bool CanExecute(VersionType versionType, Lang lang)
        {
            if (SettingItem.VersionType != versionType && SettingItem.VersionType != VersionType.All)
                return false;

            if (SettingItem.Lang != lang && SettingItem.Lang != Lang.All)
                return false;

            return true;
        }
    }
}
