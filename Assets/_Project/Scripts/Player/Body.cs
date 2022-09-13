using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    public class Body : MonoBehaviour
    {
        [SerializeField] private List<BodyPart> _bodyParts;

        private bool isFallen;

        protected void LiftAllBodyParts()
        {
            foreach (var bodyPart in _bodyParts)
            {
                Debug.Log("Кручу цикл");
                bodyPart.Lift();
            }

            /*
            if (isFallen == false)
            {
                Debug.Log("зашел в метод");
                isFallen = true;
*/
        }
    }
}