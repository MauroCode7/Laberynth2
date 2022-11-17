using System.Collections;
using System. Collections .Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISound : MonoBehaviour
{

    //ai sight
    public bool playerIsInLOS = false;
    public float fieldOfViewAngle = 160f;
    public float losRadius = 45f;

    //ai sight and memory
    private bool aiMemorizesPlayer = false;
    public float memoryStartTime = 10f;
    private float increasingMemoryTime;

    //ai hearing
    Vector3 noisePosition;
    private bool aiHeardPlayer = false;
    public float noiseTravelDistance = 50f;
    public float spinSpeed = 3f;
    private bool canSpin = false;
    private float isSpinningTime; //search at player-noise-position
    public float spinTime = 3f;

    //patroling randomly between waypoints
    public Transform [] movespots;
    private int randomSpot;

    //wait Time at waypoint for patrolling
    private float waitTime;
    public float startWaitTime = 1f;

    NavMeshAgent nav;

    //Ai strafe
    public float distToPlayer = 5.0f; // straferadius
    private float randomStrafeStartTime;
    private float waitStrafeTime;
    public float t_minStrafe; // min and max time ai waits once it has reached the "strafe" position before strafing
    public float t_maxstrafe;

    public Transform strafeRight;
    public Transform strafeLeft;
    private int randomStrafeDir;

    //when to chase
    public float chaseRadius = 20f;

    public float facePlayerFactor = 20f;
    

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;
    }



    // Use this for initialization
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, movespots.Length);
        randomStrafeDir = Random.Range (0, 2);
    }
    // void Update()
    // {
    //    float distance = Vector3.Distance(Playermove.playerPos,transform.position);

    //     if (distance > chaseRadius)
    //     {
    //         Patrol ();
    //     }
    //     else if (distance < chaseRadius)
    //     {
    //         ChasePlayer();
    //         FacePlayer();
    //     }
       
    // }
    void Update()
    {

        float distance = Vector3.Distance(MovementPlayer.playerPos, transform.position);

        if (distance <= losRadius)
        {
            CheckLOS();
        }

        if (nav.isActiveAndEnabled)
        {
            if (playerIsInLOS = false & aiMemorizesPlayer == false && aiHeardPlayer & aiHeardPlayer == false)
            {
                Patrol();
                NoiseCheck();
                
                StopCoroutine(AiMemory());
            }else if (aiHeardPlayer == true && playerIsInLOS == false && aiHeardPlayer == false)
            {
                canSpin = true;
                GoToNoisePosition();

            }else if (playerIsInLOS == true)
            {
                aiMemorizesPlayer = true;
                FacePlayer();
                ChasePlayer();
            }else if (aiMemorizesPlayer == true && playerIsInLOS == false)
            {
                ChasePlayer();
                StartCoroutine(AiMemory());
            }

        } 

    }



    void NoiseCheck()
    {   
        float distance = Vector3.Distance (MovementPlayer.playerPos, transform.position);
            
        if (distance <= noiseTravelDistance) 
        {
            if (Input.GetButton("Sonido")) //cambiar variable a caminar o correr
            {
                noisePosition = MovementPlayer.playerPos;
                aiHeardPlayer = true;
                
            }else
            {
                aiHeardPlayer = false;
                canSpin = false;
                
            }

        }
    }

    void GoToNoisePosition()
    {
        nav.SetDestination(noisePosition);
            
        if (Vector3.Distance(transform.position, noisePosition) <= 5f && canSpin == true)
        {
            isSpinningTime += Time.deltaTime;
            transform.Rotate(Vector3.up * spinSpeed, Space.World);
                
            if(isSpinningTime >= spinTime)
            {
                    canSpin = false;
                    aiHeardPlayer = false;
                    isSpinningTime = 0f;
            }
        }
    }    

    IEnumerator AiMemory()
        
    {
        increasingMemoryTime = 0;
        
        while (increasingMemoryTime < memoryStartTime)
        {
            increasingMemoryTime += Time.deltaTime;
            aiMemorizesPlayer = true;
            yield return null;  

        }
            aiHeardPlayer = false;
            aiMemorizesPlayer = false;
        
    }   

    void ChasePlayer ()
    {
        float distance = Vector3.Distance (MovementPlayer.playerPos, transform.position);
        if (distance <= chaseRadius && distance > distToPlayer)
        {
            nav.SetDestination(MovementPlayer.playerPos);
        }
            
        else if (nav.isActiveAndEnabled && distance <= distToPlayer)
        {
            randomStrafeDir = Random . Range (0, 2);
            randomStrafeStartTime = Random. Range (t_minStrafe, t_maxstrafe);
                
            if (waitStrafeTime <= 0)
            {   
                if (randomStrafeDir == 0)
                {
                        nav.SetDestination (strafeLeft.position);
                }
                else
                if (randomStrafeDir == 1)
                {
                         nav.SetDestination (strafeRight.position);
                }
                   
                    waitStrafeTime = randomStrafeStartTime;
            }
            else
            {
                    waitStrafeTime -= Time . deltaTime;
            }
                   
        }
    }
        
    void FacePlayer()
    {
        Vector3 direction = (MovementPlayer.playerPos - transform.position).normalized;
        Quaternion lookRotation= Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facePlayerFactor) ;
    }
        
    void Patrol()
    {
        nav.SetDestination (movespots[randomSpot].position) ;
        if (Vector3.Distance(transform.position, movespots[randomSpot].position) < 2.0f)
        {
            if (waitTime <= 0)
            {
                    randomSpot = Random.Range(0, movespots.Length);
                    
                    waitTime = startWaitTime;
            }
            else { waitTime -= Time. deltaTime;}
        }
    }    
        
    void CheckLOS()
    {
        Vector3 direction = MovementPlayer.playerPos - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        if (angle < fieldOfViewAngle * 0.5f)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, direction.normalized, out hit, losRadius))
            {
                if (hit.collider.tag == "Player")
                {
                        playerIsInLOS = true;
                        aiMemorizesPlayer = true;
                }else 
                {
                        playerIsInLOS = false;
                }

                
            }
        }
    
    }
}




