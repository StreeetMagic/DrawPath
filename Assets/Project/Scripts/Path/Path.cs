using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Path
{
    public class Path : MonoBehaviour
    {
        public List<GameObject> _points = new List<GameObject>();
        public Point _sidePoint;
        public Point _depthPoint;

        private void Start()
        {
            CreatePoints();
        }

        private void CreatePoints()
        {
            for (int i = 1; i < _points.Count; i++)
            {
                TurnToParent(i);
                CreateSidePoint(i, Vector3.up);
                CreateSidePoint(i, Vector3.down);
            }
        }

        private void CreateSidePoint(int numberI, Vector3 direction)
        {
            var sidePoint1 = Instantiate(
                _sidePoint,
                _points[numberI].transform.position,
                _points[numberI].transform.rotation,
                _points[numberI].transform);

            sidePoint1.transform.Translate(direction * 2);
            sidePoint1.transform.forward = _points[numberI].transform.position - sidePoint1.transform.position;

            CreateDepthPoint(sidePoint1, Vector3.right * 2);
            CreateDepthPoint(sidePoint1, Vector3.left * 2);
        }   

        private void CreateDepthPoint(Point sidePoint1, Vector3 direction)
        {
            var depthPoint1 = Instantiate(
                _depthPoint,
                sidePoint1.transform.position,
                sidePoint1.transform.rotation,
                sidePoint1.transform);
            depthPoint1.transform.Translate(direction);
            depthPoint1.transform.forward = sidePoint1.transform.position - depthPoint1.transform.position;
        }

        private void TurnToParent(int number)
        {
            Vector3 direction = _points[number - 1].transform.position - _points[number].transform.position;
            _points[number].transform.forward = direction;
        }
    }
}