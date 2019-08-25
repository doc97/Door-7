using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Controller : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration;

    private bool isLoading;

    public void LoadScene(string name)
    {
        if (isLoading || !SceneExists(name))
            return;
        isLoading = true;
 
        // Fade to black and load new scene
        fadeImage.color = Color.clear;
        fadeImage.DOFade(1, fadeDuration).OnComplete(() => StartCoroutine(LoadSceneAsync(name)));
    }

    private IEnumerator LoadSceneAsync(string name)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(name);
        while (!load.isDone)
            yield return null;
        isLoading = false;
    }

    private bool SceneExists(string name)
    {
        // Returns -1 if the scene does not exist in BuildSettings
        return SceneUtility.GetBuildIndexByScenePath(name) >= 0;
    }
}