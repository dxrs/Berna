using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieAi : MonoBehaviour
{
    public static ZombieAi instance;

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Variable animation
    public static float velo;

    //Variable buat patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //state
    public float sightRange, attackRange;
    bool playerInRange, playerInAttackRange;

    //attack
    public static string attak;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        player = GameObject.Find("Player Body").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        velo = agent.velocity.magnitude;


        //Check sight rangernya
        playerInRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        
        if(!playerInRange && !playerInAttackRange)
        {
            patroling();
            ZombieAnim.isAttack = false;
        }
        if(playerInRange && !playerInAttackRange)
        {
            chasing();
            ZombieAnim.isAttack = false;
        }
        if(playerInRange && playerInAttackRange && player!=null)
        {
            attack();
            ZombieAnim.isAttack = true;
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
        agent.updateRotation = true;

        //BERMASALAH
        if (!PlayerManager.playerManager.gameOver) 
        {
            agent.speed = 0.5f;
        }
        else 
        {
            agent.speed = 0.0f;
        }
        

        if(!walkPointSet)
        {
            searchWalkPoint();
        }
        if(walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkpoint = transform.position - walkPoint;

        //biar bisa cari walkpoint lagi kalo udah nyampe target
        if(distanceToWalkpoint.magnitude<0.05f)
        {
            walkPointSet = false;
        }

    }

    void chasing()
    {
        agent.updateRotation = true;
        walkPointSet = false;
        agent.stoppingDistance = 2;
        if (player != null) { agent.SetDestination(player.position); }
        
        agent.speed = 5;
    }

    void attack()
    {
        agent.updateRotation = false;
        if (player != null) 
        {
            FaceTarget(player.position);
        }
        
        
        
    }

    void OnDrawGizmosSelected() // buat ngatur masalah range
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void FaceTarget(Vector3 destination)
    {
        Vector3 lookPos = destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 2*Time.deltaTime);  
    }
   

}
