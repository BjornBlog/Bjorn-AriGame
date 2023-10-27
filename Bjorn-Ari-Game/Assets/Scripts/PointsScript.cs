using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsScript : MonoBehaviour
{
    private GameObject pauseObject;
    private PauseScreen pauseSystem;
    int points = 0;
    // Start is called before the first frame update
    void Awake()
    {
        pauseObject = GameObject.FindGameObjectWithTag ("Pause");
        pauseSystem = pauseObject.GetComponent<PauseScreen>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseSystem.GetIsPaused())
        { 
            return; 
        }

        
    }
    int CaluculateScore()
    {
        return 1;
    }
}
