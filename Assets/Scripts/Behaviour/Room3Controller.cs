using UnityEngine;

public class Room3Controller : RoomController
{
    private const float MAX_SLOW = 0.9f;

    #region fields
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform slowStart;
    [SerializeField]
    private Transform slowEnd;

    private PlayerController playerController;
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

        float slowEffect = Mathf.Clamp01((playerX - startX) / (endX - startX));
        float speedFactor = 1 - slowEffect * MAX_SLOW;
        playerController.speed = speedFactor * playerController.maxSpeed;
    }

    protected override void OnActivate()
    {
        playerController.speed = playerController.maxSpeed;
    }

    protected override void OnDeactivate()
    {
        playerController.speed = playerController.maxSpeed;
    }
}