using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float moveSpeed;
    public Transform target;
    public float cooltime;

    private Vector2 moveVec;

    private float timeRate;

    protected virtual void Update()
    {
        if (timeRate > cooltime)
        {
            timeRate -= cooltime;
            //Attack or Something else.
        }
        else
        {
            timeRate += Time.deltaTime;
        }
        Move();
    }

    protected virtual void Move()
    {
        transform.Translate(moveVec * moveSpeed * Time.deltaTime);
    }
}
