using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NoteScript : MonoBehaviour
{
    private GameObject pauseObject;
    private PauseScreen pauseSystem; 
    [SerializeField] 
    GameObject noteCanv = null;
    [SerializeField]
    private TextMeshProUGUI noteText;
    public string noteContent = "test /* test";
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
        pauseSystem.CurrentNote = gameObject;
        isReading = true;
        pauseSystem.Pause();
    }
    public void Done()
    {
        isReading = false;
        Destroy(gameObject);
    }
}
