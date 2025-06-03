using UnityEngine;

public class Prairiedogpuzzle : MonoBehaviour
{
    [SerializeField] private float Proximity;
    [SerializeField] private GameObject Object1;
    [SerializeField] private GameObject Object2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Object1.transform.position, Object2.transform.position) < Proximity)
        {
            Debug.Log("doine");
        }
    }
}
