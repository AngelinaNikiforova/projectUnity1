using UnityEngine;

namespace Character
{
    public class CharacterHandMovement : MonoBehaviour
    {
        public Transform handTransform;
        public float movementAmount = 0.02f;
        public float movementSpeed = 5f;
        public float stepInterval = 0.5f;

        private Vector3 originalPosition;
        private float nextStepTime;

        private void Start()
        {
            originalPosition = handTransform.localPosition;
            nextStepTime = Time.time + stepInterval;
        }

        private void Update()
        {
            float movement = Mathf.Sin(Time.time * movementSpeed) * movementAmount;
            handTransform.localPosition = originalPosition + Vector3.up * movement;

            if (Time.time >= nextStepTime)
            {
                nextStepTime = Time.time + stepInterval;
            }
        }
    }
}
