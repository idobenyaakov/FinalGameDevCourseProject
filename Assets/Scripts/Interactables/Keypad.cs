using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField] GameObject door;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject key;
    private bool doorOpen;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    protected override void Interact()
    {
        if (weapon.active == false && key.active == false)
        {
            doorOpen = !doorOpen;
            door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
            FindObjectOfType<AudioManager>().Play("Door");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Door Error");
        }
    }
}
