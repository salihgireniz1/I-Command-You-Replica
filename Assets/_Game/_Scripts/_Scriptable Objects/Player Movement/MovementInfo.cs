using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Movement Info", menuName = "Player/Player Movement Info")]
public class MovementInfo : ScriptableObject
{
    public float swerveSpeed;
    public float forwardSpeed;
    public float responseTime;
}
