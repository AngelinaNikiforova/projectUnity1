using System.Collections;
using UnityEngine;

namespace Items
{
    public class Flashlight : MonoBehaviour
    {
        public Light flashlight;
        public float smoothSpeed = 5f;
        public float targetIntensityOn = 1f;
        public float targetIntensityOff = 0f;

        private bool isFlashlightOn = false;

        private void Start()
        {
            flashlight.intensity = targetIntensityOff;
        }

        private void Update()
        {
            // Check for the "F" key press
            if (Input.GetKeyDown(KeyCode.F))
            {
                isFlashlightOn = !isFlashlightOn;

                // Set the target intensity based on flashlight state
                float targetIntensity = isFlashlightOn ? targetIntensityOn : targetIntensityOff;

                // Smoothly interpolate to the target intensity
                StartCoroutine(SmoothIntensityChange(targetIntensity));
            }
        }

        private IEnumerator SmoothIntensityChange(float targetIntensity)
        {
            float currentIntensity = flashlight.intensity;

            while (Mathf.Abs(currentIntensity - targetIntensity) > 0.01f)
            {
                currentIntensity = Mathf.Lerp(currentIntensity, targetIntensity, smoothSpeed * Time.deltaTime);
                flashlight.intensity = currentIntensity;
                yield return null;
            }

            flashlight.intensity = targetIntensity;
        }
    }
}
