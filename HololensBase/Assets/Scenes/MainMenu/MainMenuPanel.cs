using UnityEngine;
using System.Collections;

namespace MainMenuNs
{
    public class MainMenuPanel : MonoBehaviour
    {
        public void _SettingsClicked()
        {
            MainMenuSubscribers.Notify(MainMenuNotificationId.ActivateSettings);
        }

        public void _PracticeModeClicked()
        {
            MainMenuSubscribers.Notify(MainMenuNotificationId.ActivatePracticeMode);
        }

        public void _ObserverModeClicked()
        {
            MainMenuSubscribers.Notify(MainMenuNotificationId.ActivateObserveMode);
        }

    }
}
