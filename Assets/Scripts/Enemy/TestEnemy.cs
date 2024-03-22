using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : EnemyBase
{
    [SerializeField] private Transform trans; //Temp

    protected override void Awake()
    {
        base.Awake();

    }

    protected override void Update()
    {
        base.Update();
        //trans.rotation = Quaternion.Euler(0, 0, Gaze(transform.position, target.position));
    }

    protected override void Move()
    {
        base.Move();
    }
}
