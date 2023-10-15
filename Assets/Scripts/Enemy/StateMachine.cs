using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    
    public void Initialise()
    {
        
        changeState(new PatrolState());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null)
        {
            
            activeState.Perform();
        }
    }
    public void changeState(BaseState newState) 
    { 

        if (activeState != null)
        {
            //state is executed run cleanup
            activeState.Exit();
        }
        //change to new state
        activeState = newState;

        if (activeState != null)
        {
            //set new state
            activeState.stateMachine = this;
            //assign state enemy class
            activeState.enemy = GetComponent<Enemy>();
            activeState.audioManager = FindObjectOfType<AudioManager>();
            activeState.Enter();
        }
    }
}
