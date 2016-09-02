using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MainMenuNs
{

    [RequireComponent(typeof(UnityEngine.UI.Text))]
    public class ShowNotifications : MainMenuSubscribers
    {
        Text textbox;
        // Use this for initialization
        void Start()
        {
            textbox = GetComponent<Text>();
        }

        protected override void OnNotification(MainMenuNotificationId id, string param)
        {
            base.OnNotification(id, param);
            textbox.text = id.ToString();

        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
