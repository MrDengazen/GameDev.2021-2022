using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungFriction : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float frictionSpeed = 0.1f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = rb.velocity + rb.velocity.normalized * frictionSpeed * -1;
    }
}
