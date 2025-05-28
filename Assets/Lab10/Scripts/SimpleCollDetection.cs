using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleCollDetection : MonoBehaviour
{
    [SerializeField] private bool isOnSafeZone = false;

    [SerializeField] private int playerHeatlh = 0;


    [SerializeField] private float TimeTriggerHealth = 1;
    private float currentTime;



    public List<Transform> waypoints = new List<Transform>();
    void Start()
    {
        Time.timeScale = 1f;



        Destroy(this.gameObject, 5);
        float x = Random.Range(-1000, 1000);

        float y = Random.Range(-1000, 1000);
        gameObject.transform.position = waypoints[0].position;
    }
    void Update()
    {
        if (isOnSafeZone)
        {
            if (currentTime >= TimeTriggerHealth)
            {
                playerHeatlh++;
                currentTime = 0;
            }
            else
            {
                currentTime += Time.deltaTime;
            }
        }
    }
    /*  private void OnTriggerEnter(Collider obj)
      {

          if(obj.gameObject.tag == "Player")
          {
              obj.gameObject.GetComponent<Rigidbody>().AddForce(obj.transform.up *10,ForceMode.Impulse);
          }

      }*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.transform.forward * 10, ForceMode.Impulse);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        /*print("El objeto Salio " + other.name);
        isOnSafeZone = false;*/
    }
    /*private void OnTriggerStay(Collider other)
    {
        print("El objeto se mantiene " + other.name);
    
    }*/
}

