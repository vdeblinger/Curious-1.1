using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class Note : MonoBehaviour
{
    
    public string[] line;
    public float textSpeed;
    public GameObject player;
    public GameObject noteUI;
   

    public GameObject pickUpText;
    public bool inReach;


    private int index;

    // Start is called before the first frame update
    void Start()
    {
        noteUI.SetActive(false);
        
        pickUpText.SetActive(false);

        inReach = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && inReach)
        {
            noteUI.SetActive(true);
          
            player.GetComponent<TextMeshPro>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void ExitButton()
    {
        noteUI.SetActive(false);
        player.GetComponent<TextMeshPro>().enabled = true;
    }
}
