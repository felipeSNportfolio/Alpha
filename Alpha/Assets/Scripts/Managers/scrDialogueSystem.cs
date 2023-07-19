using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scrDialogueSystem : MonoBehaviour
{
    public Queue<string> sentences;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public Animator animBox;
    public bool endDialog;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(scrDialogue dialogue) 
    {
        Debug.Log("Conversar com " + dialogue.name);
        endDialog = false;

        nameText.text = dialogue.name;
        sentences.Clear();

        animBox.SetBool("dialog", true);

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() 
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) 
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue() 
    {
        animBox.SetBool("dialog", false);
        endDialog = true;
    }
}
