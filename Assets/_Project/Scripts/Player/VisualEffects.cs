using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Player
{
    public class VisualEffects : MonoBehaviour
    {
        private const float _cooldown = 1f;

        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private ParticleSystem _massiveBloodParticles;
        [SerializeField] private ParticleSystem _smallBloodParticles;
        
        private bool _canBleed;

        private void Start()
        {
            StartCoroutine(EffectCooldown());
        }

        public void StartMassiveBlood()
        {
            if (_canBleed)
            {
                _massiveBloodParticles.transform.position = _rigidbody.worldCenterOfMass;
                _massiveBloodParticles.transform.forward = Vector3.right;
                _massiveBloodParticles.Play();
                _canBleed = false;
                StartCoroutine(EffectCooldown());
            }
        }        
        
        public void StartSmallBlood()
        {
            if (_canBleed)
            {
                _smallBloodParticles.transform.position = _rigidbody.worldCenterOfMass;
                _smallBloodParticles.transform.forward = Vector3.right;
                _smallBloodParticles.Play();
                _canBleed = false;
            }
        }

        private IEnumerator EffectCooldown()
        {
            var cooldown = new WaitForSeconds(_cooldown);

            yield return cooldown;

            _canBleed = true;
        }
    }
}