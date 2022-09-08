using UnityEngine;

namespace Scripts.UI
{
    [ExecuteAlways]
    public class Pointer : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Transform _worldPointer;
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _pointerIconTransform;

        private void Update()
        {
            var position = _playerTransform.position;
            var direction = transform.position - position;
            Debug.DrawRay(position, direction);

            var ray = new Ray(position, direction);

            var planes = GeometryUtility.CalculateFrustumPlanes(_camera);

            var minDistance = Mathf.Infinity;
            
            for (var i = 0; i < planes.Length; i++)
            {
                if (planes[i].Raycast(ray, out var distance))
                {
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                    }
                }
            }

            minDistance = Mathf.Clamp(minDistance,0, direction.magnitude);        
            var worldPosition = ray.GetPoint(minDistance);
            _worldPointer.position = worldPosition;

            _pointerIconTransform.position = _camera.WorldToScreenPoint(worldPosition);
        }
    }
}