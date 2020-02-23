using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticPull : MonoBehaviour
{
    public GameObject player;

    private bool pull = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            player.GetComponent<playermovement>().pullSet(true);
            print("collision");
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            player.GetComponent<playermovement>().pullSet(false);
            pull = false;
            print("exit");
        }
    }
}
