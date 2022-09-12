using System.Collections.Generic;
using Scripts.DrawPath.Points;
using Scripts.Player;
using UnityEngine;

namespace Scripts.DrawPath
{
    public class Path : MonoBehaviour
    {
        private const int MinPointCount = 2;

        [SerializeField] private GameObject _cubeContainer;
        [SerializeField] private GameObject _pointContainer;
        [SerializeField] private Cube _cubeTemplate;
        [SerializeField] private MainPoint _mainPointTemplate;

        private readonly Vector3 _offcet = new Vector3(.03f, 0, 0);
        private readonly List<MainPoint> _points = new List<MainPoint>();

        private VisualEffects _playerVisualEffects;
        private float _offcetDelta = 0.02f;

        private void DrawCube(MainPoint start, MainPoint finish)
        {
            var cube = Instantiate(_cubeTemplate, transform.position, Quaternion.identity, _cubeContainer.transform);
            cube.Init(start, finish, _playerVisualEffects);
            cube.CreateShape();
            cube.UpdateMesh();
        }

        private void TurnToParent(MainPoint ascendant, MainPoint parent)
        {
            var direction = parent.transform.position - ascendant.transform.position;

            if (parent.transform.position.x - ascendant.transform.position.x < _offcetDelta)
            {
                ascendant.transform.Translate(_offcet);
            }

            if (parent.transform.position.x < ascendant.transform.position.x)
            {
                var rotation = Quaternion.LookRotation(direction, Vector3.down);
                ascendant.transform.rotation = rotation;
            }

            else
            {
                var rotation = Quaternion.LookRotation(direction, Vector3.up);
                ascendant.transform.rotation = rotation;
            }
        }

        public void Init(VisualEffects visualEffects)
        {
            _playerVisualEffects = visualEffects;
        }

        public void AddMainPoint(Vector3 location)
        {
            var point = Instantiate(_mainPointTemplate, location, Quaternion.identity, _pointContainer.transform);

            _points.Add(point);

            if (_points.Count == MinPointCount)
            {
                _points[0].InitSidePoints();
                _points[1].InitSidePoints();
                _points[0].transform.forward = _points[1].transform.forward;
                TurnToParent(_points[1], _points[0]);
            }

            if (_points.Count > MinPointCount)
            {
                var number = _points.Count - 1;
                _points[number].InitSidePoints();
                TurnToParent(_points[number], _points[number - 1]);
                DrawCube(_points[number - 1], _points[number]);
            }
        }
    }
}