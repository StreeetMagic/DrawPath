using UnityEngine;

namespace Scripts.MyCamera
{
    public class MyCamera : MonoBehaviour
    {
        [SerializeField] private Transform _pelvis;

        [SerializeField] private float _smoothingPower = 0.2f;
        private Vector3 _positionOffcet;

        private void Awake()
        {
            _positionOffcet = transform.position - _pelvis.transform.position;
        }

        private void FixedUpdate()
        {
            Vector3 desiredPosition = _pelvis.position + _positionOffcet;

            transform.position =
                Vector3.Lerp(transform.position, desiredPosition, 1f / _smoothingPower * Time.fixedDeltaTime);
        }
    }
}