using System.Net;
using UnityEngine;

namespace Scripts.Path.Point
{
    public class MainPoint : MonoBehaviour
    {
        [SerializeField] private float _width = 1f;
        [SerializeField] private float _thikness = .5f;
        [SerializeField] private SidePoint _sidePoint;

        
        [field: SerializeField] public SidePoint LeftPoint { get; private set; }
        [field: SerializeField] public SidePoint RightPoint { get; private set; }

        private void InitLeftPoint(SidePoint sidePoint)
        {
            LeftPoint = sidePoint;

            var closePoint = LeftPoint.CreateDepthPoint(Vector3.left * _width);
            LeftPoint.InitClosePoint(closePoint);

            var farPoint = LeftPoint.CreateDepthPoint(Vector3.right * _width);
            LeftPoint.InitFarPoint(farPoint);
        }

        private void InitRightPoint(SidePoint sidePoint)
        {
            RightPoint = sidePoint;

            var closePoint = RightPoint.CreateDepthPoint(Vector3.right * _width);
            RightPoint.InitClosePoint(closePoint);

            var farPoint = RightPoint.CreateDepthPoint(Vector3.left * _width);
            RightPoint.InitFarPoint(farPoint);
        }

        public void InitSidePoints()
        {
            var leftPoint = CreateSidePoint(Vector3.up *_thikness);
            InitLeftPoint(leftPoint);

            var rightPoint = CreateSidePoint(Vector3.down *_thikness);
            InitRightPoint(rightPoint);
        }

        private SidePoint CreateSidePoint(Vector3 direction)
        {
            var sidePoint = Instantiate(_sidePoint, transform.position, transform.rotation,
                transform);

            sidePoint.transform.Translate(direction);
            sidePoint.transform.forward = transform.position - sidePoint.transform.position;

            return sidePoint;
        }
    }
}