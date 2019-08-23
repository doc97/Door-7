using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private bool isLoading;

    public void LoadScene(string name)
    {
        if (isLoading || !SceneExists(name))
            return;

        isLoading = true;
        StartCoroutine(LoadSceneAsync(name));
    }

    private IEnumerator LoadSceneAsync(string name)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(name);

        while (!load.isDone)
        {
            yield return null;
        }
        isLoading = false;
    }

    private bool SceneExists(string name)
    {
        // Returns -1 if the scene does not exist in BuildSettings
        return SceneUtility.GetBuildIndexByScenePath(name) >= 0;
    }
}