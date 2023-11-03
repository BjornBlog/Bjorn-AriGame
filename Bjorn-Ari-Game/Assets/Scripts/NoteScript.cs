using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NoteScript : MonoBehaviour
{
    [SerializeField]
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        pauseSystem.CurrentNote = gameObject;
        isReading = true;
        pauseSystem.Pause();
    }
    public void Done()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isReading = false;
        Destroy(gameObject);
    }
}
