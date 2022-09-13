using Scripts.DrawPath;
using Scripts.States;
using UnityEngine;

namespace Scripts.Player
{
    public class BodyPart : Body
    {
        public float _sidePower = 50f;
        public float _upPower = 50f;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Cube cube))
            {
                Push(cube);
            }

            if (collision.gameObject.TryGetComponent(out Fail fail))
            {
                Debug.Log("Я коснулся пола");
                LiftAllBodyParts();
            }
        }

        public void Push(Cube position)
        {
            if (position.TopPoint.transform.position.x > transform.position.x)
            {
                Debug.Log("Толкаю влево");
                GetComponent<Rigidbody>().AddForce(Vector3.left * _sidePower, ForceMode.VelocityChange);
            }
            else
            {
                Debug.Log("Толкаю вправо");
                GetComponent<Rigidbody>().AddForce(Vector3.right * _sidePower, ForceMode.VelocityChange);
            }
        }

        public void Lift()
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * _upPower, ForceMode.VelocityChange);
            Debug.Log("поднимаю");
        }
    }
}