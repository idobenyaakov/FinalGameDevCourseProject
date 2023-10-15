using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : Interactable
{
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject ammoCount;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        weapon.SetActive(true);
        ammoCount.SetActive(true);
    }
}
