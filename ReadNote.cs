using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class ReadNote : MonoBehaviour
{
    public TextMeshProUGUI noteText;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start ()
    {
        noteText.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            noteText.text = lines[index];
        }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray()) {
            noteText.text += c; 
            yield return new WaitForSeconds(textSpeed); 
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            noteText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
