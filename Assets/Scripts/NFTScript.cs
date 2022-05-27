using UnityEngine;

public class NFTScript : MonoBehaviour
{
    public static bool ShowingTutorial = true;
    public GameObject NFTInteractMessage;
    public bool interacting = false;

    public Component[] orbitScripts;
    public AudioSource audioSource;

    private void Start()
    {
        NFTInteractMessage.SetActive(false);
    }
    public void StartNFT()
    {
        orbitScripts = GetComponentsInChildren<Orbit>();
        audioSource = GetComponent<AudioSource>();

        foreach (Orbit orbiter in orbitScripts)
            orbiter.isActive = true;

        DialogueTriggers.isWhiteListed = true;
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!ShowingTutorial)
            NFTInteractMessage.SetActive(true);
        else
            NFTInteractMessage.SetActive(false);
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!DialogueTriggers.isWhiteListed)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                NFTInteractMessage.SetActive(false);
                InteractWithNFT();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        NFTInteractMessage.SetActive(false);
    }

    public void InteractWithNFT()
    {
        interacting = true;
        if (!DialogueTriggers.isWhiteListed)
        {
            Fungus.Flowchart.BroadcastFungusMessage("ShowTutorial");
            ShowingTutorial = true;
        }
        else
        {
            
        }
    }

    public void StopInteraction()
    {
        interacting = false;
        ShowingTutorial = false;
    }
}
