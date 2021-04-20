﻿using Game.InputLogic;
using Game.TapeBackground;
using Inventory;
using Profile;
using Tools;
using UnityEngine;

namespace Game
{
    internal sealed class GameController : BaseController
    {
        public GameController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            SubscriptionProperty<float> leftMoveDiff = new SubscriptionProperty<float>();
            SubscriptionProperty<float> rightMoveDiff = new SubscriptionProperty<float>();

            InventoryModel inventoryModel = new InventoryModel();
            
            TapeBackgroundController tapeBackgroundController = 
                new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            
            AddController(tapeBackgroundController);
            
            InputGameController inputGameController = 
                new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            
            AddController(inputGameController);
            
            CarController carController = 
                new CarController();
            
            AddController(carController);
            
            InventoryController inventoryController = 
                new InventoryController(inventoryModel);
            
            AddController(inventoryController);
        }
    }
}

