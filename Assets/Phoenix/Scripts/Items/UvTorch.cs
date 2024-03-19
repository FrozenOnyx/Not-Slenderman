using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UvTorch : MonoBehaviour
{
    public GameObject torchLight;
    public bool torchActive = false;

    public Image torchTimeBar;

    public float timeInTorch;
    public float maxTimeOfTorch = 10f;
    // Update is called once per frame
    void Update()
    {
        TorchControls();
        TorchTime();
    }

    private void TorchControls()
    {
        if (Input.GetKeyDown(KeyCode.F) && torchActive == false)
        {
            torchActive = true;
            torchLight.SetActive(true);     
        }
        else if(Input.GetKeyDown(KeyCode.F) && torchActive == true)
        {
            torchActive = false;
            torchLight.SetActive(false);
        }
    }
    private void TorchTime()
    {
        if(torchActive == true && timeInTorch > 0)
        {
            timeInTorch -= Time.deltaTime;
            torchTimeBar.fillAmount = timeInTorch /10f;
            timeInTorch = Mathf.Clamp(timeInTorch, 0, 10f);
        }
        else if (torchActive == false && timeInTorch <= maxTimeOfTorch)
        {
            timeInTorch += Time.deltaTime;
            torchTimeBar.fillAmount = timeInTorch / 10f;
            timeInTorch = Mathf.Clamp(timeInTorch, 0, 10f);
        }
    }
}
