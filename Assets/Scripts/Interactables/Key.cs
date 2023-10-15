using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    public GameObject key;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        FindObjectOfType<AudioManager>().Play("Pickup");
    }

    }
