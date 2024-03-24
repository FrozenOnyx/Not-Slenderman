using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public GameObject InventoryMenu;
    private bool menuActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && menuActive == true)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActive = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        } 
        else if (Input.GetKeyDown(KeyCode.E) && menuActive == false)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
