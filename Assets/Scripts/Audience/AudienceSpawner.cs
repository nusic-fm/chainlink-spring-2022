using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceSpawner : MonoBehaviour
{
    public GameObject spotifyAudienceMember;
    public GameObject tikTokAudienceMember;
    public GameObject youTubeAudienceMember;

    public SmartContractInteraction smartContract;

    public GoalLocations goalLocationsScript;

    private ulong aokiSpotifyAudienceCount;
    private ulong aokiYouTubeAudienceCount;
    private ulong aokiTikTokAudienceCount;

    //(goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position);

    private void Start()
    {
        Invoke("SpawnAudience", 2f);
    }

    public void SpawnAudience()
    {
        aokiSpotifyAudienceCount = smartContract.AokiSpotifyAudienceNumber / 10000;
        aokiYouTubeAudienceCount = smartContract.AokiYouTubeAudienceNumber / 10000;
        aokiTikTokAudienceCount = smartContract.AokiTikTiokAudienceNumber / 10000;

        for (ulong i = 0; i < aokiSpotifyAudienceCount; i++)
        {
            Instantiate(spotifyAudienceMember, goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position, Quaternion.identity);
        }
        for (ulong i = 0; i < aokiYouTubeAudienceCount; i++)
        {
            Instantiate(youTubeAudienceMember, goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position, Quaternion.identity);
        }
        for (ulong i = 0; i < aokiTikTokAudienceCount; i++)
        {
            Instantiate(tikTokAudienceMember, goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position, Quaternion.identity);
        }
    }
}
