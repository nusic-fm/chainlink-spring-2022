using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Moralis.Web3Api.Models;
using MoralisWeb3ApiSdk;

public class ArtistNFTLoader : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public string videoUrl = "https://arweave.net/Bp2FN9YxicoL3NKOdFn0NrE_e0uZwEkRtMa3oIBoYIo";
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
        videoPlayer.url = videoUrl;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        audioSource = GetComponent<AudioSource>();
        videoPlayer.SetTargetAudioSource(0, audioSource);
        videoPlayer.EnableAudioTrack(0, true);
        
        videoPlayer.Prepare();
    }

    // Update is called once per frame
    void Update()
    {

    }

}