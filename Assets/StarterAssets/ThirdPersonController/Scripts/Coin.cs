﻿using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    [SerializeField] float coinHeight = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player")
        {
            return;
        }

        // Add to the player's score
        GameManager.inst.IncrementScore();

        // Destroy this coin object
        Destroy(gameObject);
    }

    private void Start()
    {
        // Set the initial height of the coin
        SetCoinHeight();
    }

    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }

    private void SetCoinHeight()
    {
        // Set the coin's height in the Y-axis
        Vector3 newPosition = new Vector3(transform.position.x, coinHeight, transform.position.z);
        transform.position = newPosition;
    }
}