using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    private GameObject pauseObject;
    private PauseScreen pauseSystem; 
    [SerializeField] 
    GameObject noteCanv = null;
    bool isReading = false;
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
        noteCanv.SetActive(isReading);
    }
    public void Pickup()
    {
        isReading = true;
    }
    public void Done()
    {
        isReading = false;
    }
}
