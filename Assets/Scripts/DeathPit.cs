using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeathPit : MonoBehaviour
{
    public Text _killed;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            print("collision");
            _killed.GetComponent<Text>().text = "Die";
        }
    }
}
