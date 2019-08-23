using UnityEngine;

public class CorridorInteract : MonoBehaviour
{
    void Update()
    {
        if (IsButtonDown() && HasActiveDoor())
            Debug.Log("Go " + CorridorState.Instance.ActiveDoor + "!");
    }

    private bool IsButtonDown()
    {
        return Input.GetAxis("Interact") != 0;
    }

    private bool HasActiveDoor()
    {
        return CorridorState.Instance.ActiveDoor != CorridorState.Door.None;
    }
}
