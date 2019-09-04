using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Room2Controller : MonoBehaviour
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
    private bool _isActive;
    public bool IsActive {
        get { return _isActive; }
        set { _isActive = value; }
    }
    #endregion

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!IsActive)
            return;

        if (player.transform.position.x > resetMarker.position.x)
        {
            IsActive = false;
            playerController.Active = false;
            ++moveCounter;

            player.transform
                .DOMoveX(resetPosition.position.x, 2)
                .SetEase(Ease.InOutCubic)
                .OnComplete(() => {
                    IsActive = true;
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

    public void Activate()
    {
        moveCounter = 0;
        IsActive = true;
        text.text = GetNextText(0);
    }

    public void Deactivate()
    {
        moveCounter = 0;
        IsActive = false;
        text.text = GetNextText(-1);
    }

    private string GetNextText(int index)
    {
        if (index < 0 || index >= texts.Length)
            return "";
        return texts[index];
    }
}