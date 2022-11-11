using UnityEngine;

public class WalkingState : PlayerBaseState
{
    Vector3 stackPosition = Vector3.zero;
    Vector3 stackOffset = Vector3.zero;
    public override void EnterState(PlayerStateMachine machine)
    {
        machine.GetComponent<IHandleMovement>().CanMove = true;
        stackOffset = machine.stack.transform.position - machine.transform.position;
    }

    public override void TriggerState(PlayerStateMachine machine, Collider other)
    {
        // Handle Trigger processes.
        if(other.TryGetComponent(out ITriggerPlayer triggerRespond))
        {
            triggerRespond.OnTrigger(machine);
        }
    }

    public override void UpdateState(PlayerStateMachine machine)
    {
        stackPosition = new Vector3
            (
                machine.stack.transform.position.x,
                machine.stack.transform.position.y,
                machine.transform.position.z + stackOffset.z
            );
        machine.stack.transform.position = stackPosition;
    }
}
