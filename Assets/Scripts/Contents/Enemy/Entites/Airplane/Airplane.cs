using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : EnemyBase
{
    [Header("Bomb")]
    public Bomb bomb;

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
        base.Start();
        Init();
    }

    protected override void Init()
    {
        base.Init();
        movingTo.x = Trace(transform.position, targetPos).x;
        movingTo.y = Trace(transform.position, targetPos).y;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Attack() //First : Detected(), if no target : target set to centraltower
    {
        if (target != null)
            target = Managers.Game.target;

        //GameObject b = Managers.Resource.Instantiate(bomb.gameObject, null);
        //b.transform.position = transform.position;
    }

    protected override void Detected()
    {
        base.Detected();
    }

    protected override void Move()
    {
        if (!isMove) return;

        transform.Translate(movingTo * moveSpeed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    
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

    private bool OutOfScreen()
    {
        return transform.position.x < -Managers.Game.absScreenX ||
               transform.position.x > Managers.Game.absScreenX ||
               transform.position.y < -Managers.Game.absScreenY ||
               transform.position.y > Managers.Game.absScreenY;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Background"))
        {
            isMove = false;
            Managers.Wave.WaveUpdate();
            Managers.Resource.Destroy(gameObject);
        }
    }
}
