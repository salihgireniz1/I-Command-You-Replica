using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateMachine machine);
    public abstract void UpdateState(PlayerStateMachine machine);
    public abstract void TriggerState(PlayerStateMachine machine, Collider other);
}
