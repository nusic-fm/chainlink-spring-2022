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

    private ulong deadMouseSpotifyAudienceCount;
    private ulong deadMouseYouTubeAudienceCount;
    private ulong deadMoseTikTokAudienceCount;

    private ulong racSpotifyAudienceCount;
    private ulong racYouTubeAudienceCount;
    private ulong racTikTokAudienceCount;

    ulong numToDivide = 1000000;

    private void Start()
    {
        Invoke("SpawnAudience", 2f);
    }

    public void SpawnAudience()
    {
        if (gameObject.tag == "aoki")
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
        }
        else if (gameObject.tag == "deadMouse")
        {
            deadMouseSpotifyAudienceCount = smartContract.DeadMouseSpotifyAudienceNumber / numToDivide;
            deadMouseYouTubeAudienceCount = smartContract.DeadmouseYouTubeAudienceNumber / numToDivide;
            deadMoseTikTokAudienceCount = smartContract.DeadMouseTikTiokAudienceNumber / numToDivide;

            for (ulong i = 0; i < deadMouseSpotifyAudienceCount; i++)
            {
                Instantiate(spotifyAudienceMember, goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position, Quaternion.identity);
            }
            for (ulong i = 0; i < deadMouseYouTubeAudienceCount; i++)
            {
                Instantiate(youTubeAudienceMember, goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position, Quaternion.identity);
            }
            for (ulong i = 0; i < deadMoseTikTokAudienceCount; i++)
            {
                Instantiate(tikTokAudienceMember, goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position, Quaternion.identity);
            }
        }
        else if (gameObject.tag == "RAC")
        {
            racSpotifyAudienceCount = smartContract.RacSpotifyAudienceNumber / numToDivide;
            racYouTubeAudienceCount = smartContract.RacYouTubeAudienceNumber / numToDivide;
            racTikTokAudienceCount = smartContract.RacTikTiokAudienceNumber / numToDivide;

            for (ulong i = 0; i < racSpotifyAudienceCount; i++)
            {
                Instantiate(spotifyAudienceMember, goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position, Quaternion.identity);
            }
            for (ulong i = 0; i < racYouTubeAudienceCount; i++)
            {
                Instantiate(youTubeAudienceMember, goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position, Quaternion.identity);
            }
            for (ulong i = 0; i < racTikTokAudienceCount; i++)
            {
                Instantiate(tikTokAudienceMember, goalLocationsScript.goalLocations[Random.Range(0, goalLocationsScript.goalLocations.Length)].transform.position, Quaternion.identity);
            }
        }

        Destroy(spotifyAudienceMember);
        Destroy(tikTokAudienceMember);
        Destroy(youTubeAudienceMember);
    }
}
