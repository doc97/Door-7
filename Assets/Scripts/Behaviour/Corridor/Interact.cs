using UnityEngine;

public class Interact : MonoBehaviour
{
    public Controller controller;

    void Update()
    {
        if (IsButtonDown() && HasActiveDoor())
            controller.LoadScene(GetSceneFromDoor());
    }

    private bool IsButtonDown()
    {
        return Input.GetAxis("Interact") == 1;
    }

    private bool HasActiveDoor()
    {
        return CorridorState.Instance.ActiveDoor != CorridorState.Door.None;
    }

    private string GetSceneFromDoor()
    {
        string scene;
        CorridorState.Door door = CorridorState.Instance.ActiveDoor;
        if (!CorridorState.Instance.DoorToScene.TryGetValue(door, out scene))
            return "";
        return scene;
    }
}
