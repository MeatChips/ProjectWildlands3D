using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private List<PlayerInput> players = new List<PlayerInput>(); // Players
    [SerializeField] private List<Transform> startingPoints; // Spawn points
    [SerializeField] private List<LayerMask> playerLayers; // Layermasks of different players

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

    public void AddPlayer(PlayerInput player)
    {
        // Add player to list
        players.Add(player);
    
        // Spawn player at spawnpoint
        Transform playerObj = player.transform;
        playerObj.position = startingPoints[players.Count - 1].position;
    
        // Convert layer mask (bit) to an integer representing the layer
        int layerToAdd = (int)Mathf.Log(playerLayers[players.Count - 1].value, 2);
    
        // Set the layer of the player's camera
        playerObj.GetComponentInChildren<CinemachineCamera>().gameObject.layer = layerToAdd;

        // Add the layer to the player's culling mask
        playerObj.GetComponentInChildren<Camera>().cullingMask |= 1 << layerToAdd;
    }
}
