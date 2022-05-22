using UnityEngine;
using UnityEngine.AI;

public class AudienceMember : MonoBehaviour
{
    public GoalLocations goalLocationsScript;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position);
        float speedMultiplier = Random.Range(0.1f, 1.5f);
        agent.speed *= speedMultiplier;
    }

    void Update()
    {
        if (agent.remainingDistance<1)
        {
            agent.SetDestination(goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position);
        }
    }
}
