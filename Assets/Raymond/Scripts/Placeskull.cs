using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeskull : MonoBehaviour
{
    public GameObject skull1; // public game objects for each of the skulls
    public GameObject skull2;
    public GameObject skull3;
    public GameObject skull4;
    public GameObject altar;

    public SkullArea skullAreaScript; // reference to skull area script

    public AudioSource wind;
    public PlayerMovement player;

    public GameObject win;
    bool touched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (touched) // if and if else statement checking to see how many skulls have been picked up in order to display how many will appear on the altar when interacted with
        {
            if (skullAreaScript.skullCounter >= 1 && Input.GetKeyDown(KeyCode.F) && !skull1.activeInHierarchy)
            {
                skull1.SetActive(true);
            }
            else if (skullAreaScript.skullCounter >= 2 && Input.GetKeyDown(KeyCode.F) && skull1.activeInHierarchy && !skull2.activeInHierarchy) // checks to see if skull counter is greater than or equal to 2, as well as keycode pressed being f and checks if skulls are active or now active in hierarchy
            {
                skull2.SetActive(true);
            }
            else if (skullAreaScript.skullCounter >= 3 && Input.GetKeyDown(KeyCode.F) && skull2.activeInHierarchy && !skull3.activeInHierarchy)
            {
                skull3.SetActive(true);
            }
            else if (skullAreaScript.skullCounter >= 4 && Input.GetKeyDown(KeyCode.F) && skull3.activeInHierarchy && !skull4.activeInHierarchy)
            {
                skull4.SetActive(true);
                win.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                player.audioOff = true;
                wind.Stop();
            }
        }  
    }

    public void OnTriggerEnter(Collider other) // if within radius of altar enables the touch if statements 
    {
        if(other.gameObject == altar)
        {
            touched = true;
           
        }
    }
    public void OnTriggerExit(Collider other) //  when outside of the altar disables if statement
    {
        if (other.gameObject == altar)
        {
            touched = false;

        }
    }
}
