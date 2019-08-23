using UnityEngine;

public class Initialize : MonoBehaviour
{
    void Start()
    {
        CorridorState.Instance.ActiveDoor = CorridorState.Door.None;
        CorridorState.Instance.DoorToScene.Clear();
        CorridorState.Instance.DoorToScene.Add(CorridorState.Door.None, "");
        CorridorState.Instance.DoorToScene.Add(CorridorState.Door.Door1, "Room1Scene");
        CorridorState.Instance.DoorToScene.Add(CorridorState.Door.Door2, "Room2Scene");
        CorridorState.Instance.DoorToScene.Add(CorridorState.Door.Door3, "Room3Scene");
    }
}