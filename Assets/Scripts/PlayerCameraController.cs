using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform PlayerTransform;
    public Transform NFTCenterPieceTransform;
    public Transform ConcertTopTransform;
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LookAtNFTCenterPiece()
    {
        cinemachineVirtualCamera.Follow = NFTCenterPieceTransform;
    }

    public void LookAtConcertTop()
    {
        cinemachineVirtualCamera.Follow = ConcertTopTransform;
    }


    public void ReturnPlayerView()
    {       
        cinemachineVirtualCamera.Follow = PlayerTransform;
        cinemachineVirtualCamera.AddCinemachineComponent<Cinemachine3rdPersonFollow>();
    }
}
