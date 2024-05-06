using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed;
    public float rotateSpeed = 2.0f;
    public Transform target;
    public Vector2 targetPos;
    public float distance = 0.5f;
    public bool isMove = true;

    [SerializeField] private Vector3 moveVec;
    public float cooltime;

    private float timeRate;



    private Rigidbody2D rb2d;

    private EnemyStatBase enemyStat;

    protected virtual void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemyStat = GetComponent<EnemyStatBase>();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void OnEnable()
    {
        Init();
    }

    //protected virtual void Update()
    //{
        
    //}

    protected virtual void FixedUpdate()
    {
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
        if (!isMove) return;

        rb2d.velocity = moveSpeed * Trace(transform.position, target.position).normalized; //Temp

        if (rb2d.velocity.sqrMagnitude <= 0.1f || 
            isDistance(transform.position, target.position, distance))
        {
            rb2d.velocity = Vector2.zero;
            isMove = false;
        }
    }

    protected virtual void LookAt()
    {
        Quaternion targetQuaternion = Quaternion.Euler(0, 0, Gaze(transform.position, targetPos) - 90f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, rotateSpeed * Time.deltaTime);
    }

    protected virtual void Init()
    {
        target = Managers.Game.target;
        targetPos = target.position;

        isMove = true;

        enemyStat.Init();
    }

    public Vector3 Trace(Vector3 curVec, Vector3 targetVec)
    {
        moveVec.x = targetVec.x - curVec.x;
        moveVec.y = targetVec.y - curVec.y;

        return moveVec;
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
