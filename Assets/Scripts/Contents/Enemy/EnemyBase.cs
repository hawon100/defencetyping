using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int hp;
    public int maxHp;

    public float moveSpeed;
    public Transform target;
    public float cooltime;
    public float distance = 0.5f;

    private Vector3 moveVec;

    private float timeRate;
    private bool isMove = true;

    protected virtual void Awake()
    {
        Init();
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
        RotateMove();
    }

    protected virtual void Init()
    {
        hp = maxHp;
    }

    public void DirectMove()
    {
        if (!isMove) return;

        moveVec = Tracing(transform.position, target.position).normalized;

        transform.Translate(moveVec * moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(moveVec * moveSpeed);

        CloseDistance(transform.position, target.position, distance);
        //Managers.Data
    }

    public void RotateMove()
    {
        if (!isMove) return;

        moveVec.z = Gaze(transform.position, target.position);

        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        //transform.Rotate()
        transform.rotation = Quaternion.Euler(moveVec * moveSpeed);

        CloseDistance(transform.position, target.position, distance);
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

    public void CloseDistance(Vector3 curVec, Vector3 targetVec, float distance)
    {
        if (Vector3.Distance(curVec, targetVec) <= distance) isMove = false;
    }
}
