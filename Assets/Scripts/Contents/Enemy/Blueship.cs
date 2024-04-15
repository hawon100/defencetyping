using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueship : EnemyBase
{
    [SerializeField] private Transform trans; //Temp (Name!)
    public GameObject bullet; //private Temp

    private Vector3 spriteRotation;

    protected override void Awake()
    {
        base.Awake();
        RandomInt();
    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void Update()
    {
        Move();
        RotateObject();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Attack()
    {
        
    }

    protected override void Move()
    {
        if (!isMove)
        {

        }

        base.Move();
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

    private void RandomInt()
    {
        distance = Random.Range(5f, 8f);
    }
}
