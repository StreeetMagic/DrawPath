using UnityEngine;
using UnityEngine.Events;

namespace Scripts.States
{
    public class Fail : MonoBehaviour
    {
        public event UnityAction PlayerFailed;

        private void OnCollisionEnter(Collision collision)
        {
            PlayerFailed?.Invoke();
        }
    }
}
