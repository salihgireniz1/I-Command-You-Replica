using UnityEngine;
using UnityEngine.AI;

public class Balls : MonoBehaviour
{
    public Transform stackBase;
    NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        agent.SetDestination(stackBase.position);
    }
}
