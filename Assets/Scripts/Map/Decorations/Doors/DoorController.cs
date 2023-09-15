using UnityEngine;

namespace Map.Decorations.Doors
{
    public class NewBehaviourScript : MonoBehaviour
    {
        public Transform doorPivot;      // The pivot point of the door
        public float openAngle = 90f;    // The angle by which the door will open
        public float openSpeed = 2f;     // The speed at which the door opens

        private Quaternion initialRotation;
        private Quaternion targetRotation;
        private bool isOpening = false;

        private void Start()
        {
            initialRotation = doorPivot.localRotation;
            targetRotation = initialRotation * Quaternion.Euler(0f, 0f, openAngle);
        }

        private void Update()
        {
            if (isOpening)
            {
                // Smoothly interpolate between the initial and target rotation
                doorPivot.localRotation = Quaternion.Lerp(doorPivot.localRotation, targetRotation, openSpeed * Time.deltaTime);

                // Check if the door is almost fully open
                if (Quaternion.Angle(doorPivot.localRotation, targetRotation) < 0.5f)
                {
                    isOpening = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!isOpening)
                {
                    isOpening = true;
                }
            }
        }
    }
}
