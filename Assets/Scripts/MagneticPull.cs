using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticPull : MonoBehaviour
{
    public GameObject player;
    public GameObject box;

    public bool active = false;

    public Vector2 standard;

    public void Start()
    {
        standard = gameObject.transform.position;
        gameObject.transform.position = Vector2.up * 1000;
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggle();
        }
    }

    public void toggle()
    {
        print("Q");
        if (active)
        {
            active = false;
            gameObject.transform.position = Vector2.up * 1000;
            player.GetComponent<PlayerMvt>().pullSet(false);
            if (box != null)
            {
                box.GetComponent<boxPull>().pullSet(false);
            }
        }
        else
        {
            active = true;
            gameObject.transform.position = standard;
        }
    }
    public bool getStatus()
    {
        return active;
    }
}