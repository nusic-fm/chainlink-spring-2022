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
    public ulong numToDivide = 10000;

    private void Start()
    {
        Invoke("SpawnAudience", 2f);
    }

    public void SpawnAudience()
    {
        aokiSpotifyAudienceCount = smartContract.AokiSpotifyAudienceNumber / numToDivide;
        aokiYouTubeAudienceCount = smartContract.AokiYouTubeAudienceNumber / numToDivide;
        aokiTikTokAudienceCount = smartContract.AokiTikTiokAudienceNumber / numToDivide;

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

        Destroy(spotifyAudienceMember);
        Destroy(tikTokAudienceMember);
        Destroy(youTubeAudienceMember);
    }
}
