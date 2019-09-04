using UnityEngine;
using DG.Tweening;

public class Room2Controller : MonoBehaviour
{
    private const int RESET_COUNT = 3;

    #region fields
    [SerializeField]
    private GameObject player;
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
            player.transform
                .DOMoveX(resetPosition.position.x, 2)
                .SetEase(Ease.InOutCubic)
                .OnComplete(() => {
                    IsActive = true;
                    playerController.Active = true;
                    ++moveCounter;
                    if (moveCounter >= RESET_COUNT)
                        Deactivate();
                });
        }
    }

    public void Activate()
    {
        moveCounter = 0;
        IsActive = true;
    }

    public void Deactivate()
    {
        moveCounter = 0;
        IsActive = false;
    }
}