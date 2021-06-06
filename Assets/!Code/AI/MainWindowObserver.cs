using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;


namespace AI
{
    public class MainWindowObserver : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyCountText;
        [SerializeField] private TMP_Text _healthCountText;
        [SerializeField] private TMP_Text _forceCountText;

        [SerializeField] private TMP_Text _enemyForceCountText;

        [SerializeField] private Button _addCoinsButton;
        [SerializeField] private Button _minusCoinsButton;

        [SerializeField] private Button _addHealthButton;
        [SerializeField] private Button _minusHealthButton;

        [SerializeField] private Button _addForceButton;
        [SerializeField] private Button _minusForceButton;

        [SerializeField] private Button _fightButton;

        [SerializeField] private AIDataModel _aiMoneyModel;
        [SerializeField] private AIDataModel _aiForceModel;
        [SerializeField] private AIDataModel _aiHealthModel;
        [SerializeField] private AIDataModel _aiEnemyForceModel;

        private int _allCountMoneyPlayer;
        private int _allCountHealthPlayer;
        private int _allCountForcePlayer;

        private Money _money;
        private Health _health;
        private Force _force;

        private Enemy _enemy;
        
        private const string LOCALIZATION_TABLE_NAME = "AISceneText";
        private const string PLAYERS_MONEY_KEY = "players_money";
        private const string PLAYERS_HEALTH_KEY = "players_health";
        private const string PLAYERS_POWER_KEY = "players_power";
        private const string FORCE_COUNT_KEY = "force_count";

        private void Start()
        {
            _enemy = new Enemy("Enemy Biker");

            _money = new Money(nameof(Money));
            _money.Attach(_enemy);

            _health = new Health(nameof(Health));
            _health.Attach(_enemy);

            _force = new Force(nameof(Force));
            _force.Attach(_enemy);

            _addCoinsButton.onClick.AddListener(() => ChangeMoney(true));
            _minusCoinsButton.onClick.AddListener((() => ChangeMoney(false)));

            _addHealthButton.onClick.AddListener(() => ChangeHealth(true));
            _minusHealthButton.onClick.AddListener(() => ChangeHealth(false));

            _addForceButton.onClick.AddListener(() => ChangeForce(true));
            _minusForceButton.onClick.AddListener(() => ChangeForce(false));

            _fightButton.onClick.AddListener(Fight);
        }

        private void ChangeMoney(bool isAddCount)
        {
            if (isAddCount)
            {
                _allCountMoneyPlayer++;
            }
            else
            {
                _allCountMoneyPlayer--;
            }

            StartCoroutine(ChangeDataWindow(_allCountMoneyPlayer, DataType.Money));
        }

        private void ChangeHealth(bool isAddCount)
        {
            if (isAddCount)
            {
                _allCountHealthPlayer++;
            }
            else
            {
                _allCountHealthPlayer--;
            }

            StartCoroutine(ChangeDataWindow(_allCountHealthPlayer, DataType.Health));
        }

        private void ChangeForce(bool isAddCount)
        {
            if (isAddCount)
            {
                _allCountForcePlayer++;
            }
            else
            {
                _allCountForcePlayer--;
            }

            StartCoroutine(ChangeDataWindow(_allCountForcePlayer, DataType.Force));
        }

        private void Fight()
        {
            Debug.Log(_allCountForcePlayer >= _enemy.Force
                ? "<color=#07FF00>Win!!!</color>"
                : "<color=#FF0000>Lose!!!</color>");
        }

        private IEnumerator ChangeDataWindow(int countChangeData, DataType dataType)
        {
            StringTable table;

            var loadingOperation =
                LocalizationSettings.StringDatabase.GetTableAsync(LOCALIZATION_TABLE_NAME);
            yield return loadingOperation;

            if (loadingOperation.Status == AsyncOperationStatus.Succeeded)
            {
                table = loadingOperation.Result;
            }
            else
            {
                throw new Exception
                    ($"Could not load String Table{loadingOperation.OperationException}");
            }

            switch (dataType)
            {
                case DataType.Money:
                    _moneyCountText.text =
                        $"{table.GetEntry(PLAYERS_MONEY_KEY)?.GetLocalizedString()} {countChangeData.ToString()}";
                    _money.Money = countChangeData;
                    _aiMoneyModel._playerMoney = countChangeData;
                    break;
                case DataType.Health:
                    _healthCountText.text =
                        $"{table.GetEntry(PLAYERS_HEALTH_KEY)?.GetLocalizedString()} {countChangeData.ToString()}";
                    _health.Health = countChangeData;
                    _aiHealthModel._playerHealth = countChangeData;
                    break;
                case DataType.Force:
                    _forceCountText.text =
                        $"{table.GetEntry(PLAYERS_POWER_KEY)?.GetLocalizedString()} {countChangeData.ToString()}";
                    _force.Force = countChangeData;
                    _aiForceModel._playerForce = countChangeData;
                    break;
            }

            _enemyForceCountText.text = $"{table.GetEntry(FORCE_COUNT_KEY)?.GetLocalizedString()} {_enemy.Force}";
            _aiEnemyForceModel._enemyForce = _enemy.Force;
        }
    }
}