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
        // get the rigid body and make sure every setting is set to default
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    public void CamelPowerUse()
    {
        PowerActive = true; // when the function is called set power active to true
        rb.isKinematic = false; // this makes the rock moveable/effected by gravity
    }
}
