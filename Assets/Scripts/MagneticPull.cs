using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticPull : MonoBehaviour
{
    public GameObject player;

    public bool active = false;

    public Vector2 standard;

    public void Start()
    {
        standard = gameObject.transform.position;
        gameObject.transform.position = Vector2.up * 1000;
    }

    public void toggle()
    {
        print("Q");
        if (active)
        {
            active = false;
            gameObject.transform.position = Vector2.up * 1000;
            player.GetComponent<PlayerMvt>().pullSet(false);
        }
        else
        {
            active = true;
            gameObject.transform.position = standard;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && active)
        {
            player.GetComponent<PlayerMvt>().pullSet(true);
            print("collision");
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && active)
        {
            player.GetComponent<PlayerMvt>().pullSet(false);
            print("exit");
        }
    }
}