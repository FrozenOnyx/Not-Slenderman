 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool menuActive = false;
    public GameObject creditsMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuActive == true)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            menuActive = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menuActive == false)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            menuActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        menuActive = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitToDesktop()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void CreditsMenuOpen()
    {
        creditsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void CreditsMenuClose()
    {
        creditsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
