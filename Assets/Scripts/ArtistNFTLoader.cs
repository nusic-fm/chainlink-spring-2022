using UnityEngine;
using UnityEngine.Video;

public class ArtistNFTLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string videoUrl = "https://arweave.net/Bp2FN9YxicoL3NKOdFn0NrE_e0uZwEkRtMa3oIBoYIo";

    void Start()
    {
       
        videoPlayer.url = videoUrl;
        //videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        //videoPlayer.EnableAudioTrack(0, true);        
        videoPlayer.Prepare();
    }

    void Update()
    {

    }

}