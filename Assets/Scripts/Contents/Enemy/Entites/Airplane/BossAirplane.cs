using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAirplane : EnemyBase
{
    [Header("Sprite")]
    [SerializeField] private Transform triSprite;

    [Header("Bomb")]
    public AtomicBomb bomb;
    private float timer;

    //웨이브 발산

    private Vector2 movingTo;


    protected override void Awake()
    {
        base.Awake();

        for (int i = 0; i < 3; i++)
        {
            //GameObject b = Managers.Resource.Instantiate(bomb.gameObject, null);
            //Managers.Resource.Destroy(b);
        }
    }

    protected override void Start()
    {
        triSprite.rotation = Quaternion.Euler(0, 0, Gaze(transform.position, targetPos) - 90f);
        base.Start();
    }

    protected override void Init()
    {
        base.Init();
        //movingTo.x = Trace(transform.position, targetPos).x;
        //movingTo.y = Trace(transform.position, targetPos).y;
        //triSprite.rotation = Quaternion.Euler(0, 0, Gaze(transform.position, targetPos) - 90f);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Attack() //First : Detected(), if no target : target set to centraltower
    {
        target = Managers.Game.target;

        GameObject w = Managers.Resource.Instantiate("Skills/AtomicWave");
        w.transform.position = transform.position;
        ZenWave z = w.GetComponentInChildren<ZenWave>();
        z.damage = 3;
        if (isDistance(transform.position, target.position, 5f)) z.damage = 100;
        z.StableStart();

        return;

        //GameObject b = Managers.Resource.Instantiate(bomb.gameObject, null);
        //b.transform.position = transform.position;

        //AtomicBomb a = b.GetComponent<AtomicBomb>();
        //a.onBomb -= DamagedByBomb;
        //a.onBomb += DamagedByBomb;
        //a.SetTimer(timer);
    }

    protected override void Detected()
    {
        base.Detected();
    }

    protected override void Move()
    {
        if (!isMove) return;

        //transform.Translate(movingTo * moveSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        //if (OutOfScreen())
        //{
        //    isMove = false;
        //    Managers.Wave.WaveUpdate();
        //    Managers.Resource.Destroy(gameObject);
        //}
    }

    protected override void LookAt()
    {
        base.LookAt();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Background"))
        {
            isMove = false;
            //Managers.Wave.WaveUpdate();
            Managers.Resource.Destroy(gameObject);
        }
    }
}
