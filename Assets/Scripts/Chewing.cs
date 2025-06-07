using UnityEngine;
using UnityEngine.UIElements;

public class Chewing : MonoBehaviour
{
    [SerializeField] GameObject Object1;
    public GameObject leWall;

    public float ChewRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        leWall = GameObject.Find("Chew wall"); // Find the wall object in the scene
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Object1.transform.position, leWall.transform.position) < ChewRange && Input.GetKeyDown(KeyCode.R))
        {
            Destroy(leWall);
            Debug.Log("destroyed");
        }
    }
}
