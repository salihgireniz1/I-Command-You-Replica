using UnityEngine;
using UnityEngine.AI;

public class BallController : MonoBehaviour
{
    public Transform StackBase
    {
        get => stackBase;
        set => stackBase = value;
    }
    public bool IsAttacking
    {
        get => isAttacking;
        set => isAttacking = value;
    }

    [SerializeField]
    private Transform stackBase;

    [SerializeField]
    private Transform enemyBall;

    [SerializeField]
    private bool isAttacking;
    
    [SerializeField]
    private string enemyLayer;
    
    [SerializeField]
    private float searchRadius;
    
    [SerializeField]
    private float attackMoveSpeed;
    
    [SerializeField]
    private float defaultMoveSpeed;

    Ball ball;
    NavMeshAgent agent;
    Collider[] nearEnemies;
    float distance;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ball = GetComponent<Ball>();
    }
    private void Update()
    {
        if (isAttacking)
        {
            Attack();
        }
        else
        {
            StayOnCenter();
        }
    }

    /// <summary>
    /// Try to stay on stack and move through its center.
    /// </summary>
    public void StayOnCenter()
    {
        if (agent.speed != defaultMoveSpeed)
        {
            agent.speed = defaultMoveSpeed;
        }
        agent.SetDestination(stackBase.position);
    }

    /// <summary>
    /// Handle battle behaviour.
    /// </summary>
    public void Attack()
    {
        FindClosestEnemy();

        if (enemyBall != null && enemyBall.gameObject.activeInHierarchy)
        {
            agent.SetDestination(enemyBall.position);
            if (agent.speed != attackMoveSpeed)
            {
                agent.speed = attackMoveSpeed;
            }
            if (CollapsedWithEnemy(4))
            {
                ball.GetDamage(enemyBall.GetComponent<Ball>().ballLevel);
                if (enemyBall.GetComponent<BallController>().enemyBall != transform)
                {
                    enemyBall.GetComponent<Ball>().GetDamage(ball.ballLevel);
                }
            }
        }
        else
        {
            StayOnCenter();
        }
        
    }

    /// <summary>
    /// Search for closest enemy.
    /// </summary>
    public void FindClosestEnemy()
    {
        distance = Mathf.Infinity;
        nearEnemies = Physics.OverlapSphere(transform.position, searchRadius, 1 << LayerMask.NameToLayer(enemyLayer));
        for (int i = 0; i < nearEnemies.Length; i++)
        {
            float tempDist = Vector3.Distance(transform.position, nearEnemies[i].transform.position);
            if (tempDist < distance)
            {
                distance = tempDist;
                enemyBall = nearEnemies[i].transform;
            }
        }
    }

    /// <summary>
    /// Check if the ball is close enough to enemy in battle.
    /// </summary>
    /// <param name="hitDistance">Minimum collapsing distance to check.</param>
    /// <returns>True if enemy is close enough.</returns>
    public bool CollapsedWithEnemy(float hitDistance)
    {
        if(enemyBall != null)
        {
            if(Vector3.Distance(transform.position, enemyBall.position) <= hitDistance)
            {
                return true;
            }
            return false;
        }
        return false;
    }
}
