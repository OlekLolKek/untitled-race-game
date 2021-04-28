using UnityEngine;


namespace AI
{
    class Enemy : IEnemy
    {
        #region Fields

        private const int COINS = 5;
        private const float FORCE = 1.5f;
        private const int MAX_PLAYER_HEALTH = 20;

        private string _name;
        private int _moneyPlayer;
        private int _healthPlayer;
        private int _forcePlayer;

        #endregion

        public int Force
        {
            get
            {
                var kHealth = _healthPlayer > MAX_PLAYER_HEALTH ? 100 : 5;
                var force = (int) (_moneyPlayer / COINS + kHealth + _forcePlayer / FORCE);

                return force;
            }
        }

        public Enemy(string name)
        {
            _name = name;
        }

        #region IEnemy

        public void Update(DataPlayer dataPlayer, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Money:
                    _moneyPlayer = dataPlayer.Money;
                    break;
                case DataType.Health:
                    _healthPlayer = dataPlayer.Health;
                    break;
                case DataType.Force:
                    _forcePlayer = dataPlayer.Force;
                    break;
            }
            
            Debug.Log($"Notified {_name} change to {dataPlayer}");
        }

        #endregion
    }
}