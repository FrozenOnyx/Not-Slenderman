using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AltarWin : MonoBehaviour
{

    public SkullArea skullArea;
    public GameObject winScreen;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Altar")
        {
            if (skullArea.skullCounter == 8)
            {
                winScreen.SetActive(true);
            }
        }
    }
}
