using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] public PlayerInput playerInput;
    [SerializeField] private GameObject sprite;

    [SerializeField] private Camera renderCam;
    [SerializeField] private AnimationCurve cameraMovement;
    [SerializeField] private float timeToLerpCamera;

    [SerializeField, Space] private float cameraZoom;

    private Rigidbody2D rb;

    private Vector2 mouseInput;
    private Vector3 previousMousePos;
    private Vector3 cameraLerpPos;
    private Vector3 previousCameraPos;
    private float timeSinceStartCameraMove;

    Vector2 targetPosition = Vector2.zero;

    private Vector2 moveDir;

    public Player player;

    private void Awake()
    {
        InitPlayerActions();
        rb = GetComponent<Rigidbody2D>();
    }

    private void InitPlayerActions()
    {
        playerInput.actions["Interact"].performed += (ctx) => Interact();
    }

    private void OnDisable()
    {
        DeInitPlayerActions();
    }

    private void DeInitPlayerActions()
    {
        playerInput.actions["Interact"].performed -= (ctx) => Interact();
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

        Debug.Log(moveDir);
    }

    private void FixedUpdate()
    {
        targetPosition = rb.position 
            + (moveDir 
            * player.moveSpeed 
            * Time.fixedDeltaTime);

        rb.MovePosition(targetPosition);

        if (moveDir != Vector2.zero)
        {
            sprite.transform.rotation = Quaternion.Euler(0, 0, GetAngle(moveDir));
        }
    }

    private void Interact()
    {

    }

    private void Shoot(Vector2 direction)
    {
        //spawnbullet(Vector2)
    }

    float GetAngle(Vector2 moveDir)
    {
        float angle = Mathf.Atan2(-moveDir.x, moveDir.y) * Mathf.Rad2Deg;

        return angle;
    }
}