using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : EnemyBase
{
    [SerializeField] private string targetTag;
    [SerializeField] [Range(0.0f, 10.0f)] private float range;
    [Header("Bullets")]
    public BezierBullet bezierBullet; //private Temp
    public DirectBullet directBullet; //private Temp

    [SerializeField] private bool isAttacked; //Temp

    //private Transform savedTarget;

    public bool isDetected = true; //Temp

    protected override void Awake()
    {
        base.Awake();
        //RandomInt(); //Temp

        for (int i = 0; i < 3; i++) //Temp
        {
            GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, transform.parent = null);
            Managers.Resource.Destroy(b);
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

    //protected override void Update()
    //{
    //    base.Update();
    //}

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Attack()
    {
        Detected();

        Debug.Log("Ship Attack!");
        //if (target == null) return;

        //directBullet.target = target;

        GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, null);
        b.GetComponent<BulletBase>().target = target;
        b.transform.position = transform.position;
    }

    private void Detected()
    {
        //if (!isDetected) return;

        Debug.Log("Ship Detected!");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(targetTag))
            {
                //savedTarget = target;
                target = collider.transform;
                targetPos = target.position;
                return;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    protected override void Move()
    {
        LookAt();
        base.Move();
    }

    protected override void LookAt()
    {
        if (target != null)
        {
            base.LookAt();
        }
    }

    private void LookAtGaze()
    {
        //Quaternion targetQuaternion = Quaternion.Euler(0, 0, Gaze(transform.position, gazeTarget));
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, rotateSpeed * Time.deltaTime);
    }

    protected override void Death()
    {
        base.Death();
    } 
}
