using UnityEngine;


public class Scanning : MonoBehaviour
{
    public bool CamelPowerUnlocked;
    public bool CamelPowerSelected;

    
    public float ScanRange;
    public GameObject Object1;
    public GameObject Object2;


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Object1.transform.position, Object2.transform.position) < ScanRange) //&& Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("unlocked");
        }
        else
        {
            Debug.Log("locked");
        }
        //if (CamelPowerUnlocked == false)
        //{
          //  Debug.Log("not unlocked");
        //}
          //  else //(CamelPowerUnlocked == true)
        //{
            
        //}
    }
}
