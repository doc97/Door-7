using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SplashFade : MonoBehaviour
{
    private const string NEXT_SCENE = "CorridorScene";

    void Start()
    {
        Text text = GetComponent<Text>();
        text.color = new Color(1, 1, 1, 0);

        Sequence seq = DOTween.Sequence()
            .PrependInterval(2)
            .Append(text.DOFade(1, 3))
            .AppendInterval(3)
            .Append(text.DOFade(0, 3))
            .AppendInterval(1)
            .OnComplete(() => LoadScene(NEXT_SCENE));
    }

    private void LoadScene(string name)
    {
        StartCoroutine(LoadSceneAsync(name));
    }
    
    private IEnumerator LoadSceneAsync(string name)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(name);
        while (!load.isDone)
            yield return null;
    }
}
