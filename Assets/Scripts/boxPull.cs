using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxPull : MonoBehaviour
{
    public bool pull;
    public GameObject magnet;
    // Start is called before the first frame update
    void Start()
    {
        pull = false;
    }

    public void FixedUpdate()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (pull)
        {
            rb.AddForce(Vector2.up * rb.gravityScale * 3 * gameObject.GetComponent<Rigidbody2D>().mass, ForceMode2D.Force);
        }
    }
    
    public void pullSet(bool check)
    {
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
