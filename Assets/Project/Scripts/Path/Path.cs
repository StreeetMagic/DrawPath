using System.Collections.Generic;
using Scripts.Path.Point;
using UnityEngine;

namespace Scripts.Path
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private List<MainPoint> _points = new List<MainPoint>();
        [SerializeField] private List<DrawCube> _cubes = new List<DrawCube>();
        [SerializeField] private GameObject _cubeContainer;
        [SerializeField] private GameObject _pointContainer;
        [SerializeField] private DrawCube _cubeTemplate;
        [SerializeField] private MainPoint _mainPointTemplate;

        private void CreateCube(MainPoint start, MainPoint finish)
        {
            var cube = Instantiate(_cubeTemplate, transform.position, Quaternion.identity,
                _cubeContainer.transform);

            _cubes.Add(cube);
            cube.InitMainPoints(start, finish);
            cube.CreateShape();
            cube.UpdateMesh();
        }

        private void TurnToParent(MainPoint ascendant, MainPoint parent)
        {
            Vector3 direction = parent.transform.position - ascendant.transform.position;
            ascendant.transform.forward = direction;
            ascendant.transform.eulerAngles = new Vector3(ascendant.transform.eulerAngles.x, 90, 0);
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
                CreateCube(_points[0], _points[1]);
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