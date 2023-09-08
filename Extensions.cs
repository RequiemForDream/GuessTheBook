using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Utils
{
    public static class Extensions
    {
        public static void Deactivate(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        public static void Activate(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public static void Subscribe(Button button, UnityAction unityAction)
        {
            button.onClick.AddListener(unityAction);
        }
    }
}
