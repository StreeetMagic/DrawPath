using UnityEngine;

namespace Scripts.Path
{
    public class DrawPath : MonoBehaviour
    {
        [SerializeField] private Path _pathTemplate;
    
        private void Start()
        {
            Instantiate(_pathTemplate, transform.position, Quaternion.identity, transform);
        }
    }
}
