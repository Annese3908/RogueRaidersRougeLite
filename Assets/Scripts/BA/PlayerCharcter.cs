using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    private int health;
    private Vector3 respawnPoint; // Store the respawn position

    void Start() {
        health = 5;
        respawnPoint = transform.position; // Set the initial position as the respawn point
    }

    // Method to call to deal damage to the player
    public void Hurt(int damage) {
        health -= damage;
        Debug.Log($"Health: {health}");

        if (health <= 0) {
            Respawn();
        }
    }


    //CODING TASK 3 add one new feature to our game! I chose to modify the playcharcter script 
    // because the health of th player would keep 
    // dropping into the negative values which should be possible
    // Death Message
    void Respawn() {
        Debug.Log("Player has died! Restart");
        transform.position = respawnPoint; // Move the player to a starting point
        health = 5; // Reset health to start playing the game again
    }
}
