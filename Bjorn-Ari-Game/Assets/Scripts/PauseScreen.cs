using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    bool xButton = false;
    bool isPaused = false;
    [SerializeField] 
    GameObject pauseMenu = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            isPaused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }    
        else if((Input.GetKeyDown(KeyCode.Escape) && isPaused) || xButton)
        {
            xButton = false;
            isPaused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        pauseMenu.SetActive(isPaused);
    }
    public void UnPause()
    {
        xButton = true;
    }
    public bool GetIsPaused() 
    { 
        return isPaused; 
    }
}
