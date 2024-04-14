using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Rotate : MonoBehaviour
{
    public float rotationSpeed = 2.0f;

    public Transform target;

    void Update()
    {
        Quaternion targetQuaternion = Quaternion.Euler(0, 0, TraceZ());
        transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, rotationSpeed * Time.deltaTime);
    }

    private float TraceZ()
    {
        return Mathf.Atan2(target.position.y - transform.position.y,
                           target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
    }
}
