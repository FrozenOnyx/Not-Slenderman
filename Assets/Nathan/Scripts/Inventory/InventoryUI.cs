using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public GameObject InventoryMenu;
    private bool menuActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("e") && menuActive == true)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActive = false;
        }

        if (Input.GetButtonDown("e") && menuActive == false)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActive = true;
        }
    }
}
