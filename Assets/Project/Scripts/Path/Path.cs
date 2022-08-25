using System.Collections.Generic;
using Scripts.Path.Point;
using UnityEngine;

namespace Scripts.Path
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private List<MainPoint> _points = new List<MainPoint>();
        [SerializeField] private GameObject _cubeContainer;
        [SerializeField] private List<DrawCube> _cubes = new List<DrawCube>();
        [SerializeField] private DrawCube _cubeTemplate;

        private void Start()
        {
            CreatePoints();
            
            DrawMesh();
            
        }

        private void CreatePoints()
        {
           // var point1 = Instantiate(_poin)

        }

        private void DrawMesh()
        {
            CreateVertices();

            CreateCube(_points[0], _points[1]);
        }


        private void CreateCube(MainPoint start, MainPoint finish)
        {
            var cube = Instantiate(_cubeTemplate, transform.position, Quaternion.identity,
                _cubeContainer.transform);
            
            _cubes.Add(cube);
            cube.InitMainPoints(start, finish);
            cube.CreateShape();
            cube.UpdateMesh();
        }
        
        private void CreateVertices()
        {
            _points[0].transform.forward = _points[0].transform.position - _points[1].transform.position;
            _points[0].InitSidePoints();

            for (int i = 1; i < _points.Count; i++)
            {
                TurnToParent(_points[i], _points[i - 1]);
                _points[i].InitSidePoints();
            }
        }

        private void TurnToParent(MainPoint ascendant, MainPoint parent)
        {
            Vector3 direction = parent.transform.position - ascendant.transform.position;
            ascendant.transform.forward = direction;
        }
    }
}