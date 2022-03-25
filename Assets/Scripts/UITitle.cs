using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UITitle : Singleton
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
        _GM.ChangedGameState(GameState.Playing);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
