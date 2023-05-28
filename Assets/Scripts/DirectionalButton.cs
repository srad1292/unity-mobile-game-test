using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DirectionalButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler 
{

    enum Direction { Up, Right, Down, Left };

    [SerializeField] Direction direction;
    [SerializeField] Player player;
    [SerializeField] float threshold = 0.4f;

    private Button myButton;

    private float heldTime = 0f;
    private bool isPressed = false;

    private void Start() {
        myButton = GetComponent<Button>();
    }

    private void Update() {
        if(isPressed) {
            heldTime += Time.deltaTime;
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        print("Pointer down");
        isPressed = true;
        if(direction == Direction.Up) {
            player.OnMoveButonPressed(Vector2.up);
        } else if (direction == Direction.Down) {
            player.OnMoveButonPressed(Vector2.down);
        } else if (direction == Direction.Left) {
            player.OnMoveButonPressed(Vector2.left);
        } else if (direction == Direction.Right) {
            player.OnMoveButonPressed(Vector2.right);
        }
        myButton.OnPointerDown(eventData);

    }

    public void OnPointerUp(PointerEventData eventData) {
        print("Pointer up");
        

        if (heldTime < threshold) {
            print("Should move player");
            if (direction == Direction.Up) {
                player.OnMoveButtonTapped(Vector2.up);
            }
            else if (direction == Direction.Down) {
                player.OnMoveButtonTapped(Vector2.down);
            }
            else if (direction == Direction.Left) {
                player.OnMoveButtonTapped(Vector2.left);
            }
            else if (direction == Direction.Right) {
                player.OnMoveButtonTapped(Vector2.right);
            }
        }
        DepressButton();
        myButton.OnPointerUp(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData) { }

    public void OnPointerExit(PointerEventData eventData) {
        print("On Pointer Exit");
        myButton.OnDeselect(eventData);
        myButton.OnPointerExit(eventData);
        DepressButton();
        
    }

    private void DepressButton() {
        isPressed = false;
        heldTime = 0f;
        
        player.OnMoveButtonReleased();
    }
}
