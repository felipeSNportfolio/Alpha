using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDialogueTrigger : MonoBehaviour
{
    public scrDialogue dialogue;

    public void TriggerDialogue() 
    {
        FindObjectOfType<scrDialogueSystem>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<scrDialogueTrigger>().TriggerDialogue();
            }
        }
    }
}
