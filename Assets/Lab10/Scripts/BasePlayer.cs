using UnityEngine;
using System;

public class BasePlayer : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private int currentLife = 20;


    void Start()
    {

    }
    void Update()
    {
        Movement();
        PlayerRotation();
    }
    public void Movement()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * speed * Time.deltaTime;
        /* if (Input.GetKey(KeyCode.S))
               transform.position += -transform.forward * speed * Time.deltaTime;
           if (Input.GetKey(KeyCode.A))
               transform.position += -transform.right * speed * Time.deltaTime;
           if (Input.GetKey(KeyCode.D))
               transform.position += transform.right * speed * Time.deltaTime;   */
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * dashForce, ForceMode.Impulse);
        }
    }
    public void PlayerRotation()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out RaycastHit hit))
        {
            Vector3 lookPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.root.LookAt(lookPos);
        }
    }
    public void TakeDamage()
    {
        currentLife--;
    }
    public void TakeDamage(int damage)
    {
        currentLife -= damage;
    }

}

