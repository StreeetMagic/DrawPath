using System;
using UnityEngine;

namespace Scripts.DrawPath.Points
{
    public class MainPoint : MonoBehaviour
    {
        private const float Width = 1f;
        private const float Thickness = 0.2f;

        [SerializeField] private SidePoint _sidePoint;
        [field: SerializeField] public float CreationTime { get; private set; }

        public SidePoint LeftPoint { get; private set; }
        public SidePoint RightPoint { get; private set; }

        public void InitCreationTime(float time)
        {
            CreationTime = time;
        }

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

        public void LogMe()
        {
            var x = Math.Round(transform.position.x, 3);
            var y = Math.Round(transform.position.y, 3);
            var t = Math.Round(CreationTime, 3);

           // Debug.Log($"new PointSetting(new Vector3({x}f, {y}f, 0), {t}f),");
            
        }
    }
}