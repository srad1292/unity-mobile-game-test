using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 100f;

    Rigidbody2D myRigidBody2d;

    private Vector2 movementInput;

    private void Start() {
        movementInput = Vector2.zero;
        myRigidBody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void MovePlayer() {
        myRigidBody2d.velocity = movementInput * playerSpeed * Time.fixedDeltaTime;
    }

    private void OnMove(InputValue value) {
        movementInput = value.Get<Vector2>();
    }

}
