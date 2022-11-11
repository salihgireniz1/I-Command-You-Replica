using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeTrigger : MonoBehaviour, ITriggerPlayer
{
    public int upgradeAmount = 1;
    public void OnTrigger(PlayerStateMachine player)
    {
        player.stack.LevelUpBalls(upgradeAmount);
    }
}
