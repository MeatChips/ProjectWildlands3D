using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;
using static UnityEngine.Rendering.DebugUI.Table;

[RequireComponent(typeof(NavMeshAgent))]
public class GijsAI : MonoBehaviour
{
    private int currentTarget;
    [SerializeField] private Transform[] targets;
    private float stoppingDistance = 1.5F;
    private NavMeshAgent agent;

    private float timer = 4.0f;
    private float maxTimer = 4.0f;

    [SerializeField] private GameObject poopPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            LeavePoop();
            timer = maxTimer;
        }

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

    private void LeavePoop()
    {
        GameObject go = Instantiate(poopPrefab, transform.position, Quaternion.identity);
        Destroy(go, 30); //Destroy after 5 seconds.
    }
}
