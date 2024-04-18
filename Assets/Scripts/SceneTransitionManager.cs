using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;

    public void GotoScene(int sceneIndex)

    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }
    
    IEnumerator GoToSceneRoutine(int sceneIndex)

    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
    }
    

     
}
