using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Player
{
    public class VisualEffects : MonoBehaviour
    {
        private const float _cooldown = 1f;

        [SerializeField] private GameObject _massiveBlood;
        [SerializeField] private GameObject _smallBlood;

        [SerializeField] private Rigidbody _rigidbody;

        private ParticleSystem _massiveBloodParticles;
        private ParticleSystem _smallBloodParticles;
        private bool _canBleed;

        private void Start()
        {
            _massiveBloodParticles = _massiveBlood.GetComponent<ParticleSystem>();
            _smallBloodParticles = _smallBlood.GetComponent<ParticleSystem>();
            StartCoroutine(EffectCooldown());
        }

        public void StartMassiveBlood()
        {
            if (_canBleed)
            {
                _massiveBlood.transform.position = _rigidbody.worldCenterOfMass;
                _massiveBlood.transform.forward = Vector3.right;
                _massiveBloodParticles.Play();
                _canBleed = false;
                StartCoroutine(EffectCooldown());
            }
        }        
        
        public void StartSmallBlood()
        {
            if (_canBleed)
            {
                _smallBlood.transform.position = _rigidbody.worldCenterOfMass;
                _smallBlood.transform.forward = Vector3.right;
                _smallBloodParticles.Play();
                _canBleed = false;
                StartCoroutine(EffectCooldown());
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