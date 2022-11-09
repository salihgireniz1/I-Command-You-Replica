using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, IHandleMovement
{
    #region Properties
    public MovementInfo MovementInfo => movementInfo;

    public Rigidbody Body => body;

    public bool CanMove
    {
        get => canMove;
        set => canMove = value;
    }
    #endregion

    #region Variables

    [SerializeField]
    private MovementInfo movementInfo;

    [SerializeField]
    private bool canMove;

    float swerveSpeed;
    float smoothTime;
    float forwardSpeed;
    Vector3 velocity;

    private Rigidbody body;

    private Vector3 firstTouch = Vector3.zero;
    private Vector3 lastTouch = Vector3.zero;
    private Vector3 deltaTouch = Vector3.zero;
    private Vector3 direction = Vector3.zero;
    #endregion

    #region MonoBehavior Callbacks
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        GetMovementInfo();
    }
    #endregion

    #region Methods

    public void GetMovementInfo()
    {
        try
        {
            swerveSpeed = movementInfo.swerveSpeed;
            smoothTime = movementInfo.responseTime;
            forwardSpeed = movementInfo.forwardSpeed;
        }
        catch (System.NullReferenceException)
        {
            Debug.LogWarning($"{movementInfo} is null. Please insert one.");
            swerveSpeed = 4f;
            smoothTime = 0.4f;
            forwardSpeed = 6f;
        }
    }

    public void Move()
    {
        if (!canMove) return;

        if (Input.GetMouseButtonDown(0))
        {
            firstTouch = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            lastTouch = Input.mousePosition;
            firstTouch = Vector3.SmoothDamp(firstTouch, lastTouch, ref velocity, smoothTime);

            deltaTouch = lastTouch - firstTouch;
            direction = new Vector3(deltaTouch.x, 0f, 0f);
            body.velocity = direction * swerveSpeed * Time.fixedDeltaTime;
            if (body.velocity != Vector3.zero)
                body.rotation = Quaternion.LookRotation(body.velocity);
        }
        else if (body.velocity != Vector3.zero)
        {
            // Stop the player. Do not allow fixedupdate to miss this.
            body.velocity = Vector3.zero;
        }
    }
    #endregion
}
