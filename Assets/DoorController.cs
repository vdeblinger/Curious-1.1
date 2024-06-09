using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;

    
    public void OpenDoor(GameObject obj)
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
                    animator.SetBool("Is Open", isOpen);
                    
                }
            }
        }
        
    }
}
