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
            InventoryMenu.SetActive(false);
            menuActive = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && menuActive == false)
        {
            InventoryMenu.SetActive(true);
            menuActive = true;
        }
    }
}
