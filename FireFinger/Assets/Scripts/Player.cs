using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float movementSpeed = 3;
    private InputAction movement;
    [SerializeField] private  InputActionAsset playerControls;

    private void Awake()
    {
        var gameplayActionMap = playerControls.GetActionMap("Player");
        movement = gameplayActionMap.GetAction("Movement");
        movement.performed += OnMovementChanged;
    }

    private void OnMovementChanged(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();

        Direction = new Vector3(direction.x, direction.y, 0);
    }

    private void FixedUpdate()
    {

        if (!IsMoving) return;

        transform.position += Direction * movementSpeed * Time.deltaTime;
    }

    private bool IsMoving => Direction != Vector3.zero;
    private Vector3 Direction { get; set; }

    private void OnDisable()
    {
        movement.Disable();
    }

    private void OnEnable()
    {
        movement.Enable();
    }

    
}
