using System.Net;
using UnityEngine;

namespace Scripts.Path.Point
{
    public class MainPoint : MonoBehaviour
    {
        [field: SerializeField] public SidePoint LeftPoint { get; private set; }
        [field: SerializeField] public SidePoint RightPoint { get; private set; }

        public void InitLeftPoint(SidePoint sidePoint)
        {
            LeftPoint = sidePoint;
        }

        public void InitRightPoint(SidePoint sidePoint)
        {
            RightPoint = sidePoint;
        }
    }
}