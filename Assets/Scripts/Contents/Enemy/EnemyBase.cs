using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int hp;
    public int maxHp;

    public float moveSpeed;
    public Transform target;
    public float cooltime;
    public float distance = 0.5f;

    private bool isAttack;

    [SerializeField] private Vector3 moveVec;

    private float timeRate;
    public bool isMove = true;

    protected PoolManager poolManager;
    protected Poolable poolable;

    protected virtual void Awake()
    {
        Init();

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
        CheckObstacle();
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

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
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

        return moveVec.normalized;
    }

    public float Gaze(Vector3 currentVec, Vector3 targetVec)
    {
        float degree = Mathf.Atan2(targetVec.y - currentVec.y, targetVec.x - currentVec.x);

        return degree * Mathf.Rad2Deg;
    }

    public void CloseDistance(Vector3 currentVec, Vector3 targetVec, float distance)
    {
        if (Vector3.Distance(currentVec, targetVec) <= distance)
        {
            isMove = false;
            isAttack = true;
        }
    }

    public void CheckObstacle()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 2f, Tracing(transform.position, target.position), 1.5f, 6);

        if (hit)
        {
            isMove = false;
            isAttack = true;
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
