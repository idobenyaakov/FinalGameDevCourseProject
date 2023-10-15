using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBox : Interactable
{
    public Material mat;
    [SerializeField] GameObject weapon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {

        FindObjectOfType<AudioManager>().Play("Glass Break");
        weapon.layer = LayerMask.NameToLayer("Interactable");
    }
}
