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

    public bool isDetected = true; //Temp

    protected override void Awake()
    {
        base.Awake();

        for (int i = 0; i < 3; i++) //Temp
        {
            GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, null);
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
            Detected();
        }
    }

    private void Detected()
    {
        Debug.Log("Detected from Ship!");

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

        //if (target == null)
        //{
        //    target = Managers.Game.target;
        //}
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

    //public override void Damage(int value)
    //{
    //    StartCoroutine(DamageMotion());
    //    base.Damage(value);
    //}

    //protected override void Death()
    //{
    //    base.Death();
    //} 

    //private IEnumerator DamageMotion()
    //{
    //    gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
    //    yield return new WaitForSeconds(0.4f);
    //    gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    //    yield return new WaitForSeconds(0.4f);
    //}
}
