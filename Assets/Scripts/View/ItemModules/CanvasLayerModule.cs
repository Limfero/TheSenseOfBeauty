using UnityEngine;

namespace View.ItemModules
{
    public class CanvasLayerModule : MonoBehaviour
    {
        [SerializeField] private int _upOrder = 5;
        [SerializeField] private int _downOrder = 3;

        private Canvas _canvas;

        private void Awake()
        {
            try
            {
                _canvas = GetComponentInChildren<Canvas>();
            }
            finally
            {
                enabled = false;
            }
        }

        private void OnMouseDrag()
        {
            if (_canvas != null)
                _canvas.sortingOrder = _upOrder;
        }

        private void OnMouseUp()
        {
            if (_canvas != null)
                _canvas.sortingOrder = _downOrder;
        }
    }
}