using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

// This script is mainly for the other player stuff that has nothing to do with movement
public class Player : MonoBehaviour
{
    private PlayerInput playerInput; // player Input component

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>(); // Get player input component
    }

    // If player hits deathzone, respawn it back on the spawn position
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            transform.position = GameObject.Find("SpawnPoint1").transform.position;
        }
    }

    // If player leaves game (THIS IS FOR UI). Then destroy the player
    public void LeaveGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log($"Player {playerInput.playerIndex} is leaving.");
            Destroy(gameObject); // Destroy player
        }
    }
}
