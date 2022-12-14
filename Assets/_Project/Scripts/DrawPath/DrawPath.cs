using System.Collections;
using Scripts.Player;
using UnityEngine;

namespace Scripts.DrawPath
{
    public class DrawPath : MonoBehaviour
    {
        private const float Cooldown = .05f;
        private const float Distance = 1f;

        [SerializeField] private Path _pathTemplate;
        [SerializeField] private Camera _camera;
        [SerializeField] private VisualEffects _visualEffects;

        private Vector3 _worldPosition;
        private Plane _plane = new Plane(Vector3.forward, 0);
        private Coroutine _drawingCoroutine;

        private void Update()
        {
            Draw();
        }

        private void Draw()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_drawingCoroutine != null)
                {
                    StopCoroutine(_drawingCoroutine);
                }
                _drawingCoroutine = StartCoroutine(Drawing());
            }

            if (Input.GetMouseButtonUp(0))
            {
                StopCoroutine(_drawingCoroutine);
            }
        }

        private Vector3 GetClickPosition()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            _plane.Raycast(ray, out var location);

            return _worldPosition = ray.GetPoint(location);
        }

        private IEnumerator Drawing()
        {
            var path = Instantiate(_pathTemplate, transform.position, Quaternion.identity, transform);
            var position = GetClickPosition();
            path.AddMainPoint(position);
            path.Init(_visualEffects);
            var prevPoint = position;

            while (true)
            {
                var currPoint = GetClickPosition();
                var distance = Vector3.Distance(prevPoint, currPoint);

                if (distance > Distance)
                {
                    path.AddMainPoint(_worldPosition);
                    prevPoint = currPoint;
                }

                yield return new WaitForSeconds(Cooldown);
            }
        }
    }


}