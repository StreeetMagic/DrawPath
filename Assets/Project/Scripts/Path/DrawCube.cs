using Scripts.Path.Point;
using UnityEngine;

namespace Scripts.Path
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(Rigidbody))]
    
    public class DrawCube : MonoBehaviour
    {
        [SerializeField] private MainPoint[] _mainPoints = new MainPoint[2];
        [SerializeField] private Vector3[] _vertices;
        [SerializeField] private int[] _triangles;
        [SerializeField] private Mesh mesh;

        private void Awake()
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
        }

        private void Start()
        {
            GetComponent<MeshCollider>().sharedMesh = mesh;
            GetComponent<Rigidbody>().isKinematic = true;
        }

        public void InitMainPoints(MainPoint first, MainPoint second)
        {
            _mainPoints[0] = first;
            _mainPoints[1] = second;
        }


        public void CreateShape()
        {
            _vertices = new Vector3[]
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

            _triangles = new int[]
            {
                0, 2, 1, //face front
                0, 3, 2,

                2, 3, 4, //face top
                2, 4, 5,

                1, 2, 5, //face right
                1, 5, 6,

                0, 7, 4, //face left
                0, 4, 3,

                5, 4, 7, //face back
                5, 7, 6,

                0, 6, 7, //face bottom
                0, 1, 6
            };
        }

        public void UpdateMesh()
        {
            mesh.Clear();
            mesh.vertices = _vertices;
            mesh.triangles = _triangles;
        }
    }
}