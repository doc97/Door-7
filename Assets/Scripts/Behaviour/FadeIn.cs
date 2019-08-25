using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeIn : MonoBehaviour
{
    [Tooltip("Duration in seconds")]
    public float duration;
    [Tooltip("Ease function")]
    public Ease ease = Ease.Linear;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        image.color = Color.black;
        image.DOFade(0, duration).SetEase(ease);
    }
}
