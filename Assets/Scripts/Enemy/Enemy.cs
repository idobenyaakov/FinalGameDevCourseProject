using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }
    public Path path;
    [Header("Sight Values")]
    public float sightDistance = 20f;
    public float fov = 85f;
    public float eyeHeight;
    [Header("Weapon Values")]
    public Transform gunBarrel;
    [Range(0.1f,10f)]
    public float fireRate;
    [SerializeField] private string currentState;
    public float health = 100f;
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }
    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position,player.transform.position) < sightDistance)//player is close enough to be seen
            {
                //Debug.Log("player in close enough");
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -fov && angleToPlayer <= fov)//player in the los of enemy
                {
                    //Debug.Log("player is in sight");
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if(Physics.Raycast(ray,out hitInfo, sightDistance))//no object blocking the los
                    {
                        //Debug.Log("player is in a clear line of sight");
                        if (hitInfo.transform.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }
                    Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                }
            }
        }
        return false;

        
    }

    public void EnemyTakeDamage(float amount)
    {
        Debug.Log("enemy taking damage");
        health -= amount;
        if (health <= 0)
        {
            EnemeyDie();
        }
    }

    private void EnemeyDie()
    {
        FindObjectOfType<AudioManager>().Play("Enemy Death");
        Destroy(gameObject);
    }
}
