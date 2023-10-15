using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;
    

    public override void Enter()
    {
    
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if( shotTimer > enemy.fireRate )
            {
                if( audioManager == null ) { Debug.Log("audioManager is null"); }
                if (enemy == null) { Debug.Log("enemy is null"); }
                audioManager.Play("Enemy shot"); 

                Shoot();
            }
            if ( moveTimer > Random.Range(3,7) )
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            else
            {
                losePlayerTimer += Time.deltaTime;
                if( losePlayerTimer > 8 )
                {
                    stateMachine.changeState(new PatrolState());
                }
            }
        }
    }
    public void Shoot()
    {
        //ref to the gun barrel
        Transform gunBarrel = enemy.gunBarrel;
        //Instantiate new bullet
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunBarrel.position, enemy.transform.rotation);
        //direct to the player
        Vector3 shootDirection = (enemy.Player.transform.position - gunBarrel.transform.position).normalized;

        
        //add force rigidbody of the bullet
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f,3f),Vector3.up)* shootDirection * 30;
        //Debug.Log("Shooting");
        shotTimer = 0;
    }
    void Start()
    {

    }
    void Update()
    {

    }
}
