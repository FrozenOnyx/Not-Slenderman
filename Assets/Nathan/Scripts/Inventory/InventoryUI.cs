using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public GameObject InventoryMenu;
    private bool menuActive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && menuActive == true)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActive = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && menuActive == false)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActive = true;
        }
    }
}
