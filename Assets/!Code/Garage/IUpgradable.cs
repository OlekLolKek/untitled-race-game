namespace Garage
{
    public interface IUpgradable
    {
        float Speed { get; set; }
        void Restore();
    }
}