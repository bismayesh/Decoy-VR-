using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public string sceneName; // Name of the scene to transition to
    public float delaySeconds = 2f; // Delay before transitioning

    void Start()
    {
        // Start the coroutine when this script starts
        StartCoroutine(TransitionAfterDelay());
    }

    IEnumerator TransitionAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delaySeconds);

        // Load the next scene
        SceneManager.LoadScene(sceneName);
    }
}

