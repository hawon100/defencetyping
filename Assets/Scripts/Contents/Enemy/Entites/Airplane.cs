using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : EnemyBase
{
    [SerializeField] private string targetTag;
    [SerializeField] [Range(0.0f, 10.0f)] private float range;
    [Header("Bullets")]
    public DirectBullet directBullet; //private Temp

    public bool isDetected = true; //Temp

    private Vector3 moveVector;

    protected override void Awake()
    {
        base.Awake();

        for (int i = 0; i < 3; i++) //Temp
        {
            //GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, null);
            //Managers.Resource.Destroy(b);
        }
    }

    protected override void Start()
    {
        base.Start();
        Init();
    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Attack() //First : Detected(), if no target : target set to centraltower
    {
        Detected();

        if (target != null)
        {
            //change target to isDetected, then if detected shoot the tower!
            GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, null);
            BulletBase s = b.GetComponent<BulletBase>();
            s.target = target;
            s.Init();
            b.transform.position = transform.position;
        }
        else
        {
            target = Managers.Game.target;
        }
    }

    private void Detected()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(targetTag))
            {
                //savedTarget = target;
                target = collider.transform;
                targetPos = target.position;
                isMove = false;
                return;
            }
        }
    }

    protected override void Move()
    {
        LookAt();
        //moveVec.x = targetPos.x - transform.position.x;
        //moveVec.y = targetPos.y - transform.position.y;
        //moveVec = moveVec.normalized;
        //transform.Translate(moveVec * moveSpeed * Time.deltaTime);
        if (!isMove) return;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    protected override void LookAt()
    {
        if (target != null)
        {
            base.LookAt();
        }
    }
}
