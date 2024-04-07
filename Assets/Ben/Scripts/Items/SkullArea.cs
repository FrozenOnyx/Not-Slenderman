using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkullArea : MonoBehaviour
{
    public int skullCounter = 0;
    public GameObject skull;
    public bool destroy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Debug.Log("head");
            destroy = true;
        }
        else
        {
            destroy = false;
        }
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Skull") && destroy)
        {
            skullCounter++;
            Destroy(other.gameObject);
  
        }
    }
}
