using System.Collections.Generic;


namespace AI
{
    abstract class DataPlayer
    {
        private string _titleData;
        private int _countMoney;
        private int _countHealth;
        private int _countForce;

        private List<IEnemy> _enemies = new List<IEnemy>();
        
        protected DataPlayer(string titleData)
        {
            _titleData = titleData;
        }

        public void Attach(IEnemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void Detach(IEnemy enemy)
        {
            _enemies.Remove(enemy);
        }

        protected void Notify(DataType dataType)
        {
            foreach (var enemy in _enemies)
            {
                enemy.Update(this, dataType);
            }
        }

        public string TitleData => _titleData;

        public int Money
        {
            get => _countMoney;
            set
            {
                if (_countMoney != value)
                {
                    _countMoney = value;
                    Notify(DataType.Money);
                }
            }
        }

        public int Health
        {
            get => _countHealth;
            set
            {
                if (_countHealth != value)
                {
                    _countHealth = value;
                    Notify(DataType.Health);
                }
            }
        }

        public int Force
        {
            get => _countForce;
            set
            {
                if (_countForce != value)
                {
                    _countForce = value;
                    Notify(DataType.Force);
                }
            }
        }
    }
}