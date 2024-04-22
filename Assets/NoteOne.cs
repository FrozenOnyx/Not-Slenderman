using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteOne : MonoBehaviour
{
    public bool inNote = false;
    public TextMeshProUGUI noteTextOne;
    public TextMeshProUGUI noteTextTwo;
    public TextMeshProUGUI noteTextThree;
    public TextMeshProUGUI noteTextFour;
    public TextMeshProUGUI noteTextFive;
    public TextMeshProUGUI noteTextSix;
    
    public GameObject interact;

    public string noteLineOne;
    public string noteLineTwo;
    public string noteLineThree;
    public string noteLineFour;
    public string noteLineFive;
    public string noteLineSix;
    public GameObject noteThing;

    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.F) && inNote && !isPaused) 
        
       {
            Debug.Log("note one touched");
            Time.timeScale = 0;
            noteTextOne.SetText(noteLineOne);
            noteTextTwo.SetText(noteLineTwo);
            noteTextThree.SetText(noteLineThree);
            noteTextFour.SetText(noteLineFour);
            noteTextFive.SetText(noteLineFive);
            noteTextSix.SetText(noteLineSix);
            isPaused = true;
            noteThing.SetActive(true);
       } 
       else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
            noteThing.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inNote = true;
            interact.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            inNote = false;
            interact.SetActive(false);
        }
    }
}
