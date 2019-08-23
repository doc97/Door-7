using System.Collections.Generic;

/* Singleton for storing CorridorScene state */
public sealed class CorridorState
{
    private static readonly CorridorState instance = new CorridorState();

    static CorridorState() {}
    private CorridorState() {}
    public static CorridorState Instance { get { return instance; } }

    public enum Door {
        None,
        Door1,
        Door2,
        Door3
    }
    private Door _activeDoor;
    public Door ActiveDoor {
        get { return _activeDoor; }
        set { _activeDoor = value; }
    }
    private Dictionary<Door, string> _doorToScene = new Dictionary<Door, string>();
    public Dictionary<Door, string> DoorToScene {
        get { return _doorToScene; }
    }
}