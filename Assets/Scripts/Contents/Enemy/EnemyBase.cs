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

    private bool isAttack = true;

    [SerializeField] private Vector3 moveVec;
    [SerializeField] private Vector3 movePos;

    private float timeRate;
    private bool isMove = true;

    protected PoolManager poolManager;
    protected Poolable poolable;

    protected virtual void Awake()
    {
        Init();
        //Temp
        movePos = target.position;

        poolManager = Managers.Pool;
        poolable = GetComponent<Poolable>();
    }

    protected virtual void Update()
    {
        if (timeRate > cooltime)
        {
            timeRate -= cooltime;

            if (isAttack) Attack();
            //Attack or Something else.
        }
        else
        {
            timeRate += Time.deltaTime;
        }
        DirectMove();
    }

    protected virtual void FixedUpdate()
    {
        CloseDistance(transform.position, target.position, distance);
    }

    protected virtual void Init()
    {
        hp = maxHp;
    }

    protected virtual void Attack()
    {

    }

    protected virtual void DirectMove()
    {
        if (!isMove) return;

        //moveVec = Tracing(transform.position, target.position).normalized;

        //transform.Translate(moveVec * moveSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(moveVec * moveSpeed);
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
        if (Vector3.Distance(curVec, targetVec) <= distance)
        {
            isMove = false;
        }
    }

    public void Damage(int value)
    {
        hp -= value;
        hp = Mathf.Clamp(hp, 0, maxHp);

        if (hp <= 0) Death();
    }

    protected virtual void Death()
    {
        poolManager.Push(poolable);
    }
}
