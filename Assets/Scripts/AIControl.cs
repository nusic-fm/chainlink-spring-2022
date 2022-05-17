using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    public GoalLocations goalLocationsScript;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position);
    }

    void Update()
    {
        if (agent.remainingDistance<1)
        {
            agent.SetDestination(goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position);
        }
    }
}
