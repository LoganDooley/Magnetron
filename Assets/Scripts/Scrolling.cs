using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public GameObject player;
    private float _min = -3f;
    private float _max = 3f;
    private float _cameraVel = 0.1f;

    void FixedUpdate()
    {
        if(player.transform.position.x-gameObject.transform.position.x < _min)
        {
            gameObject.transform.Translate(Vector3.left * _cameraVel);
        }
        if(player.transform.position.x - gameObject.transform.position.x > _max)
        {
            gameObject.transform.Translate(Vector3.right * _cameraVel);
        }
    }
}
