﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region fields
    [Tooltip("Units per second")]
    public float maxSpeed = 1;
    [Tooltip("Units per second")]
    public float speed = 1;
    public float epsilon;
    public Transform leftBoundary;
    public Transform rightBoundary;

    private bool _isActive;
    public bool IsActive {
        get { return _isActive; }
        set { _isActive = value; }
    }
    #endregion

    void Start()
    {
        IsActive = true;
    }

    void Update()
    {
        if (!IsActive)
            return;

        Vector3 newPosition = transform.position;
        float inputDeltaX = Input.GetAxis("Horizontal");
        float translateX = speed * inputDeltaX * Time.deltaTime;
        newPosition += Vector3.right * translateX;
        if (newPosition.x < leftBoundary.position.x + epsilon)
            newPosition.x = leftBoundary.position.x + epsilon;
        if (newPosition.x > rightBoundary.position.x - epsilon)
            newPosition.x = rightBoundary.position.x - epsilon;
        transform.position = newPosition;
    }
}
