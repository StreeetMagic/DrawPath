using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Path
{
    public class DrawPath : MonoBehaviour
    {
        [SerializeField] private Path _pathTemplate;
        [SerializeField] private List<Path> _paths = new List<Path>();
        [SerializeField] private GameObject _omegaBall;

        private Vector3 worldPosition;
        private Plane plane = new Plane(Vector3.forward, 0);
        private Coroutine _drawingCoroutine;
        private bool CanDraw;
        

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_drawingCoroutine != null)
                {
                    CanDraw = false;
                }
                CanDraw = true;
                StartCoroutine(Drawing());
            }

            if (Input.GetMouseButtonUp(0))
            {
                CanDraw = false;
            }
        }

        private IEnumerator Drawing()
        {
            var path = Instantiate(_pathTemplate, transform.position, Quaternion.identity, transform);
            _paths.Add(path);

            var prevPoint = new Vector3(0, 0, 0);
            var currPoint = new Vector3(0, 0, 0);

            while (CanDraw)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (plane.Raycast(ray, out var distance))
                {
                    worldPosition = ray.GetPoint(distance);

                    prevPoint = currPoint;

                    currPoint = worldPosition;
                }

                var distance1 = Vector3.Distance(prevPoint, currPoint);

                if (distance1 > 1f)
                {
                    Debug.Log(distance1);
                    path.AddMainPoint(worldPosition);
                }

                yield return new WaitForSeconds(.05f);
            }
        }
    }
}