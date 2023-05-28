using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 100f;
    [SerializeField] float tapThrust = 100f;

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
        OnMoveButtonTapped(value.Get<Vector2>());
        movementInput = value.Get<Vector2>();
    }

    public void OnMoveButtonTapped(Vector2 direction) {
        myRigidBody2d.AddForce(direction * tapThrust);
    }

    public void OnMoveButonPressed(Vector2 direction) {
        movementInput = direction;
    }

    public void OnMoveButtonReleased() {
        movementInput = Vector2.zero;
    }

}
