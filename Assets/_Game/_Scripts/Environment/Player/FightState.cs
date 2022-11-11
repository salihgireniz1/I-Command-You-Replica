using UnityEngine;
using UnityEngine.AI;

public class FightState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine machine)
    {
        //machine.stack.AttackEnemyStack();
        machine.GetComponent<IHandleMovement>().CanMove = false;
        CameraController.Instance.BattleView();
    }

    public override void TriggerState(PlayerStateMachine machine, Collider other)
    {

    }

    public override void UpdateState(PlayerStateMachine machine)
    {

    }
}
