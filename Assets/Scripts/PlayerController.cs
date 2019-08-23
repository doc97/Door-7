using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Units per second")]
    public float maxSpeed = 1;

    void Update()
    {
        float inputDeltaX = Input.GetAxis("Horizontal");
        float translateX = maxSpeed * inputDeltaX * Time.deltaTime;
        transform.Translate(Vector3.right * translateX);
    }
}
