using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject panel;
    public GameObject player;
    public PlayerController playerController;
    public GameObject audioMenu;
    public GameObject controlsMenu;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    private void Update()
    {
        if(playerController.isPaused)
        {
            openPauseMenu();
            playerController.isPaused = false;
        }
    }

    public void Continue()
    {

        Time.timeScale = 1;
        playerController.enabled = true;
        pauseMenu.SetActive(false);
        panel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void openPauseMenu()
    {
        if (!pauseMenu.activeSelf)
        {
            panel.SetActive(true);
            pauseMenu.SetActive(true);
            playerController.timer = 0f;
            playerController.enabled = false;
        }
        else
        {
            playerController.enabled = true;
            panel.SetActive(false);
            pauseMenu.SetActive(false);
        }

    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenAudio()
    {
        optionsMenu.SetActive(false);
        audioMenu.SetActive(true);
    }
    public void OpenControls()
    {
        optionsMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }
    public void OpenOptions()
    {
        pauseMenu.SetActive(false);
        audioMenu.SetActive(false);
        controlsMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void GoToPause()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
