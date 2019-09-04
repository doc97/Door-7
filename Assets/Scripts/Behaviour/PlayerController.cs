using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region fields
    [SerializeField, Tooltip("Units per second")]
    private float maxSpeed = 1;
    public float epsilon;
    public Transform leftBoundary;
    public Transform rightBoundary;

    private bool _active;
    public bool Active {
        get { return _active; }
        set { _active = value; }
    }
    #endregion

    void Start()
    {
        Active = true;
    }

    void Update()
    {
        if (!Active)
            return;

        Vector3 newPosition = transform.position;
        float inputDeltaX = Input.GetAxis("Horizontal");
        float translateX = maxSpeed * inputDeltaX * Time.deltaTime;
        newPosition += Vector3.right * translateX;
        if (newPosition.x < leftBoundary.position.x + epsilon)
            newPosition.x = leftBoundary.position.x + epsilon;
        if (newPosition.x > rightBoundary.position.x - epsilon)
            newPosition.x = rightBoundary.position.x - epsilon;
        transform.position = newPosition;
    }
}
