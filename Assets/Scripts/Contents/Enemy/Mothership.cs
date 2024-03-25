using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : EnemyBase
{
    [SerializeField] private Transform trans; //Temp
    public GameObject smallship; //private Temp
    [SerializeField] private int spawnCount; //Temp

    private Vector3 spriteRotation;

    private bool isSpawn;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void Update()
    {
        if (isSpawn) Attack();
        RotateObject();
        DirectMove();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        SeekerBlah();
    }

    protected override void Attack()
    {
        for (int i = 0; i < 360; i += 360 / spawnCount)
        {
            Poolable ship = poolManager.Pop(smallship, transform);

            ship.transform.parent = null;
            ship.transform.position = transform.position + Vector3.right * Mathf.Cos(i * Mathf.Deg2Rad)
                                                         + Vector3.up * Mathf.Sin(i * Mathf.Deg2Rad);
            ship.gameObject.GetComponent<EnemyBase>().target = target;
        }

        isSpawn = false;
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

    private void SeekerBlah()
    {
        //CloseDistance(transform.position, )
    }
}
