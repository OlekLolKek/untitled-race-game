using UnityEngine;


namespace Rewards
{
    [System.Serializable]
    public class Reward
    {
        [SerializeField] private RewardType _rewardType;
        [SerializeField] private Sprite _iconCurrency;
        [SerializeField] private int _countCurrency;

        public RewardType RewardType => _rewardType;
        public Sprite IconCurrency => _iconCurrency;
        public int CountCurrency => _countCurrency;
    }
}