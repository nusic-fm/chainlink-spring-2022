using UnityEngine;
using Fungus;

public class DialogueTriggers : Command
{
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
}