using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class BallStack : MonoSingleton<BallStack>
{
    public List<GameObject> ActiveBalls
    {
        get => activeBalls;
    }

    [SerializeField]
    private List<GameObject> activeBalls;

    int lowestLevelInStack = 1;
    int maxAvailableLevel; 
    Ball ball = new Ball();
    private void Start()
    {
        ActivateBalls(1);
    }

    [Button("Activate Balls")]
    public void ActivateBalls(int amount)
    {
        lowestLevelInStack = 1;
        for (int i = 0; i < amount; i++)
        {
            GameObject ball = ObjectPooler.SpawnFromQueue();
            ball.GetComponent<BallController>().StackBase = this.transform;
            ball.transform.Translate(Vector3.one);
            activeBalls.Add(ball);
        }
    }
    [Button("Deactivate Balls")]
    public void DeactivateRandomBalls(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            //Check if stack is empty and make player failed.
            if (activeBalls.Count == 0) return;
            GameObject objToRemove = activeBalls[activeBalls.Count - 1];
            activeBalls.Remove(objToRemove);

            ObjectPooler.ResetObject(objToRemove);
        }
    }

    [Button("Level Up Balls")]
    public void LevelUpBalls(int amount)
    {
        List<GameObject> ballsToUpgrade = GetLowestLevelBalls();
        
        for (int i = 0; i < ballsToUpgrade.Count; i++)
        {
            ball = ballsToUpgrade[i].GetComponent<Ball>();
            ball.LevelUp(amount);
        }
        if (lowestLevelInStack < ball.MaxLevel)
            lowestLevelInStack += 1;
    }
    public List<GameObject> GetLowestLevelBalls()
    {
        List<GameObject> lowestBalls = new List<GameObject>();
        for (int i = 0; i < activeBalls.Count; i++)
        {
            if (activeBalls[i].GetComponent<Ball>().ballLevel == lowestLevelInStack)
            {
                lowestBalls.Add(activeBalls[i]);
            }
        }
        return lowestBalls;
    }
}
