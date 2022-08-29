using UnityEngine;

namespace Scripts.DrawPath.Points
{
    public class SidePoint : MonoBehaviour
    {
        [SerializeField] private DepthPoint _depthPoint;

        public DepthPoint ClosePoint { get; private set; }
        public DepthPoint FarPoint { get; private set; }

        public void InitClosePoint(DepthPoint depthPoint)
        {
            ClosePoint = depthPoint;
        }

        public void InitFarPoint(DepthPoint depthPoint)
        {
            FarPoint = depthPoint;
        }

        public DepthPoint CreateDepthPoint(Vector3 direction)
        {
            var depthPoint1 = Instantiate(_depthPoint, transform.position, transform.rotation,
                transform);

            depthPoint1.transform.Translate(direction);
            depthPoint1.transform.forward = transform.position - depthPoint1.transform.position;

            return depthPoint1;
        }
    }
}