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

    // variable buat attack
    public float timeBetweenAttack;
    bool alredyAttack;

    //state
    public float sightRange, attackRange;
    bool playerInRange, playerInAttackRange;


    [Header("Hitted Effect")]
    public float blinkIntensity;
    public float blinkDuration;
    float blinkTimer;
    SkinnedMeshRenderer meshRender;

    //attack
    public static string attak;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        meshRender =GetComponentInChildren<SkinnedMeshRenderer>();
    }

    void Update()
    {
        velo = agent.velocity.magnitude;

        //effect kena hit
        blinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(blinkTimer/blinkDuration);
        float intensity = lerp * blinkIntensity;
        meshRender.material.color = Color.white * intensity;

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
            attak = "dunno";
        }
        if(playerInRange && playerInAttackRange)
        {
            attack();
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
        agent.speed = 0.5f;

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
        walkPointSet = false;
        agent.stoppingDistance = 2;
        agent.SetDestination(player.position);
        agent.speed = 5;
    }

    void attack()
    {
        attak = "serang";
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public static void shooted()
    {
        ZombieAi.instance.blinkTimer = ZombieAi.instance.blinkDuration;
    }
    
}
