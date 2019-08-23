using UnityEngine;

public class FollowObject : MonoBehaviour {
    public bool snapAtStart;
    public Transform target;
    public float smoothTime = 0.2f;
    [Tooltip("Units per second")]
    public float maxSpeed = Mathf.Infinity;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        if (snapAtStart)
            transform.position = offset + target.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = offset + target.position;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime, maxSpeed);
        transform.position = smoothedPosition;
    }
}