using UnityEngine;
using UnityEngine.Events;

namespace Scripts.States
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] _effects;
        
        private bool _isFinished;

        public event UnityAction PlayerFinished;

        private void OnCollisionEnter(Collision collision)
        {
            if (_isFinished == false)
            {
                StartEffects();
                PlayerFinished?.Invoke();
            }
        }

        private void StartEffects()
        {
            foreach (var effect in _effects)
            {
                effect.Play();
            }
            _isFinished = true;
        }
    }
}