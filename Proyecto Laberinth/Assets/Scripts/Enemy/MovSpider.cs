using UnityEngine;
using UnityEngine.AI;


public class MovSpider : MonoBehaviour
{   

    public Transform[] patrolPoints;
    public int currentPatrolPoint;
    public NavMeshAgent agent;
    public Animator animator;
    public float waitAtPoint = 2f;
    private float waitCounter;
    public float chaseRange;
    public float attackRange;
    public float timeBetweenAttacks;
    private float attackCounter;
    private bool life;
    public enum AIState
    {
        Idle,
        Patrolling,
        Chasing,
        Attacking
    };

    public AIState currentState;

    void Start()
    {
        waitCounter = waitAtPoint;
    }
    
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, MovementPlayer.playerPos);  

        switch (currentState)
        {
            case AIState.Idle:
                animator.SetBool("IsMoving",false);

                if (waitCounter > 0)
                {
                    waitCounter -= Time.deltaTime;
                }
                else
                {
                        currentState = AIState.Patrolling;
                        agent.SetDestination(patrolPoints[currentPatrolPoint].position);
                }
                if(distanceToPlayer <= chaseRange)
                {
                    currentState = AIState.Chasing;
                    animator.SetBool("IsMoving",true);
                }
                break;
                
            case AIState.Patrolling:
            
                    
                if(agent.remainingDistance <= .2f)  //.noseque
                {
                    currentPatrolPoint++;
                    if(currentPatrolPoint >= patrolPoints.Length)
                    {
                        currentPatrolPoint=0;       
                    }
                        currentState = AIState.Idle;
                        waitCounter = waitAtPoint;
                    }

                    if (distanceToPlayer <= chaseRange)
                    {
                        currentState = AIState.Chasing;
                    }
                    
                    animator.SetBool("IsMoving",true);

                    break;

        case AIState.Chasing:
            agent.SetDestination(MovementPlayer.playerPos); //laweactmhijodelaputa
    

            if (distanceToPlayer <= attackRange)
            {
                currentState = AIState.Attacking;
                animator.SetTrigger("Attack");
                animator.SetBool("IsMoving", false);

                agent.velocity = Vector3.zero;
                agent.isStopped = true;

                attackCounter = timeBetweenAttacks;
            }

            if (distanceToPlayer > chaseRange)
            {
                currentState = AIState.Idle;
                waitCounter = waitAtPoint;

                agent.velocity = Vector3.zero;
                agent.SetDestination(transform.position);

            }

                break;

        case AIState.Attacking:
                    
            transform.LookAt(MovementPlayer.playerPos, Vector3.up);
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

                attackCounter -= Time.deltaTime;
                if (attackCounter <= 0)
                {
                    if (distanceToPlayer < attackRange && life == false)
                    {
                        animator.SetTrigger("Attack");
                        attackCounter = timeBetweenAttacks;
                        
                        
                    }
                    else
                    {
                        currentState = AIState.Idle;
                        waitCounter = waitAtPoint;

                        agent.isStopped = false;
                    }
                }

                break;
        }

    }
}
 

    



