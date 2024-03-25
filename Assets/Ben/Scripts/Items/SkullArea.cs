using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullArea : MonoBehaviour
{
    public int skullCounter = 0;

    bool inside = false;
    bool destroy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inside)
        {
            Debug.Log("head");
            destroy = true;
        }
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject == GameObject.FindWithTag("Skull") && destroy)
        {
            skullCounter++;
            inside = false;
            Destroy(other.gameObject);
  
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameObject.FindWithTag("Skull"))
        {
            destroy = false;
            inside = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject == GameObject.FindWithTag("Skull"))
        {
            inside = false;
        }
    }
}
