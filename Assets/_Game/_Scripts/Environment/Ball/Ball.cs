using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int MaxLevel => maxLevel;
    public int BallLevel { get; private set; }

    [Range(1, 5)]
    public int startLevel = 1;

    [SerializeField]
    private int maxLevel;

    [SerializeField]
    private float scaleGrowthAmount;
    
    [SerializeField]
    private bool colorCanChange = false;

    [SerializeField]
    private List<Color> levelColors;


    Renderer rend;
    private void OnEnable()
    {
        rend = GetComponent<Renderer>();
        BallLevel = startLevel;
        if (colorCanChange) rend.material.color = levelColors[BallLevel - 1];

        LevelUp(BallLevel - 1);
    }

    /// <summary>
    /// Increase level of the ball. Change it's color and scale.
    /// </summary>
    /// <param name="amount">Upgration count of ball.</param>
    public void LevelUp(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (BallLevel >= MaxLevel) return;
            BallLevel++;
            if (colorCanChange) rend.material.color = levelColors[BallLevel - 1];
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
            if (BallLevel <= 1)
            {
                // Handle Destruction.
                BallStack.Instance.DeactivateCertainBall(this.gameObject);
            }
            else
            {
                BallLevel--;
                if (colorCanChange) rend.material.color = levelColors[BallLevel - 1];
                transform.localScale /= scaleGrowthAmount;
            }
        }
    }
}
