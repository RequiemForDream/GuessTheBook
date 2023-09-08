using UnityEngine;

namespace UI
{
    public class CanvasModel : MonoBehaviour
    {
        public bool IsActiveOnStart = true;

        protected Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            Show(IsActiveOnStart);
        }

        protected void Show(bool show)
        {
            _canvas.enabled = show;
        }
    }
}
