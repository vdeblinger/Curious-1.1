using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    private NPCController npc;
    private ChestController chest;

    // Update is called once per frame
    void Update()
    {
        if(!inDialogue())
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }  
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    private bool inDialogue()
    {
        if (npc != null)
            return npc.DialogueActive();
        else 
            return false;   
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            npc = collision.gameObject.GetComponent<NPCController>();   

            if (Input.GetKey(KeyCode.E))
                collision.gameObject.GetComponent<NPCController>().ActiveDialogue();
        }
        if (collision.gameObject.tag == "Object")
        {
            chest = collision.gameObject.GetComponent<ChestController>();

            if (Input.GetKey(KeyCode.E))
                collision.gameObject.GetComponent<ChestController>().OpenChest();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        npc = null;
    }
    
}
