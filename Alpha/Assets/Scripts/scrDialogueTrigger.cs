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
}
