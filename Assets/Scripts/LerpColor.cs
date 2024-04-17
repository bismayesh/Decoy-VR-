using UnityEngine;

public class ColorLerpVR : MonoBehaviour
{
    public Color startColor = Color.red;
    public Color endColor = Color.blue;
    public float lerpDuration = 1f;

    private float lerpTimer = 0f;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = startColor;
    }

    void Update()
    {
        // Increment the timer
        lerpTimer += Time.deltaTime;

        // Calculate t value for lerping
        float t = Mathf.Clamp01(lerpTimer / lerpDuration);

        // Lerp between startColor and endColor
        Color lerpedColor = Color.Lerp(startColor, endColor, t);

        // Apply the lerped color to the renderer
        rend.material.color = lerpedColor;

        // Reset timer when it reaches or exceeds lerpDuration
        if (lerpTimer >= lerpDuration)
        {
            lerpTimer = 0f;
            // Swap start and end colors for continuous lerping
            Color tempColor = startColor;
            startColor = endColor;
            endColor = tempColor;
        }
    }
}


