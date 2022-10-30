using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectMover : MonoBehaviour
{
    [SerializeField]
    private Vector2 EndPos;
    [SerializeField]
    private float speed;

    private void FixedUpdate() {
        if (Grid.State == GridState.moving) {
            transform.position = Vector2.MoveTowards(transform.position, EndPos, Math.Min(speed, Mathf.Min(speed, (EndPos - (Vector2) transform.position).magnitude)));
        }
    }
}