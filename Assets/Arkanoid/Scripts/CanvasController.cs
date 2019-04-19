using UnityEngine;
using UnityEngine.UI;

namespace Assets.Arkanoid.Scripts
{
    public class CanvasController : MonoBehaviour
    {
        public Canvas TargetCanvas;
        public GraphicRaycaster TargetRaycaster;

        public void Toggle()
        {
            Set(!(TargetCanvas.enabled && TargetRaycaster.enabled));
        }

        public void Set(bool state)
        {
            TargetCanvas.enabled = state;
            if (TargetRaycaster != null)
            {
                TargetRaycaster.enabled = state;
            }
        }

        private void Awake()
        {
            var isValid = true;
            isValid &= TargetCanvas != null;
#if UNITY_EDITOR
            Debug.Assert(TargetCanvas != null, "TargetCanvas is null");
#endif
            gameObject.SetActive(isValid);
        }

#if UNITY_EDITOR

        private void OnValidate()
        {
            if (TargetCanvas == null)
            {
                TargetCanvas = GetComponent<Canvas>();
            }

            if (TargetRaycaster == null)
            {
                TargetRaycaster = GetComponent<GraphicRaycaster>();
            }
        }

        private void Reset()
        {
            OnValidate();
        }
#endif
    }
}
