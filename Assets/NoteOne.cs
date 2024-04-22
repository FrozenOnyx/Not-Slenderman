using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteOne : MonoBehaviour
{
    public bool inNote = false;
    public TextMeshProUGUI notePage;
    public string note;
    public GameObject noteThing;

    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.F) && inNote && !isPaused) 
        
       {
            Debug.Log("note one touched");
            Time.timeScale = 0;
            notePage.SetText(note);
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
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            inNote = false;
        }
    }
}
