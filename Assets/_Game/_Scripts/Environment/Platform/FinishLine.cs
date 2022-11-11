using UnityEngine;

public class FinishLine : MonoBehaviour, ITriggerPlayer
{
    public void OnTrigger(PlayerStateMachine player)
    {
        player.SwitchState(player.fightState);
    }
}
