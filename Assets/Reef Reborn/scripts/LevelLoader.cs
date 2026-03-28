using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Image fadeImage;
    public float duration = 1.5f;
    public string nextScene;
    bool clicked = false;   

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !clicked)
        {
            clicked = true;
            StartCoroutine(FadeInAndLoad());
        }
    }

    IEnumerator FadeInAndLoad()
    {
        Color color = fadeImage.color;
        color.a = 0;
        fadeImage.color = color;

        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;
            color.a = t / duration;
            fadeImage.color = color;
            yield return null;
        }

        // Ensure fully opaque
        color.a = 1;
        fadeImage.color = color;

        SceneManager.LoadScene(nextScene);
    }
}
