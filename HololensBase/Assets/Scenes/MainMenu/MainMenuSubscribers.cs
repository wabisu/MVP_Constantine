using UnityEngine;
using System.Collections;
using GenericNotifierNs;

namespace MainMenuNs
{
   public  enum MainMenuNotificationId
    {
        ActivateObserveMode,
        ActivatePracticeMode,
        ActivateSettings
    }

    public class MainMenuSubscribers : MonoBehaviour
    {

        static GenericNotifier<MainMenuNotificationId, string> Notifier = new GenericNotifier<MainMenuNotificationId, string>();
        public static void Notify(MainMenuNotificationId id)
        {
            Notifier.Notify(id);
        } 
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        protected virtual void OnNotification(MainMenuNotificationId id, string param)
        {
            Debug.Log(" notification " + id + " param " + (param ?? "NULL"));
        }

        protected virtual  void OnEnable()
        {
            Notifier.Subscribe(OnNotification);
        }

        protected virtual  void OnDisable()
        {
            Notifier.UnSubscribe(OnNotification);
        }
    }

}


