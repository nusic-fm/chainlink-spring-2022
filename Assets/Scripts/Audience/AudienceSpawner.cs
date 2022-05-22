using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceSpawner : MonoBehaviour
{
    public GameObject spotifyAudienceMember;
    public GameObject tikTokAudienceMember;
    public GameObject youTubeAudienceMember;

    public GoalLocations goalLocationsScript;

    private int spotifyAudienceCount = 15000;
    private int tikTokAudienceCount;
    private int youTubeAudienceCount;

    //(goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position);

    private void Start()
    {
        for (int i = 0; i < spotifyAudienceCount; i++)
        {
            Instantiate(spotifyAudienceMember, goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position, Quaternion.identity);
        }
    }
}
