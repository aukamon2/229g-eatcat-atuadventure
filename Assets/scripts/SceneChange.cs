using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
  public void MainMenu()
  {
        SceneManager.LoadSceneAsync(0);
  }
    public void GamePlay()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Credit() 
    {
        SceneManager.LoadSceneAsync(2);
    }
}
