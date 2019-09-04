using UnityEngine;

public class Room4Controller : RoomController
{
    #region fields
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject roomTransitionObject;

    private RoomTransition roomTransition;
    #endregion

    void Start()
    {
        roomTransition = roomTransitionObject.GetComponent<RoomTransition>();
    }

    protected override void OnUpdate()
    {
        if (player.position.y < -10)
            roomTransition.GotoRoom(0, true);
    }

    protected override void OnActivate() {}
    protected override void OnDeactivate() {}
}