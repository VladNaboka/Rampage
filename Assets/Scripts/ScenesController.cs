using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    [SerializeField] string nameSceneGame;
    [SerializeField] string nameAboutGame;
    [SerializeField] string namePrivateGame;
    [SerializeField] string nameSceneMenu;
    public void StartGame()
    {
        SceneManager.LoadScene(nameSceneGame);
        Time.timeScale = 1f;
    }
    public void StartAboutScene()
    {
        SceneManager.LoadScene(nameAboutGame);
        Time.timeScale = 1f;
    }
    public void StartPrivateScene()
    {
        SceneManager.LoadScene(namePrivateGame);
        Time.timeScale = 1f;
    }
    public void OnReturnMenu()
    {
        SceneManager.LoadScene(nameSceneMenu);
        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
