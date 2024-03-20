using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UvTorch : MonoBehaviour
{
    public GameObject torchLight;
    public bool torchActive = false;
    public bool torchDisbled = false;

    public Image torchTimeBar;

    public float timeInTorch;
    public float maxTimeOfTorch = 10f;
    // Update is called once per frame
    void Update()
    {
        TorchControls();
        TorchTime();
        TorchDisable();
    }

    private void TorchControls()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && torchActive == false && torchDisbled == false)
        {
            torchActive = true;
            torchLight.SetActive(true);     
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && torchActive == true && torchDisbled == false)
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
            torchTimeBar.fillAmount = timeInTorch /maxTimeOfTorch;
            timeInTorch = Mathf.Clamp(timeInTorch, 0, maxTimeOfTorch);
        }
        else if (torchActive == false && timeInTorch <= maxTimeOfTorch)
        {
            timeInTorch += Time.deltaTime;
            torchTimeBar.fillAmount = timeInTorch / maxTimeOfTorch;
            timeInTorch = Mathf.Clamp(timeInTorch, 0, maxTimeOfTorch);
        }
    }

    private void TorchDisable()
    {
        if(timeInTorch <= 0)
        {
            torchActive = false;
            torchLight.SetActive(false);
            torchDisbled = true;
        }
        else if(timeInTorch >= 4)
        {
            torchDisbled = false;
        }
    }
}
