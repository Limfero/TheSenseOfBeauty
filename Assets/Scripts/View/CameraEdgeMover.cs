using Models;
using UnityEngine;

namespace View
{
    public class CameraEdgeMover : MonoBehaviour
    {
        [SerializeField] private CameraEdge _edge;
        [SerializeField] private Vector3 _offset;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 viewportPosition = Vector3.zero;

            switch (_edge)
            {
                case CameraEdge.Left:
                    viewportPosition = new Vector3(0, 0.5f, 0);
                    break;
                case CameraEdge.Right:
                    viewportPosition = new Vector3(1, 0.5f, 0);
                    break;
                case CameraEdge.Top:
                    viewportPosition = new Vector3(0.5f, 1, 0);
                    break;
                case CameraEdge.Bottom:
                    viewportPosition = new Vector3(0.5f, 0, 0);
                    break;
                case CameraEdge.BottomRightCorner:
                    viewportPosition = new Vector3(1, 0, 0);
                    break;
                case CameraEdge.TopLeftCorner:
                    viewportPosition = new Vector3(0, 1, 0);
                    break;
                case CameraEdge.TopRightCorner:
                    viewportPosition = new Vector3(1, 1, 0);
                    break;
            }

            Vector3 worldPosition = _camera.ViewportToWorldPoint(viewportPosition);

            transform.position = worldPosition + _offset + GetOffsetDirection();
        }

        private Vector3 GetOffsetDirection()
        {
            return _edge switch
            {
                CameraEdge.Left => Vector3.left,
                CameraEdge.Right => Vector3.right,
                CameraEdge.Top => Vector3.up,
                CameraEdge.Bottom => Vector3.down,
                CameraEdge.TopLeftCorner => new Vector3(-1, 1, 0).normalized,
                CameraEdge.TopRightCorner => new Vector3(1, 1, 0).normalized,
                CameraEdge.BottomRightCorner => new Vector3(1, -1, 0).normalized,
                _ => Vector3.zero,
            };
        }
    }
}