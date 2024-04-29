using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject wendigo;

    public bool playerIsDead = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == wendigo)
        {
            SceneManager.LoadScene(2);
        }
    }
}
