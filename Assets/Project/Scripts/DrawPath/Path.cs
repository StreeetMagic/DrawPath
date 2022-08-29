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

        public void AddMainPoint(Vector3 location)
        {
            var point = Instantiate(_mainPointTemplate, location, Quaternion.identity, _pointContainer.transform);

            _points.Add(point);

            if (_points.Count == 2)
            {
                 TurnToParent(_points[1], _points[0]);
                _points[0].InitSidePoints();
                _points[1].InitSidePoints();
                //_points[0].transform.forward = _points[1].transform.forward;
            }

            if (_points.Count > 2)
            {
                var lastNumber = _points.Count - 1;

                point.transform.rotation = _points[lastNumber - 1].transform.rotation;
                TurnToParent(_points[lastNumber], _points[lastNumber - 1]);
                point.transform.right = Vector3.forward;
                _points[lastNumber].InitSidePoints();
                CreateCube(_points[lastNumber - 1], _points[lastNumber]);
            }
        }

        private void CreateCube(MainPoint start, MainPoint finish)
        {
            var cube = Instantiate(_cubeTemplate, transform.position, Quaternion.identity,
                _cubeContainer.transform);

            cube.InitMainPoints(start, finish);
            cube.CreateShape();
            cube.UpdateMesh();
        }

        private void TurnToParent(MainPoint child, MainPoint parent)
        {
            var direction = parent.transform.position - child.transform.position;
            child.transform.forward = direction;
            // child.transform.eulerAngles = new Vector3(child.transform.eulerAngles.x, 90, 0);
        }
    }
}