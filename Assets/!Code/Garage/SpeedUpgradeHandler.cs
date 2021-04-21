namespace Garage
{
    public class SpeedUpgradeHandler : IUpgradeHandler
    {
        private readonly float _speed;

        public SpeedUpgradeHandler(float speed)
        {
            _speed = speed;
        }

        public IUpgradable Upgrade(IUpgradable upgradable)
        {
            upgradable.Speed = _speed;
            return upgradable;
        }
    }
}