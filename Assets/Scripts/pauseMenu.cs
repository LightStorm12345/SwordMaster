using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void GameExit()
    {
        Application.Quit();
    }
    public void Respawm()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
