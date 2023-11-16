using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NoteScript : MonoBehaviour
{
    private TMP_Text NoteTMP;
    private GameObject pauseObject;
    private PauseScreen pauseSystem; 
    private GameObject noteCanv = null;
    public string noteText = "TEST /* TEST";
    // Start is called before the first frame update
    void Awake()
    {
        noteCanv = GameObject.Find("NoteScreen");
        NoteTMP =  GameObject.Find("NoteText").GetComponent<TMP_Text>();
        noteCanv.SetActive(false);
        pauseObject = GameObject.FindGameObjectWithTag("Pause");
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
