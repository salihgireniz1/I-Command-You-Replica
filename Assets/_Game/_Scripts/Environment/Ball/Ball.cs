using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int MaxLevel => levelColors.Count;

    [Range(1, 5)]
    public int startLevel = 1;

    public int ballLevel;

    public List<Color> levelColors;
    public List<GameObject> PopParticles;
    public float scaleGrowthAmount;

    Renderer rend;
    private void OnEnable()
    {
        rend = GetComponent<Renderer>();
        ballLevel = startLevel;
        rend.material.color = levelColors[ballLevel-1];

        LevelUp(ballLevel - 1);
    }

    /// <summary>
    /// Increase level of the ball. Change it's color and scale.
    /// </summary>
    /// <param name="amount">Upgration count of ball.</param>
    public void LevelUp(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (ballLevel >= MaxLevel) return;
            ballLevel++;
            rend.material.color = levelColors[ballLevel - 1];
            transform.localScale *= scaleGrowthAmount;
        }
    }

    /// <summary>
    /// Handle battle behaviour of ball. Level down until it pops.
    /// </summary>
    /// <param name="damageAmount"></param>
    public void GetDamage(int damageAmount)
    {
        for (int i = 0; i < damageAmount; i++)
        {
            if (ballLevel <= 1)
            {
                // Handle Destruction.
                BallStack.Instance.DeactivateCertainBall(this.gameObject);
            }
            else
            {
                ballLevel--;
                rend.material.color = levelColors[ballLevel - 1];
                transform.localScale /= scaleGrowthAmount;
            }
        }
    }
}
