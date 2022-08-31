using UnityEngine;

namespace Scripts.MyCamera
{
    public class MyCamera : MonoBehaviour
    {
        [SerializeField] private Transform _pelvis;

        private const float SmoothingPower = 0.2f;
        private Vector3 _positionOffset = new Vector3(0, 2, 13);

        private void LateUpdate()
        {
            Vector3 desiredPosition = _pelvis.position + _positionOffset;
            transform.position =
                Vector3.Lerp(transform.position, desiredPosition, 1f / SmoothingPower * Time.deltaTime);
        }
    }
}