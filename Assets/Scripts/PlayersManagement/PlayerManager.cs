using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private List<PlayerInput> players = new List<PlayerInput>(); // List of Players
    [SerializeField] private List<Transform> startingPoints; // List of Spawn points
    [SerializeField] private List<LayerMask> playerLayers; // List of Layermasks for different players
    [SerializeField] private List<Color> playerColors; // List of of player colors

    private PlayerInputManager playerInputManager;

    private void Awake()
    {
        // Grab the PlayerInputManager
        playerInputManager = FindAnyObjectByType<PlayerInputManager>();
    }

    private void OnEnable()
    {
        // Subscribe to the event when a player joins
        playerInputManager.onPlayerJoined += AddPlayer;
    }

    private void OnDisable()
    {
        // Unsubscribe from the event when the object is disabled
        playerInputManager.onPlayerJoined -= AddPlayer;
    }

    private void AddPlayer(PlayerInput player)
    {
        // Add player to list
        players.Add(player);

        // Get the index of this player
        int index = players.Count - 1;

        // Spawn player at spawnpoint
        Transform playerObj = player.transform;
        playerObj.position = startingPoints[players.Count - 1].position;
    
        // Convert layer mask (bit) to an integer representing the layer
        int layerToAdd = (int)Mathf.Log(playerLayers[players.Count - 1].value, 2);
    
        // Set the layer of the player's camera
        playerObj.GetComponentInChildren<CinemachineCamera>().gameObject.layer = layerToAdd;

        // Add the layer to the player's culling mask
        playerObj.GetComponentInChildren<Camera>().cullingMask |= 1 << layerToAdd;

        // Set player color (if color list and renderer exist)
        Renderer rend = playerObj.GetComponentInChildren<Renderer>();
        if (rend != null && index < playerColors.Count)
        {
            rend.material.color = playerColors[index];
        }
    }
}
