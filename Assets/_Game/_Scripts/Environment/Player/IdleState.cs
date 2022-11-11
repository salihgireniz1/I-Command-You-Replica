using UnityEngine;

public class IdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine machine)
    {
        machine.GetComponent<IHandleMovement>().CanMove = false;
    }

    public override void TriggerState(PlayerStateMachine machine, Collider other)
    {

    }

    public override void UpdateState(PlayerStateMachine machine)
    {
        if (Input.GetMouseButtonDown(0))
        {
            machine.SwitchState(machine.walkingState);
        }
    }
}
