using UnityEngine;
using Fungus;
using StarterAssets;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;
using UnityEngine.Networking;

public class DialogueTriggers : Command
{
    public GameObject Player;
    public static bool isWhiteListed = false;
    
    public bool interacting = false;
    public GameObject DOXInteractMessage;

    public string path;
    public RawImage rawImage;

    public void OpenExplorer()
    {
        path = "";// EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
        StartCoroutine(GetTexture());
    }

    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("file:///" + path); ;

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else 
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            rawImage.texture = myTexture;
        }
    }

    public override void OnEnter()
    {
        Fungus.Flowchart.BroadcastFungusMessage("ShowTutorial");
        NFTScript.ShowingTutorial = true;
    }

    private void OnTriggerEnter(Collider other)
    {
         DOXInteractMessage.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            DOXInteractMessage.SetActive(false);
            InteractWithDOX();
        }
    }

    private void OnTriggerExit(Collider other)
    {

        DOXInteractMessage.SetActive(false);
    }

    public void InteractWithDOX()
    {
        interacting = true;
        if (!isWhiteListed)
        {
            Fungus.Flowchart.BroadcastFungusMessage("NotWhiteListed");
        }
        else
        {
            Fungus.Flowchart.BroadcastFungusMessage("IsWhiteListed");
        }
    }

    public void InputName()
    {
#if UNITY_WEBGL

        Player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
        FirstPersonController.CanMove = false;
#else

#endif
        FirstPersonController.CanMove = false;
    }

    public void DoneInputName()
    {
#if UNITY_WEBGL

        Player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        FirstPersonController.CanMove = true;
#else

#endif
    }

    public void StopInteractWithDOX()
    {
        interacting = false;
    }
}