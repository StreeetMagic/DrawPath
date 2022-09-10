using System;
using UnityEngine;
using UnityEngine.VFX;

namespace Scripts.Finish
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] _effects;
        
        private bool _isFinished;

        private void OnCollisionEnter(Collision collision)
        {
            if (_isFinished == false)
            {
                StartEffects();
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