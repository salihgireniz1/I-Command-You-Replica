using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public BallStack stack;

    public PlayerBaseState idleState = new IdleState();
    public PlayerBaseState walkingState = new WalkingState();
    public PlayerBaseState fightState = new FightState();


    PlayerBaseState currentState;
    private void Start()
    {
        SwitchState(idleState);
    }
    public void SwitchState(PlayerBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        currentState.TriggerState(this, other);
    }
}
