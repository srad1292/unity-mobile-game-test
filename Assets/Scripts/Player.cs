using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 100f;
    [SerializeField] float tapThrust = 100f;

    Rigidbody2D myRigidBody2d;

    private Vector3 movementInput;
    private List<Placer> heldPlacers;

    private void Start() {
        heldPlacers = new List<Placer>();
        movementInput = Vector2.zero;
        myRigidBody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void MovePlayer() {
        myRigidBody2d.velocity = movementInput * playerSpeed * Time.fixedDeltaTime;
        if (movementInput != Vector3.zero && heldPlacers.Count > 0) {
            for (int idx = 0; idx < heldPlacers.Count; idx++) {
                heldPlacers[idx].transform.position = transform.position + (movementInput * -0.6f * (idx+1));
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Goal") {
            if(heldPlacers.Count == 0 ) { return; }

            Goal goal = other.GetComponent<Goal>();
            int matchingIndex = heldPlacers.FindIndex(placer => placer.myColor == goal.myColor);
            if (!goal.filled && matchingIndex >= 0) {
                FillGoal(goal, matchingIndex);
            }
        }
        else if (other.tag == "Placer") {
            Placer placer = other.GetComponent<Placer>();
            placer.Pickup();
            heldPlacers.Add(placer);
            heldPlacers[heldPlacers.Count-1].transform.position = transform.position + (movementInput * -0.6f * (heldPlacers.Count));

        }
    }

    private void FillGoal(Goal goal, int placerIndex) {
        heldPlacers[placerIndex].SetPlacer(goal);
        heldPlacers.RemoveAt(placerIndex);
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
