using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallStack : MonoBehaviour
{
    List<BallController> myBalls = new List<BallController>();
    private void Start()
    {
        foreach (Transform child in transform)
        {
            myBalls.Add(child.GetComponent<BallController>());
        }
    }

    [Button("Attack!")]
    public void AttackEnemyStack()
    {
        foreach (var ball in myBalls)
        {
            ball.IsAttacking = true;
        }
    }
}
