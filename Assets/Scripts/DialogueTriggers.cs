using UnityEngine;
using Fungus;
using StarterAssets;

public class DialogueTriggers : Command
{
    public GameObject Player;
    public bool isWhiteListed = false;
    public GameObject DOXInteractMessage;
    /*
    public Flowchart DOXInteractMessage;

    private void OnTriggerEnter(Collider other)
    {
        DOXInteractMessage.SetBooleanVariable("isInDOXTrigger", true);
        Fungus.Flowchart.BroadcastFungusMessage("DOXPrompt");
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DOXInteractMessage.SetBooleanVariable("isInDOXTrigger", false);
            InteractWithDOX();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DOXInteractMessage.SetBooleanVariable("isInDOXTrigger", false);
    }*/

    public override void OnEnter()
    {
        Fungus.Flowchart.BroadcastFungusMessage("ShowTutorial");
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
}