using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public string levelSelect, mainMenu;
    public GameObject pauseScreen;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }
    public void PauseUnpause()
    {
        if(isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale= 1; // continue the game with a time scale of 1
        }else{
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale= 0f; // stop the game by stopping time
        }
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
