using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleePlayer : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;

    void Update()
    {
        if (player != null)
        {
            Vector3 dir = (transform.position - player.position).normalized;
            transform.Translate(dir * speed * Time.deltaTime, Space.World);
        }
    }
}

