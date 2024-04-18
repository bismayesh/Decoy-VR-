using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;
    public float delayBeforeTransition = 3f; // Adjust this value to set the delay before transition
    public int targetSceneIndex = 1; // Index of the target scene in the build settings

    void Start()
    {
        // Start the scene transition after the specified delay
        StartCoroutine(StartTransitionAfterDelay());
    }

    IEnumerator StartTransitionAfterDelay()
    {
        // Wait for the specified delay before starting the transition
        yield return new WaitForSeconds(delayBeforeTransition);

        // Start the scene transition
        yield return StartCoroutine(GoToSceneAsyncRoutine(targetSceneIndex));
    }

    IEnumerator GoToSceneAsyncRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        float timer = 0;
        while (timer <= fadeScreen.fadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        operation.allowSceneActivation = true;

        // Wait for the new scene to finish loading before unloading the current scene
        yield return new WaitUntil(() => operation.isDone && SceneManager.GetSceneByBuildIndex(sceneIndex).isLoaded);

        // Unload the current scene (Scene 1)
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}

