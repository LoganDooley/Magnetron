using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float accel = 0.01f;

    public float max_speed = 0.1f;

    public float jump_velocity = 1f;

    public float friction = 0.1f;

    private Vector3 velocity = Vector3.zero;

    private bool canJump = true;

    public bool pull = false;

    public float magnet_velocity = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Mathf.Abs(velocity.x) < max_speed)
        {
            if (Input.GetKey(KeyCode.A))
            {
                velocity.x -= accel;
            }
            if (Input.GetKey(KeyCode.D))
            {
                velocity.x += accel;
            }
        }
        if (Input.GetKey(KeyCode.Space) && canJump && Mathf.Abs(velocity.y) < 0.01 && !pull)
        {
            velocity.y = jump_velocity;
            canJump = false;
        }
        velocity -= velocity * friction;
        if (pull)
        {
            velocity += Vector3.up * magnet_velocity;
        }
        transform.position += velocity;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
    public void pullSet(bool set)
    {
        pull = set;
    }
}
