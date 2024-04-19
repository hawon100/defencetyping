using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int hp;
    public int maxHp;

    public float moveSpeed;
    public Transform target;
    public float cooltime;
    public float distance = 0.5f;

    [SerializeField] private Vector3 moveVec;

    private float timeRate;
    public bool isMove = true;
    public bool isDeath;

    public Vector3 gazeTarget;

    public float rotateSpeed = 2.0f;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRend;

    protected virtual void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }

    protected virtual void FixedUpdate()
    {
        if (isDeath) return;

        if (timeRate > cooltime)
        {
            timeRate -= cooltime;
            Attack();
        }
        else
        {
            timeRate += Time.deltaTime;
        }

        if (!isMove) return;

        Move();
    }

    protected virtual void Attack()
    {

    }

    protected virtual void Move()
    {
        if (!isMove) return;

        rb2d.velocity = Trace(transform.position, target.position) * moveSpeed; //Temp

        if (isDistance(transform.position, target.position, distance))
        {
            isMove = false;
            rb2d.velocity = Vector2.zero;
        }
    }

    protected virtual void LookAt()
    {
        Quaternion targetQuaternion = Quaternion.Euler(0, 0, Gaze(transform.position, target.position) - 90f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, rotateSpeed * Time.deltaTime);
    }

    protected virtual void Init()
    {
        hp = maxHp;
    }

    public Vector3 Trace(Vector3 curVec, Vector3 targetVec)
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

    public void Damage(int value)
    {
        hp -= value;
        hp = Mathf.Clamp(hp, 0, maxHp);

        if (hp <= 0) Death();
    }

    protected virtual void Death()
    {
        Managers.Resource.Destroy(gameObject);
        //Managers.Spawn.curEnemy.Remove(this.gameObject);
    }
}
