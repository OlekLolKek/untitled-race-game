using Abilities;
using Tools;
using UnityEngine;


namespace Game
{
    internal sealed class CarController : BaseController, IAbilityActivator
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/Car"};
        private readonly CarView _carView;
        
        public CarController()
        {
            _carView = LoadView();
        }

        private CarView LoadView()
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<CarView>();
        }

        public GameObject GetViewObject()
        {
            return _carView.gameObject;
        }
    } 
}

