using Garage;
using UnityEngine;


namespace Profile
{
    internal sealed class Car : IUpgradable
    {
        private readonly float _defaultSpeed;
        
        public float Speed { get; set; }

        public Car(float speed)
        {
            _defaultSpeed = speed;
            Restore();
        }

        public void Restore()
        {
            Debug.Log("Restored speed");
            Speed = _defaultSpeed;
        }
    }
}

