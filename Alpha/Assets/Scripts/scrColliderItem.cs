using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrColliderItem : MonoBehaviour
{
    bool getItem;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && getItem)
        {
            FindObjectOfType<scrDialogueTrigger>().TriggerDialogue();
        }

        if (FindObjectOfType<scrDialogueSystem>().endDialog == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            getItem = true;
        }
    }
}
