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

    public SkullArea skullArea;

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

        if (Input.GetKey(KeyCode.F))
        {
            if (skullArea.skullCounter == 1)
            {
                Debug.Log("Slot1Active");
                slot1.SetActive(true);
            }
            else if (skullArea.skullCounter == 2)
            {
                Debug.Log("Slot2Active");
                slot1.SetActive(true);
                slot2.SetActive(true);
            }
            else if (skullArea.skullCounter == 3)
            {
                Debug.Log("Slot3Active");
                slot1.SetActive(true);
                slot2.SetActive(true);
                slot3.SetActive(true);
            }
            else if (skullArea.skullCounter == 4)
            {
                Debug.Log("Slot4Active");
                slot1.SetActive(true);
                slot2.SetActive(true);
                slot3.SetActive(true);
                slot4.SetActive(true);
            }
            else if (skullArea.skullCounter == 5)
            {
                Debug.Log("Slot5Active");
                slot1.SetActive(true);
                slot2.SetActive(true);
                slot3.SetActive(true);
                slot4.SetActive(true);
                slot5.SetActive(true);
            }
            else if (skullArea.skullCounter == 6)
            {
                Debug.Log("Slot6Active");
                slot1.SetActive(true);
                slot2.SetActive(true);
                slot3.SetActive(true);
                slot4.SetActive(true);
                slot5.SetActive(true);
                slot6.SetActive(true);
            }
            else if (skullArea.skullCounter == 7)
            {
                Debug.Log("Slot7Active");
                slot1.SetActive(true);
                slot2.SetActive(true);
                slot3.SetActive(true);
                slot4.SetActive(true);
                slot5.SetActive(true);
                slot6.SetActive(true);
                slot7.SetActive(true);
            }
            else if (skullArea.skullCounter == 8)
            {
                Debug.Log("Slot8Active");
                slot1.SetActive(true);
                slot2.SetActive(true);
                slot3.SetActive(true);
                slot4.SetActive(true);
                slot5.SetActive(true);
                slot6.SetActive(true);
                slot7.SetActive(true);
                slot8.SetActive(true);
            }
        }
        

        /*if (Input.GetKeyDown(KeyCode.F) && nearAltar == true)
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
        }*/
    }
}
