using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Fail
{
    public class Fail : MonoBehaviour
    {
        public event UnityAction PlayerFallen;

        private void OnCollisionEnter(Collision collision)
        {
            PlayerFallen?.Invoke();
        }
    }
}
