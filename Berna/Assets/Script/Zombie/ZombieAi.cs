using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Variable buat patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // variable buat attack
    public float timeBetweenAttack;
    bool alredyAttack;

    //state
    public float sightRange, attackRange;
    bool playerInRange, playerInAttackRange;


    private void Awake()
    {
        player = GameObject.Find("playersementara").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Check sight rangernya
        playerInRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        
        if(!playerInRange && !playerInAttackRange)
        {
            patroling();
        }
        if(playerInRange && !playerInAttackRange)
        {
            chasing();
        }
        if(playerInRange && playerInAttackRange)
        {
            //void attak taroh sini
        }
    }

    void searchWalkPoint()
    {
        float randomz = Random.Range(-walkPointRange,walkPointRange);
        float randomx = Random.Range(-walkPointRange,walkPointRange);

        walkPoint = new Vector3(transform.position.x+randomx, transform.position.y, transform.position.z+randomz);
        if(Physics.Raycast(walkPoint,-transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    void patroling()
    {

        agent.speed = 2;
        agent.acceleration = 3;

        if(!walkPointSet)
        {
            searchWalkPoint();
        }
        if(walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkpoint = transform.position -walkPoint;

        //biar bisa cari walkpoint lagi kalo udah nyampe target
        if(distanceToWalkpoint.magnitude<1f)
        {
            walkPointSet = false;
        }

    }

    void chasing()
    {
        agent.SetDestination(player.position);
        agent.speed = 10;
        agent.acceleration = 5;
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
