using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Room2Controller : RoomController
{
    private const int RESET_COUNT = 3;

    #region fields
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Text text;
    [SerializeField]
    private string[] texts;
    [SerializeField]
    private Transform resetMarker;
    [SerializeField]
    private Transform resetPosition;

    private PlayerController playerController;
    private int moveCounter;
    private bool isResetActive;
    #endregion

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    protected override void OnUpdate()
    {
        if (isResetActive && player.transform.position.x > resetMarker.position.x)
        {
            isResetActive = false;
            playerController.Active = false;
            ++moveCounter;

            player.transform
                .DOMoveX(resetPosition.position.x, 2)
                .SetEase(Ease.InOutCubic)
                .OnComplete(() => {
                    isResetActive = true;
                    playerController.Active = true;
                    if (moveCounter >= RESET_COUNT)
                        Deactivate();
                });
            Sequence seq = DOTween.Sequence();
            seq.Append(text.DOFade(0, 1));
            seq.AppendCallback(() => text.text = GetNextText(moveCounter));
            seq.AppendInterval(0.5f);
            seq.Append(text.DOFade(1, 1));
            seq.Play();
        }
    }

    protected override void OnActivate()
    {
        moveCounter = 0;
        isResetActive = true;
        text.text = GetNextText(0);
    }

    protected override void OnDeactivate()
    {
        moveCounter = 0;
        isResetActive = false;
        text.text = GetNextText(-1);
    }

    private string GetNextText(int index)
    {
        if (index < 0 || index >= texts.Length)
            return "";
        return texts[index];
    }
}