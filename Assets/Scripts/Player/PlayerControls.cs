using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] public PlayerInput playerInput;
    [SerializeField] private GameObject sprite;

    [SerializeField] private Camera renderCam;
    [SerializeField] private AnimationCurve cameraMovement;
    [SerializeField] private float timeToLerpCamera;

    [SerializeField, Space] private float cameraZoom;

    private Rigidbody2D rb;

    Vector2 targetPosition = Vector2.zero;

    private Vector2 moveDir;

    public Player player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var shootDir = playerInput.actions["ShootDirection"].ReadValue<Vector2>();

        Shoot(shootDir);

        var input = playerInput.actions["Move"].ReadValue<Vector2>();

        if (input != moveDir)
        {
            moveDir = input;
        }
    }

    private void FixedUpdate()
    {
        targetPosition = rb.position 
            + (moveDir 
            * player.moveSpeed 
            * player.speedMultiplier
            * Time.fixedDeltaTime);

        rb.MovePosition(targetPosition);

        if (moveDir != Vector2.zero)
        {
            sprite.transform.rotation = Quaternion.Euler(0, 0, GetAngle(moveDir));
        }
    }

    private void Shoot(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            return;
        }

        player.Shoot(direction);
    }

    float GetAngle(Vector2 moveDir)
    {
        float angle = Mathf.Atan2(-moveDir.x, moveDir.y) * Mathf.Rad2Deg;

        return angle;
    }
}