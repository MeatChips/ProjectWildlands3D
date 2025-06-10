using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class ScanningNaked : MonoBehaviour
{
    public bool ChewPowerUnlocked;

    public float ScanRange;
    public GameObject Object1;
    public GameObject Object2;

    private void Start()
    {
        ChewPowerUnlocked = false;
    }

    // Update is called once per frame
    public void Scan(InputAction.CallbackContext context)
    {

        // if the distance between the player and the scancube is less than scanrange and L is pressed unlock camel power
        if (Vector3.Distance(Object1.transform.position, Object2.transform.position) < ScanRange && context.performed)
        {
            ChewPowerUnlocked = true;
            Debug.Log("camel unlocked");
        }
    }
    public void UsePower(InputAction.CallbackContext context)
    {
        if (ChewPowerUnlocked && context.performed)

        {
        }
    }
    // if the camel power has been unlocked and R is pressed, select the camelpower. causing the rock to be able to be moved

}

