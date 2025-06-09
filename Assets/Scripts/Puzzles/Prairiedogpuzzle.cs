using UnityEngine;

public class Prairiedogpuzzle : MonoBehaviour
{
    [SerializeField] private float Proximity;
    [SerializeField] private GameObject Object1;
    [SerializeField] private GameObject Object2;
    [SerializeField] private GameObject Object3;
    [SerializeField] private GameObject Object4;
    [SerializeField] private GameObject Object5;
    [SerializeField] private GameObject uiCanvas;
    public bool iscreated;
    public bool iscreated2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Object4.SetActive(false);
        Object5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Object1.transform.position, Object2.transform.position) < Proximity && !iscreated && !iscreated2) 
        {
            Instantiate(Object3,transform.position, Quaternion.identity);
            iscreated = true;
            Object4.SetActive(true);
            Object5.SetActive(true);
            iscreated2 = true;
            uiCanvas.gameObject.SetActive(false);
            Debug.Log("doine");
        }
    }
}
