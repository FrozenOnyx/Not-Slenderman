using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public GameObject InventoryMenu;
    private bool menuActive = false;
    public GameObject slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8;
    public bool nearSkull;
    public bool nearAltar;

    private bool slotActive1 = false;
    private bool slotActive2 = false;
    private bool slotActive3 = false;
    private bool slotActive4 = false;
    private bool slotActive5 = false;
    private bool slotActive6 = false;
    private bool slotActive7 = false;
    private bool slotActive8 = false;



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

        if (Input.GetKeyDown(KeyCode.Q) && nearSkull == true) //nearSkull will check if player is near a skull, change variable if needed
        {
            if (slotActive1 == false)
            {
                Debug.Log("Slot1Active");
                slot1.SetActive(true);
                slotActive1 = true;
            } 
            else if (slotActive2 == false)
            {
                Debug.Log("Slot2Active");
                slot2.SetActive(true);
                slotActive2 = true;
            }
            else if (slotActive3 == false)
            {
                Debug.Log("Slot3Active");
                slot3.SetActive(true);
                slotActive3 = true;
            }
            else if (slotActive4 == false)
            {
                Debug.Log("Slot4Active");
                slot4.SetActive(true);
                slotActive4 = true;
            }
            else if (slotActive5 == false)
            {
                Debug.Log("Slot5Active");
                slot5.SetActive(true);
                slotActive5 = true;
            }
            else if (slotActive6 == false)
            {
                Debug.Log("Slot6Active");
                slot6.SetActive(true);
                slotActive6 = true;
            }
            else if (slotActive7 == false)
            {
                Debug.Log("Slot7Active");
                slot7.SetActive(true);
                slotActive7 = true;
            }
            else if (slotActive8 == false)
            {
                Debug.Log("Slot8Active");
                slot8.SetActive(true);
                slotActive8 = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && nearAltar == true)
        {
            if (slotActive8 == true)
            {
                Debug.Log("Slot8Active");
                slot8.SetActive(false);
                slotActive8 = false;
            } 
            else if (slotActive7 == true)
            {
                Debug.Log("Slot7Active");
                slot7.SetActive(false);
                slotActive7 = false;
            }
            else if(slotActive6 == true)
            {
                Debug.Log("Slot6Active");
                slot6.SetActive(false);
                slotActive6 = false;
            } 
            else if (slotActive5 == true)
            {
                Debug.Log("Slot5Active");
                slot5.SetActive(false);
                slotActive5 = false;
            }
            else if (slotActive4 == true)
            {
                Debug.Log("Slot4Active");
                slot4.SetActive(false);
                slotActive4 = false;
            }
            else if (slotActive3 == true)
            {
                Debug.Log("Slot3Active");
                slot3.SetActive(false);
                slotActive3 = false;
            }
            else if(slotActive2 == true)
            {
                Debug.Log("Slot2Active");
                slot2.SetActive(false);
                slotActive2 = false;
            } 
            else if (slotActive1 == true)
            {
                Debug.Log("Slot1Active");
                slot1.SetActive(false);
                slotActive1 = false;
            }
        }
    }
}
