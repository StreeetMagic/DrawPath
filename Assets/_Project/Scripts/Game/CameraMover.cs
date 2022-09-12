using UnityEngine;

namespace Scripts.Game
{
    public class CameraMover : MonoBehaviour
    {
        private const float SmoothingPower = 0.1f;
        
        [SerializeField] private Transform _pelvis;

        private Vector3 _positionOffcet;

        private void Awake()
        {
            _positionOffcet = transform.position - _pelvis.transform.position;
        }

        private void FixedUpdate()
        {
            Vector3 desiredPosition = _pelvis.position + _positionOffcet;

            transform.position =
                Vector3.Lerp(transform.position, desiredPosition, 1f / SmoothingPower * Time.fixedDeltaTime);
        }
    }
}