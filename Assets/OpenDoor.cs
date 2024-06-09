using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenDoor : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;
    public Rigidbody2D rb;
    public bool inRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    public void OpeningDoor(GameObject obj)
    {
        if (!isOpen)
        {
            PlayerManager manager = obj.GetComponent<PlayerManager>();
            if (manager)
            {
                if (manager.keyCount > 0)
                {
                    isOpen = true;
                    manager.UseKey();
                    Debug.Log("Door Is Now Open");
                    animator.SetBool("isOpen", isOpen);
                    Debug.Log("Door Is Now Open");
                }
            }
        }

    }
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                animator.Play("ODtest");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log("Player now in range");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            Debug.Log("Player now out of range");
        }
    }
}
