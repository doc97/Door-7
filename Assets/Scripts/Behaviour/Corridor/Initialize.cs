using UnityEngine;

public class Initialize : MonoBehaviour
{
    void Start()
    {
        CorridorState.Instance.ActiveDoor = CorridorState.Door.None;
        CorridorState.Instance.DoorToScene.Clear();
        CorridorState.Instance.DoorToScene.Add(CorridorState.Door.None, "");
        CorridorState.Instance.DoorToScene.Add(CorridorState.Door.Door1, "CorridorScene");
        CorridorState.Instance.DoorToScene.Add(CorridorState.Door.Door2, "");
        CorridorState.Instance.DoorToScene.Add(CorridorState.Door.Door3, "");
    }
}