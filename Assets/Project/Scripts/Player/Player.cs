using UnityEngine;

namespace Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody _pelvis;
        
        private void Start()
        {
            //_pelvis.AddTorque(new Vector3(0,100,100));        
        }
    }
}
