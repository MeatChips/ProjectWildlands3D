
 using System;
 using UnityEngine;
 using UnityEngine.AI;
 
 [RequireComponent(typeof(NavMeshAgent))]
public class AIAgent : MonoBehaviour
{
    [SerializeField]
    private Transform[] targets;
    private int currentTarget;
    private NavMeshAgent agent;
    private float stoppingDistance = 1.5F;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(targets[currentTarget].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < stoppingDistance)
            SetNewDestination();
    }

    private void SetNewDestination()
    {
        currentTarget++;

        if (currentTarget >= targets.Length)
            currentTarget = 0;
        else if (currentTarget < 0)
            currentTarget = targets.Length - 1;

        agent.SetDestination(targets[currentTarget].position);
    }
}