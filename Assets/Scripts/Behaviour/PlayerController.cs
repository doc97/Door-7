using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("Units per second")]
    private float maxSpeed = 1;
    [SerializeField]
    private Transform leftBoundary;
    [SerializeField]
    private Transform rightBoundary;
    [SerializeField]
    private float epsilon;
    

    void Update()
    {
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
