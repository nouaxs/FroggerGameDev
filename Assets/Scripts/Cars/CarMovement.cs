using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]


/**
 * This class provides an implementation of the car movement behaviour
 */
public class CarMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;

    private void Awake()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    
    }


    private void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
    }

}
