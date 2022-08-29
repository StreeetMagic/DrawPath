using System.Collections;
using UnityEngine;

namespace Scripts.DrawPath
{
    public class DrawPath : MonoBehaviour
    {
        private const float Cooldown = .01f;
        private const float Distance = .3f;
        
        [SerializeField] private Path _pathTemplate;
        [SerializeField] private Camera _camera;

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

            var prevPoint = new Vector3(0, 0, 0);
            var currPoint = new Vector3(0, 0, 0);

            while (true)
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (_plane.Raycast(ray, out var location))
                {
                    _worldPosition = ray.GetPoint(location);
                    prevPoint = currPoint;
                    currPoint = _worldPosition;
                }
                
                var distance = Vector3.Distance(prevPoint, currPoint);

                Debug.Log(distance);    
                
                if (distance > Distance)
                {
                    path.AddMainPoint(_worldPosition);
                }

                yield return new WaitForSeconds(Cooldown);
            }
        }
    }
}