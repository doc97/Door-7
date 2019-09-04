using UnityEngine;

public class DevTools : MonoBehaviour
{
    #region fields
    [SerializeField]
    private GameObject management;

    private RoomTransition roomTransition;
    #endregion

    void Start()
    {
        roomTransition = management.GetComponent<RoomTransition>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            roomTransition.GotoRoom(0, true);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            roomTransition.GotoRoom(1, true);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            roomTransition.GotoRoom(2, true);
    }
}