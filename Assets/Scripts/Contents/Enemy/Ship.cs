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

    private Transform savedTarget;

    public bool isDetected = true; //Temp

    protected override void Awake()
    {
        base.Awake();
        RandomInt(); //Temp

        for (int i = 0; i < 5; i++) //Temp
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

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        LookAt();
        Detected();
    }

    protected override void Attack()
    {
        directBullet.target = target;

        GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, transform.parent = null);

        b.transform.parent = null;
        b.transform.position = transform.position;
    }

    private void Detected()
    {
        if (!isDetected) return;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(targetTag))
            {
                savedTarget = target;
                target = collider.transform;
                isDetected = false;
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
        Quaternion targetQuaternion = Quaternion.Euler(0, 0, Gaze(transform.position, gazeTarget));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, rotateSpeed * Time.deltaTime);
    }

    protected override void Death()
    {
        base.Death();
    } 

    private void RandomInt()
    {
        distance = Random.Range(5, 7);
    }
}
