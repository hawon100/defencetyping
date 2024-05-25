using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : EnemyBase
{
    [Header("Bullet")]
    public DirectBullet directBullet;

    [Header("Particle System")]
    public ParticleSystem particle;

    private Animator anime;
    private int attackAnime = Animator.StringToHash("Attack");
    
    private Rigidbody2D rb2d;

    protected override void Awake()
    {
        base.Awake();
        rb2d = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();

        for (int i = 0; i < 3; i++)
        {
            GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, null);
            Managers.Resource.Destroy(b);
        }
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

        //Quaternion initialRotation = transform.rotation;
        //float progress = 0f;

        //while (progress < 1f)
        //{
        //    LookAt();
        //    progress += Time.deltaTime * rotSpeed;

        //    // 목표 각도에 거의 도달했는지 확인
        //    if (Quaternion.Angle(transform.rotation, targetQuaternion) < 0.1f)
        //    {
        //        transform.rotation = targetQuaternion;
        //        break;
        //    }

        //    yield return null; // 다음 프레임까지 대기
        //}

        bool isRotate = true;

        while (isRotate)
        {
            Quaternion targetQuaternion = Quaternion.Euler(0, 0, Gaze(transform.position, targetPos) - 90f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, rotSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetQuaternion) <= 0.1f) isRotate = false;

            yield return null;
        }

        anime.SetTrigger(attackAnime);

        GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, null);
        BulletBase s = b.GetComponent<DirectBullet>();
        s.Init();
        s.target = target;
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

        if (rb2d.velocity.sqrMagnitude <= 0.1f ||
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
