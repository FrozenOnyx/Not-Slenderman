using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeskull : MonoBehaviour
{
    public GameObject skull1;
    public GameObject skull2;
    public GameObject skull3;
    public GameObject skull4;
    public GameObject skull5;
    public GameObject skull6;
    public GameObject skull7;
    public GameObject skull8;
    public GameObject altar;

    public SkullArea skullAreaScript;

    public GameObject win;
    bool touched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (touched)
        {
            if (skullAreaScript.skullCounter >= 1 && Input.GetKeyDown(KeyCode.F) && !skull1.activeInHierarchy)
            {
                skull1.SetActive(true);
            }
            else if (skullAreaScript.skullCounter >= 2 && Input.GetKeyDown(KeyCode.F) && skull1.activeInHierarchy && !skull2.activeInHierarchy)
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
            }
            if (skullAreaScript.skullCounter >= 5 && Input.GetKeyDown(KeyCode.F) && skull4.activeInHierarchy && !skull5.activeInHierarchy)
            {
                skull5.SetActive(true);
            }
            else if (skullAreaScript.skullCounter >= 6 && Input.GetKeyDown(KeyCode.F) && skull5.activeInHierarchy && !skull6.activeInHierarchy)
            {
                skull6.SetActive(true);
            }
            else if (skullAreaScript.skullCounter >= 7 && Input.GetKeyDown(KeyCode.F) && skull6.activeInHierarchy && !skull7.activeInHierarchy)
            {
                skull7.SetActive(true);
            }
            else if (skullAreaScript.skullCounter >= 8 && Input.GetKeyDown(KeyCode.F) && skull7.activeInHierarchy && !skull8.activeInHierarchy)
            {
                skull8.SetActive(true);
            }
        }  
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == altar)
        {
            touched = true;
           
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == altar)
        {
            touched = false;

        }
    }
}
