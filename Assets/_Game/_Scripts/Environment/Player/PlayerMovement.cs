using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, IHandleMovement
{
    public float SwerveSpeed => swerveSpeed;
    public float ForwardSpeed => forwardSpeed;
    public bool CanMove
    {
        get => canMove;
        set => canMove = value;
    }

    [SerializeField]
    public float swerveSpeed;

    [SerializeField]
    public float forwardSpeed;

    [SerializeField]
    private bool canMove;

    Rigidbody body;
    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Handle swerving processes of object.
    /// </summary>
    /// <returns>Swerve amount on X-Axis.</returns>
    public Vector3 SwerveAmount()
    {
        if (!CanMove) return Vector3.zero;

        if (Input.GetMouseButton(0))
        {
            float xVelocity = Input.GetAxis("Mouse X") * swerveSpeed * Time.fixedDeltaTime;
            return new Vector3(xVelocity, 0f, 0f);
        }
        else
        {
            // Prevent slippery movement.
            return Vector3.zero;
        }
    }
    public Vector3 ForwardAmount()
    {
        if (!CanMove) return Vector3.zero;

        float zVelocity = forwardSpeed * Time.fixedDeltaTime;
        Vector3 velocity = new Vector3(0f, 0f, zVelocity);
        return velocity;
    }

    private void FixedUpdate()
    {
        body.velocity = SwerveAmount() + ForwardAmount();
    }
}
