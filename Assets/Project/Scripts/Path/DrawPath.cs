using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Path
{
    public class DrawPath : MonoBehaviour
    {
        [SerializeField] private Path _pathTemplate;
        [SerializeField] private List<Path> _paths = new List<Path>();

        private Vector3 _worldPosition;
        private Plane _plane = new Plane(Vector3.forward, 0);
        private Coroutine _drawingCoroutine;

        private void Update()
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

        private IEnumerator Drawing()
        {
            var path = Instantiate(_pathTemplate, transform.position, Quaternion.identity, transform);
            _paths.Add(path);

            var prevPoint = new Vector3(0, 0, 0);
            var currPoint = new Vector3(0, 0, 0);

            while (true)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (_plane.Raycast(ray, out var distance))
                {
                    _worldPosition = ray.GetPoint(distance);
                    prevPoint = currPoint;
                    currPoint = _worldPosition;
                }
                var distance1 = Vector3.Distance(prevPoint, currPoint);

                if (distance1 > 1f)
                {
                    path.AddMainPoint(_worldPosition);
                }

                yield return new WaitForSeconds(.05f);
            }
        }
    }
}