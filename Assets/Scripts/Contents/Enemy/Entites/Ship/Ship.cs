using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : EnemyBase
{
    [Header("Bullet")]
    public DirectBullet directBullet;
    public BezierBullet bezierBullet;
    public ParabolaBullet paraBullet;

    [Header("Particle System")]
    public ParticleSystem particle;

    private Animator anime;
    private readonly int attackAnime = Animator.StringToHash("Attack");
    //readonly : Only for Read

    private Rigidbody2D rb2d;

    protected override void Awake()
    {
        base.Awake();
        rb2d = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    protected override void Start()
    {
        Init();
    }

    protected override void Init()
    {
        particle.Play();
        base.Init();
    }


    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Attack()
    {
        if (isMove) return;

        Detected();

        if (detectedTarget != target) target = Managers.Game.target;

        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        bool isRotate = true;

        while (isRotate)
        {
            Quaternion targetQuaternion = Quaternion.Euler(0, 0, Gaze(transform.position, targetPos) - 90f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, rotSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetQuaternion) <= 0.1f) isRotate = false;

            yield return null;
        }

        anime.SetTrigger(attackAnime);

        //GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, null);
        GameObject b = Managers.Resource.Instantiate(paraBullet.gameObject, null);
        BulletBase s = b.GetComponent<BulletBase>();

        //GameObject b = Managers.Resource.Instantiate(bezierBullet.gameObject, null);
        //BulletBase s = b.GetComponent<BezierBullet>();
        //s.Init();
        Debug.Log(target);
        s.target = target;
        s.triggerTag = targetTag;
        b.transform.position = transform.position;
    }

    protected override void Detected()
    {
        base.Detected();
    }

    protected override void Move()
    {
        if (!isMove)
        {
            rb2d.velocity = Vector2.zero;
            particle.Stop();
            return;
        }

        Detected();

        if (detectedTarget != null) target = detectedTarget;

        LookAt();

        rb2d.velocity = moveSpeed * Trace(transform.position, target.position);

        if (rb2d.velocity.sqrMagnitude <= 0.9f ||
            isDistance(transform.position, target.position, stopDistance))
        {
            rb2d.velocity = Vector2.zero;
            isMove = false;
        }
    }

    protected override void LookAt()
    {
        base.LookAt();
    }
}
