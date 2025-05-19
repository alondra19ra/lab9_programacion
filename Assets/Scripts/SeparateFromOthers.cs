using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparateFromOthers : MonoBehaviour
{
    public float speed = 2f;
    public float separationDistance = 3f;

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 moveDir = Vector3.zero;
        foreach (GameObject enemy in enemies)
        {
            if (enemy != this.gameObject)
            {
                float dist = Vector3.Distance(transform.position, enemy.transform.position);
                if (dist < separationDistance)
                {
                    moveDir += (transform.position - enemy.transform.position).normalized / dist;
                }
            }
        }
        transform.Translate(moveDir * speed * Time.deltaTime, Space.World);
    }
}

