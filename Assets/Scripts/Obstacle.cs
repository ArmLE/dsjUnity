using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;

public class Obstacle : MonoBehaviour {

    ThirdPersonController playerMovement;

	private void Start () {
        playerMovement = GameObject.FindObjectOfType<ThirdPersonController>();
	}

   public void OnTriggerEnter(Collider other)
        {
        if (other.gameObject.CompareTag("Player")) // Usar CompareTag para comparar tags
        {
            // Kill the player
            playerMovement.PlayerDeath(); // Llama al nuevo método de reinicio
        }
    }

    private void Update () {
	
	}
}