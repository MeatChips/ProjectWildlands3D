using UnityEngine;
using UnityEngine.UIElements;

public class Chewing : MonoBehaviour
{
    [SerializeField] GameObject Object1;
    [SerializeField] GameObject Object2;

    public float ChewRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Object1.transform.position, Object2.transform.position) < ChewRange && Input.GetKeyDown(KeyCode.R))
        {
            Destroy(gameObject);
            Debug.Log("destroyed");
        }
    }
}
