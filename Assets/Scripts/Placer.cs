using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placer : MonoBehaviour
{
    public GameColor myColor;
    public PlacerStatus status { get; private set; }
    [SerializeField] Vector3 heldScale;

    BoxCollider2D myCollider;
    Vector3 normalScale;


    private void Start() {
        myCollider = GetComponent<BoxCollider2D>();
        normalScale = transform.localScale;
        status = PlacerStatus.Untouched;
    }

    public void Pickup() {
        myCollider.enabled = false;
        status = PlacerStatus.Held;
        transform.localScale = heldScale;
    }

    public void SetPlacer(Goal goal) {
        transform.localScale = normalScale;
        status = PlacerStatus.Placed;
        transform.position = goal.gameObject.transform.position;
        goal.FillGoal();
    }
}
