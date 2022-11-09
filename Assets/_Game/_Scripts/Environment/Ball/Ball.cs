using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int MaxLevel => levelColors.Count;

    public int ballLevel;

    public List<Color> levelColors;
    public float scaleGrowthAmount;

    Renderer rend;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
        InitializeBall();
    }

    /// <summary>
    /// Increase level of the ball. Change it's color and scale.
    /// </summary>
    /// <param name="amount">Upgration count of ball.</param>
    public void LevelUp(int amount)
    {
        if (ballLevel >= MaxLevel) return;

        for (int i = 0; i < amount; i++)
        {
            ballLevel++;
            rend.material.color = levelColors[ballLevel - 1];
            transform.localScale = transform.localScale * scaleGrowthAmount;
        }
    }
    public void InitializeBall()
    {
        ballLevel = 1;
        rend.material.color = levelColors[0];
    }
}
