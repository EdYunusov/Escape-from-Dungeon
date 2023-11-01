using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private const string MainMenuSceneTitle = "MainMenu";
    private const string LevelOne = "maze_one";

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneTitle);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(LevelOne);
    }
}
