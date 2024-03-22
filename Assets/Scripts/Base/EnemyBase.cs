using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float moveSpeed;
    public Transform target;
    public float cooltime;

    private Vector3 moveVec;

    private float timeRate;
    private bool isMove = true;

    protected virtual void Awake()
    {

    }

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
        if (!isMove) return;

        moveVec = Tracing(transform.position, target.position).normalized;

        transform.Translate(moveVec * moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f) isMove = false;
        //Managers.Data
    }

    public Vector3 Tracing(Vector3 curVec, Vector3 targetVec)
    {
        moveVec.x = targetVec.x - curVec.x;
        moveVec.y = targetVec.y - curVec.y;

        return moveVec;
    }

    public float Gaze(Vector3 curVec, Vector3 targetVec)
    {
        float degree = Mathf.Atan2(targetVec.y - curVec.y, targetVec.x - curVec.x);

        return degree * Mathf.Rad2Deg;
    }
}
