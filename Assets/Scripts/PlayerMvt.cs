using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvt : MonoBehaviour
{
    public float accel = 500f;
    private Vector3 vel = Vector3.zero;
    public float jump_accel = 0.1f;
    public float max_speed = 1000f;
    public bool can_jump = false;
    public bool pull = false;
    public float magnet_accel = 0.1f;
    public GameObject magnet;

    public void FixedUpdate()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if(Mathf.Abs(rb.velocity.x) < max_speed)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector2.left * accel);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector2.right * accel);
            }
        }
        if(Input.GetKey(KeyCode.W) && can_jump && Mathf.Abs(rb.velocity.y) < 0.001)
        {
            rb.AddForce(Vector2.up * jump_accel, ForceMode2D.Impulse);
        }
        if (pull)
        {
            rb.AddForce(Vector2.up * 4 * gameObject.GetComponent<Rigidbody2D>().mass, ForceMode2D.Impulse);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetType() == typeof(BoxCollider2D))
        {
            can_jump = true;
        }
    }

    public void pullSet(bool check)
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        pull = check;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        bool flag = magnet.GetComponent<MagneticPull>().getStatus();
        if (collision.gameObject.tag == "Magnet_Field" && flag)
        {
            pullSet(true);
            print("collision");
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        bool flag = magnet.GetComponent<MagneticPull>().getStatus();
        if (collision.gameObject.tag == "Magnet_Field" && flag)
        {
            pullSet(false);
            print("exit");
        }
    }
}
