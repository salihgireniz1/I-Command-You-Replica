using DG.Tweening;
using UnityEngine;

public class CameraController : MonoSingleton<CameraController>
{
    public Transform runnerTarget;

    public Vector3 runnerTargetOffset;

    public bool isFollowing;
    public Vector3 battlePosition;
    public Vector3 battleRotation;
    public float moveDuration;

    Vector3 targetPos;
    private void LateUpdate()
    {

        if (isFollowing)
        {
            targetPos = new Vector3
                    (
                        transform.position.x,
                        runnerTarget.position.y + runnerTargetOffset.y,
                        runnerTarget.position.z + runnerTargetOffset.z
                    );
            transform.position = targetPos;
        }

    }
    public void BattleView()
    {
        isFollowing = false;

        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOMove(battlePosition, moveDuration))
            .Join(transform.DORotate(battleRotation, moveDuration))
            .OnComplete(StartBattle());
        
    }
    TweenCallback StartBattle()
    {
        return delegate
        {
            BallStack.Instance.AttackEnemyStack();
            FindObjectOfType<EnemyBallStack>().AttackEnemyStack();
        };
    }
}
