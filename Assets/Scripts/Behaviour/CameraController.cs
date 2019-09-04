using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region fields
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Transform leftBoundary;
    [SerializeField]
    private Transform rightBoundary;
    [SerializeField]
    private Transform followObject;
    [SerializeField]
    private Vector3 offset = Vector3.zero;
    #endregion

    void Start()
    {
        if (cam == null)
            cam = Camera.main;
    }

    void LateUpdate()
    {
        Vector3 newPosition = offset + followObject.position;
        float camHalfWidth = cam.orthographicSize * cam.aspect;
        if (newPosition.x < leftBoundary.position.x + camHalfWidth)
            newPosition.x = leftBoundary.position.x + camHalfWidth;
        if (newPosition.x > rightBoundary.position.x - camHalfWidth)
            newPosition.x = rightBoundary.position.x - camHalfWidth;
        transform.position = newPosition;
    }
}