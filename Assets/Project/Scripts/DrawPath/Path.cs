using System.Collections.Generic;
using Scripts.DrawPath.Points;
using UnityEngine;

namespace Scripts.DrawPath
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private GameObject _cubeContainer;
        [SerializeField] private GameObject _pointContainer;
        [SerializeField] private DrawCube _cubeTemplate;
        [SerializeField] private MainPoint _mainPointTemplate;

        private readonly List<MainPoint> _points = new List<MainPoint>();

        private void CreateCube(MainPoint start, MainPoint finish)
        {
            var cube = Instantiate(_cubeTemplate, transform.position, Quaternion.identity,
                _cubeContainer.transform);

            cube.InitMainPoints(start, finish);
            cube.CreateShape();
            cube.UpdateMesh();
        }

        private void TurnToParent(MainPoint ascendant, MainPoint parent)
        {
            var transform1 = ascendant.transform;
            Vector3 direction = parent.transform.position - transform1.position;
            transform1.forward = direction;
            transform1.eulerAngles = new Vector3(transform1.eulerAngles.x, 90, 0);
        }

        public void AddMainPoint(Vector3 location)
        {
            var point = Instantiate(_mainPointTemplate, location, Quaternion.identity, _pointContainer.transform);

            _points.Add(point);

            if (_points.Count == 2)
            {
                _points[0].InitSidePoints();
                _points[1].InitSidePoints();
                TurnToParent(_points[1], _points[0]);
                _points[0].transform.forward = _points[1].transform.forward;
            }

            if (_points.Count > 2)
            {
                var number = _points.Count - 1;
                _points[number].InitSidePoints();
                TurnToParent(_points[number], _points[number - 1]);
                CreateCube(_points[number - 1], _points[number]);
            }
        }
    }
}