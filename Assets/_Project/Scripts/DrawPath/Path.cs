using System;
using System.Collections.Generic;
using Scripts.DrawPath.Points;
using Scripts.Player;
using UnityEngine;

namespace Scripts.DrawPath
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private GameObject _cubeContainer;
        [SerializeField] private GameObject _pointContainer;
        [SerializeField] private DrawCube _cubeTemplate;
        [SerializeField] private MainPoint _mainPointTemplate;

        private VisualEffects _visualEffects;

        private readonly List<MainPoint> _points = new List<MainPoint>();
        private float offset = .01f;

        private void CreateCube(MainPoint start, MainPoint finish)
        {
            var cube = Instantiate(_cubeTemplate, transform.position, Quaternion.identity,
                _cubeContainer.transform);
            cube.Init(start, finish, _visualEffects);
            cube.CreateShape();
            cube.UpdateMesh();
        }

        private void TurnToParent(MainPoint ascendant, MainPoint parent)
        {
            var direction = parent.transform.position - ascendant.transform.position;

            if (parent.transform.position.x - ascendant.transform.position.x < offset)
            {
                ascendant.transform.Translate(new Vector3(offset * 3, 0, 0));
            }

            if (parent.transform.position.x < ascendant.transform.position.x)
            {
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.down);
                ascendant.transform.rotation = rotation;
            }

            else
            {
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
                ascendant.transform.rotation = rotation;
            }
        }

        public void Init(VisualEffects visualEffects)
        {
            _visualEffects = visualEffects;
        }

        public void AddMainPoint(Vector3 location)
        {
            var point = Instantiate(_mainPointTemplate, location, Quaternion.identity, _pointContainer.transform);

            _points.Add(point);

            if (_points.Count == 2)
            {
                _points[0].InitSidePoints();
                _points[1].InitSidePoints();
                _points[0].transform.forward = _points[1].transform.forward;
                TurnToParent(_points[1], _points[0]);
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