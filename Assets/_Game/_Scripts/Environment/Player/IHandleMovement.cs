using Unity.VisualScripting;
using UnityEngine;

internal interface IHandleMovement
{
    public float SwerveSpeed { get; }
    public float ForwardSpeed { get; }
    public bool CanMove { get; set; }
    Vector3 SwerveAmount();
    Vector3 ForwardAmount();
}