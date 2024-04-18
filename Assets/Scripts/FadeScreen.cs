using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2;
    public Color fadeColor;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend=GetComponent<Renderer>();
        if (fadeOnStart)
            FadeIn();
    }

    public void FadeIn()
    {
        Fade(1, 0);
    }
    public void FadeOut()
    {
        Fade(0,1);
    }

    public void Fade(float alphaIN, float alphaOut)
    {
        StartCoroutine (FadeRoutine(alphaIN, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIN, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration) 
        {
            Color newColor= fadeColor;
            newColor.a = Mathf.Lerp(alphaIN, alphaOut, timer/fadeDuration);

            rend.material.SetColor("_Color", newColor);

            timer +=Time.deltaTime;
            yield return null;
        }
        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;

        rend.material.SetColor("_Color", newColor2);
    }
}
