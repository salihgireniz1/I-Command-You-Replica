using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class BallStack : MonoBehaviour
{
    public List<GameObject> ActiveBalls
    {
        get => activeBalls;
    }

    [SerializeField]
    private List<GameObject> activeBalls;

    [Button("Activate Balls")]
    public void ActivateBalls(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject ball = ObjectPooler.SpawnFromQueue();
            ball.GetComponent<Balls>().stackBase = this.transform;
            ball.transform.Translate(Vector3.one);
            // Handle ball default settings like assigning a default color etc.

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
            int randomIndex = Random.Range(0, activeBalls.Count);
            GameObject objToRemove = activeBalls[activeBalls.Count - 1];
            activeBalls.Remove(objToRemove);

            ObjectPooler.ResetObject(objToRemove);
        }
    }
}
