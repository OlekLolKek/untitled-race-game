using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Rewards
{
    public class DailyRewardView : MonoBehaviour
    {
        private const string CURRENT_SLOT_IN_ACTIVE_KEY = nameof(CURRENT_SLOT_IN_ACTIVE_KEY);
        private const string TIME_GET_REWARD_KEY = nameof(TIME_GET_REWARD_KEY);

        [Header("Settings Time Get Reward")] 
        [SerializeField] private float _timeCooldown = 86400;
        [SerializeField] private float _timeDeadLine = 172800;

        [Header("Settings Rewards")] 
        [SerializeField] private List<Reward> _rewards;

        [Header("UI Elements")] 
        [SerializeField] private TMP_Text _timerNewReward;
        [SerializeField] private Transform _mountRootSlotsReward;
        [SerializeField] private ContainerSlotRewardView _containerSlotRewardView;
        [SerializeField] private Button _getRewardButton;
        [SerializeField] private Button _resetButton;

        public float TimeCooldown => _timeCooldown;
        public float TimeDeadLine => _timeDeadLine;
        public List<Reward> Rewards => _rewards;
        public TMP_Text TimerNewReward => _timerNewReward;
        public Transform MountRootSlotsReward => _mountRootSlotsReward;
        public ContainerSlotRewardView ContainerSlotRewardView => _containerSlotRewardView;
        public Button GetRewardButton => _getRewardButton;
        public Button ResetButton => _resetButton;

        public int CurrentSlotInActive
        {
            get => PlayerPrefs.GetInt(CURRENT_SLOT_IN_ACTIVE_KEY, 0);
            set => PlayerPrefs.SetInt(CURRENT_SLOT_IN_ACTIVE_KEY, value);
        }

        public DateTime? TimeGetReward
        {
            get
            {
                var data = PlayerPrefs.GetString(TIME_GET_REWARD_KEY, null);

                if (!string.IsNullOrEmpty(data))
                    return DateTime.Parse(data);

                return null;
            }
            set
            {
                if (value != null)
                {
                    PlayerPrefs.SetString(TIME_GET_REWARD_KEY, value.ToString());
                }
                else
                {
                    PlayerPrefs.DeleteKey(TIME_GET_REWARD_KEY);
                }
            }
        }

        private void OnDestroy()
        {
            _getRewardButton.onClick.RemoveAllListeners();
            _resetButton.onClick.RemoveAllListeners();
        }
    }
}