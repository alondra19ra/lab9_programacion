using UnityEngine;

public class SeekPlayer : MonoBehaviour
{
    public Transform target;

    void FixedUpdate()
    {
        if (target == null) return;

        Vector3 dir = target.position - transform.position;
        dir.y = 0; 
        GetComponent<SteeringAgent>().ApplySteering(dir.normalized);
    }
}
