using TMPro;
using UnityEngine;
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

        private int _allCountMoneyPlayer;
        private int _allCountHealthPlayer;
        private int _allCountForcePlayer;

        private Money _money;
        private Health _health;
        private Force _force;

        private Enemy _enemy;

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

            ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);
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

            ChangeDataWindow(_allCountHealthPlayer, DataType.Health);
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

            ChangeDataWindow(_allCountForcePlayer, DataType.Force);
        }

        private void Fight()
        {
            Debug.Log(_allCountForcePlayer >= _enemy.Force
                ? "<color=#07FF00>Win!!!</color>"
                : "<color=#FF0000>Lose!!!</color>");
        }

        private void ChangeDataWindow(int countChangeData, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Money:
                    _moneyCountText.text = $"Player Money: {countChangeData.ToString()}";
                    _money.Money = countChangeData;
                    break;
                case DataType.Health:
                    _healthCountText.text = $"Player Health: {countChangeData.ToString()}";
                    _health.Health = countChangeData;
                    break;
                case DataType.Force:
                    _forceCountText.text = $"Player Force: {countChangeData.ToString()}";
                    _force.Force = countChangeData;
                    break;
            }

            _enemyForceCountText.text = $"Enemy Force = {_enemy.Force}";
        }
    }
}