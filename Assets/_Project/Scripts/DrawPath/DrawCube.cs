using Scripts.DrawPath.Points;
using TMPro;
using UnityEngine;

namespace Scripts.DrawPath
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MeshCollider))]
    public class DrawCube : MonoBehaviour
    {
        private readonly MainPoint[] _mainPoints = new MainPoint[2];
        private int[] _triangles;
        private Vector3[] _vertices;
        private Mesh _mesh;
        private MeshCollider _meshCollider;

        private void Awake()
        {
            _mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = _mesh;
            _meshCollider = GetComponent<MeshCollider>();
        }

        private void Start()
        {
            GetComponent<MeshCollider>().sharedMesh = _mesh;
            GetComponent<Rigidbody>().isKinematic = true;
           // GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

        public void InitMainPoints(MainPoint first, MainPoint second)
        {
            _mainPoints[0] = first;
            _mainPoints[1] = second;
        }

        public void CreateShape()
        {
            _vertices = new[]
            {
                _mainPoints[0].RightPoint.ClosePoint.transform.position,
                _mainPoints[1].RightPoint.ClosePoint.transform.position,
                _mainPoints[1].LeftPoint.ClosePoint.transform.position,
                _mainPoints[0].LeftPoint.ClosePoint.transform.position,
                _mainPoints[0].LeftPoint.FarPoint.transform.position,
                _mainPoints[1].LeftPoint.FarPoint.transform.position,
                _mainPoints[1].RightPoint.FarPoint.transform.position,
                _mainPoints[0].RightPoint.FarPoint.transform.position,
            };

            _triangles = new[]
            {
                0, 2, 1,
                0, 3, 2,

                2, 3, 4,
                2, 4, 5,

                1, 2, 5,
                1, 5, 6,

                0, 7, 4,
                0, 4, 3,

                5, 4, 7,
                5, 7, 6,

                0, 6, 7,
                0, 1, 6
            };
        }

        public void UpdateMesh()
        {
            _mesh.Clear();
            _mesh.vertices = _vertices;
            _mesh.triangles = _triangles;
        }

        public void SetMaterial(PhysicMaterial mat)
        {
            _meshCollider.material = mat;
        }
    }
}