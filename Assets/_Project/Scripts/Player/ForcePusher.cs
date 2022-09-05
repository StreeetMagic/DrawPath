using Scripts.DrawPath;
using UnityEngine;

namespace Scripts.Player
{
    public class ForcePusher : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out DrawCube cube))
            {
                var myPos = _rigidbody.worldCenterOfMass;

                //var cubePos = collision.transform.TransformPoint(collision.transform.position);
                var cubeRb = collision.gameObject.TryGetComponent(out Rigidbody rigidbody);

                var cubePos = rigidbody.centerOfMass;

                var direction = (cubePos - myPos).normalized;

                _rigidbody.AddForce(direction * 500f, ForceMode.Acceleration);

                Debug.Log(direction);
                // Debug.Log(direction);
            }
        }
    }
}