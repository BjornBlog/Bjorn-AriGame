using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerScript : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        controller = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
