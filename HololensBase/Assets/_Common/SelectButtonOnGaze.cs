using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HoloBasicsNs
 {
    [RequireComponent(typeof(Collider))]
    public class SelectButtonOnGaze : MonoBehaviour
    {
        Button button;

        void Start()
        {
            button = transform.parent.GetComponent<Button>();
            if (button == null)
                Debug.Log("Required button attached to  " + transform.parent.gameObject.name);
        }

        void OnGazeEnter()
        {
            button.Select();
        }

        void OnSelect()
        {
            var pointerData = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(button.gameObject, pointerData, ExecuteEvents.pointerClickHandler);
        }
        void OnGazeLeave()
        {
            //  if (EventSystem.current.currentSelectedGameObject ==  transform.parent.gameObject)
            {

                EventSystem.current.SetSelectedGameObject(null);

            }
        }

    }

}
