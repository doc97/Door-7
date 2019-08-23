﻿using UnityEngine;
using UnityEngine.Assertions;

public class DoorHighlight : MonoBehaviour
{
    private SpriteRenderer sprite;

    void Start()
    {
        Assert.AreEqual(transform.childCount, 1);
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsPlayer(other))
        {
            sprite.color = Color.white;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (IsPlayer(other))
        {
            sprite.color = Color.clear;
        }
    }

    private bool IsPlayer(Collider2D other)
    {
        return other.tag == "Player";
    }
}
