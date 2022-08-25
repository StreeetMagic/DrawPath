using UnityEngine;

namespace Scripts.Path.Point
{
    public class SidePoint : MonoBehaviour
    {
        [SerializeField] private DepthPoint _depthPoint;

        [field: SerializeField] public DepthPoint ClosePoint { get; private set; }
        [field: SerializeField] public DepthPoint FarPoint { get; private set; }

        public void InitClosePoint(DepthPoint depthPoint)
        {
            ClosePoint = depthPoint;
        }

        public void InitFarPoint(DepthPoint depthPoint)
        {
            FarPoint = depthPoint;
        }

        public void InitDepthPoints()
        {
            var closePoint = CreateDepthPoint(Vector3.right * 2);
            InitClosePoint(closePoint);

            var farPoint = CreateDepthPoint(Vector3.left * 2);
            InitFarPoint(farPoint);
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