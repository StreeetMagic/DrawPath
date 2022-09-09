using System.Collections.Generic;
using Scripts.DrawPath;
using UnityEngine;

namespace Scripts.Player
{
    public class ForcePusher : MonoBehaviour
    {
        [SerializeField] private List<Rigidbody> _rigidbodies;
        [SerializeField] private float _explosionForce = 150f;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out DrawCube cube))
            {
                var position = cube.LowPoint.transform.position;

                foreach (var rb in _rigidbodies)
                {
                    rb.AddExplosionForce(_explosionForce, position, 10f, 2f, ForceMode.VelocityChange);
                }
            }
        }
    }
}