using System.Collections.Generic;
using Scripts.Path.Point;
using UnityEngine;

namespace Scripts.Path
{
    public class Path : MonoBehaviour
    {
        public List<MainPoint> _points = new List<MainPoint>();
        public SidePoint _sidePoint;
        public DepthPoint _depthPoint;

        private void Start()
        {
            DrawMesh();
        }

        private void DrawMesh()
        {
            for (int i = 1; i < _points.Count; i++)
            {
                TurnToParent(_points[i], _points[i - 1]);
                InitSidePoints(_points[i]);
            }

            TurnToParent(_points[0], _points[1]);
            InitSidePoints(_points[0]);
        }

        private void InitSidePoints(MainPoint mainPoint)
        {
            mainPoint.InitLeftPoint(CreateSidePoint(mainPoint, Vector3.up));
            mainPoint.InitRightPoint(CreateSidePoint(mainPoint, Vector3.down));
        }

        private SidePoint CreateSidePoint(MainPoint parent, Vector3 direction)
        {
            var sidePoint1 = Instantiate(_sidePoint, parent.transform.position, parent.transform.rotation,
                parent.transform);


            sidePoint1.transform.Translate(direction * 2);
            sidePoint1.transform.forward = parent.transform.position - sidePoint1.transform.position;

            sidePoint1.InitClosePoint(CreateDepthPoint(sidePoint1, Vector3.right * 2));
            sidePoint1.InitFarPoint(CreateDepthPoint(sidePoint1, Vector3.left * 2));

            return sidePoint1;
        }

        private DepthPoint CreateDepthPoint(SidePoint sidePoint1, Vector3 direction)
        {
            var depthPoint1 = Instantiate(_depthPoint, sidePoint1.transform.position, sidePoint1.transform.rotation,
                sidePoint1.transform);


            depthPoint1.transform.Translate(direction);
            depthPoint1.transform.forward = sidePoint1.transform.position - depthPoint1.transform.position;

            return depthPoint1;
        }

        private void TurnToParent(MainPoint ascendant, MainPoint parent)
        {
            Vector3 direction = parent.transform.position - ascendant.transform.position;
            ascendant.transform.forward = direction;
        }
    }
}