using UnityEngine;

namespace Scripts.Path.Point
{
    public class SidePoint : MonoBehaviour
    {
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
    }
}