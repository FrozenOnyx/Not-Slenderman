using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AltarWin : MonoBehaviour
{

    public SkullArea skullArea;
    public GameObject winScreen;

    public bool playerWins = false;
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Altar")
        {

            Debug.Log("Colliding with altar");

            if (skullArea.skullCounter == 8 && Input.GetKey(KeyCode.F))
            {
                winScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
