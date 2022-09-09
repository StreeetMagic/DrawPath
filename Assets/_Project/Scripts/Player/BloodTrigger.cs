using System;
using UnityEngine;

namespace Scripts.Player
{
    public class BloodTrigger : MonoBehaviour

    {
        [SerializeField] private VisualEffects _visualEffects;

        private void OnCollisionEnter(Collision collision)
        {
            _visualEffects.StartSmallBlood();
        }
    }
}