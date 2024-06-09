using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int keyCount;

    public void PickupKey()
    {
        if (keyCount == 1)
        {
            return;
        }
        else
            keyCount++;
            Debug.Log("Picked up key");

    }
    public void UseKey()
    {
        keyCount--;
        Debug.Log("Used key");
    }
}
