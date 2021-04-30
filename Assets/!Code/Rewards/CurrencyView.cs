using System;
using TMPro;
using UnityEngine;


namespace Rewards
{
    public class CurrencyView : MonoBehaviour
    {
        private const string COIN_KEY = nameof(COIN_KEY);
        private const string PREMIUM_COIN_KEY = nameof(PREMIUM_COIN_KEY);

        public static CurrencyView Instance;

        [SerializeField] private TMP_Text _currentCountCoin;
        [SerializeField] private TMP_Text _currentCountPremiumCoin;

        private int Coins
        {
            get => PlayerPrefs.GetInt(COIN_KEY, 0);
            set => PlayerPrefs.SetInt(COIN_KEY, value);
        }

        private int PremiumCoins
        {
            get => PlayerPrefs.GetInt(PREMIUM_COIN_KEY, 0);
            set => PlayerPrefs.SetInt(PREMIUM_COIN_KEY, value);
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            RefreshText();
        }

        public void AddCoins(int value)
        {
            Coins += value;
            RefreshText();
        }

        public void AddPremiumCoins(int value)
        {
            PremiumCoins += value;
            RefreshText();
        }

        private void RefreshText()
        {
            _currentCountCoin.text = Coins.ToString();
            _currentCountPremiumCoin.text = PremiumCoins.ToString();
        }
    }
}