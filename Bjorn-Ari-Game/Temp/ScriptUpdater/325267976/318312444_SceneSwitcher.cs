using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
   public void loadLevel(string levelName)
   {
    SceneManager.LoadScene(levelName);
   }
   void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            loadLevel("Menu");
        }
    }

    public void deathScene(string Death)
    {
        SceneManager.LoadScene(Death);
    }


//    public void quitGame()
//    {
//     Application.Quit();
//    }
}
