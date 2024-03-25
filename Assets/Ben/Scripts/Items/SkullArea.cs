using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullArea : MonoBehaviour
{
    public int skullCounter = 0;

    bool isPressed = false;
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
            isPressed = true;
        }
        else
        {
            isPressed = false;
        }
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject == GameObject.FindWithTag("Skull") && isPressed)
        {
            skullCounter++;
            Destroy(other.gameObject);
        }
    }
}
