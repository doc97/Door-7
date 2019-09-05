using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region fields
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Transform followObject;
    public Vector3 offset = Vector3.zero;
    public Transform leftBoundary;
    public Transform rightBoundary;

    private bool _isActive;
    public bool IsActive {
        get { return _isActive; }
        set { _isActive = value; }
    }
    private float _epsilon;
    public float Epsilon {
        get { return _epsilon; }
        set { _epsilon = value; }
    }
    #endregion

    void Start()
    {
        IsActive = true;
        if (cam == null)
            cam = Camera.main;
        Epsilon = cam.orthographicSize * cam.aspect;
    }

    void LateUpdate()
    {
        if (!IsActive)
            return;

        Vector3 newPosition = offset + followObject.position;
        if (newPosition.x < leftBoundary.position.x + Epsilon)
            newPosition.x = leftBoundary.position.x + Epsilon;
        if (newPosition.x > rightBoundary.position.x - Epsilon)
            newPosition.x = rightBoundary.position.x - Epsilon;
        transform.position = newPosition;
    }
}