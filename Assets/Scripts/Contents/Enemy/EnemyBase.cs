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

    private Rigidbody2D rb2d; //Temp

    protected virtual void Awake()
    {
        Init();

        rb2d = GetComponent<Rigidbody2D>(); //Temp
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        if (timeRate > cooltime)
        {
            timeRate -= cooltime;

            Debug.Log("Attack!");
            Attack();
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
        if (isDistance(transform.position, target.position, distance))
        {
            isMove = false;
        }
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
        if (!isMove)
        {
            rb2d.velocity = Vector3.zero;
            return;
        }

        rb2d.velocity = Tracing(transform.position, target.position) * moveSpeed; //Temp
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

    public bool isDistance(Vector3 currentVec, Vector3 targetVec, float distance)
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

    private void AllMight()
    {
        transform.LookAt(target);
    }
}
