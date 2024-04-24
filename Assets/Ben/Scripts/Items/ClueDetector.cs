using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueDetector : MonoBehaviour
{
    public bool isInsideUv = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Clue"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            isInsideUv = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Clue"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            isInsideUv = false;
        }
    }
}
