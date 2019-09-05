using UnityEngine;
using DG.Tweening;

public class RoomTransition : MonoBehaviour
{
    #region fields
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private GameObject[] rooms;
    [SerializeField]
    private Transform[] leftBoundaries;
    [SerializeField]
    private Transform[] rightBoundaries;
    [SerializeField]
    private Transform[] nextMarkers;
    [SerializeField]
    private Ease ease = Ease.Linear;
    [SerializeField]
    private float duration;

    private PlayerController playerController;
    private CameraController cameraController;
    private RoomController[] roomControllers;
    private int roomIndex;
    private bool isTransitioning;
    #endregion

    void Start()
    {
        Debug.Assert(leftBoundaries.Length > 0);
        Debug.Assert(leftBoundaries.Length == rightBoundaries.Length);

        playerController = player.GetComponent<PlayerController>();
        cameraController = cam.GetComponent<CameraController>();
        roomControllers = new RoomController[rooms.Length];
        for (int i = 0; i < rooms.Length; ++i)
            roomControllers[i] = rooms[i].GetComponentInChildren<RoomController>();

        playerController.leftBoundary = leftBoundaries[roomIndex];
        playerController.rightBoundary = rightBoundaries[roomIndex];
        cameraController.leftBoundary = leftBoundaries[roomIndex];
        cameraController.rightBoundary = rightBoundaries[roomIndex];
    }

    void Update()
    {
        if (isTransitioning || roomIndex >= nextMarkers.Length)
            return;

        bool isPastMarker = player.transform.position.x - playerController.epsilon > nextMarkers[roomIndex].position.x;
        if (isPastMarker)
            GotoRoom(++roomIndex, false);
    }

    public void GotoRoom(int index, bool updatePlayerPosition)
    {
        if (isTransitioning || roomIndex >= leftBoundaries.Length)
            return;

        roomIndex = index;

        playerController.IsActive = false;
        cameraController.IsActive = false;
        isTransitioning = true;

        playerController.leftBoundary = leftBoundaries[roomIndex];
        playerController.rightBoundary = rightBoundaries[roomIndex];
        cameraController.leftBoundary = leftBoundaries[roomIndex];
        cameraController.rightBoundary = rightBoundaries[roomIndex];

        DeactivateControllers();

        if (updatePlayerPosition) {
            Vector3 position = player.transform.position;
            position.x = playerController.leftBoundary.position.x + playerController.epsilon;
            position.y = 0;
            player.transform.position = position;
        }

        ActivateController(roomIndex);

        Vector3 camTarget = new Vector3(
            cameraController.offset.x
                + cameraController.leftBoundary.position.x
                + cameraController.Epsilon,
            cameraController.offset.y,
            cameraController.offset.z
        );
        cam.transform
            .DOMove(camTarget, duration)
            .SetEase(ease)
            .OnComplete(() => {
                playerController.IsActive = true;
                cameraController.IsActive = true;
                isTransitioning = false;
            });
    }

    private void DeactivateControllers()
    {
        foreach (RoomController controller in roomControllers)
            controller?.Deactivate();
    }

    private void ActivateController(int index)
    {
        if (index < 0 || index >= roomControllers.Length)
            return;
        roomControllers[index]?.Activate();
    }
}