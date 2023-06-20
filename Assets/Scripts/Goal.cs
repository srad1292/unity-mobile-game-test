using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameColor myColor;
    [SerializeField] Color filledColor;

    SpriteRenderer mySpriteRenderer;
    public bool filled { get; private set; }

    private void Start() {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FillGoal() {
        filled = true;
        mySpriteRenderer.color = filledColor;
    }
}
