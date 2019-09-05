using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Room3Controller : RoomController
{
    private const float MIN_SLOW = 0.5f;
    private const float MAX_SLOW = 0.9f;

    #region fields
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform slowStart;
    [SerializeField]
    private Transform slowEnd;
    [SerializeField]
    private Text[] texts;

    private PlayerController playerController;
    private Text previousText;
    private int currentIndex;
    #endregion

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    } 

    protected override void OnUpdate()
    {
        float playerX = player.transform.position.x;
        float startX = slowStart.position.x;
        float endX = slowEnd.position.x;

        float progress = Mathf.Clamp01((playerX - startX) / (endX - startX));
        float speedFactor = 1 - (progress > 0 ? (progress * (MAX_SLOW - MIN_SLOW) + MIN_SLOW) : 0);
        playerController.speed = speedFactor * playerController.maxSpeed;

        int index = (int) Mathf.Floor(progress * texts.Length);
        if (index != currentIndex)
        {
            ShowText(index);
            currentIndex = index;
        }
    }

    protected override void OnActivate()
    {
        playerController.speed = playerController.maxSpeed;
        ShowText(0);
    }

    protected override void OnDeactivate()
    {
        playerController.speed = playerController.maxSpeed;
        ShowText(-1);
    }

    private void ShowText(int index)
    {
        bool inRange = index >= 0 && index < texts.Length;
        // Fade out previous and fade in new text
        Sequence seq = DOTween.Sequence();
        if (previousText != null)
            seq.Append(previousText.DOFade(0, 0.5f)).AppendInterval(0.5f);
        if (inRange)
            seq.Append(texts[index].DOFade(1, 0.5f));
        seq.OnComplete(() => previousText = inRange ? texts[index] : null);
        seq.Play();
    }
}