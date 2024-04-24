using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
{
    public GameObject uv;

  
    // Update is called once per frame
    void Update()
    {
        if (!uv.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
}
