using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombship : EnemyBase
{
    [SerializeField] private Transform trans; //Temp (Name!)
    [SerializeField] private SpriteRenderer spriteRend;

    private Vector3 spriteRotation;

    private bool isAttack;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void Update()
    {
        base.Update();
        RotateObject();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (isDistance(transform.position, target.position, 5f)) isAttack = true;
    }

    protected override void Attack()
    {
        if (isAttack) StartCoroutine(SuicideBomb());
    }

    private IEnumerator SuicideBomb()
    {
        isAttack = false;
        WaitForSeconds time = new WaitForSeconds(0.07f);

        for (int i = 0; i < 3; i++)
        {
            spriteRend.color = Color.red;
            yield return time;
            spriteRend.color = Color.white;
            yield return time;
        }

        Death();
    }

    protected override void DirectMove()
    {
        base.DirectMove();
    }

    private void RotateObject()
    {
        spriteRotation.z = Gaze(transform.position, target.position) - 90f;

        transform.rotation = Quaternion.Euler(spriteRotation);
    }

    protected override void Death()
    {
        base.Death();
    }
}
