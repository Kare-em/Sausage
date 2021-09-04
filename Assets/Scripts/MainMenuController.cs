using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private MouseController mouseController;
    private void Start()
    {
        mouseController = FindObjectOfType<MouseController>();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PlayScene");
        mouseController.enabled = false;
    }
    public void Won()
    {
        SceneManager.LoadScene("Menu");
    }
}
