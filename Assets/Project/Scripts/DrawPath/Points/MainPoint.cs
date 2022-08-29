using System.Net;
using UnityEngine;

namespace Scripts.Path.Point
{
    public class MainPoint : MonoBehaviour
    {
        private const float Width = 1f;
        private const float Thickness = 0.3f;

        [SerializeField] private SidePoint _sidePoint;

        public SidePoint LeftPoint { get; private set; }
        public SidePoint RightPoint { get; private set; }

        public void InitSidePoints()
        {
            var leftPoint = CreateSidePoint(Vector3.up * Thickness);
            InitLeftPoint(leftPoint);

            var rightPoint = CreateSidePoint(Vector3.down * Thickness);
            InitRightPoint(rightPoint);
        }

        private void InitLeftPoint(SidePoint sidePoint)
        {
            LeftPoint = sidePoint;

            var closePoint = LeftPoint.CreateDepthPoint(Vector3.left * Width);
            LeftPoint.InitClosePoint(closePoint);

            var farPoint = LeftPoint.CreateDepthPoint(Vector3.right * Width);
            LeftPoint.InitFarPoint(farPoint);
        }

        private void InitRightPoint(SidePoint sidePoint)
        {
            RightPoint = sidePoint;

            var closePoint = RightPoint.CreateDepthPoint(Vector3.left * Width);
            RightPoint.InitClosePoint(closePoint);

            var farPoint = RightPoint.CreateDepthPoint(Vector3.right * Width);
            RightPoint.InitFarPoint(farPoint);
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