using UnityEngine;
using UnityEngine.Events;


public class Scanning : MonoBehaviour
{
    public bool CamelPowerUnlocked;
    public bool CamelPowerSelectFake;
    [SerializeField] private UnityEvent CamelPowerSelected;
    
    public float ScanRange;
    public GameObject Object1;
    public GameObject Object2;

    private void Start()
    {
        CamelPowerUnlocked = false;
    }
    // Update is called once per frame
    void Update()
    {
        //if the distance between the player and the scancube is less than scanrange and L is pressed unlock camel power
        if (Vector3.Distance(Object1.transform.position, Object2.transform.position) < ScanRange && Input.GetKeyDown(KeyCode.L))
        {
            CamelPowerUnlocked= true;
            Debug.Log("unlocked");
        }
        
      //if the camel power has been unlocked and R is pressed, select the camelpower. causing the rock to be able to be moved
        if (CamelPowerUnlocked && Input.GetKeyDown(KeyCode.R))

        {
           
            CamelPowerSelected.Invoke();
         
        }
       
    }
}
