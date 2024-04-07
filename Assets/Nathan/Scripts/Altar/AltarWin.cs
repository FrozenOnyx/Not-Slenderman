using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarWin : MonoBehaviour
{

    public SkullArea skullArea;
    public GameObject winScreen;

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == Altar)
        {
            Destroy(collision.gameObject);
        }
    }
}
