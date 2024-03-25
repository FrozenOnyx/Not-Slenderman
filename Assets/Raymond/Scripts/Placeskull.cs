using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeskull : MonoBehaviour
{
    public GameObject skull1;
    public GameObject skull2;
    public GameObject skull3;
    public GameObject altar;

    public SkullArea skullAreaScript;

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
            if (skullAreaScript.skullCounter == 1 && Input.GetKeyDown(KeyCode.F))
            {
                skull1.SetActive(true);
            }
            else if (skullAreaScript.skullCounter == 2 && Input.GetKeyDown(KeyCode.F))
            {
                skull2.SetActive(true);
            }
            else if (skullAreaScript.skullCounter == 3 && Input.GetKeyDown(KeyCode.F))
            {
                skull3.SetActive(true);
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
