using UnityEngine;

internal interface IHandleMovement
{
    MovementInfo MovementInfo { get; }

    Rigidbody Body { get; }

    bool CanMove { get; set; }

    void GetMovementInfo();

    void Move();
}