using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : EnemyBase
{
    [SerializeField] private Transform trans; //Temp
    [SerializeField] private int spawnCount; //Temp
    [SerializeField] private float radius;

    [Header("Ships")]
    public EnemyBase ship; //private Temp
    public DirectBullet directBullet; //private Temp

    private Vector3 spriteRotation;

    private bool isSpawn = true;

    private WaitForSeconds gazeOnTime = new WaitForSeconds(1f);
    private List<EnemyBase> curShips = new List<EnemyBase>();

    private Vector2 gazePoint;

    protected override void Awake()
    {
        base.Awake();

        for (int i = 0; i < 5; i++) //Temp
        {
            //GameObject s = Managers.Resource.Instantiate(ship.gameObject, transform.parent = null);
            //Managers.Resource.Destroy(s);
            //GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, transform.parent = null);
            //Managers.Resource.Destroy(b);
        }
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        LookAt();
        Move();

        if (!isMove) Attack();

        if (curShips.Count == 0 && !isSpawn) isSpawn = true;
       
        if (isSpawn)
        {
            StartCoroutine(Spawn());
            isSpawn = false;
        
        }
    }

    protected override void Attack()
    {
        //GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, null);

        //b.transform.position = transform.position;
    }

    private IEnumerator Spawn()
    {
        Debug.Log(curShips.Count);
        for (int i = 0; i < 360; i += 360 / spawnCount)
        { 
            targetPos.x = Mathf.Cos(i * Mathf.Deg2Rad) * 5f;
            targetPos.y = Mathf.Sin(i * Mathf.Deg2Rad) * 5f;

            GameObject s = Managers.Resource.Instantiate(ship.gameObject, transform.parent = null);
          
            s.transform.position = transform.position;

            curShips.Add(s.GetComponent<EnemyBase>());
        }

        isSpawn = false;

        yield return gazeOnTime;

        for (int i = 0; i < curShips.Count; i++)
        {
            curShips[i].targetPos = target.position;
        }
    }

    protected override void Move()
    {
        base.Move();
    }

    protected override void LookAt()
    {
        base.LookAt();
    }

    protected override void Death()
    {
        base.Death();
    }
}
