using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject wendigo;

    public GameObject gameOverUi;
    public bool playerIsDead = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == wendigo)
        {
            Debug.Log("dead");
            playerIsDead = true;
            gameOverUi.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
