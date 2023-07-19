using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayer2D : MonoBehaviour
{
    public Rigidbody rbPlayer;
    public float speed;
    float eixoX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        eixoX = Input.GetAxisRaw("Horizontal");

        if (eixoX < 0)
        {
            transform.position = new Vector3(transform.position.x + -speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        
        if (eixoX > 0)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inicial"))
        {
            FindObjectOfType<scrDialogueTrigger>().TriggerDialogue();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Dialog"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<scrDialogueTrigger>().TriggerDialogue();
            }
        }
    }
}
