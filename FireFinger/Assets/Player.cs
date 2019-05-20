using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;


public class Player : MonoBehaviour
{
    public InputMaster controls;

    private void Awake() 
    {
        controls.Player.Shoot.performed += ctx => Shoot();
    }

    void Shoot ()
    {
        Debug.Log("We shot!");
    }

    private void OnEnable() {
        controls.Enable();
    }
    private void OnDisable() {
        controls.Disable();
    }
}
