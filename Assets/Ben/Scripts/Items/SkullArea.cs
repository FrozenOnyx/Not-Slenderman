using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullArea : MonoBehaviour
{
    public int skullCounter = 0;
    public GameObject skull;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            skull.SetActive(false);
            skullCounter++;
            Debug.Log("head");
        }
    }
}
