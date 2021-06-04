using System;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.UI;


namespace Notifications
{
    public class NotificationWindow : MonoBehaviour
    {
        private const string ANDROID_NOTIFIER_ID = "android_notifier_id";

        [SerializeField] private Button _buttonNotification;

        private void Start()
        {
            _buttonNotification.onClick.AddListener(CreateNotification);
        }

        private void OnDestroy()
        {
            _buttonNotification.onClick.RemoveAllListeners();
        }

        private void CreateNotification()
        {
#if UNITY_ANDROID
            var androidSettingsChannel = new AndroidNotificationChannel
            {
                Id = ANDROID_NOTIFIER_ID,
                Name = "New Unreal Engine Project",
                Importance = Importance.High,
                CanBypassDnd = true,
                CanShowBadge = true,
                Description = "Enter the game to enter the game!",
                EnableLights = true,
                EnableVibration = true,
                LockScreenVisibility = LockScreenVisibility.Public
            };

            AndroidNotificationCenter.RegisterNotificationChannel(androidSettingsChannel);

            var androidSettingsNotification = new AndroidNotification
            {
                Color = Color.black,
                RepeatInterval = TimeSpan.FromSeconds(1),
                Title = "New Unreal Engine Project",
                Text = "Enter the game to enter the game!"
            };

            AndroidNotificationCenter.SendNotification(androidSettingsNotification,
                ANDROID_NOTIFIER_ID);
#elif UNITY_IOS
            var iosSettingsNotification = new iOSNotification
            {
            Identifier = "android_notifier_id",
            Title = "Game Notifier",
            Subtitle = "Subtitle notifier",
            Body = "Enter the game and get free crystals",
            Badge = 1,
            Data = "01/02/2021",
            ForegroundPresentationOption = PresentationOption.Alert,
            ShowInForeground = false
            };
      
            iOSNotificationCenter.ScheduleNotification(iosSettingsNotification);
#endif
        }
    }
}