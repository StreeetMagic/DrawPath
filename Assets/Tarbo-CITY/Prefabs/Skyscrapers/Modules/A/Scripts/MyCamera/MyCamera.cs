using System;
using UnityEngine;

namespace Scripts.MyCamera
{
    public class MyCamera : MonoBehaviour
    {
        [SerializeField] private Transform _pelvis;

        [SerializeField] private Camera _camera;
        
        private Vector3 _offset = new Vector3(0, 2, 13);

        private void Update()
        {
            var position = _pelvis.transform.position + _offset;
            _camera.transform.position = position;
        }
    }
}