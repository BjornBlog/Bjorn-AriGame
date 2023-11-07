using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NoteScript : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI NoteTMP;
    private GameObject pauseObject;
    private PauseScreen pauseSystem; 
    [SerializeField] 
    GameObject noteCanv = null;
    bool isReading = false;
    public string noteText = "TEST /* TEST";
    // Start is called before the first frame update
    void Awake()
    {
        noteCanv.SetActive(false);
        pauseObject = GameObject.FindGameObjectWithTag ("Pause");
        pauseSystem = pauseObject.GetComponent<PauseScreen>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pickup()
    {   
        noteCanv.SetActive(true);
        pauseSystem.note = true;
        pauseSystem.noteObj = gameObject;
        NoteTMP.text = noteText;
        pauseSystem.Pause();
    }
    public void Done()
    {
        noteCanv.SetActive(false);
        Destroy(gameObject);
    }
}
