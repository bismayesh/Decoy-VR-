using UnityEngine;

public class GradualVolumeIncrease : MonoBehaviour
{
    public AudioSource audioSource;
    public float maxVolume = 1.0f;
    public float fadeInDuration = 5.0f; // Duration in seconds for the volume to fade in

    private float currentVolume = 0.0f;
    private float timer = 0.0f;
    private bool isFadingIn = true;

    void Start()
    {
        // Start playing the audio
        audioSource.Play();
    }

    void Update()
    {
        // If the volume is not yet at max and we're still fading in
        if (currentVolume < maxVolume && isFadingIn)
        {
            // Increment the timer
            timer += Time.deltaTime;

            // Calculate the current volume based on time
            currentVolume = Mathf.Lerp(0.0f, maxVolume, timer / fadeInDuration);

            // Set the volume of the audio source
            audioSource.volume = currentVolume;

            // If the timer exceeds the fade-in duration, stop fading in
            if (timer >= fadeInDuration)
            {
                isFadingIn = false;
            }
        }
    }
}


