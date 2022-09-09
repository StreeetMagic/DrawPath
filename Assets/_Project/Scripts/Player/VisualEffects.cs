using System;
using Scripts.DrawPath;
using UnityEngine;

namespace Scripts.Player
{
    public class VisualEffects : MonoBehaviour
    {
        [SerializeField] private GameObject _blood;
        [SerializeField] private Rigidbody _rigidbody;
        private ParticleSystem _particleSystem;

        private void Start()
        {
            _particleSystem = _blood.GetComponent<ParticleSystem>();
        }

        public void StartMassiveBlood()
        {
            _blood.transform.position = _rigidbody.worldCenterOfMass;
            _blood.transform.forward = Vector3.right;
            _particleSystem.Play();
        }
    }
}