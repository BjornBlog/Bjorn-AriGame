using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject CurrentNote;
    bool isPaused = false;
    [SerializeField] 
    GameObject pauseMenu = null;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                UnPause();
            }
            else if(!isPaused)
            {
                Pause();
            }   
        }    
        // pauseMenu.SetActive(isPaused);
    }
    public void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void UnPause()
    {
        CurrentNote.GetComponent<NoteScript>().Done();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public bool GetIsPaused() 
    { 
        return isPaused; 
    }
}
