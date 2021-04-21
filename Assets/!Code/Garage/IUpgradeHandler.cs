namespace Garage
{
    public interface IUpgradeHandler
    {
        IUpgradable Upgrade(IUpgradable upgradable);
    }
}