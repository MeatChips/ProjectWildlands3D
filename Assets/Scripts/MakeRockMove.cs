using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class MakeRockMove : MonoBehaviour
{

    public bool PowerActive;
    public Rigidbody rb;
    private void Start()
    {
        //get the rigid body and make sure every setting is set to default
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    //private void Update()
    //{//if the power is active (aka the previous event has been completed make the rock movable (by setting kinematic to false)
    //    if (PowerActive)
    //    {
    //        rb.WakeUp();
    //        rb.isKinematic = false;
           
    //    }
    //}
    public void CamelPowerUse()
    {
        //when the event is recieved set power active to true
        PowerActive = true;
        rb.isKinematic = false;

        Debug.Log("Used");
    }
    
    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.G))
     //   {
    //        rb.isKinematic = true ;
     //   }
    //}
}
