using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;
using static UnityEngine.Rendering.DebugUI.Table;

[RequireComponent(typeof(NavMeshAgent))]
public class GijsAI1 : MonoBehaviour
{
    private int currentTarget;
    private float stoppingDistance = 1.5F;
    private NavMeshAgent agent;

    [SerializeField] private List<GameObject> poopObjects = new List<GameObject>();

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < stoppingDistance && poopObjects.Count > 0)
            SetNewDestination();

        FindAndAddObjects();

        poopObjects.RemoveAll(gameObject => gameObject == null);
    }

    private void SetNewDestination()
    {
        currentTarget++;

        if (currentTarget >= poopObjects.Count)
            currentTarget = 0;
        else if (currentTarget < 0)
            currentTarget = poopObjects.Count - 1;

        agent.SetDestination(poopObjects[currentTarget].transform.position);
    }

    private void FindAndAddObjects()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Poop");

        foreach (GameObject obj in objects)
        {
            if (!poopObjects.Contains(obj)) // Avoid duplicates
            {
                poopObjects.Add(obj);
            }
        }
    }
}
