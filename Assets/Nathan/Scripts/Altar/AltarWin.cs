using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AltarWin : MonoBehaviour
{

    public SkullArea skullArea;
    public GameObject winScreen;
    public int skullsInserted;

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Altar")
        {

            Debug.Log("Colliding with altar");

            if (skullArea.skullCounter == 8 && Input.GetKey(KeyCode.F))
            {
                skullsInserted++;
                if (skullsInserted >= 8)
                {
                    winScreen.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }
    }
}
