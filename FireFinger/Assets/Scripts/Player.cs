using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float movementSpeed = 3;
    private  InputMaster playerControls;

    private void Awake()
    {
        playerControls = new InputMaster();
        playerControls.Player.Movement.performed += ctx => OnMovement(ctx.ReadValue<Vector2>());
    }

    private void OnMovement(Vector2 direction)
    {
        Direction = new Vector3(direction.x, direction.y, 0);
        // Debug.Log(direction.x+":"+direction.y);
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
        playerControls.Disable();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    
}
