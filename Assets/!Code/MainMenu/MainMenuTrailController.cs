using Tools;
using UnityEngine;


namespace Ui
{
    public class MainMenuTrailController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath
        {
            PathResource = "Prefabs/trailCursor"
        };

        private readonly MainMenuTrailView _view;

        public MainMenuTrailController()
        {
            _view = LoadView();
            _view.Init();
        }

        private MainMenuTrailView LoadView()
        {
            GameObject objectView = 
                Object.Instantiate(
                    ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objectView);
            return objectView.GetComponent<MainMenuTrailView>();
        }
    }
}