using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunpowdership : EnemyBase
{
    [Header("Particle System")]
    public ParticleSystem particle;

    private Rigidbody2D rb2d;

    protected override void Awake()
    {
        base.Awake();
        rb2d = GetComponent<Rigidbody2D>();
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
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Tower")) 
            StartCoroutine(Bomb());
    }

    private IEnumerator Bomb()
    {
        if (isMove) yield return null;

        Detected();

        if (detectedTarget != target) target = Managers.Game.target;
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
