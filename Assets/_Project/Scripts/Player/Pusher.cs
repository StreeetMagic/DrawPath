using System.Collections.Generic;
using Scripts.DrawPath;
using UnityEngine;

namespace Scripts.Player
{
    public class Pusher : MonoBehaviour
    {
        private const float ExplosionForce = 15f;

        [SerializeField] private List<Rigidbody> _rigidbodies;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Cube cube))
            {
                var position = cube.LowPoint.transform.position;

                foreach (var rb in _rigidbodies)
                {
                    rb.AddExplosionForce(ExplosionForce, position, 10f, 2f, ForceMode.VelocityChange);
                }
            }
        }
    }
}