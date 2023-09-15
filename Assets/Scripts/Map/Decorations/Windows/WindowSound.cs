using UnityEngine;

namespace Map.Decorations.Windows
{
    public class WindowSound : MonoBehaviour
    {
        public AudioClip soundEffect;       // The sound effect to play
        public AudioSource audioSource;     // The AudioSource component to play the sound
        public GameObject objectToDisappear; // The GameObject to disappear

        public float soundDelay = 1f;       // Delay before playing the sound effect
        public float disappearDelay = 5f;   // Delay before the object disappears

        private bool hasLookedOut = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!hasLookedOut && other.CompareTag("Player"))
            {
                objectToDisappear.SetActive(true);
                
                // Play the sound effect after the soundDelay
                Invoke("PlaySoundEffect", soundDelay);

                // Set the flag to prevent repeated playing
                hasLookedOut = true;

                // Make the object disappear after the disappearDelay
                Invoke("DisappearObject", disappearDelay);
            }
        }

        private void PlaySoundEffect()
        {
            // Play the sound effect
            audioSource.PlayOneShot(soundEffect);
        }

        private void DisappearObject()
        {
            // Deactivate the object to make it disappear
            objectToDisappear.SetActive(false);
        }
    }
}
