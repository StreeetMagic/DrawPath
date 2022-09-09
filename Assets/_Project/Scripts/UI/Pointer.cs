using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    [ExecuteAlways]
    public class Pointer : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _pointerIconTransform;
        [SerializeField] private Image _image;

        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Vector3 _offcet = new Vector3(5, 0, 0);

        private void Update()
        {
            LocateArrow();
            LocateText();
        }

        private void LocateText()
        {
            _text.transform.position = _image.transform.position + _offcet;

            var distance = Mathf.Round((transform.position - _playerTransform.position).magnitude);

            var text = distance.ToString() + " m";

            _text.text = text;
        }

        private void LocateArrow()
        {
            var position = _playerTransform.position;
            var direction = transform.position - position;
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

            if (minDistance > direction.magnitude)
            {
                _image.gameObject.SetActive(false);
            }
            else
            {
                _image.gameObject.SetActive(true);
            }

            minDistance = Mathf.Clamp(minDistance, 0, direction.magnitude);
            var worldPosition = ray.GetPoint(minDistance);

            _pointerIconTransform.position = _camera.WorldToScreenPoint(worldPosition);

            _pointerIconTransform.up = direction;
        }
    }
}