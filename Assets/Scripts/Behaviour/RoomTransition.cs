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
    private int roomIndex;
    private bool isTransitioning;
    #endregion

    void Start()
    {
        Debug.Assert(leftBoundaries.Length > 0);
        Debug.Assert(leftBoundaries.Length == rightBoundaries.Length);

        playerController = player.GetComponent<PlayerController>();
        cameraController = cam.GetComponent<CameraController>();

        playerController.leftBoundary = leftBoundaries[roomIndex];
        playerController.rightBoundary = rightBoundaries[roomIndex];
        cameraController.leftBoundary = leftBoundaries[roomIndex];
        cameraController.rightBoundary = rightBoundaries[roomIndex];
    }

    void Update()
    {
        if (isTransitioning || roomIndex >= nextMarkers.Length)
            return;

        if (player.transform.position.x - playerController.epsilon > nextMarkers[roomIndex].position.x)
        {
            playerController.Active = false;
            cameraController.Active = false;
            isTransitioning = true;
            nextRoom();
            cam.transform
                .DOMoveX(cameraController.leftBoundary.position.x + cameraController.Epsilon, duration)
                .SetEase(ease)
                .OnComplete(() => {
                    playerController.Active = true;
                    cameraController.Active = true;
                    isTransitioning = false;
                });
        }
    }

    private void nextRoom()
    {
        ++roomIndex;
        playerController.leftBoundary = leftBoundaries[roomIndex];
        playerController.rightBoundary = rightBoundaries[roomIndex];
        cameraController.leftBoundary = leftBoundaries[roomIndex];
        cameraController.rightBoundary = rightBoundaries[roomIndex];
    }
}