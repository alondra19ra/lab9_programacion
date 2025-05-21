using UnityEngine;

public class SteeringAgent : MonoBehaviour
{
    public float speed = 3f;

    private Rigidbody rb;
    private Vector3 steeringForce;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void ApplySteering(Vector3 force)
    {
        steeringForce += force;
    }

    void FixedUpdate()
    {
        Vector3 direction = steeringForce;
        direction.y = 0;

        if (direction.sqrMagnitude > 0.01f)
        {
            rb.linearVelocity = direction.normalized * speed;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }

        steeringForce = Vector3.zero;
    }
}




