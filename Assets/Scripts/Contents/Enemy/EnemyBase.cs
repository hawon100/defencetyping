using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed = 1f;
    public float rotSpeed = 2f;
    public float stopDistance = 5f;
    public bool isMove = true;
    protected Vector3 moveVec;

    [Header("Attack")]
    public Transform target;
    public Vector2 targetPos;
    public float cooltime;
    protected float timeRate;

    [Header("Detect")]
    [SerializeField] protected string targetTag;
    [SerializeField] [Range(0.0f, 10.0f)] protected float range;

    private EnemyStatBase enemyStat;

    protected virtual void Awake()
    {
        enemyStat = GetComponent<EnemyStatBase>();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void OnEnable()
    {
        Init();
    }

    protected virtual void FixedUpdate()
    {
        if (!Managers.Wave.isWave)
        {
            enemyStat.Damage(enemyStat.maxHp);
            return; //KILL SWITCH!
        }

        if (timeRate > cooltime)
        {
            timeRate -= cooltime;
            Attack();
        }
        else
        {
            timeRate += Time.deltaTime;
        }
        Move();
    }

    protected virtual void Attack()
    {

    }

    protected virtual void Move()
    {

    }

    protected virtual void Detected()
    {
        //수정 사항!!
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(targetTag))
            {
                target = collider.transform;
                //targetPos = target.position;
                isMove = false;
                return;
            }
        }
    }


    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(transform.position, range);
    //}

    protected virtual void LookAt()
    {
        Quaternion targetQuaternion = Quaternion.Euler(0, 0, Gaze(transform.position, target.position) - 90f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, rotSpeed * Time.deltaTime);
    }

    protected virtual void Init()
    {
        target = Managers.Game.target;
        //targetPos = target.position;

        isMove = true;

        enemyStat.Init();
    }

    protected Vector3 Trace(Vector3 curVec, Vector3 targetVec)
    {
        moveVec.x = targetVec.x - curVec.x;
        moveVec.y = targetVec.y - curVec.y;

        return moveVec.normalized;
    }

    protected float Gaze(Vector3 currentVec, Vector3 targetVec)
    {
        float degree = Mathf.Atan2(targetVec.y - currentVec.y, targetVec.x - currentVec.x);

        return degree * Mathf.Rad2Deg;
    }

    protected bool isDistance(Vector3 currentVec, Vector3 targetVec, float distance)
    {
        return (targetVec - currentVec).sqrMagnitude <= distance * distance;
    }
}
