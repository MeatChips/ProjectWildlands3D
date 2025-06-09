using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class Scanning : MonoBehaviour
{
    public bool CamelPowerUnlocked;
    public bool CamelPowerSelectFake;
    [SerializeField] private UnityEvent CamelPowerSelected;
    
    public float ScanRange;
    public GameObject Object1;
    public GameObject Object2;
    public ParticleSystem scanParticles; // reference to particle system

    private void Start()
    {
        CamelPowerUnlocked = false;
    }
    public MakeRockMove rockScript; // Reference to the MakerockMove script

    private void Awake()
    {
        rockScript = GameObject.Find("MoveRock").GetComponent<MakeRockMove>(); // Find the script  
    }


    // Update is called once per frame
    public void Scan(InputAction.CallbackContext context)
    {

        // if the distance between the player and the scancube is less than scanrange and L is pressed unlock camel power
        if (Vector3.Distance(Object1.transform.position, Object2.transform.position) < ScanRange && context.performed)
        {
            scanParticles.Play();
            CamelPowerUnlocked = true;
            Debug.Log("camel unlocked");
        }
    }
    public void UsePower(InputAction.CallbackContext context)
    {
 if (CamelPowerUnlocked && context.performed)

        {
            rockScript.CamelPowerUse(); // Assign the CamelPowerUse method to the event
        }     
    }
      // if the camel power has been unlocked and R is pressed, select the camelpower. causing the rock to be able to be moved
       
    }

